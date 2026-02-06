meta:
  id: asa_game_object
  title: ARK Survival Ascended Game Object
  file-extension: bin
  endian: le
doc: |
  Game table 'game' contains serialized game objects (actors, items, components, etc).
  Each row has a GUID key and binary blob value.
  
  === STRUCTURE ANALYSIS (4,543 Ragnarok files) ===
  
  GameObject Header:
  - ClassName (8 bytes): Name hash + instance
  - IsItem (4 bytes): Type/flag indicator
  - NameCount (4 bytes): Number of name strings
  - Names (variable): Null-terminated strings
  - DataFileIndex (4 bytes): Unknown purpose
  - Flags (1-2 bytes): Property hints
    * 3 files (AnimSequence) have 1 byte
    * 4,540 files have 2 bytes
    * Flag[1] always 0x00 (unused/reserved)
  
  Property Flags Pattern:
  - 0x00 (97 files):    97% have properties
  - 0x01 (1,486):      100% have properties (Items)
  - 0x02 (1,380):        6% have properties (NPCZoneManager)
  - 0x08 (153):        100% have properties (Creatures)
  - 0x0A (1,427):        7% have properties (NPCZoneVolume)
  
  Property Reading:
  - 42% of files have real properties
  - 58% have only "None" terminator
  - Must always attempt read (flags have exceptions)
  - Stops at "None" name or end of data
  
  Post-Property Data (48 files):
  - DinoDeathHarvestingComponent: Fixed 32 bytes (component reference)
  - InstancedFoliageActor: Variable 268-30,082 bytes (instance data)
seq:
  - id: objects
    type: game_object
    repeat: eos
types:
  game_object:
    doc: |
      A serialized game object stored in the 'game' table.
      Not all game objects have the same structure - some have minimal data.
    seq:
      - id: class_name
        type: asa_name
        doc: Object's class (e.g., Dilo_Character_BP_C, PrimalItem_*, NPCZoneManager)
      - id: is_item
        type: s4
        doc: Appears to be a flag/type indicator (not just boolean)
      - id: name_count
        type: s4
        doc: Number of name strings that follow
      - id: names
        type: asa_string
        repeat: expr
        repeat-expr: name_count
        doc: Object names (null-terminated strings)
      - id: data_file_index
        type: s4
        doc: Index into data file (purpose unclear, often 0)
      - id: flags
        type: property_flags
        doc: |
          Property hint flags (1-2 bytes).
          3 files (AnimSequence) have only 1 byte remaining = 1 flag byte.
          All other files have 2 bytes = 2 flag bytes.
          Flag[1] is always 0x00 (unused/reserved).
      - id: properties
        type: property_list
        doc: |
          Properties continue until "None" name or end of data.
          Cannot rely on flags to skip - must always attempt read.
      - id: extra_data
        size-eos: true
        if: _io.eof == false
        doc: |
          Some classes have additional data after properties:
          - InstancedFoliageActor: Variable-length instance data (268-30,082 bytes, avg ~11,210)
          - DinoDeathHarvestingComponent: Fixed 32-byte component reference
  property_flags:
    doc: |
      Property flags field (1 or 2 bytes).
      Flag patterns observed (4,543 files):
      - 0x00 (97 files):  97% have properties (DinoCharacterStatusComponent)
      - 0x01 (1,486):    100% have properties (Items/Skins)
      - 0x02 (1,380):      6% have properties (NPCZoneManager, mostly just "None")
      - 0x08 (153):      100% have properties (Creatures)
      - 0x0A (1,427):      7% have properties (NPCZoneVolume, mostly just "None")
      
      Flag[1] is ALWAYS 0x00 in all 4,540 files with 2 bytes.
      Cannot skip property reading based on flags due to exceptions.
    seq:
      - id: flag0
        type: u1
        doc: First flag byte (has patterns but exceptions exist)
      - id: flag1
        type: u1
        if: not _io.eof
        doc: Second flag byte (always 0x00, unused/reserved)
  property_list:
    doc: |
      List of properties terminated by "None" property name.
      
      Distribution from 4,543 files:
      - 1,912 files (42%) have real properties
      - 2,631 files (58%) have only "None" terminator
      - 3 files (0.07%) have 0 bytes = cannot read properties (AnimSequence)
      
      Top property types:
      - StructProperty: 44% (e.g., ItemID)
      - ArrayProperty: 43% (e.g., CustomItemDatas, HibernatedEntities)
      - DoubleProperty: 4% (e.g., FirstUpdateTime)
      - ByteProperty: 4% (e.g., NumberOfLevelUpPointsApplied)
      - ObjectProperty: 3% (e.g., Instigator)
    seq:
      - id: properties
        type: asa_property
        repeat: until
        repeat-until: _.is_none or _io.eof
  asa_property:
    doc: |
      UE5.5 property format (SaveVersion 14+).
      Reading stops when name == "None" or no bytes remain.
    seq:
      - id: name
        type: asa_name
        doc: Property name (if "None", this marks end of property list)
      - id: type_name
        type: asa_name
        if: not is_none
        doc: Property type (StructProperty, ArrayProperty, etc.)
      - id: size
        type: s4
        if: not is_none
        doc: Size of property value in bytes
      - id: index
        type: s4
        if: not is_none
        doc: Property index (usually 0)
      - id: value
        size: size
        if: not is_none and size > 0
        doc: Property value data (format depends on type_name)
    instances:
      is_none:
        value: name.name_hash == 0x000d5a38 and name.name_instance == 0
        doc: "None" has hash 875832 (0x000D5A38) and instance 0
  asa_name:
    doc: |
      Name reference stored as hash + instance.
      The actual string is looked up in the SaveHeader's name table.
      Hash is computed from the string, instance differentiates duplicates.
    seq:
      - id: name_hash
        type: s4
        doc: Hash value of the name string (looked up in name table)
      - id: name_instance
        type: s4
        doc: Instance number for this name (usually 0)
  asa_string:
    doc: |
      Null-terminated string stored with length prefix.
      Used for object names (not property names).
    seq:
      - id: length
        type: s4
        doc: String length INCLUDING null terminator
      - id: value
        size: length
        type: str
        encoding: ASCII
        if: length > 0
        doc: String bytes with null terminator
