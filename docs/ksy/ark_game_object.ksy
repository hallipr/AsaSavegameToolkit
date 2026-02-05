meta:
  id: ark_game_object
  title: ARK Game Object (from SQLite save database)
  license: MIT
  endian: le
  encoding: UTF-8

doc: |
  ARK: Survival Ascended game object format as stored in the SQLite database.
  Based on ark-sa-save-tools ArkGameObject implementation.
  This is the binary format stored in the 'value' column of the 'game' table.

params:
  - id: save_version
    type: s4
    doc: Save version from SaveHeader
  - id: name_table
    type: name_table_type
    doc: Name table for resolving name references

seq:
  - id: class_name
    type: ark_name
    doc: Blueprint class name (e.g., "/Game/PrimalEarth/Dinos/Dodo/Dodo_Character_BP")
  - id: should_be_zero
    type: s4
    doc: Always zero
    valid: 0
  - id: name_count
    type: s4
    doc: Number of names in the hierarchy
  - id: names
    type: 
      switch-on: save_version < 13
      cases:
        true: ark_name
        false: ark_string
    repeat: expr
    repeat-expr: name_count
    doc: Object name hierarchy
  - id: data_file_part
    type: data_file_reference
    doc: Reference to data file part
  - id: unknown_byte
    type: u1
    doc: Unknown byte, purpose unclear
  - id: unknown_byte_v14
    type: u1
    if: save_version >= 14
    doc: Additional unknown byte in version 14+, should be 0
    valid: 0
  - id: properties
    type: property_container
    doc: Object properties
  - id: extra_data
    type: extra_data
    if: not _io.eof
    doc: Optional extra data at end

instances:
  use_ue55_structure:
    value: save_version >= 14
    doc: Save version 14+ uses UE5.5 property structure

types:
  name_table_type:
    doc: Name table for resolving IDs to strings
    
  ark_name:
    doc: Name reference from name table
    seq:
      - id: name_id
        type: s4
        doc: Index into name table
      - id: instance
        type: s4
        doc: Instance number for duplicate names
    instances:
      resolved_name:
        value: _root.name_table.names[name_id]
      full_name:
        value: instance == 0 ? resolved_name : resolved_name + "_" + instance.to_s
        
  ark_string:
    doc: Length-prefixed string
    seq:
      - id: length
        type: s4
        doc: Length in characters (negative = Unicode)
      - id: value
        type: str
        size: length < 0 ? ((-length) * 2) - 2 : length - 1
        encoding: length < 0 ? 'UTF-16LE' : 'UTF-8'
        if: length != 0
      - id: terminator
        size: length < 0 ? 2 : 1
        if: length != 0
        
  data_file_reference:
    doc: Reference to which data file part this object belongs to
    seq:
      - id: part_index
        type: s4
        doc: Index into data files/parts list from SaveHeader
        
  property_container:
    doc: Container of properties
    seq:
      - id: properties
        type: property
        repeat: until
        repeat-until: _.is_terminator or _io.eof
        doc: Properties until None terminator
        
  property:
    doc: Property placeholder - see ark_property.ksy for full implementation
    instances:
      is_terminator:
        value: false  # Actual check: property name == "None"
        
  extra_data:
    doc: Extra data sometimes present at end of object
    seq:
      - id: has_uuid2
        type: b32le
        doc: Whether a second UUID follows
      - id: uuid2
        size: 16
        if: has_uuid2.value
        doc: Second UUID, purpose unclear
        
  b32le:
    doc: 32-bit boolean
    seq:
      - id: value_raw
        type: s4
    instances:
      value:
        value: value_raw != 0
