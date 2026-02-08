using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit
{
    /// <summary>
    /// Configuration for debug output and coverage tracking
    /// </summary>
    public class AsaReaderSettings
    {
        /// <summary>
        /// AsaReaderSettings instance with no debug output
        /// </summary>
        public static AsaReaderSettings None { get; } = new();

        /// <summary>
        /// Directory path where debug output files will be written
        /// </summary>
        public string? OutputDirectory { get; set; }

        /// <summary>
        /// Maximum number of processor cores to use for parallel processing. Default is the number of logical processors on the machine.
        /// </summary>
        public int MaxCores { get; set; } = Environment.ProcessorCount;

        /// <summary>
        /// Whether to track file read coverage and generate annotated hex dumps
        /// </summary>
        public bool TrackCoverage { get; set; }

        [MemberNotNullWhen(true, nameof(OutputDirectory))]
        public bool HasOutput => !string.IsNullOrEmpty(OutputDirectory);

        public void CreateOutputDirectory()
        {
            if (!string.IsNullOrEmpty(OutputDirectory) && !Directory.Exists(OutputDirectory))
            {
                Directory.CreateDirectory(OutputDirectory);
            }
        }

        public void DeleteOutputDirectory()
        {
            if (!string.IsNullOrEmpty(OutputDirectory) && Directory.Exists(OutputDirectory))
            {
                Directory.Delete(OutputDirectory, true);
            }
        }
    }
}
