using System.Text;

namespace AsaSavegameToolkit.Analysis
{
    /// <summary>
    /// Represents a section of the file with its status
    /// </summary>
    public record FileSection
    {
        public long Offset { get; init; }
        public long Length { get; init; }
        public FileSectionType Type { get; init; }
        public string? Description { get; init; }

        public long EndOffset => Offset + Length;

        public override string ToString() => 
            $"[{Offset:X8}-{EndOffset:X8}] ({Length:N0} bytes) {Type}" + 
            (Description != null ? $": {Description}" : "");
    }

    public enum FileSectionType
    {
        /// <summary>
        /// Section was fully read and all bytes understood
        /// </summary>
        Complete,
        
        /// <summary>
        /// Section was identified and partially read, but parser is incomplete/buggy
        /// </summary>
        Incomplete,
        
        /// <summary>
        /// Section not read - unknown what this data represents
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Analyzes file coverage from read sections
    /// </summary>
    public class FileCoverageAnalyzer
    {
        private readonly List<ReadSection> _readSections;
        private readonly long _fileSize;

        public FileCoverageAnalyzer(List<ReadSection> readSections, long fileSize)
        {
            _readSections = readSections ?? throw new ArgumentNullException(nameof(readSections));
            _fileSize = fileSize;
        }

        /// <summary>
        /// Analyzes coverage and returns all sections (read + gaps)
        /// </summary>
        public List<FileSection> AnalyzeCoverage()
        {
            var sections = new List<FileSection>();

            if (_readSections.Count == 0)
            {
                // Entire file is unknown
                if (_fileSize > 0)
                {
                    sections.Add(new FileSection
                    {
                        Offset = 0,
                        Length = _fileSize,
                        Type = FileSectionType.Unknown,
                        Description = "Entire file unread"
                    });
                }
                return sections;
            }

            // Sort read sections by offset
            var sortedReads = _readSections
                .OrderBy(s => s.Offset)
                .ToList();

            // Merge overlapping sections
            var mergedReads = MergeOverlappingSections(sortedReads);

            long currentOffset = 0;

            foreach (var read in mergedReads)
            {
                // Add gap before this read section if there is one
                if (currentOffset < read.Offset)
                {
                    sections.Add(new FileSection
                    {
                        Offset = currentOffset,
                        Length = read.Offset - currentOffset,
                        Type = FileSectionType.Unknown,
                        Description = "Unread gap"
                    });
                }

                // Add the read section
                sections.Add(new FileSection
                {
                    Offset = read.Offset,
                    Length = read.Length,
                    Type = read.Complete ? FileSectionType.Complete : FileSectionType.Incomplete,
                    Description = read.Type
                });

                currentOffset = read.Offset + read.Length;
            }

            // Add final gap if file continues beyond last read
            if (currentOffset < _fileSize)
            {
                sections.Add(new FileSection
                {
                    Offset = currentOffset,
                    Length = _fileSize - currentOffset,
                    Type = FileSectionType.Unknown,
                    Description = "Unread end of file"
                });
            }

            return sections;
        }

        /// <summary>
        /// Merges overlapping read sections
        /// </summary>
        private static List<ReadSection> MergeOverlappingSections(List<ReadSection> sortedSections)
        {
            if (sortedSections.Count == 0) return sortedSections;

            var merged = new List<ReadSection>();
            var current = sortedSections[0];

            for (int i = 1; i < sortedSections.Count; i++)
            {
                var next = sortedSections[i];

                // Check if sections overlap or are adjacent
                if (current.Offset + current.Length >= next.Offset)
                {
                    // Merge sections
                    long newEnd = Math.Max(current.Offset + current.Length, next.Offset + next.Length);
                    current = new ReadSection(
                        current.Offset,
                        newEnd - current.Offset,
                        current.Type,
                        current.Complete && next.Complete
                    );
                }
                else
                {
                    merged.Add(current);
                    current = next;
                }
            }

            merged.Add(current);
            return merged;
        }

