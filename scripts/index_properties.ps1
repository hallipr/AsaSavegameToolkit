param(
    [string]$fileName
)

# Index Ragnarok bin files by flag field, first property name, and first property type

$gameDir = "d:\repos\AsaSavegameToolkit\.work\Ragnarok_WP\game"
$headerPath = "d:\repos\AsaSavegameToolkit\.work\Ragnarok_WP\custom\SaveHeader_0.json"
$outputJson = "d:\repos\AsaSavegameToolkit\.work\output\ragnarok_property_index.json"

# Load name table from SaveHeader
Write-Host "Loading name table from SaveHeader_0.json..."
$header = Get-Content $headerPath | ConvertFrom-Json -AsHashtable
$nameTable = $header.NameTable
Write-Host "Loaded $($nameTable.Count) names"

function Read-Name {
    param($reader)
    
    $hash = $reader.ReadInt32()
    $instance = $reader.ReadInt32()
    $hashString = "$hash"
    if ($nameTable.ContainsKey($hashString)) { 
        return @{
            Hash = $hash
            Instance = $instance
            Name = $nameTable[$hashString]
        }
    }
}

# Get all bin files
$binFiles = Get-ChildItem -Path $gameDir -Recurse -Filter "*.bin"
Write-Host "Found $($binFiles.Count) bin files"

if($fileName) {
    $binFiles = $binFiles | Where-Object { $_.Name -like "*$fileName*" }
    if ($binFiles.Count -eq 0) {
        Write-Host "No files found with '$fileName'" -ForegroundColor Red
        exit
    }
    Write-Host "Filtering to file: $fileName"
}

$results = @()
$processed = 0

foreach ($file in $binFiles) {
    $processed++
    if ($processed % 100 -eq 0) {
        Write-Host "Processed $processed / $($binFiles.Count) files..."
    }
    
    try {
        $stream = [IO.File]::Open($file.FullName, [IO.FileMode]::Open, [IO.FileAccess]::Read, [IO.FileShare]::Read)
        $reader = New-Object System.IO.BinaryReader($stream)
        
        # Read GameObject structure
        # ClassName (8 bytes name hash + 4 bytes instance)
        $className = Read-Name $reader
        
        # IsItem (4 bytes)
        $isItem = $reader.ReadInt32()
        
        # Name count and names
        $nameCount = $reader.ReadInt32()

        # names are null terminated strings
        for($i = 0; $i -lt $nameCount; $i++) {
            $nameLength = $reader.ReadInt32()  # includes null terminator
            $reader.ReadBytes($nameLength) | Out-Null            
        }
        
        # DataFileIndex (4 bytes)
        $dataFileIndex = $reader.ReadInt32()
        
        # PropertyHint flags (2 bytes)
        $flags = @($reader.ReadByte())
        if($stream.Position -lt $stream.Length) {
            $flags += $reader.ReadByte()
        }
        
        $result = [ordered]@{
            FileName = $file.Name
            RelativePath = $file.FullName.Replace("$gameDir\", "")
            ClassName = $className.Name
            IsItem = $isItem
            NameCount = $nameCount
            DataFileIndex = $dataFileIndex
            Flags = $flags
            Flag1Hex = "0x{0:X4}" -f $flags[0]
            Flag1Binary = [Convert]::ToString($flags[0], 2).PadLeft(8, '0')
            BytesAfterFlags = $stream.Length - $stream.Position
        }
        
        # Only read the first property info if there are enough bytes left in the stream to avoid errors
        if ($stream.Position + 16 -lt $stream.Length) {
            $propName = Read-Name $reader
            if ($propName) {
                $propType = Read-Name $reader
                $result.FirstPropertyName = $propName.Name
                $result.FirstPropertyIndex = $propName.Index
                $result.FirstPropertyType = $propType.Name
            }
        }
        
        $results += $result
        
        $reader.Close()
        $stream.Close()
    }
    catch {
        Write-Host "ERROR processing $($file.Name): $_" -ForegroundColor Red
    }
    finally {
        if ($reader) { $reader.Close() }
        if ($stream) { $stream.Close() }
    }
}

Write-Host "`n=== ANALYSIS COMPLETE ===" -ForegroundColor Green
Write-Host "Total files processed: $processed"
Write-Host "Unique flag values: $(($results.Flags | Sort-Object -Unique).Count)"

# Export to CSV
$results | ConvertTo-Json -Depth 5 | Out-File -FilePath $outputJson -Encoding UTF8
Write-Host "`nResults exported to: $outputJson" -ForegroundColor Green

# Show summary by flags
Write-Host "`n=== SUMMARY BY FLAGS ===" -ForegroundColor Cyan
$grouped = $results | Group-Object { $_.Flag1Binary } | Sort-Object Name
foreach ($group in $grouped) {
    $first = $group.Group | Select-Object -First 1
    Write-Host "`nFlag1 = $($first.Flags[0]) ($($group.Name), 0x$($first.Flag1Hex)): $($group.Count) files" -ForegroundColor Yellow
    
    # Show unique property name/type combinations
    $propCombos = $group.Group | Where-Object { $_.FirstPropertyName -ne "" } | 
        Group-Object {$_.FirstPropertyName}, {$_.FirstPropertyType} | 
        Sort-Object Count -Descending
    
    if ($propCombos.Count -gt 0) {
        Write-Host "  Property Name/Type combinations:"
        foreach ($combo in $propCombos | Select-Object -First 5) {
            $parts = $combo.Name -split ", "
            Write-Host "    $($parts[0]) : $($parts[1]) - $($combo.Count) files"
        }
        if ($propCombos.Count -gt 5) {
            Write-Host "    ... and $($propCombos.Count - 5) more combinations"
        }
    }
    
    # Show example files
    Write-Host "  Example files:"
    foreach ($ex in $group.Group | Select-Object -First 3) {
        Write-Host "    $($ex.FileName) - Class: $($ex.ClassName)"
    }
}

Write-Host "`n=== TOP PROPERTY NAMES ===" -ForegroundColor Cyan
$topProps = $results | Where-Object { $_.FirstPropertyName -ne "" } | 
    Group-Object { $_.FirstPropertyName } | 
    Sort-Object Count -Descending | 
    Select-Object -First 10
    
foreach ($prop in $topProps) {
    Write-Host "$($prop.Name): $($prop.Count) files"
}

Write-Host "`n=== TOP PROPERTY TYPES ===" -ForegroundColor Cyan
$topTypes = $results | Where-Object { $_.FirstPropertyType -ne "" } | 
    Group-Object { $_.FirstPropertyType } | 
    Sort-Object Count -Descending | 
    Select-Object -First 10

foreach ($type in $topTypes) {
    Write-Host "$($type.Name): $($type.Count) files"
}
