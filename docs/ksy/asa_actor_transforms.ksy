meta:
  id: asa_actor_transforms
  title: ARK Survival Ascended Actor Transforms
  file-extension: bin
  endian: le
doc: |
  The ActorTransforms blob from the 'custom' table.
  Contains location and rotation data for actors in the world.
seq:
  - id: transforms
    type: actor_transform
    repeat: until
    repeat-until: _.actor_id.is_empty
types:
  actor_transform:
    seq:
      - id: actor_id
        size: 16
        type: guid
        doc: GUID of the actor
      - id: location_x
        type: f8
        doc: X coordinate
        if: not actor_id.is_empty
      - id: location_y
        type: f8
        doc: Y coordinate
        if: not actor_id.is_empty
      - id: location_z
        type: f8
        doc: Z coordinate
        if: not actor_id.is_empty
      - id: rotation_w
        type: f8
        doc: Quaternion W component
        if: not actor_id.is_empty
      - id: rotation_x
        type: f8
        doc: Quaternion X component
        if: not actor_id.is_empty
      - id: rotation_y
        type: f8
        doc: Quaternion Y component
        if: not actor_id.is_empty
      - id: rotation_z
        type: f8
        doc: Quaternion Z component
        if: not actor_id.is_empty
  guid:
    seq:
      - id: data
        size: 16
    instances:
      is_empty:
        value: |
          data[0] == 0 and data[1] == 0 and data[2] == 0 and data[3] == 0 and
          data[4] == 0 and data[5] == 0 and data[6] == 0 and data[7] == 0 and
          data[8] == 0 and data[9] == 0 and data[10] == 0 and data[11] == 0 and
          data[12] == 0 and data[13] == 0 and data[14] == 0 and data[15] == 0
