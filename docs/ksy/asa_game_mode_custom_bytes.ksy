meta:
  id: asa_game_mode_custom_bytes
  title: ARK Survival Ascended Game Mode Custom Bytes
  file-extension: bin
  endian: le
doc: |
  The GameModeCustomBytes blob from the 'custom' table.
  Contains tribe and player profile data stored in the save.
seq:
  - id: data_count
    type: s4
    doc: Number of data entries (tribes + profiles)
  - id: entries
    type: data_entry
    repeat: expr
    repeat-expr: data_count
types:
  data_entry:
    seq:
      - id: entry_type
        type: s4
        doc: Type identifier (1 = tribe, 2 = profile)
      - id: data_size
        type: s4
      - id: data
        size: data_size
        type:
          switch-on: entry_type
          cases:
            1: tribe_data
            2: profile_data
  tribe_data:
    doc: Serialized tribe information
    seq:
      - id: tribe_id
        type: s4
      - id: tribe_name
        type: asa_string
      - id: owner_player_data_id
        type: s4
      - id: tribe_members_count
        type: s4
      - id: tribe_members
        type: s4
        repeat: expr
        repeat-expr: tribe_members_count
      - id: tribe_admins_count
        type: s4
      - id: tribe_admins
        type: s4
        repeat: expr
        repeat-expr: tribe_admins_count
      - id: properties
        type: property_list
  profile_data:
    doc: Serialized player profile information
    seq:
      - id: player_data_id
        type: s4
      - id: unique_id
        type: unique_net_id
      - id: player_name
        type: asa_string
      - id: properties
        type: property_list
  property_list:
    doc: List of properties terminated by "None" property
    seq:
      - id: properties
        type: asa_property
        repeat: until
        repeat-until: _.is_none
  asa_property:
    doc: ARK property format
    seq:
      - id: name
        type: asa_string
      - id: type_name
        type: asa_string
        if: not is_none
      - id: size
        type: s4
        if: not is_none
      - id: index
        type: s4
        if: not is_none
      - id: value
        size: size
        if: not is_none
    instances:
      is_none:
        value: name.value == "None"
  unique_net_id:
    seq:
      - id: platform_type
        type: s4
      - id: data_size
        type: s4
      - id: data
        size: data_size
  asa_string:
    seq:
      - id: size
        type: s4
      - id: value
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
