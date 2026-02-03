
namespace AsaSavegameToolkit;

public class FieldReadMap
{
    private readonly List<ReadSection> _sectionsRead;
    private readonly List<SkippedSection> _sectionsSkipped;

    public FieldReadMap(int length, List<ReadSection> sectionsRead, List<SkippedSection> sectionsSkipped)
    {
        Length = length;
        SectionsRead = sectionsRead;
        SectionsSkipped = sectionsSkipped;
    }

    public int Length { get; }

    public List<ReadSection> SectionsRead
    {
        get => _sectionsRead;
        set
        {
            _sectionsRead.Clear();
            _sectionsRead.AddRange(value.OrderBy(x => x.Offset).ThenByDescending(x => x.Length));
        }
    }

    public List<SkippedSection> SectionsSkipped
    {
        get => _sectionsSkipped;
        set
        {
            _sectionsSkipped.Clear();
            _sectionsSkipped.AddRange(value.OrderBy(x => x.Offset).ThenByDescending(x => x.Length));
        }
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
    public bool Complete { get; }

    public ReadSection(long offset, long length, string type, bool complete)
    {
        Offset = offset;
        Length = length;
        Type = type;
        Complete = complete;
    }

    public override string ToString() => $"[{Offset:X8}-{Offset + Length - 1:X8}] {Type}";
}