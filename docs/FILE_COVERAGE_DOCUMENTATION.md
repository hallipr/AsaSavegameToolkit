# File Coverage Visualization - Three-State System

## Understanding the `Complete` Flag

The `Complete` property in `ReadSection` is a **declarative statement about parser quality**, not a computed property. It distinguishes between:

### Three States:

#### ? Complete (Green)
```csharp
archive.RecordRead(offset: 1000, length: 500, type: "Header", complete: true);
```
**Meaning:** "I read bytes 1000-1500 as the Header AND my parser fully understands every byte"

#### ?? Incomplete (Orange/Yellow)
```csharp
archive.RecordRead(offset: 5000, length: 50000, type: "NameTable", complete: false);
```
**Meaning:** "I read bytes 5000-55000 as the NameTable BUT my parser is buggy/incomplete - I'm still working on it"

#### ? Unknown (Red/Gray)
No `RecordRead` call for this range.

**Meaning:** "I have no idea what bytes 55000-60000 represent - completely unidentified"

## Why This Matters

This three-state system lets you track parsing progress semantically:

### Example: Parsing the Object Table

```csharp
// Declare the whole table region (even if parsing is incomplete)
using (archive.BeginRead("ObjectTable", complete: false))
{
    // offset: 10000, length: 100000
    
    // Try to parse objects (may fail for some)
    for (int i = 0; i < objectCount; i++)
    {
        if (TryParseObject(archive, out var obj))
        {
            // Success - individual object parsed
        }
        else
        {
            // Failed - but we still marked the parent section
            archive.SkipBytes(estimatedObjectSize);
        }
    }
}
// Result: Section marked as "ObjectTable" (100KB) with Complete=false
```

The visualization shows:
- **Large orange block**: "This is the object table (100KB)"
- **Not gaps**: We know what it IS
- **Orange = TODO**: Parser needs work

Without this, you'd only see:
- Small green blocks where parsing succeeded
- Large red gaps labeled "Unknown"
- No indication that you've IDENTIFIED the data structure

## Visualization Output

### Console (Text Map)
```
File Coverage Map (1,234,567 bytes)
================================================================================
???????????????????????????????????????????????????????????????????????????
================================================================================
? = Complete   ? = Incomplete   ? = Unknown

Complete: 456,123 bytes (37.0%)
Incomplete: 389,000 bytes (31.5%)
Unknown: 389,444 bytes (31.5%)
Sections: 12 complete, 8 incomplete, 5 unknown
```

### HTML Report
- **Green segments**: Fully working parsers
- **Orange segments**: Identified but needs work
- **Red segments**: No clue what this is
- **Hover tooltips**: Show section type and size
- **Detailed table**: All sections with offsets

## Best Practices

### Mark Large Structural Regions
```csharp
// Even if you can't parse it all yet, mark what you know
using (archive.BeginRead("NameTable", complete: false))
{
    // Parse what you can
    ParseNameTableHeader();  // This works
    // Skip what you can't
    archive.SkipBytes(nameTableData);  // TODO: implement this
}
```

### Progressive Refinement
As you improve the parser, mark sections as complete:

**Version 1:**
```csharp
archive.RecordRead(1000, 50000, "NameTable", complete: false);  // 31% unknown
```

**Version 2 (after fixing bugs):**
```csharp
archive.RecordRead(1000, 50000, "NameTable", complete: true);   // 5% unknown
```

The visualization shows your progress!

### Nested Sections
```csharp
// Outer section (incomplete)
using (archive.BeginRead("GameObjects", complete: false))
{
    foreach (var obj in objects)
    {
        // Inner sections (may be complete)
        using (archive.BeginRead($"GameObject[{obj.Id}]", complete: tryParseResult))
        {
            TryParseObject(obj);
        }
    }
}
```

## Implementation Notes

### In AsaArchive
```csharp
public void RecordRead(long offset, long length, string type, bool complete = true)
{
    SectionsRead.Add(new ReadSection(offset, length, type, complete));
}

public IDisposable BeginRead(string type, bool complete = true)
{
    return new ReadTracker(this, Position, type, complete);
}
```

### Setting `complete` Parameter
- **Default true**: Most primitive reads (int, string, etc.)
- **Explicitly false**: Complex structures you're still implementing
- **Computed**: Based on parsing success: `complete: result.Success`

## Visualizing Progress

Run tests and open `.work/output/parsed/coverage.html` to see:
1. What % of the file you've identified (complete + incomplete)
2. What % you fully understand (complete only)
3. What % is still mysterious (unknown)
4. Specific sections that need work (orange)

This helps prioritize: **"Fix the NameTable parser (31% of file, all incomplete)"** rather than guessing where to focus efforts.
