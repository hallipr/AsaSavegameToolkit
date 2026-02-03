
namespace AsaSavegameToolkit;

public class FieldReadMap
{
    public FieldReadMap(long length, List<ReadSection> sectionsRead, List<SkippedSection> sectionsSkipped)
    {
        Length = length;
        SectionsRead = sectionsRead;
        SectionsSkipped = sectionsSkipped;
    }

    public long Length { get; }

    public List<ReadSection> SectionsRead
    {
        get;
        set => field = [.. value.OrderBy(x => x.Offset).ThenByDescending(x => x.Length)];
    }

    public List<SkippedSection> SectionsSkipped
    {
        get;
        set => field = [.. value.OrderBy(x => x.Offset).ThenByDescending(x => x.Length)];
    }
}

/// <summary>
/// Represents a section of the file that was skipped
/// </summary>
public record SkippedSection
{
    public SkippedSection(long offset, long length, string? reason)
    {
        Offset = offset;
        Length = length;
        Reason = reason;
    }

    public long Offset { get; set; }
    public long Length { get; set; }
    public string? Reason { get; set; }
}

/// <summary>
/// Represents a section of the file that was read
/// </summary>
public record ReadSection
{
    public long Offset { get; init; }
    public long Length { get; init; }
    public string Type { get; init; }
    
    /// <summary>
    /// Indicates parser completeness for this section.
    /// True = Section fully parsed and all bytes understood
    /// False = Section identified but parser is incomplete/buggy (some bytes not understood)
    /// This is a declarative statement about implementation quality, not computed from offsets.
    /// Example: "bytes 1000-5000 are the NameTable (Complete=false means parser needs work)"
    /// </summary>
    public bool Complete { get; }

    public ReadSection(long offset, long length, string type, bool complete)
    {
        Offset = offset;
        Length = length;
        Type = type;
        Complete = complete;
    }

    public override string ToString() => $"[{Offset:X8}-{Offset + Length - 1:X8}] {Type}" + (Complete ? "" : " (incomplete)");
}