param(
    [string]$OutputPath,
    [switch]$Nuget
)

if (!$OutputPath) {
    $OutputPath = Join-Path $PSScriptRoot ".work"
}

if (Test-Path -Path $OutputPath) {
    Remove-Item -Recurse -Force -Path $OutputPath
}

New-Item -ItemType Directory -Path $OutputPath | Out-Null

if($Nuget) {
    Write-Host "Packing AsaSavegameToolkit NuGet package into $OutputPath" -ForegroundColor Yellow
    dotnet pack $PSScriptRoot/../AsaSavegameToolkit/src/AsaSavegameToolkit.csproj `
        -c Release `
        -o $OutputPath `
        /p:DebugType=embedded `
        /p:PackageOutputPath=$OutputPath
    Write-Host "Packing completed." -ForegroundColor Green
} else {
    Write-Host "Building AsaSavCli into $OutputPath" -ForegroundColor Yellow
    dotnet publish $PSScriptRoot/../AsaSavCli/src/AsaSavCli.csproj `
        -c Release `
        -o $OutputPath `
        /p:PublishSingleFile=true
    write-Host "Build completed." -ForegroundColor Green
}
