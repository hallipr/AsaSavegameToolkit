using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

using AsaSavegameToolkit.Types;

using Microsoft.Extensions.Logging;

namespace AsaSavegameToolkit
{

    public class AsaArchive : IDisposable
    {
        private readonly ILogger _logger;
        private readonly Stream _stream;
        private readonly DebugSettings _debugSettings;
        private readonly BinaryReader _reader;
        private readonly Stack<CoverageNode> _coverageStack = new();

        public AsaArchive(ILogger logger, Stream stream, string fileName) : this(logger, stream, fileName, DebugSettings.None)
        {
        }

        public AsaArchive(ILogger logger, Stream stream, string fileName, DebugSettings debugSettings)
        {
            _logger = logger;
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            FileName = fileName;
            _debugSettings = debugSettings;
            _reader = new BinaryReader(_stream);
            
            // Initialize coverage tracking with root node
            CoverageRoot = new CoverageNode
            {
                Offset = 0,
                Length = 0, // Will be updated as we read
                Description = "root",
                Type = "file",
                IsSkipped = false
            };

            _coverageStack.Push(CoverageRoot);
        }

        /// <summary>
        /// Root node of the hierarchical coverage tree
        /// </summary>
        public CoverageNode CoverageRoot { get; }

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

        #region Read Operations

        public IDisposable? Track(string type, string description)
        {
            return _debugSettings.TrackCoverage ? new CoverageTracker(this, type, description) : null;
        }

        public T Track<T>(string type, string description, Func<T> action)
        {
            if (!_debugSettings.TrackCoverage)
            {
                return action();
            }

            using var tracker = Track(type, description);
            return action();
        }

        public void SkipBytes(int count, string reason = "")
        {
            if (count < 0)
            {
                _logger.LogError("Attempting to skip a negative number of bytes at offset {Offset:X}. Count: {Count}", _stream.Position, count);
                throw new ArgumentOutOfRangeException(nameof(count), "SkipButes count must be greater than zero.");
            }

            if (_stream.Position + count >= _stream.Length)
            {
                _logger.LogError("Attempting to skip beyond the end of the stream at offset {Offset:X}. Count: {Count}", _stream.Position, count);
                throw new ArgumentOutOfRangeException(nameof(count), "Attempting to skip beyond the end of the stream.");
            }

            if (_debugSettings.TrackCoverage)
            {
                var offset = _stream.Position;
                var node = new CoverageNode
                {
                    Offset = offset,
                    Length = count,
                    Type = "skip",
                    Description = reason,
                    IsSkipped = true,
                };
                _coverageStack.Peek().Children.Add(node);
            }
            
            _stream.Seek(count, SeekOrigin.Current);
        }

        public bool TryReadString(string description, [NotNullWhen(true)] out string? value)
        {
            using var tracker = Track("string", description);

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
            using var tracker = Track("name", description);
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

        public byte ReadByte(string description) => Track("s1", description, _reader.ReadByte);
        public short ReadInt16(string description) => Track("s2", description, _reader.ReadInt16);
        public int ReadInt32(string description) => Track("s4", description, _reader.ReadInt32);
        public long ReadInt64(string description) => Track("s8", description, _reader.ReadInt64);
        public float ReadSingle(string description) => Track("f4", description, _reader.ReadSingle);
        public double ReadDouble(string description) => Track("f8", description, _reader.ReadDouble);
        public uint ReadUInt32(string description) => Track("u4", description, _reader.ReadUInt32);
        public byte[] ReadBytes(int length, string description) => Track("bytes", description, () => _reader.ReadBytes(length));

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
                using var tracker = Track("string", description);
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

            // Add title and file info
            sb.AppendLine($"# {Path.GetFileName(FileName)}");
            sb.AppendLine();
            sb.AppendLine($"File Size: {_stream.Length:N0} bytes (0x{_stream.Length:X})");
            
            int parsedCount = CountNodes(CoverageRoot, false);
            int skippedCount = CountNodes(CoverageRoot, true);
            
            sb.AppendLine($"Sections Read: {parsedCount}");
            sb.AppendLine($"Sections Skipped: {skippedCount}");
            sb.AppendLine();

            // Output table header
            sb.AppendLine("| offset | offset | type   |                  hex |    parsed | description           |");
            sb.AppendLine("| -----: | -----: | ------ | -------------------: | --------: | --------------------- |");

            // Pre-read and cache all small section data
            var sectionData = PreloadAllSectionData(CoverageRoot);

            // Process the hierarchical structure as a flat table
            ProcessNodesAsTable(sb, CoverageRoot.Children, 0, sectionData);

            sb.AppendLine();
            return sb.ToString();
        }

        private int CountNodes(CoverageNode node, bool countSkipped)
        {
            int count = (node.IsSkipped == countSkipped && node != CoverageRoot) ? 1 : 0;
            foreach (var child in node.Children)
            {
                count += CountNodes(child, countSkipped);
            }
            return count;
        }

        private Dictionary<CoverageNode, byte[]> PreloadAllSectionData(CoverageNode root)
        {
            var data = new Dictionary<CoverageNode, byte[]>();
            PreloadNodeData(root, data);
            return data;
        }

        private void PreloadNodeData(CoverageNode node, Dictionary<CoverageNode, byte[]> data)
        {
            if (node.Length > 0 && node.Length <= 64 && !node.IsSkipped)
            {
                try
                {
                    _stream.Position = node.Offset;
                    byte[] buffer = new byte[node.Length];
                    _stream.ReadExactly(buffer, 0, (int)node.Length);
                    data[node] = buffer;
                }
                catch
                {
                    // Skip if read fails
                }
            }

            foreach (var child in node.Children)
            {
                PreloadNodeData(child, data);
            }
        }