        /// <summary>
        /// Gets coverage statistics
        /// </summary>
        public CoverageStats GetStatistics()
        {
            var sections = AnalyzeCoverage();

            long completeBytes = sections.Where(s => s.Type == FileSectionType.Complete).Sum(s => s.Length);
            long incompleteBytes = sections.Where(s => s.Type == FileSectionType.Incomplete).Sum(s => s.Length);
            long unknownBytes = sections.Where(s => s.Type == FileSectionType.Unknown).Sum(s => s.Length);

            return new CoverageStats
            {
                TotalFileSize = _fileSize,
                BytesComplete = completeBytes,
                BytesIncomplete = incompleteBytes,
                BytesUnknown = unknownBytes,
                PercentageComplete = _fileSize > 0 ? (double)completeBytes / _fileSize * 100 : 0,
                PercentageIncomplete = _fileSize > 0 ? (double)incompleteBytes / _fileSize * 100 : 0,
                PercentageUnknown = _fileSize > 0 ? (double)unknownBytes / _fileSize * 100 : 0,
                CompleteSectionCount = sections.Count(s => s.Type == FileSectionType.Complete),
                IncompleteSectionCount = sections.Count(s => s.Type == FileSectionType.Incomplete),
                UnknownSectionCount = sections.Count(s => s.Type == FileSectionType.Unknown)
            };
        }

