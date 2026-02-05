using System.Diagnostics.CodeAnalysis;
using System.Text;

using AsaSavegameToolkit.Types;

namespace AsaSavegameToolkit
{

    public class AsaArchive : IDisposable
    {
        private readonly Stream _stream;
        private readonly DebugSettings _debugSettings;
        private readonly BinaryReader _reader;

        public AsaArchive(Stream stream, string fileName) : this(stream, fileName, DebugSettings.None)
        {
        }

        public AsaArchive(Stream stream, string fileName, DebugSettings debugSettings)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            FileName = fileName;
            _debugSettings = debugSettings;
            _reader = new BinaryReader(_stream);
        }

        /// <summary>
        /// List of all sections read from the file
        /// </summary>
        public List<ParsedSection> SectionsRead { get; } = [];
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

        /// <summary>
        /// Records a section that was read from the file and its purpose is known
        /// </summary>
        public void MarkParsed(long offset, long length, string type)
        {
            if (_debugSettings.TrackCoverage)
            {
                SectionsRead.Add(new ParsedSection(offset, length, type));
            }
        }

        /// <summary>
        /// Records that a section of the data was skipped or its purpose is unknown
        /// </summary>
        /// <remarks>
        /// If sections overlap, the narrowest/smallest section takes precedence. This implies that the whole file is
        /// initially considered "skipped" until marked otherwise and explicitly marking a section as skipped is only
        /// necessary if it overlaps a larger section that was marked as parsed.
        /// </remarks>
        public void MarkSkipped(long offset, long length, string reason)
        {
            if (_debugSettings.TrackCoverage)
            {
                SectionsSkipped.Add(new SkippedSection(offset, length, reason));
            }
        }

        #region Read Operations

        public IDisposable Track(string type)
        {
            return _debugSettings.TrackCoverage ? new CoverageTracker(this, type) : NullTracker.Shared;
        }

        public T Track<T>(string type, Func<T> action)
        {
            if (!_debugSettings.TrackCoverage)
            {
                return action();
            }

            using var tracker = Track(type);
            return action();
        }

        public void SkipBytes(int count, string reason = "skipped")
        {
            var offset = _stream.Position;
            MarkSkipped(offset, count, reason);
            _stream.Seek(count, SeekOrigin.Current);
        }

        public bool TryReadString(string description, [NotNullWhen(true)] out string? value)
        {
            using var tracker = Track(description);

            int size = ReadInt32("string size");
            if (size == 0)
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
        /// Generates an annotated hex dump markdown file
        /// </summary>
        public string GenerageCoverageReport()
        {
            var sb = new StringBuilder();

            // Sort sections by offset
            var sortedSections = SectionsRead.OrderBy(s => s.Offset).ToList();
            var sortedSkipped = SectionsSkipped.OrderBy(s => s.Offset).ToList();

            // Build a merged list of all sections for sequential processing
            var allSections = new List<(long offset, long length, string description, bool isSkipped)>();
            foreach (var section in sortedSections)
            {
                allSections.Add((section.Offset, section.Length, section.Description, false));
            }
            foreach (var section in sortedSkipped)
            {
                allSections.Add((section.Offset, section.Length, section.Reason, true));
            }
            allSections = allSections.OrderBy(s => s.offset).ThenByDescending(x => x.length).ToList();

            // Add title and file info
            sb.AppendLine($"# {Path.GetFileName(FileName)}");
            sb.AppendLine();
            sb.AppendLine($"File Size: {_stream.Length:N0} bytes (0x{_stream.Length:X})");
            sb.AppendLine($"Sections Read: {sortedSections.Count}");
            sb.AppendLine($"Sections Skipped: {sortedSkipped.Count}");
            sb.AppendLine();

            // Generate hex dump with annotations
            long currentOffset = 0;

            foreach (var (offset, length, description, isSkipped) in allSections)
            {
                // Add gap if there is one
                if (currentOffset < offset)
                {
                    AddUnknownSection(sb, currentOffset, offset - currentOffset);
                    currentOffset = offset;
                }

                // Add section header with offset and size info
                sb.AppendLine($"## {description}");
                sb.AppendLine();
                sb.AppendLine($"Offset: 0x{offset:X} | Size: {length} bytes (0x{length:X})");
                sb.AppendLine();

                // Add hex dump with column headers
                AddHexDump(sb, offset, length);

                currentOffset = offset + length;
            }

            // Add any remaining unknown data
            if (currentOffset < _stream.Length)
            {
                AddUnknownSection(sb, currentOffset, _stream.Length - currentOffset);
            }

            return sb.ToString();
        }

        private void AddHexDump(StringBuilder sb, long offset, long length)
        {
            sb.AppendLine("```");
            sb.AppendLine("         00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F");
            sb.AppendLine("       +------------------------------------------------");

            long sectionStart = offset;
            long sectionEnd = offset + length;
            
            // Align to 16-byte boundaries
            long rowStart = (offset / 16) * 16;
            long rowEnd = ((sectionEnd + 15) / 16) * 16;

            byte[] buffer = new byte[16];

            for (long rowOffset = rowStart; rowOffset < rowEnd; rowOffset += 16)
            {
                // Read the entire 16-byte row
                _stream.Position = rowOffset;
                int bytesRead = _stream.Read(buffer, 0, 16);

                // Format row address (aligned to 16-byte boundary)
                sb.Append($"{rowOffset:X6} | ");

                // Output each byte in the row
                for (int i = 0; i < 16; i++)
                {
                    long byteOffset = rowOffset + i;
                    
                    // Check if this byte is within the section
                    if (byteOffset >= sectionStart && byteOffset < sectionEnd)
                    {
                        // Read actual byte value
                        if (i < bytesRead)
                        {
                            sb.Append($"{buffer[i]:X2} ");
                        }
                        else
                        {
                            sb.Append("·· ");
                        }
                    }
                    else
                    {
                        // Outside section - show placeholder
                        sb.Append("·· ");
                    }
                }
                sb.AppendLine();
            }

            sb.AppendLine("```");
            sb.AppendLine();
        }

        private void AddUnknownSection(StringBuilder sb, long offset, long length)
        {
            sb.AppendLine("## Unknown");
            sb.AppendLine();
            sb.AppendLine($"Offset: 0x{offset:X} | Size: {length} bytes (0x{length:X})");
            sb.AppendLine();

            AddHexDump(sb, offset, length);
        }

        public void Dispose()
        {
            _stream?.Dispose();
            _reader?.Dispose();
            GC.SuppressFinalize(this);
        }

        private class CoverageTracker : IDisposable
        {
            private readonly AsaArchive _archive;
            private readonly long _startPosition;
            private readonly string _type;

            public CoverageTracker(AsaArchive archive, string type)
            {
                _archive = archive;
                _startPosition = archive.Position;
                _type = type;
            }

            public void Dispose()
            {
                long length = _archive.Position - _startPosition;
                if (length > 0)
                {
                    _archive.MarkParsed(_startPosition, length, _type);
                }
            }
        }

        private class NullTracker : IDisposable
        {
            public static NullTracker Shared = new();

            public void Dispose()
            {
            }
        }
    }
}
