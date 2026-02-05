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
        private readonly BinaryReader _reader;

        /// <summary>
        /// List of all sections read from the file
        /// </summary>
        public List<ReadSection> SectionsRead { get; } = [];
        public List<SkippedSection> SectionsSkipped { get; } = [];

        public string FileName { get; }
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
            FileName = fileName;
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

        public IDisposable Track(string type)
        {
            return new ReadTracker(this, type, complete: true);
        }

        public T Track<T>(string type, Func<T> action)
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

        public bool TryReadString(string description, [NotNullWhen(true)] out string? value)
        {
            using var tracker = Track(description);

            int size = ReadInt32("string size");
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
                ReadBytes(byteSize, "null terminator");
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        public bool TryReadName(string description, [NotNullWhen(true)] out AsaName? name)
        {
            if (!HasNameTable)
            {
                if (TryReadString(description, out var str))
                {
                    name = AsaName.From(str);
                    return true;
                }
                name = null;
                return false;
            }

            return TryReadNameFromTable(description, out name);
        }

        private bool TryReadNameFromTable(string description, [NotNullWhen(true)] out AsaName? name)
        {
            using var tracker = Track(description);
            try
            {
                int id = ReadInt32("name id");
                
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

                int instance = ReadInt32("name instance");
                name = AsaName.From(nameString, instance);
                return true;
            }
            catch
            {
                name = null;
                return false;
            }
        }

        public int ReadInt32(string description) => Track(description, _reader.ReadInt32);
        public uint ReadUInt32(string description) => Track(description, _reader.ReadUInt32);
        public short ReadInt16(string description) => Track(description, _reader.ReadInt16);
        public long ReadInt64(string description) => Track(description, _reader.ReadInt64);
        public float ReadSingle(string description) => Track(description, _reader.ReadSingle);
        public double ReadDouble(string description) => Track(description, _reader.ReadDouble);
        public byte ReadByte(string description) => Track(description, _reader.ReadByte);
        public byte[] ReadBytes(int length, string description) => Track(description, () => _reader.ReadBytes(length));
        
        public bool ReadBool(int length, string description)
        {
            return length == 1 ? ReadByte(description) != 0
                : length == 4 ? ReadInt32(description) != 0
                : ReadBytes(length, description).Any(x => x != 0);
        }
        
        public bool TryReadStringStored(string description, [NotNullWhen(true)] out string? value)
        {
            try
            {
                using var tracker = Track(description);
                int length = ReadByte("string length");
                SkipBytes(1);
                value = Encoding.UTF8.GetString(ReadBytes(length - 1, "string bytes"));
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
                var fileName = Path.ChangeExtension(FileName, ".bin");
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
