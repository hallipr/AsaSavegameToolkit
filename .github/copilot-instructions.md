# GitHub Copilot Instructions

This file contains project-specific instructions for GitHub Copilot when working in this repository.

## Project Structure

- `AsaSavegameToolkit/` - Core library for reading/parsing ARK: Survival Ascended save files
- `AsaSavCli/` - Command-line interface tool built on top of the library
- Tests use MSTest framework

## Development Guidelines

### Test Output

- Always place test output, dumps, and generated files in the `.work/output/` directory
- This directory is gitignored and used for temporary test data
- Do not commit test output files to the repository

## Code Style

- Use C# 10+ features where appropriate
- Prefer `var` for local variables when type is obvious
- Use nullable reference types consistently

## Commands

The CLI uses System.CommandLine with a command-per-file architecture:
- Each command should inherit from `CommandDefinition`
- Place new commands in `AsaSavCli/src/Commands/`
- Register commands in `Program.cs`
