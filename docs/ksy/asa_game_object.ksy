meta:
  id: asa_game_object
  title: ARK Survival Ascended Game Object
  file-extension: bin
  endian: le
doc: |
  Game table key and value format. Both are binary blobs containing serialized game objects.
  Keys contain object identification, values contain object properties and data.
seq:
  - id: objects
    type: game_object
    repeat: eos
types:
  game_object:
    doc: A serialized game object (actor, item, component, etc)
    seq:
      - id: guid
        size: 16
        doc: Unique identifier for this object
      - id: names_count
        type: s4
      - id: names
        type: asa_name
        repeat: expr
        repeat-expr: names_count
      - id: is_item
        type: u1
        doc: Boolean flag indicating if this is an item
      - id: class_name
        type: asa_name
      - id: is_level_transient
        type: u1
        if: is_item == 0
      - id: parent_names_count
        type: s4
        if: is_item == 0
      - id: parent_names
        type: asa_name
        repeat: expr
        repeat-expr: parent_names_count
        if: is_item == 0
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
        type: asa_name
      - id: type_name
        type: asa_name
        if: not is_none
      - id: size
        type: s4
        if: not is_none
      - id: index
        type: s4
        if: not is_none
      - id: value
        size: size
        if: not is_none and size > 0
        doc: Property value data (format depends on type_name)
    instances:
      is_none:
        value: name.value == "None"
  asa_name:
    doc: |
      Name reference. Can be either a string or an index into the name table.
      Format depends on whether save has a name table.
    seq:
      - id: name_index
        type: s4
        doc: Index into name table (or -1 for inline string)
      - id: instance_index
        type: s4
        doc: Instance number for this name
      - id: inline_name
        type: asa_string
        if: name_index == -1
    instances:
      value:
        value: inline_name.value
        if: name_index == -1
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