        /// <summary>
        /// Generates an HTML visualization of file coverage
        /// </summary>
        public string GenerateHtmlVisualization(List<FileSection>? sections = default)
        {
            sections ??= AnalyzeCoverage();
            var stats = GetStatistics();

            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html><head>");
            sb.AppendLine("<title>File Coverage Analysis</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 20px; background: #f5f5f5; }");
            sb.AppendLine(".container { max-width: 1200px; margin: 0 auto; background: white; padding: 20px; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); }");
            sb.AppendLine("h1 { color: #333; border-bottom: 2px solid #4CAF50; padding-bottom: 10px; }");
            sb.AppendLine(".stats { display: grid; grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); gap: 15px; margin: 20px 0; }");
            sb.AppendLine(".stat-card { background: #f9f9f9; padding: 15px; border-radius: 6px; border-left: 4px solid #4CAF50; }");
            sb.AppendLine(".stat-label { font-size: 12px; color: #666; text-transform: uppercase; margin-bottom: 5px; }");
            sb.AppendLine(".stat-value { font-size: 24px; font-weight: bold; color: #333; }");
            sb.AppendLine(".coverage-bar { height: 40px; background: #eee; border-radius: 4px; overflow: hidden; margin: 20px 0; position: relative; }");
            sb.AppendLine(".segment { height: 100%; float: left; transition: opacity 0.2s; }");
            sb.AppendLine(".segment:hover { opacity: 0.8; }");
            sb.AppendLine(".segment-complete { background: #4CAF50; }");
            sb.AppendLine(".segment-incomplete { background: #FF9800; }");
            sb.AppendLine(".segment-unknown { background: #f44336; }");
            sb.AppendLine(".legend { margin: 20px 0; }");
            sb.AppendLine(".legend-item { display: inline-block; margin-right: 20px; }");
            sb.AppendLine(".legend-color { display: inline-block; width: 20px; height: 20px; margin-right: 5px; vertical-align: middle; border-radius: 3px; }");
            sb.AppendLine(".sections-table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            sb.AppendLine(".sections-table th, .sections-table td { padding: 10px; text-align: left; border-bottom: 1px solid #ddd; }");
            sb.AppendLine(".sections-table th { background: #f5f5f5; font-weight: 600; }");
            sb.AppendLine(".sections-table tr:hover { background: #f9f9f9; }");
            sb.AppendLine(".type-complete { color: #4CAF50; font-weight: bold; }");
            sb.AppendLine(".type-incomplete { color: #FF9800; font-weight: bold; }");
            sb.AppendLine(".type-unknown { color: #f44336; font-weight: bold; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head><body>");
            sb.AppendLine("<div class='container'>");

            // Title and stats
            sb.AppendLine("<h1>File Coverage Analysis</h1>");
            sb.AppendLine("<div class='stats'>");
            sb.AppendLine($"<div class='stat-card'><div class='stat-label'>File Size</div><div class='stat-value'>{FormatBytes(stats.TotalFileSize)}</div></div>");
            sb.AppendLine($"<div class='stat-card'><div class='stat-label'>Complete</div><div class='stat-value'>{FormatBytes(stats.BytesComplete)} ({stats.PercentageComplete:F1}%)</div></div>");
            sb.AppendLine($"<div class='stat-card'><div class='stat-label'>Incomplete</div><div class='stat-value'>{FormatBytes(stats.BytesIncomplete)} ({stats.PercentageIncomplete:F1}%)</div></div>");
            sb.AppendLine($"<div class='stat-card'><div class='stat-label'>Unknown</div><div class='stat-value'>{FormatBytes(stats.BytesUnknown)} ({stats.PercentageUnknown:F1}%)</div></div>");
            sb.AppendLine("</div>");

            // Coverage bar
            sb.AppendLine("<h2>Visual Coverage Map</h2>");
            sb.AppendLine("<div class='coverage-bar'>");
            foreach (var section in sections)
            {
                double widthPercent = (double)section.Length / _fileSize * 100;
                string cssClass = section.Type switch
                {
                    FileSectionType.Complete => "segment-complete",
                    FileSectionType.Incomplete => "segment-incomplete",
                    _ => "segment-unknown"
                };
                string title = $"{section.Type}: {FormatBytes(section.Length)} @ 0x{section.Offset:X8} - {section.Description}";
                sb.AppendLine($"<div class='segment {cssClass}' style='width: {widthPercent:F4}%' title='{title}'></div>");
            }
            sb.AppendLine("</div>");

            // Legend
            sb.AppendLine("<div class='legend'>");
            sb.AppendLine("<div class='legend-item'><span class='legend-color segment-complete'></span>Complete (Fully Parsed)</div>");
            sb.AppendLine("<div class='legend-item'><span class='legend-color segment-incomplete'></span>Incomplete (Identified, Parser Buggy)</div>");
            sb.AppendLine("<div class='legend-item'><span class='legend-color segment-unknown'></span>Unknown (Not Identified)</div>");
            sb.AppendLine("</div>");

            // Sections table
            sb.AppendLine("<h2>Section Details</h2>");
            sb.AppendLine("<table class='sections-table'>");
            sb.AppendLine("<thead><tr><th>Offset</th><th>Length</th><th>Type</th><th>Description</th></tr></thead>");
            sb.AppendLine("<tbody>");
            foreach (var section in sections)
            {
                string typeClass = section.Type switch
                {
                    FileSectionType.Complete => "type-complete",
                    FileSectionType.Incomplete => "type-incomplete",
                    _ => "type-unknown"
                };
                sb.AppendLine($"<tr>");
                sb.AppendLine($"<td>0x{section.Offset:X8}</td>");
                sb.AppendLine($"<td>{FormatBytes(section.Length)}</td>");
                sb.AppendLine($"<td class='{typeClass}'>{section.Type}</td>");
                sb.AppendLine($"<td>{section.Description ?? "-"}</td>");
                sb.AppendLine($"</tr>");
            }
            sb.AppendLine("</tbody></table>");

            sb.AppendLine("</div></body></html>");

            return sb.ToString();
        }

        private static string FormatBytes(long bytes)
        {
            string[] sizes = ["B", "KB", "MB", "GB"];
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }
    }

    public record CoverageStats
    {
        public long TotalFileSize { get; init; }
        public long BytesComplete { get; init; }
        public long BytesIncomplete { get; init; }
        public long BytesUnknown { get; init; }
        public double PercentageComplete { get; init; }
        public double PercentageIncomplete { get; init; }
        public double PercentageUnknown { get; init; }
        public int CompleteSectionCount { get; init; }
        public int IncompleteSectionCount { get; init; }
        public int UnknownSectionCount { get; init; }
    }
}