        private void ProcessNodesAsTable(StringBuilder sb, List<CoverageNode> nodes, int indentLevel, Dictionary<CoverageNode, byte[]> sectionData)
        {
            var sortedNodes = nodes.OrderBy(n => n.Offset).ToList();
            
            foreach (var node in sortedNodes)
            {
                string indent = indentLevel > 0 ? new string('-', indentLevel) + " " : "";
                string description = indent + node.Description;
                string type = node.IsSkipped ? "skip" : node.Type ?? InferTypeFromLength(node.Length);

                if (node.Children.Count > 0)
                {
                    // Parent node - just show description, no type/hex/parsed
                    sb.AppendLine($"| {node.Offset:X6} | {node.Offset,6} | {type,-6} | {"",-20} | {"",-9} | {description,-21} |");
                    
                    // Recursively process children with increased indent
                    ProcessNodesAsTable(sb, node.Children, indentLevel + 1, sectionData);
                }
                else
                {
                    // Leaf node - show all details
                    string hex = GetHexForTable(node, sectionData);
                    string parsed = node.IsSkipped ? "" : GetParsedForTable(node, type, sectionData);
                    
                    sb.AppendLine($"| {node.Offset:X6} | {node.Offset,6} | {type,-6} | {hex,20} | {parsed,9} | {description,-21} |");
                }
            }
        }

        private static string InferTypeFromLength(long length)
        {
            return length switch
            {
                1 => "b1",
                2 => "s2",
                4 => "s4",
                8 => "s8",
                _ when length > 8 => "bytes",
                _ => "??"
            };
        }

        private string GetHexForTable(CoverageNode node, Dictionary<CoverageNode, byte[]> sectionData)
        {
            byte[] data;
            
            if (sectionData.TryGetValue(node, out var cached))
            {
                data = cached;
            }
            else
            {
                try
                {
                    _stream.Position = node.Offset;
                    data = new byte[node.Length];
                    _stream.ReadExactly(data, 0, (int)node.Length);
                }
                catch
                {
                    return "";
                }
            }
            
            // For table format, show first 3 and last 3 bytes with ellipsis for longer data
            if (data.Length <= 8)
            {
                return string.Join(" ", data.Select(b => $"{b:X2}"));
            }
            else
            {
                string startHex = string.Join(" ", data.Take(3).Select(b => $"{b:X2}"));
                string endHex = string.Join(" ", data.TakeLast(3).Select(b => $"{b:X2}"));
                return $"{startHex} .. {endHex}";
            }
        }

        private string GetParsedForTable(CoverageNode node, string type, Dictionary<CoverageNode, byte[]> sectionData)
        {
            if (node.Length > 8 || type == "bytes" || type == "skip")
                return "";
                
            try
            {
                byte[] data;
                
                if (sectionData.TryGetValue(node, out var cached))
                {
                    data = cached;
                }
                else if (node.Length <= 64)
                {
                    _stream.Position = node.Offset;
                    data = new byte[node.Length];
                    _stream.ReadExactly(data, 0, (int)node.Length);
                }
                else
                {
                    return "";
                }
                
                return type switch
                {
                    "b1" or "s1" => (data[0] != 0).ToString().ToLower(),
                    "s2" => BitConverter.ToInt16(data, 0).ToString(),
                    "s4" => BitConverter.ToInt32(data, 0).ToString(),
                    "u4" => BitConverter.ToUInt32(data, 0).ToString(),
                    "s8" => BitConverter.ToInt64(data, 0).ToString(),
                    "f4" => BitConverter.ToSingle(data, 0).ToString("F2"),
                    "f8" => BitConverter.ToDouble(data, 0).ToString("F2"),
                    _ => ""
                };
            }
            catch
            {
                return "";
            }
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
            private readonly CoverageNode _node;

            public CoverageTracker(AsaArchive archive, string type, string description)
            {
                _archive = archive;
                
                // Create new node and push to stack
                _node = new CoverageNode
                {
                    Type = type,
                    Description = description,
                    Offset = archive.Position,
                    Length = 0, // Will be set on dispose
                    IsSkipped = false
                };
                
                _archive._coverageStack.Push(_node);
            }

            public void Dispose()
            {
                // Pop from stack
                var popped = _archive._coverageStack.Pop();
                
                // Set the length
                popped.Length = _archive.Position - popped.Offset;
                
                // Add to parent's children (peek will give us parent since we just popped)
                if (_archive._coverageStack.Count > 0)
                {
                    _archive._coverageStack.Peek().Children.Add(popped);
                }
            }
        }
    }

    /// <summary>
    /// Represents a node in the hierarchical coverage tree
    /// </summary>
    public class CoverageNode
    {
        public long Offset { get; init; }
        public long Length { get; set; }
        public required string Description { get; init; }
        public required string Type { get; init; }
        public bool IsSkipped { get; init; }
        public string? Reason { get; init; }
        public List<CoverageNode> Children { get; } = [];
        public IEnumerable<CoverageNode> Descendants => Children.SelectMany(x => x.Children.Prepend(x));

        public override string ToString() => $"[{Offset:X8}-{Offset + Length - 1:X8}] {Description} ({Children.Count} children)";
    }
}
