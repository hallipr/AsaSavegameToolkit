$work = Join-Path $PSScriptRoot "../.work"
New-Item -ItemType Directory -Path $work -ErrorAction SilentlyContinue | Out-Null

$saves = Get-ChildItem $PSScriptRoot/../AsaSavegameToolkit/tests/assets -Filter *.ark
foreach ($save in $saves) {
    $outputDir = Join-Path $work "output" ($save.BaseName)

    dotnet run --project $PSScriptRoot/../AsaSavCli/src -- `
        dump `
        $save.FullName `
        $outputDir
}