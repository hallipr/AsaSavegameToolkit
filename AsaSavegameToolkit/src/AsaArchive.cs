using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

using AsaSavegameToolkit.Analysis;
using AsaSavegameToolkit.Types;

namespace AsaSavegameToolkit
{

    public class AsaArchive : IDisposable
    {
        private readonly Stream _stream;
        private readonly string? _debugOutputPath;
        private readonly string _fileName;
        private readonly BinaryReader _reader;

        /// <summary>
        /// List of all sections read from the file
        /// </summary>
        public List<ReadSection> SectionsRead { get; } = [];
        public List<SkippedSection> SectionsSkipped { get; } = [];

        public Dictionary<int, string> ConstantNameTable { get; set; } = [];
        public Dictionary<int, string> NameTable { get; set; } = [];
        public bool HasNameTable => (NameTable?.Count > 0) || (ConstantNameTable?.Count > 0);
        public bool HasInstanceInNameTable { get; set; }

        public long Position
        {
            get => _stream.Position;
            set => _stream.Position = value;
        }

        public long Limit => _stream.Length;
        public short SaveVersion { get; internal set; }

        public AsaArchive(Stream stream, string? debugOutputPath, string fileName)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            _debugOutputPath = debugOutputPath;
            _fileName = fileName;
            _reader = new BinaryReader(_stream);
        }

        /// <summary>
        /// Records a section that was read from the file
        /// </summary>
        public void RecordRead(long offset, long length, string type, bool complete = true)
        {
            SectionsRead.Add(new ReadSection(offset, length, type, complete));
        }

        public void RecordSkipped(long offset, long length, string reason)
        {
            SectionsSkipped.Add(new SkippedSection(offset, length, reason));
        }

        #region Read Operations

        private ReadTracker Track(string type)
        {
            return new ReadTracker(this, type, complete: true);
        }

        private T Track<T>(string type, Func<T> action)
        {
            using var tracker = Track(type);
            return action();
        }

        public void SkipBytes(int count, string reason = "skipped")
        {
            var offset = _stream.Position;
            RecordSkipped(offset, count, reason);            
            _stream.Seek(count, SeekOrigin.Current);
        }

        public bool TryReadString([NotNullWhen(true)] out string? value)
        {
            using var tracker = Track("String");

            int size = ReadInt32("size");
            if(size == 0)
            {
                value = null;
                return false;
            }

            bool multibyte = size < 0;
            int byteSize = multibyte ? 2 : 1;
            int readSize = Math.Abs(size) * byteSize;

            if (readSize + _stream.Position > _stream.Length)
            {
                //logger.LogWarning("String size exceeds stream length.");
                value = null;
                return false;
            }

            try
            {
                byte[] buffer = ReadBytes(readSize - byteSize, "string bytes");
                value = (multibyte ? Encoding.Unicode : Encoding.ASCII).GetString(buffer);
                ReadBytes(byteSize, "null term");
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        public bool TryReadName([NotNullWhen(true)] out AsaName? name)
        {
            if (!HasNameTable)
            {
                if (TryReadString(out var str))
                {
                    name = AsaName.From(str);
                    return true;
                }
                name = null;
                return false;
            }

            return TryReadNameFromTable(out name);
        }

        private bool TryReadNameFromTable([NotNullWhen(true)] out AsaName? name)
        {
            using var tracker = Track("Name");
            try
            {
                int id = _reader.ReadInt32();
                
                if (!NameTable.TryGetValue(id, out var nameString))
                {
                    if (!ConstantNameTable.TryGetValue(id, out nameString))
                    {
                        nameString = $"Unknown_{id}";
                    }
                }

                if (HasInstanceInNameTable)
                {
                    name = AsaName.From(nameString);
                    return true;
                }

                int instance = _reader.ReadInt32();
                name = AsaName.From(nameString, instance);
                return true;
            }
            catch
            {
                name = null;
                return false;
            }
        }

        public int ReadInt32(string name = "int32") => Track(name, _reader.ReadInt32);
        public uint ReadUInt32(string name = "uint32") => Track(name, _reader.ReadUInt32);
        public short ReadInt16(string name = "int16") => Track(name, _reader.ReadInt16);
        public long ReadInt64(string name = "int64") => Track(name, _reader.ReadInt64);
        public float ReadSingle(string name = "float") => Track(name, _reader.ReadSingle);
        public double ReadDouble(string name = "double") => Track(name, _reader.ReadDouble);
        public byte ReadByte(string name = "byte") => Track(name, _reader.ReadByte);
        public byte[] ReadBytes(int length, string name = "bytes") => Track(name, () => _reader.ReadBytes(length));
        public bool ReadBool(string name = "bool") => Track(name, () => _reader.ReadInt32() != 0);

        public bool TryReadStringStored([NotNullWhen(true)] out string? value)
        {
            try
            {
                int length = ReadByte();
                SkipBytes(1);
                value = Encoding.UTF8.GetString(ReadBytes(length - 1));
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        #endregion

        /// <summary>
        /// Gets a coverage analyzer for this archive
        /// </summary>
        public Analysis.FileCoverageAnalyzer GetCoverageAnalyzer()
        {
            return new Analysis.FileCoverageAnalyzer(SectionsRead, Limit);
        }

        public void Dispose()
        {
            if(!string.IsNullOrEmpty(_debugOutputPath))
            {
                var fileName = Path.ChangeExtension(_fileName, ".bin");
                var filePath = Path.Join(_debugOutputPath, "source", fileName);
                WriteFileStream(filePath);

                var outFile = Path.Join(_debugOutputPath, "source", Path.ChangeExtension(fileName, ".html"));
                var analyzer = new FileCoverageAnalyzer(SectionsRead, _stream.Length);
                File.WriteAllText(outFile, analyzer.GenerateHtmlVisualization());
            }
            _stream?.Dispose();
            _reader?.Dispose();
            GC.SuppressFinalize(this);
        }

        private void WriteFileStream(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath) ?? throw new Exception("Invalid file path");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using var fileStream = File.OpenWrite(filePath);
            _stream.Position = 0;
            _stream.CopyTo(fileStream);
        }

        private class ReadTracker : IDisposable
        {
            private readonly AsaArchive _archive;
            private readonly long _startPosition;
            private readonly string _type;
            private readonly bool _complete;

            public ReadTracker(AsaArchive archive, string type, bool complete = true)
            {
                _archive = archive;
                _startPosition = archive.Position;
                _type = type;
                _complete = complete;
            }

            public void Dispose()
            {
                long length = _archive.Position - _startPosition;
                if (length > 0)
                {
                    _archive.RecordRead(_startPosition, length, _type, _complete);
                }
            }
        }
    }
}
