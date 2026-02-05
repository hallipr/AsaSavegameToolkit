
namespace AsaSavegameToolkit;

public class FieldReadMap
{
    public FieldReadMap(long length, List<ParsedSection> sectionsRead, List<SkippedSection> sectionsSkipped)
    {
        Length = length;
        SectionsRead = sectionsRead;
        SectionsSkipped = sectionsSkipped;
    }

    public long Length { get; }

    public List<ParsedSection> SectionsRead
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
    public SkippedSection(long offset, long length, string reason)
    {
        Offset = offset;
        Length = length;
        Reason = reason;
    }

    public long Offset { get; set; }
    public long Length { get; set; }
    public string Reason { get; set; }
}

/// <summary>
/// Represents a section of the file that was read
/// </summary>
public record ParsedSection
{
    public long Offset { get; init; }
    public long Length { get; init; }
    public string Description { get; init; }

    public ParsedSection(long offset, long length, string description)
    {
        Offset = offset;
        Length = length;
        Description = description;
    }

    public override string ToString() => $"[{Offset:X8}-{Offset + Length - 1:X8}] {Description}";
}