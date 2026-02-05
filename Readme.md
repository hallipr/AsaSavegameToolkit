# AsaSavegameToolkit

![Build and Test](https://github.com/your-username/AsaSavegameToolkit/workflows/Build%20and%20Test/badge.svg)

This repo started as a direct copy of parts of the https://github.com/miragedmuk/ASV repo. `ASV` uses `ArkSavegameToolkit` from https://github.com/DodoCooker/ArkSavegameToolkit and `ArkSavegameToolkit` is a .NET port of https://github.com/Qowyn/ark-savegame-toolkit

## Features

- C# library for reading ARK: Survival Ascended save files
- Command-line interface (CLI) for analyzing saves
- Support for save version 14+ (UE5.5 structure)
- Parallel processing for improved performance
- Cross-platform support (Windows, Linux, macOS)

## Building

```bash
# Restore dependencies
dotnet restore AsaSavegameToolkit.slnx

# Build library
dotnet build AsaSavegameToolkit/src/AsaSavegameToolkit.csproj --configuration Release

# Build CLI
dotnet build AsaSavCli/src/AsaSavCli.csproj --configuration Release

# Run tests
dotnet test AsaSavegameToolkit/tests/AsaSavegameToolkit.Tests/AsaSavegameToolkit.Tests.csproj
```

## CI/CD

The project uses GitHub Actions for continuous integration:
- **Build and Test**: Builds and tests on Ubuntu, Windows, and macOS
- **Code Coverage**: Generates coverage reports
- **Release Artifacts**: Creates platform-specific builds for the CLI tool

See [.github/workflows/build-and-test.yml](.github/workflows/build-and-test.yml) for details.