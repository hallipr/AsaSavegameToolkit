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
  - id: unknown_1
    type: u4
    if: save_version >= 14
    doc: Unknown integer field
  - id: unknown_2
    type: u4
    if: save_version >= 14
    doc: Unknown integer field
  - id: name_table_offset
    type: s4
    doc: Offset to the name table within this blob
  - id: game_time
    type: f8
    doc: In-game time as a double
  - id: unknown_3
    type: u4
    if: save_version > 11
    doc: Unknown integer field
  - id: data_files
    type: data_files_section
    doc: List of data files referenced by this save
instances:
  name_table:
    type: name_table_section
    pos: name_table_offset
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
        type: name_table_entry
        repeat: expr
        repeat-expr: count
  name_table_entry:
    seq:
      - id: key
        type: s4
      - id: value
        type: asa_string
  asa_string:
    doc: |
      ARK string format. Size is a signed 32-bit integer.
      Positive = ASCII string, Negative = UTF-16 string
      encoded_string:
    seq:
      - id: length
        type: s4
      - id: bytes
        size: |
          is_wide ? length * -2 : length
    instances:
      is_wide:
        value: length < 0
      value:
        value: |
          is_wide ? bytes.to_s('utf16') : bytes.to_s('utf8')
