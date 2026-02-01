meta:
  id: asa_save_header
  title: ARK Survival Ascended Save Header
  file-extension: bin
  endian: le
doc: |
  The SaveHeader blob from the 'custom' table in ARK: Survival Ascended save files.
  Contains metadata about the save including version, data files, and name table.
seq:
  - id: save_version
    type: s2
    doc: Save format version number
  - id: name_table_offset
    type: s4
    doc: Offset to the name table within this blob
  - id: game_time
    type: f8
    doc: In-game time as a double
  - id: unknown_int1
    type: s4
    if: save_version > 11
    doc: Unknown integer field (appears to be 582 in observed saves)
  - id: data_files
    type: data_files_section
    doc: List of data files referenced by this save
  - id: name_table
    type: name_table_section
    doc: String name table used for efficient storage
types:
  data_files_section:
    seq:
      - id: count
        type: s4
      - id: files
        type: data_file_entry
        repeat: expr
        repeat-expr: count
      - id: unknown1
        type: s4
      - id: unknown2
        type: s4
  data_file_entry:
    seq:
      - id: name
        type: asa_string
      - id: record_terminator
        type: s4
        doc: Always seems to be -1
  name_table_section:
    seq:
      - id: count
        type: s4
      - id: names
        type: asa_string
        repeat: expr
        repeat-expr: count
  asa_string:
    doc: |
      ARK string format. Size is a signed 32-bit integer.
      Positive = ASCII string, Negative = UTF-16 string
    seq:
      - id: size
        type: s4
      - id: data
        size: |
          size == 0 ? 0 :
          size == 1 ? 1 :
          size == -1 ? 2 :
          size < 0 ? (-size * 2) :
          size
        type: str
        encoding: |
          size < 0 ? "UTF-16LE" : "ASCII"
        if: size != 0
