using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit
{
    /// <summary>
    /// Configuration for debug output and coverage tracking
    /// </summary>
    public class DebugSettings
    {
        public DebugSettings(string outputPath) : this(outputPath, trackCoverage: false)
        {
        }

        public DebugSettings(bool trackCoverage) : this(outputDirectory: null, trackCoverage)
        {
        }

        public DebugSettings(string? outputDirectory, bool trackCoverage)
        {
            OutputDirectory = outputDirectory;
            TrackCoverage = trackCoverage;
        }

        /// <summary>
        /// Creates a DebugSettings instance with no debug output
        /// </summary>
        public static DebugSettings None { get; } = new(outputDirectory: null, trackCoverage: false);

        /// <summary>
        /// Directory path where debug output files will be written
        /// </summary>
        public string? OutputDirectory { get; init; }

        /// <summary>
        /// Whether to track file read coverage and generate annotated hex dumps
        /// </summary>
        public bool TrackCoverage { get; init; }

        [MemberNotNullWhen(true, nameof(OutputDirectory))]
        public bool HasOutput => !string.IsNullOrEmpty(OutputDirectory);

        internal void CreateOutputDirectory()
        {
            if (!string.IsNullOrEmpty(OutputDirectory) && !Directory.Exists(OutputDirectory))
            {
                Directory.CreateDirectory(OutputDirectory);
            }
        }
    }
}
