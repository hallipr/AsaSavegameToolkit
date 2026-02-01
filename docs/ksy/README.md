# ARK: Survival Ascended Save Format Documentation

This directory contains Kaitai Struct (.ksy) files documenting the binary formats used in ARK: Survival Ascended save files.

## File Structure

ARK save files (.ark) are SQLite databases with two main tables:

### `custom` Table
Contains 4 key-value pairs with binary blob values:

1. **SaveHeader** (`asa_save_header.ksy`)
   - Save version, game time
   - List of referenced data files
   - Name table for efficient string storage

2. **GameModeCustomBytes** (`asa_game_mode_custom_bytes.ksy`)
   - Tribe data
   - Player profile data

3. **ActorTransforms** (`asa_actor_transforms.ksy`)
   - Location (X, Y, Z) for each actor
   - Rotation (Quaternion) for each actor

4. **ActorTransformsDelta**
   - Similar format to ActorTransforms
   - Contains transform deltas/changes

### `game` Table
Contains thousands of key-value pairs where both key and value are binary blobs:

- **Key**: Object identification data (see `asa_game_object.ksy`)
- **Value**: Object properties and state data (see `asa_game_object.ksy`)

## Common Types

### `asa_string`
ARK's custom string format:
- Size is a signed 32-bit integer
- Positive size = ASCII string
- Negative size = UTF-16LE string (size is absolute value)
- Size 0 = null string
- Size ±1 = empty string

### `asa_name`
Name reference used throughout the format:
- Can be an index into the name table
- Can be an inline string
- Includes instance index for duplicate names

### `asa_property`
Property format used for object data:
- Name and type (both asa_name)
- Size and index
- Binary value blob (format depends on type)

## Usage

These .ksy files can be used with Kaitai Struct tools to:
- Generate parsers in various languages
- Visualize binary data structure
- Document the format for reverse engineering

Example:
```bash
kaitai-struct-compiler -t python asa_save_header.ksy
```
