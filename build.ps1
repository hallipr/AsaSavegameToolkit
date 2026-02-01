param(
    [string]$OutputPath
)

if (!$OutputPath) {
    $OutputPath = Join-Path $PSScriptRoot ".work"
}

if (Test-Path -Path $OutputPath) {
    Remove-Item -Recurse -Force -Path $OutputPath
}

New-Item -ItemType Directory -Path $OutputPath | Out-Null

Write-Host "Building AsaSavCli into $OutputPath" -ForegroundColor Yellow
dotnet publish $PSScriptRoot/AsaSavCli/src/AsaSavCli.csproj `
    -c Release `
    -o $OutputPath `
    --self-contained true `
    /p:PublishSingleFile=true `
    /p:IncludeAllContentForSelfExtract=true `
    /p:PublishTrimmed=true
write-Host "Build completed." -ForegroundColor Green

Write-Host "Packing AsaSavegameToolkit NuGet package into $OutputPath" -ForegroundColor Yellow
dotnet pack $PSScriptRoot/AsaSavegameToolkit/src/AsaSavegameToolkit.csproj `
    -c Release `
    -o $OutputPath `
    /p:DebugType=embedded `
    /p:PackageOutputPath=$OutputPath
Write-Host "Packing completed." -ForegroundColor Green
