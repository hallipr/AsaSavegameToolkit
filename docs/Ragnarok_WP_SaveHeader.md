# File Header

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
00000: 0E 00 0A 02 00 00 F5 03 00 00 25 06 02 00 22 4B
00010: 40 17 8C D7 97 41 12 00 00 00
```

| offset | type |          value h |            value d | description       |
| -----: | ---- | ---------------: | -----------------: | ----------------- |
|      0 | u2   |             0E00 |                 14 | file version      |
|      2 | u4   |         0A020000 |                522 | unknown           |
|      6 | u4   |         F5030000 |               1013 | unknown           |
|      A | u4   |         25060200 |             132645 | name table offset |
|      E | f8   | 224B40178CD79741 | 100000517.81278661 | game time         |
|     16 | u4   |         12000000 |                 18 | unknown           |

# Unknown string table
| offset | type   |           value h |                                      value d | description |
| -----: | ------ | ----------------: | -------------------------------------------: | ----------- |
|     1A | u4     |          95000000 |                                          149 | count       |
|     1E | s4     |          0C000000 |                                           12 | length      |
|     22 | string | 526167 ... 575000 |                                  Ragnarok_WP | value       |
|     2E | ??     |          FFFFFFFF |                                           -1 | unknown     |
|     32 | s4     |          29000000 |                                           41 | length      |
|     36 | string | 526167 ... 344200 |     Ragnarok_WP_MainGrid_L6_X0_Y0_DL54B0FA4B | value       |
|     5F | ??     |          FFFFFFFF |                                           -1 | unknown     |
|    ... | ...    |               ... |                                          ... | ...         |
|   1D43 | s4     |          2D000000 |                                           45 | length      |
|   1D47 | string | 526167 ... 343000 | Ragnarok_WP_MainGrid_L0_X-18_Y-17_DL4D20BA40 | value       |
|   1D74 | ??     |          FFFFFFFF |                                           -1 | unknown     |

# Unknown object table
| offset | type   |           value h |                                      value d | description    |
| -----: | ------ | ----------------: | -------------------------------------------: | -------------- |
|   1D78 | u4     |          98000000 |                                          152 | count          |
|   1D7C | s4     |          2D000000 |                                           45 | length         |
|   1D80 | string | 526167 ... 413800 | Ragnarok_WP_MainGrid_L0_X-18_Y-16_DLCFA08AA8 | value          |
|   1DAD | s4     |          00000000 |                                            0 | property count |
|   1DB1 | s4     |          2D000000 |                                           45 | length         |
|   1DB5 | string | 526167 ... 343000 | Ragnarok_WP_MainGrid_L0_X-17_Y-15_DL4D20BA40 | value          |
|   1DE2 | s4     |          00000000 |                                            0 | property count |
|    ... | ...    |               ... |                                          ... | ...            |
|  202C3 | s4     |          2D000000 |                                           45 | length         |
|  202C7 | string | 526167 ... 343000 | Ragnarok_WP_MainGrid_L0_X-17_Y-17_DL4D20BA40 | value          |
|  202F4 | s4     |          01000000 |                                            1 | property count |

## Ragnarok_WP_MainGrid_L0_X-17_Y-17_DL4D20BA40 properties
```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
202F0:                         02 00 00 00 01 00 00 00
20300: FF FF FF FF 01 00 00 00 FF FF FF FF
```

### DL4D20BA40.0
| offset | type |  value h | value d | description    |
| -----: | ---- | -------: | ------: | -------------- |
|  202F8 | s4   | 02000000 |       2 | property count |

### DL4D20BA40.0.0
| offset | type |  value h | value d | description    |
| -----: | ---- | -------: | ------: | -------------- |
|  202FC | s4   | 01000000 |       1 | property count |

#### DL4D20BA40.0.0.0
| offset | type |  value h | value d | description    |
| -----: | ---- | -------: | ------: | -------------- |
|  20300 | s4   | FFFFFFFF |      -1 | property count |

#### DL4D20BA40.0.1
| offset | type |  value h | value d | description    |
| -----: | ---- | -------: | ------: | -------------- |
|  20304 | s4   | 01000000 |       1 | property count |

#### DL4D20BA40.0.1.0
| offset | type |  value h | value d | description    |
| -----: | ---- | -------: | ------: | -------------- |
|  20308 | s4   | FFFFFFFF |      -1 | property count |

```json
"Ragnarok_WP_MainGrid_L0_X-17_Y-17_DL4D20BA40": {
  "0": [{   // 1
    "0.0": [{   // 2
      "0.0.0": [{  // 1
        "0.0.0.0": [] // -1
      }]
    },
    { 
      "0.0.1": [{  // 1
        "0.0.1.0": [] // -1
      }]
    }]
  }]
}
```

# ... unknown object table
| offset | type   |           value h |                                      value d | description    |
| -----: | ------ | ----------------: | -------------------------------------------: | -------------- |
|  2030C | s4     |          2D000000 |                                           45 | length         |
|  20310 | string | 526167 ... 343000 | Ragnarok_WP_MainGrid_L0_X-15_Y-15_DL4D20BA40 | value          |
|  2033D | s4     |          00000000 |                                            0 | property count |
|    ... | ...    |               ... |                                          ... | ...            |
|  205EC | s4     |          2D000000 |                                           45 | length         |
|  205F0 | string | 526167 ... 413800 | Ragnarok_WP_MainGrid_L0_X-15_Y-14_DLCFA08AA8 | value          |
|  2061D | s4     |          00000000 |                                            0 | property count |

# Unknown
| offset | type |  value h | value d | description |
| -----: | ---- | -------: | ------: | ----------- |
|  20621 | ??   | 00000000 |       0 | unknown     |

# Name Table
| offset | type |  value h | value d | description |
| -----: | ---- | -------: | ------: | ----------- |
|  20625 | u4   | 63020000 |     611 | count       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20620:                            E9 33 1E 37 4A 00 00
20630: 00 2F 47 61 6D 65 2F 4D 6F 64 73 2F 52 61 67 6E
20640: 61 72 6F 6B 2F 52 61 67 6E 61 72 6F 6B 5F 57 50
20650: 2E 52 61 67 6E 61 72 6F 6B 5F 57 50 3A 50 65 72
20660: 73 69 73 74 65 6E 74 4C 65 76 65 6C 2E 4E 50 43
20670: 5A 6F 6E 65 56 6F 6C 75 6D 65 00
```

| offset | type   |           value h |                                                                   value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------: | ----------- |
|  20629 | u4     |          E9331E37 |                                                                 924726249 | index       |
|  2062D | s4     |          4A000000 |                                                                        74 | length      |
|  20631 | string | 2F4761 ... 6D6500 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneVolume | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20670:                                  88 C5 B8 D4 4E
20680: 00 00 00 2F 47 61 6D 65 2F 4D 6F 64 73 2F 52 61
20690: 67 6E 61 72 6F 6B 2F 52 61 67 6E 61 72 6F 6B 5F
206A0: 57 50 2E 52 61 67 6E 61 72 6F 6B 5F 57 50 3A 50

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
206B0: 65 72 73 69 73 74 65 6E 74 4C 65 76 65 6C 2E 4E
206C0: 50 43 5A 6F 6E 65 4D 61 6E 61 67 65 72 35 31 34
206D0: 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  2067B | u4     |          88C5B8D4 |                                                                    3568878984 | index       |
|  2067F | s4     |          4E000000 |                                                                            78 | length      |
|  20683 | string | 2F4761 ... 313400 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager514 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
206D0:    40 36 6F 29 4F 00 00 00 2F 47 61 6D 65 2F 50
206E0: 72 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73
206F0: 2F 44 69 72 65 77 6F 6C 66 2F 44 69 72 65 77 6F
20700: 6C 66 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E
20710: 44 69 72 65 77 6F 6C 66 5F 43 68 61 72 61 63 74
20720: 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------: | ----------- |
|  206D1 | u4     |          40366F29 |                                                                      695154240 | index       |
|  206D5 | s4     |          4F000000 |                                                                             79 | length      |
|  206D9 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Direwolf/Direwolf_Character_BP.Direwolf_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20720:                         22 26 AD 09 05 00 00 00
20730: 4E 6F 6E 65 00
```

| offset | type   |    value h |   value d | description |
| -----: | ------ | ---------: | --------: | ----------- |
|  20728 | u4     |   2226AD09 | 162342434 | index       |
|  2072C | s4     |   05000000 |         5 | length      |
|  20730 | string | 4E6F6E6500 |      None | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20730:                DF 29 DF 06 43 00 00 00 2F 47 61
20740: 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 44
20750: 69 6E 6F 73 2F 53 74 61 67 2F 53 74 61 67 5F 43
20760: 68 61 72 61 63 74 65 72 5F 42 50 2E 53 74 61 67
20770: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------: | ----------- |
|  20735 | u4     |          DF29DF06 |                                                          115288543 | index       |
|  20739 | s4     |          43000000 |                                                                 67 | length      |
|  2073D | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Stag/Stag_Character_BP.Stag_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20780: EE D9 C5 77 4E 00 00 00 2F 47 61 6D 65 2F 4D 6F
20790: 64 73 2F 52 61 67 6E 61 72 6F 6B 2F 52 61 67 6E
207A0: 61 72 6F 6B 5F 57 50 2E 52 61 67 6E 61 72 6F 6B
207B0: 5F 57 50 3A 50 65 72 73 69 73 74 65 6E 74 4C 65
207C0: 76 65 6C 2E 4E 50 43 5A 6F 6E 65 4D 61 6E 61 67
207D0: 65 72 35 31 35 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  20780 | u4     |          EED9C577 |                                                                    2009455086 | index       |
|  20784 | s4     |          4E000000 |                                                                            78 | length      |
|  20788 | string | 2F4761 ... 313500 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager515 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
207D0:                   89 18 B3 9A 4D 00 00 00 2F 47
207E0: 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F
207F0: 44 69 6E 6F 73 2F 41 72 67 65 6E 74 61 76 69 73
20800: 2F 41 72 67 65 6E 74 5F 43 68 61 72 61 63 74 65
20810: 72 5F 42 50 2E 41 72 67 65 6E 74 5F 43 68 61 72
20820: 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------: | ----------- |
|  207D6 | u4     |          8918B39A |                                                                   2595428489 | index       |
|  207DA | s4     |          4D000000 |                                                                           77 | length      |
|  207DE | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Argentavis/Argent_Character_BP.Argent_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20820:                                  49 3E 7F C2 4E
20830: 00 00 00 2F 47 61 6D 65 2F 4D 6F 64 73 2F 52 61
20840: 67 6E 61 72 6F 6B 2F 52 61 67 6E 61 72 6F 6B 5F
20850: 57 50 2E 52 61 67 6E 61 72 6F 6B 5F 57 50 3A 50
20860: 65 72 73 69 73 74 65 6E 74 4C 65 76 65 6C 2E 4E
20870: 50 43 5A 6F 6E 65 4D 61 6E 61 67 65 72 37 36 35
20880: 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  2082B | u4     |          493E7FC2 |                                                                    3263118921 | index       |
|  2082F | s4     |          4E000000 |                                                                            78 | length      |
|  20833 | string | 2F4761 ... 363500 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager765 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20880:    63 FE BA E8 4B 00 00 00 2F 47 61 6D 65 2F 50
20890: 72 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73
208A0: 2F 47 61 6C 6C 69 6D 69 6D 75 73 2F 47 61 6C 6C
208B0: 69 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E 47
208C0: 61 6C 6C 69 5F 43 68 61 72 61 63 74 65 72 5F 42
208D0: 50 5F 43 00
```

| offset | type   |           value h |                                                                    value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------: | ----------- |
|  20881 | u4     |          63FEBAE8 |                                                                 3904568931 | index       |
|  20885 | s4     |          4B000000 |                                                                         75 | length      |
|  20889 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Gallimimus/Galli_Character_BP.Galli_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
208D0:             C1 50 6F 7D 4B 00 00 00 2F 47 61 6D
208E0: 65 2F 4D 6F 64 73 2F 52 61 67 6E 61 72 6F 6B 2F
208F0: 52 61 67 6E 61 72 6F 6B 5F 57 50 2E 52 61 67 6E
20900: 61 72 6F 6B 5F 57 50 3A 50 65 72 73 69 73 74 65
20910: 6E 74 4C 65 76 65 6C 2E 4E 50 43 5A 6F 6E 65 4D
20920: 61 6E 61 67 65 72 00
```

| offset | type   |           value h |                                                                    value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------: | ----------- |
|  208D4 | u4     |          C1506F7D |                                                                 2104447169 | index       |
|  208D8 | s4     |          4B000000 |                                                                         75 | length      |
|  208DC | string | 2F4761 ... 657200 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20920:                      17 A7 47 B2 4C 00 00 00 2F
20930: 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68
20940: 2F 44 69 6E 6F 73 2F 57 6F 6F 6C 6C 79 52 68 69
20950: 6E 6F 2F 52 68 69 6E 6F 5F 43 68 61 72 61 63 74
20960: 65 72 5F 42 50 2E 52 68 69 6E 6F 5F 43 68 61 72
20970: 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  20927 | u4     |          17A747B2 |                                                                  2991040279 | index       |
|  2092B | s4     |          4C000000 |                                                                          76 | length      |
|  2092F | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/WoollyRhino/Rhino_Character_BP.Rhino_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20970:                                  F3 DE 07 F6 4F
20980: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
20990: 61 72 74 68 2F 44 69 6E 6F 73 2F 44 69 72 65 62
209A0: 65 61 72 2F 44 69 72 65 62 65 61 72 5F 43 68 61
209B0: 72 61 63 74 65 72 5F 42 50 2E 44 69 72 65 62 65
209C0: 61 72 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F
209D0: 43 00
```

| offset | type   |           value h |                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------: | ----------- |
|  2097B | u4     |          F3DE07F6 |                                                                     4127710963 | index       |
|  2097F | s4     |          4F000000 |                                                                             79 | length      |
|  20983 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Direbear/Direbear_Character_BP.Direbear_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
209D0:       99 18 22 CD 4C 00 00 00 2F 47 61 6D 65 2F
209E0: 50 72 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F
209F0: 73 2F 54 72 6F 6F 64 6F 6E 2F 54 72 6F 6F 64 6F
20A00: 6E 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E 54
20A10: 72 6F 6F 64 6F 6E 5F 43 68 61 72 61 63 74 65 72
20A20: 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  209D2 | u4     |          991822CD |                                                                  3441563801 | index       |
|  209D6 | s4     |          4C000000 |                                                                          76 | length      |
|  209DA | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Troodon/Troodon_Character_BP.Troodon_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20A20:                   1D 46 0E FA 40 00 00 00 2F 47
20A30: 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F
20A40: 44 69 6E 6F 73 2F 41 6E 74 2F 41 6E 74 5F 43 68
20A50: 61 72 61 63 74 65 72 5F 42 50 2E 41 6E 74 5F 43
20A60: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                         value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------: | ----------- |
|  20A26 | u4     |          1D460EFA |                                                      4195239453 | index       |
|  20A2A | s4     |          40000000 |                                                              64 | length      |
|  20A2E | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Ant/Ant_Character_BP.Ant_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20A60:                                           8A 4C
20A70: CD ED 58 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D
20A80: 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 4D 65
20A90: 67 61 74 68 65 72 69 75 6D 2F 4D 65 67 61 74 68
20AA0: 65 72 69 75 6D 5F 43 68 61 72 61 63 74 65 72 5F
20AB0: 42 50 2E 4D 65 67 61 74 68 65 72 69 75 6D 5F 43
20AC0: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                                 value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------: | ----------- |
|  20A6E | u4     |          8A4CCDED |                                                                              3989654666 | index       |
|  20A72 | s4     |          58000000 |                                                                                      88 | length      |
|  20A76 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Megatherium/Megatherium_Character_BP.Megatherium_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20AC0:                                           E7 08
20AD0: 3E CB 63 00 00 00 2F 47 61 6D 65 2F 4D 6F 64 73
20AE0: 2F 52 61 67 6E 61 72 6F 6B 2F 52 61 67 6E 61 72
20AF0: 6F 6B 5F 57 50 2E 52 61 67 6E 61 72 6F 6B 5F 57
20B00: 50 3A 50 65 72 73 69 73 74 65 6E 74 4C 65 76 65
20B10: 6C 2E 4E 50 43 5A 6F 6E 65 4D 61 6E 61 67 65 72
20B20: 5F 55 41 49 44 5F 35 38 31 31 32 32 41 30 46 45
20B30: 31 34 43 44 37 34 30 32 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  20ACE | u4     |          E7083ECB |                                                                                         3409840359 | index       |
|  20AD2 | s4     |          63000000 |                                                                                                 99 | length      |
|  20AD6 | string | 2F4761 ... 303200 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager_UAID_581122A0FE14CD7402 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20B30:                            8F 7C D2 FE 56 00 00
20B40: 00 2F 47 61 6D 65 2F 41 53 41 2F 44 69 6E 6F 73
20B50: 2F 47 69 67 61 6E 74 6F 72 61 70 74 6F 72 2F 47
20B60: 69 67 61 6E 74 6F 72 61 70 74 6F 72 5F 43 68 61
20B70: 72 61 63 74 65 72 5F 42 50 2E 47 69 67 61 6E 74
20B80: 6F 72 61 70 74 6F 72 5F 43 68 61 72 61 63 74 65
20B90: 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  20B39 | u4     |          8F7CD2FE |                                                                            4275207311 | index       |
|  20B3D | s4     |          56000000 |                                                                                    86 | length      |
|  20B41 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/Gigantoraptor/Gigantoraptor_Character_BP.Gigantoraptor_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20B90:                      76 82 8F 06 63 00 00 00 2F
20BA0: 47 61 6D 65 2F 4D 6F 64 73 2F 52 61 67 6E 61 72
20BB0: 6F 6B 2F 52 61 67 6E 61 72 6F 6B 5F 57 50 2E 52
20BC0: 61 67 6E 61 72 6F 6B 5F 57 50 3A 50 65 72 73 69
20BD0: 73 74 65 6E 74 4C 65 76 65 6C 2E 4E 50 43 5A 6F
20BE0: 6E 65 4D 61 6E 61 67 65 72 5F 55 41 49 44 5F 37
20BF0: 43 31 30 43 39 35 45 37 44 34 30 30 43 37 33 30
20C00: 32 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  20B97 | u4     |          76828F06 |                                                                                          110068342 | index       |
|  20B9B | s4     |          63000000 |                                                                                                 99 | length      |
|  20B9F | string | 2F4761 ... 303200 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager_UAID_7C10C95E7D400C7302 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20C00:       44 CE 7F 57 4C 00 00 00 2F 47 61 6D 65 2F
20C10: 41 53 41 2F 44 69 6E 6F 73 2F 49 63 65 57 79 76
20C20: 65 72 6E 2F 57 79 76 65 72 6E 5F 43 68 61 72 61
20C30: 63 74 65 72 5F 42 50 5F 49 63 65 2E 57 79 76 65
20C40: 72 6E 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F
20C50: 49 63 65 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  20C02 | u4     |          44CE7F57 |                                                                  1467993668 | index       |
|  20C06 | s4     |          4C000000 |                                                                          76 | length      |
|  20C0A | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/IceWyvern/Wyvern_Character_BP_Ice.Wyvern_Character_BP_Ice_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20C50:                   EB C1 12 C3 63 00 00 00 2F 47
20C60: 61 6D 65 2F 4D 6F 64 73 2F 52 61 67 6E 61 72 6F
20C70: 6B 2F 52 61 67 6E 61 72 6F 6B 5F 57 50 2E 52 61
20C80: 67 6E 61 72 6F 6B 5F 57 50 3A 50 65 72 73 69 73
20C90: 74 65 6E 74 4C 65 76 65 6C 2E 4E 50 43 5A 6F 6E
20CA0: 65 4D 61 6E 61 67 65 72 5F 55 41 49 44 5F 42 30
20CB0: 36 45 42 46 43 36 30 45 38 30 42 33 37 31 30 32
20CC0: 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  20C56 | u4     |          EBC112C3 |                                                                                         3272786411 | index       |
|  20C5A | s4     |          63000000 |                                                                                                 99 | length      |
|  20C5E | string | 2F4761 ... 303200 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager_UAID_B06EBFC60E80B37102 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20CC0:    B4 04 85 7A 50 00 00 00 2F 47 61 6D 65 2F 41
20CD0: 53 41 2F 44 69 6E 6F 73 2F 44 61 72 6B 50 65 67
20CE0: 61 73 75 73 2F 44 61 72 6B 50 65 67 61 73 75 73

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20CF0: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E 44 61
20D00: 72 6B 50 65 67 61 73 75 73 5F 43 68 61 72 61 63
20D10: 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  20CC1 | u4     |          B404857A |                                                                      2055537844 | index       |
|  20CC5 | s4     |          50000000 |                                                                              80 | length      |
|  20CC9 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/DarkPegasus/DarkPegasus_Character_BP.DarkPegasus_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20D10:                            9B 17 A2 E6 59 00 00
20D20: 00 2F 47 61 6D 65 2F 4D 6F 64 73 2F 52 61 67 6E
20D30: 61 72 6F 6B 2F 52 61 67 6E 61 72 6F 6B 5F 57 50
20D40: 2E 52 61 67 6E 61 72 6F 6B 5F 57 50 3A 50 65 72
20D50: 73 69 73 74 65 6E 74 4C 65 76 65 6C 2E 4E 50 43
20D60: 5A 6F 6E 65 4D 61 6E 61 67 65 72 42 6C 75 65 70
20D70: 72 69 6E 74 5F 4C 61 6E 64 00
```

| offset | type   |           value h |                                                                                  value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------: | ----------- |
|  20D19 | u4     |          9B17A2E6 |                                                                               3869382555 | index       |
|  20D1D | s4     |          59000000 |                                                                                       89 | length      |
|  20D21 | string | 2F4761 ... 6E6400 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManagerBlueprint_Land | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20D70:                               07 C6 63 67 4F 00
20D80: 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61
20D90: 72 74 68 2F 44 69 6E 6F 73 2F 51 75 65 74 7A 61
20DA0: 6C 63 6F 61 74 6C 75 73 2F 51 75 65 74 7A 5F 43
20DB0: 68 61 72 61 63 74 65 72 5F 42 50 2E 51 75 65 74
20DC0: 7A 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43
20DD0: 00
```

| offset | type   |           value h |                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------: | ----------- |
|  20D7A | u4     |          07C66367 |                                                                     1734592007 | index       |
|  20D7E | s4     |          4F000000 |                                                                             79 | length      |
|  20D82 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Quetzalcoatlus/Quetz_Character_BP.Quetz_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20DD0:    5E 3A 33 F9 55 00 00 00 2F 47 61 6D 65 2F 50
20DE0: 72 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73
20DF0: 2F 74 69 74 61 6E 6F 73 61 75 72 2F 54 69 74 61
20E00: 6E 6F 73 61 75 72 5F 43 68 61 72 61 63 74 65 72
20E10: 5F 42 50 2E 54 69 74 61 6E 6F 73 61 75 72 5F 43
20E20: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  20DD1 | u4     |          5E3A33F9 |                                                                           4180884062 | index       |
|  20DD5 | s4     |          55000000 |                                                                                   85 | length      |
|  20DD9 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/titanosaur/Titanosaur_Character_BP.Titanosaur_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20E20:                                           C1 F7
20E30: F0 BB 5B 00 00 00 2F 47 61 6D 65 2F 4D 6F 64 73
20E40: 2F 52 61 67 6E 61 72 6F 6B 2F 52 61 67 6E 61 72
20E50: 6F 6B 5F 57 50 2E 52 61 67 6E 61 72 6F 6B 5F 57
20E60: 50 3A 50 65 72 73 69 73 74 65 6E 74 4C 65 76 65
20E70: 6C 2E 4E 50 43 5A 6F 6E 65 4D 61 6E 61 67 65 72
20E80: 42 6C 75 65 70 72 69 6E 74 5F 4C 61 6E 64 5F 43
20E90: 00
```

| offset | type   |           value h |                                                                                    value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------: | ----------- |
|  20E2E | u4     |          C1F7F0BB |                                                                                 3153131457 | index       |
|  20E32 | s4     |          5B000000 |                                                                                         91 | length      |
|  20E36 | string | 2F4761 ... 5F4300 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManagerBlueprint_Land_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20E90:    A3 90 67 9A 55 00 00 00 2F 47 61 6D 65 2F 50
20EA0: 72 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73
20EB0: 2F 54 68 79 6C 61 63 6F 6C 65 6F 2F 54 68 79 6C
20EC0: 61 63 6F 6C 65 6F 5F 43 68 61 72 61 63 74 65 72
20ED0: 5F 42 50 2E 54 68 79 6C 61 63 6F 6C 65 6F 5F 43
20EE0: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  20E91 | u4     |          A390679A |                                                                           2590478499 | index       |
|  20E95 | s4     |          55000000 |                                                                                   85 | length      |
|  20E99 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Thylacoleo/Thylacoleo_Character_BP.Thylacoleo_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20EE0:                                           5F 94
20EF0: CC BA 73 00 00 00 2F 47 61 6D 65 2F 4D 6F 64 73
20F00: 2F 52 61 67 6E 61 72 6F 6B 2F 52 61 67 6E 61 72
20F10: 6F 6B 5F 57 50 2E 52 61 67 6E 61 72 6F 6B 5F 57
20F20: 50 3A 50 65 72 73 69 73 74 65 6E 74 4C 65 76 65
20F30: 6C 2E 4E 50 43 5A 6F 6E 65 4D 61 6E 61 67 65 72
20F40: 42 6C 75 65 70 72 69 6E 74 5F 4C 61 6E 64 5F 43
20F50: 5F 55 41 49 44 5F 35 38 31 31 32 32 41 30 46 45
20F60: 31 34 38 42 36 46 30 32 00
```

| offset | type   |           value h |                                                                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------: | ----------- |
|  20EEE | u4     |          5F94CCBA |                                                                                                         3133969503 | index       |
|  20EF2 | s4     |          73000000 |                                                                                                                115 | length      |
|  20EF6 | string | 2F4761 ... 303200 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManagerBlueprint_Land_C_UAID_581122A0FE148B6F02 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20F60:                            4F 2C DF E4 3E 00 00
20F70: 00 2F 47 61 6D 65 2F 41 53 41 2F 44 69 6E 6F 73
20F80: 2F 42 69 73 6F 6E 2F 42 69 73 6F 6E 5F 43 68 61
20F90: 72 61 63 74 65 72 5F 42 50 2E 42 69 73 6F 6E 5F
20FA0: 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                       value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------: | ----------- |
|  20F69 | u4     |          4F2CDFE4 |                                                    3839831119 | index       |
|  20F6D | s4     |          3E000000 |                                                            62 | length      |
|  20F71 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/Bison/Bison_Character_BP.Bison_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
20FA0:                                              1C
20FB0: BC 49 FF 71 00 00 00 2F 47 61 6D 65 2F 4D 6F 64
20FC0: 73 2F 52 61 67 6E 61 72 6F 6B 2F 52 61 67 6E 61
20FD0: 72 6F 6B 5F 57 50 2E 52 61 67 6E 61 72 6F 6B 5F
20FE0: 57 50 3A 50 65 72 73 69 73 74 65 6E 74 4C 65 76
20FF0: 65 6C 2E 4E 50 43 5A 6F 6E 65 4D 61 6E 61 67 65
21000: 72 42 6C 75 65 70 72 69 6E 74 5F 4C 61 6E 64 5F
21010: 55 41 49 44 5F 35 38 31 31 32 32 41 30 46 45 31
21020: 34 44 31 36 45 30 32 00
```

| offset | type   |           value h |                                                                                                          value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------: | ----------- |
|  20FAF | u4     |          1CBC49FF |                                                                                                       4283022364 | index       |
|  20FB3 | s4     |          71000000 |                                                                                                              113 | length      |
|  20FB7 | string | 2F4761 ... 303200 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManagerBlueprint_Land_UAID_581122A0FE14D16E02 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21020:                         6C 20 7E AA 56 00 00 00
21030: 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74
21040: 68 2F 44 69 6E 6F 73 2F 45 71 75 75 73 2F 45 71
21050: 75 75 73 5F 43 68 61 72 61 63 74 65 72 5F 42 50
21060: 5F 55 6E 69 63 6F 72 6E 2E 45 71 75 75 73 5F 43
21070: 68 61 72 61 63 74 65 72 5F 42 50 5F 55 6E 69 63
21080: 6F 72 6E 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  21028 | u4     |          6C207EAA |                                                                            2860392556 | index       |
|  2102C | s4     |          56000000 |                                                                                    86 | length      |
|  21030 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Equus/Equus_Character_BP_Unicorn.Equus_Character_BP_Unicorn_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21080:                   67 A7 81 7C 4E 00 00 00 2F 47
21090: 61 6D 65 2F 4D 6F 64 73 2F 52 61 67 6E 61 72 6F
210A0: 6B 2F 52 61 67 6E 61 72 6F 6B 5F 57 50 2E 52 61
210B0: 67 6E 61 72 6F 6B 5F 57 50 3A 50 65 72 73 69 73
210C0: 74 65 6E 74 4C 65 76 65 6C 2E 4E 50 43 5A 6F 6E
210D0: 65 4D 61 6E 61 67 65 72 35 32 34 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  21086 | u4     |          67A7817C |                                                                    2088871783 | index       |
|  2108A | s4     |          4E000000 |                                                                            78 | length      |
|  2108E | string | 2F4761 ... 323400 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager524 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
210D0:                                     01 08 E2 5F
210E0: 4C 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
210F0: 45 61 72 74 68 2F 44 69 6E 6F 73 2F 4D 61 6D 6D
21100: 6F 74 68 2F 4D 61 6D 6D 6F 74 68 5F 43 68 61 72
21110: 61 63 74 65 72 5F 42 50 2E 4D 61 6D 6D 6F 74 68
21120: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  210DC | u4     |          0108E25F |                                                                  1608648705 | index       |
|  210E0 | s4     |          4C000000 |                                                                          76 | length      |
|  210E4 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Mammoth/Mammoth_Character_BP.Mammoth_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21130: 11 9B B6 D4 67 00 00 00 2F 47 61 6D 65 2F 41 53
21140: 41 2F 44 69 6E 6F 73 2F 53 68 6F 75 6C 64 65 72
21150: 44 72 61 67 6F 6E 2F 53 68 6F 75 6C 64 65 72 44
21160: 72 61 67 6F 6E 5F 43 68 61 72 61 63 74 65 72 5F
21170: 42 50 5F 57 69 6E 74 65 72 2E 53 68 6F 75 6C 64
21180: 65 72 44 72 61 67 6F 6E 5F 43 68 61 72 61 63 74
21190: 65 72 5F 42 50 5F 57 69 6E 74 65 72 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  21130 | u4     |          119BB6D4 |                                                                                             3568737041 | index       |
|  21134 | s4     |          67000000 |                                                                                                    103 | length      |
|  21138 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/ShoulderDragon/ShoulderDragon_Character_BP_Winter.ShoulderDragon_Character_BP_Winter_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21190:                                              CC
211A0: 97 B4 1D 55 00 00 00 2F 47 61 6D 65 2F 50 72 69
211B0: 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 54
211C0: 65 72 72 6F 72 42 69 72 64 2F 54 65 72 72 6F 72
211D0: 42 69 72 64 5F 43 68 61 72 61 63 74 65 72 5F 42
211E0: 50 2E 54 65 72 72 6F 72 42 69 72 64 5F 43 68 61
211F0: 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  2119F | u4     |          CC97B41D |                                                                            498374604 | index       |
|  211A3 | s4     |          55000000 |                                                                                   85 | length      |
|  211A7 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/TerrorBird/TerrorBird_Character_BP.TerrorBird_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
211F0:                                     32 65 15 25
21200: 4C 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
21210: 45 61 72 74 68 2F 44 69 6E 6F 73 2F 41 6E 74 2F
21220: 46 6C 79 69 6E 67 41 6E 74 5F 43 68 61 72 61 63
21230: 74 65 72 5F 42 50 2E 46 6C 79 69 6E 67 41 6E 74
21240: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  211FC | u4     |          32651525 |                                                                   622159154 | index       |
|  21200 | s4     |          4C000000 |                                                                          76 | length      |
|  21204 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Ant/FlyingAnt_Character_BP.FlyingAnt_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21250: FA 3D AD 79 46 00 00 00 2F 47 61 6D 65 2F 50 72
21260: 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F
21270: 50 74 65 72 6F 2F 50 74 65 72 6F 5F 43 68 61 72
21280: 61 63 74 65 72 5F 42 50 2E 50 74 65 72 6F 5F 43
21290: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                               value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------: | ----------- |
|  21250 | u4     |          FA3DAD79 |                                                            2041396730 | index       |
|  21254 | s4     |          46000000 |                                                                    70 | length      |
|  21258 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Ptero/Ptero_Character_BP.Ptero_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21290:                                           F5 2B
212A0: 58 27 67 00 00 00 2F 47 61 6D 65 2F 41 53 41 2F
212B0: 44 69 6E 6F 73 2F 53 68 6F 75 6C 64 65 72 44 72
212C0: 61 67 6F 6E 2F 53 68 6F 75 6C 64 65 72 44 72 61
212D0: 67 6F 6E 5F 43 68 61 72 61 63 74 65 72 5F 42 50
212E0: 5F 41 75 74 75 6D 6E 2E 53 68 6F 75 6C 64 65 72
212F0: 44 72 61 67 6F 6E 5F 43 68 61 72 61 63 74 65 72
21300: 5F 42 50 5F 41 75 74 75 6D 6E 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  2129E | u4     |          F52B5827 |                                                                                              660089845 | index       |
|  212A2 | s4     |          67000000 |                                                                                                    103 | length      |
|  212A6 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/ShoulderDragon/ShoulderDragon_Character_BP_Autumn.ShoulderDragon_Character_BP_Autumn_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21300:                                        21 8A 64
21310: 13 4D 00 00 00 2F 47 61 6D 65 2F 41 53 41 2F 44
21320: 69 6E 6F 73 2F 53 70 69 72 69 74 42 65 61 72 2F

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21330: 53 70 69 72 69 74 42 65 61 72 5F 43 68 61 72 61
21340: 63 74 65 72 5F 42 50 2E 53 70 69 72 69 74 42 65
21350: 61 72 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F
21360: 43 00
```

| offset | type   |           value h |                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------: | ----------- |
|  2130D | u4     |          218A6413 |                                                                    325356065 | index       |
|  21311 | s4     |          4D000000 |                                                                           77 | length      |
|  21315 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/SpiritBear/SpiritBear_Character_BP.SpiritBear_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21360:       ED 5D 77 10 67 00 00 00 2F 47 61 6D 65 2F
21370: 41 53 41 2F 44 69 6E 6F 73 2F 53 68 6F 75 6C 64
21380: 65 72 44 72 61 67 6F 6E 2F 53 68 6F 75 6C 64 65
21390: 72 44 72 61 67 6F 6E 5F 43 68 61 72 61 63 74 65
213A0: 72 5F 42 50 5F 53 75 6D 6D 65 72 2E 53 68 6F 75
213B0: 6C 64 65 72 44 72 61 67 6F 6E 5F 43 68 61 72 61
213C0: 63 74 65 72 5F 42 50 5F 53 75 6D 6D 65 72 5F 43
213D0: 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  21362 | u4     |          ED5D7710 |                                                                                              276258285 | index       |
|  21366 | s4     |          67000000 |                                                                                                    103 | length      |
|  2136A | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/ShoulderDragon/ShoulderDragon_Character_BP_Summer.ShoulderDragon_Character_BP_Summer_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
213D0:    4D 22 DA 53 54 00 00 00 2F 47 61 6D 65 2F 53
213E0: 63 6F 72 63 68 65 64 45 61 72 74 68 2F 44 69 6E
213F0: 6F 73 2F 52 6F 63 6B 47 6F 6C 65 6D 2F 52 6F 63
21400: 6B 47 6F 6C 65 6D 5F 43 68 61 72 61 63 74 65 72
21410: 5F 42 50 2E 52 6F 63 6B 47 6F 6C 65 6D 5F 43 68
21420: 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                             value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------: | ----------- |
|  213D1 | u4     |          4D22DA53 |                                                                          1406804557 | index       |
|  213D5 | s4     |          54000000 |                                                                                  84 | length      |
|  213D9 | string | 2F4761 ... 5F4300 | /Game/ScorchedEarth/Dinos/RockGolem/RockGolem_Character_BP.RockGolem_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21420:                                        7F 97 93
21430: DC 51 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61
21440: 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 47 69 67
21450: 61 6E 6F 74 6F 73 61 75 72 75 73 2F 47 69 67 61
21460: 6E 74 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E
21470: 47 69 67 61 6E 74 5F 43 68 61 72 61 63 74 65 72
21480: 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                          value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------: | ----------- |
|  2142D | u4     |          7F9793DC |                                                                       3700660095 | index       |
|  21431 | s4     |          51000000 |                                                                               81 | length      |
|  21435 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Giganotosaurus/Gigant_Character_BP.Gigant_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21480:                   A6 57 27 D5 5F 00 00 00 2F 47
21490: 61 6D 65 2F 41 53 41 2F 44 69 6E 6F 73 2F 44 65
214A0: 69 6E 6F 74 68 65 72 69 75 6D 2F 44 69 6E 6F 73
214B0: 2F 44 65 69 6E 6F 74 68 65 72 69 75 6D 41 53 41
214C0: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E 44 65
214D0: 69 6E 6F 74 68 65 72 69 75 6D 41 53 41 5F 43 68
214E0: 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                                        value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------: | ----------- |
|  21486 | u4     |          A65727D5 |                                                                                     3576125350 | index       |
|  2148A | s4     |          5F000000 |                                                                                             95 | length      |
|  2148E | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/Deinotherium/Dinos/DeinotheriumASA_Character_BP.DeinotheriumASA_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
214E0:                                        9F 1B DE
214F0: BD 50 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61
21500: 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 44 69 6D
21510: 6F 72 70 68 6F 64 6F 6E 2F 44 69 6D 6F 72 70 68
21520: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E 44 69
21530: 6D 6F 72 70 68 5F 43 68 61 72 61 63 74 65 72 5F
21540: 42 50 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  214ED | u4     |          9F1BDEBD |                                                                      3185449887 | index       |
|  214F1 | s4     |          50000000 |                                                                              80 | length      |
|  214F5 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Dimorphodon/Dimorph_Character_BP.Dimorph_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21540:                A9 9B BD D8 61 00 00 00 2F 47 61
21550: 6D 65 2F 41 53 41 2F 44 69 6E 6F 73 2F 43 65 72
21560: 61 74 6F 73 61 75 72 75 73 2F 44 69 6E 6F 73 2F
21570: 43 65 72 61 74 6F 73 61 75 72 75 73 5F 43 68 61
21580: 72 61 63 74 65 72 5F 42 50 5F 41 53 41 2E 43 65
21590: 72 61 74 6F 73 61 75 72 75 73 5F 43 68 61 72 61
215A0: 63 74 65 72 5F 42 50 5F 41 53 41 5F 43 00
```

| offset | type   |           value h |                                                                                          value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------: | ----------- |
|  21545 | u4     |          A99BBDD8 |                                                                                       3636304809 | index       |
|  21549 | s4     |          61000000 |                                                                                               97 | length      |
|  2154D | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/Ceratosaurus/Dinos/Ceratosaurus_Character_BP_ASA.Ceratosaurus_Character_BP_ASA_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
215A0:                                           D6 30
215B0: 3F 92 49 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D
215C0: 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 43 6F
215D0: 65 6C 61 63 61 6E 74 68 2F 43 6F 65 6C 5F 43 68
215E0: 61 72 61 63 74 65 72 5F 42 50 2E 43 6F 65 6C 5F
215F0: 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------: | ----------- |
|  215AE | u4     |          D6303F92 |                                                               2453614806 | index       |
|  215B2 | s4     |          49000000 |                                                                       73 | length      |
|  215B6 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Coelacanth/Coel_Character_BP.Coel_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
215F0:                                              1D
21600: F0 D1 E9 49 00 00 00 2F 47 61 6D 65 2F 50 72 69
21610: 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 50
21620: 65 6C 61 67 6F 72 6E 69 73 2F 50 65 6C 61 5F 43
21630: 68 61 72 61 63 74 65 72 5F 42 50 2E 50 65 6C 61
21640: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------: | ----------- |
|  215FF | u4     |          1DF0D1E9 |                                                               3922849821 | index       |
|  21603 | s4     |          49000000 |                                                                       73 | length      |
|  21607 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Pelagornis/Pela_Character_BP.Pela_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21650: B4 D7 23 50 55 00 00 00 2F 47 61 6D 65 2F 50 72
21660: 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F
21670: 50 6C 65 73 69 6F 73 61 75 72 2F 50 6C 65 73 69
21680: 6F 73 61 75 72 5F 43 68 61 72 61 63 74 65 72 5F
21690: 42 50 2E 50 6C 65 73 69 6F 73 61 75 72 5F 43 68
216A0: 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  21650 | u4     |          B4D72350 |                                                                           1344526260 | index       |
|  21654 | s4     |          55000000 |                                                                                   85 | length      |
|  21658 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Plesiosaur/Plesiosaur_Character_BP.Plesiosaur_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
216A0:                                        74 59 B0
216B0: BC 49 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61
216C0: 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 4D 6F 73
216D0: 61 73 61 75 72 75 73 2F 4D 6F 73 61 5F 43 68 61
216E0: 72 61 63 74 65 72 5F 42 50 2E 4D 6F 73 61 5F 43
216F0: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------: | ----------- |
|  216AD | u4     |          7459B0BC |                                                               3165673844 | index       |
|  216B1 | s4     |          49000000 |                                                                       73 | length      |
|  216B5 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Mosasaurus/Mosa_Character_BP.Mosa_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
216F0:                                           9F 3E
21700: 97 DA 53 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D
21710: 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 4D 6F
21720: 73 61 73 61 75 72 75 73 2F 4D 6F 73 61 5F 43 68
21730: 61 72 61 63 74 65 72 5F 42 50 5F 4D 65 67 61 2E
21740: 4D 6F 73 61 5F 43 68 61 72 61 63 74 65 72 5F 42
21750: 50 5F 4D 65 67 61 5F 43 00
```

| offset | type   |           value h |                                                                            value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------: | ----------- |
|  216FE | u4     |          9F3E97DA |                                                                         3667345055 | index       |
|  21702 | s4     |          53000000 |                                                                                 83 | length      |
|  21706 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Mosasaurus/Mosa_Character_BP_Mega.Mosa_Character_BP_Mega_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21750:                            EE 5A 25 E7 58 00 00
21760: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
21770: 74 68 2F 44 69 6E 6F 73 2F 54 75 73 6F 74 65 75
21780: 74 68 69 73 2F 54 75 73 6F 74 65 75 74 68 69 73
21790: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E 54 75
217A0: 73 6F 74 65 75 74 68 69 73 5F 43 68 61 72 61 63
217B0: 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                                 value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------: | ----------- |
|  21759 | u4     |          EE5A25E7 |                                                                              3877985006 | index       |
|  2175D | s4     |          58000000 |                                                                                      88 | length      |
|  21761 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Tusoteuthis/Tusoteuthis_Character_BP.Tusoteuthis_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
217B0:                            F4 DE A3 8D 4D 00 00
217C0: 00 2F 47 61 6D 65 2F 4D 6F 64 73 2F 52 61 67 6E
217D0: 61 72 6F 6B 2F 52 61 67 6E 61 72 6F 6B 5F 57 50
217E0: 2E 52 61 67 6E 61 72 6F 6B 5F 57 50 3A 50 65 72
217F0: 73 69 73 74 65 6E 74 4C 65 76 65 6C 2E 4E 50 43
21800: 5A 6F 6E 65 4D 61 6E 61 67 65 72 31 31 00
```

| offset | type   |           value h |                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------: | ----------- |
|  217B9 | u4     |          F4DEA38D |                                                                   2376326900 | index       |
|  217BD | s4     |          4D000000 |                                                                           77 | length      |
|  217C1 | string | 2F4761 ... 313100 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager11 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21800:                                           39 68
21810: 9F 1D 43 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D
21820: 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 44 6F
21830: 64 6F 2F 44 6F 64 6F 5F 43 68 61 72 61 63 74 65
21840: 72 5F 42 50 2E 44 6F 64 6F 5F 43 68 61 72 61 63
21850: 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------: | ----------- |
|  2180E | u4     |          39689F1D |                                                          496986169 | index       |
|  21812 | s4     |          43000000 |                                                                 67 | length      |
|  21816 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Dodo/Dodo_Character_BP.Dodo_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21850:                            01 ED 1D 57 43 00 00
21860: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
21870: 74 68 2F 44 69 6E 6F 73 2F 44 69 6C 6F 2F 44 69
21880: 6C 6F 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E
21890: 44 69 6C 6F 5F 43 68 61 72 61 63 74 65 72 5F 42
218A0: 50 5F 43 00
```

| offset | type   |           value h |                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------: | ----------- |
|  21859 | u4     |          01ED1D57 |                                                         1461579009 | index       |
|  2185D | s4     |          43000000 |                                                                 67 | length      |
|  21861 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Dilo/Dilo_Character_BP.Dilo_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
218A0:             B2 59 88 E0 4D 00 00 00 2F 47 61 6D
218B0: 65 2F 4D 6F 64 73 2F 52 61 67 6E 61 72 6F 6B 2F
218C0: 52 61 67 6E 61 72 6F 6B 5F 57 50 2E 52 61 67 6E
218D0: 61 72 6F 6B 5F 57 50 3A 50 65 72 73 69 73 74 65
218E0: 6E 74 4C 65 76 65 6C 2E 4E 50 43 5A 6F 6E 65 4D
218F0: 61 6E 61 67 65 72 33 32 00
```

| offset | type   |           value h |                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------: | ----------- |
|  218A4 | u4     |          B25988E0 |                                                                   3767032242 | index       |
|  218A8 | s4     |          4D000000 |                                                                           77 | length      |
|  218AC | string | 2F4761 ... 333200 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager32 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
218F0:                            F7 A0 6F 5E 4E 00 00
21900: 00 2F 47 61 6D 65 2F 4D 6F 64 73 2F 52 61 67 6E
21910: 61 72 6F 6B 2F 52 61 67 6E 61 72 6F 6B 5F 57 50
21920: 2E 52 61 67 6E 61 72 6F 6B 5F 57 50 3A 50 65 72
21930: 73 69 73 74 65 6E 74 4C 65 76 65 6C 2E 4E 50 43
21940: 5A 6F 6E 65 4D 61 6E 61 67 65 72 33 33 38 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  218F9 | u4     |          F7A06F5E |                                                                    1584374007 | index       |
|  218FD | s4     |          4E000000 |                                                                            78 | length      |
|  21901 | string | 2F4761 ... 333800 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager338 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21940:                                              EB
21950: 8B 5A 03 5B 00 00 00 2F 47 61 6D 65 2F 50 72 69
21960: 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 4D

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21970: 65 67 61 6C 6F 73 61 75 72 75 73 2F 4D 65 67 61
21980: 6C 6F 73 61 75 72 75 73 5F 43 68 61 72 61 63 74
21990: 65 72 5F 42 50 2E 4D 65 67 61 6C 6F 73 61 75 72
219A0: 75 73 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F
219B0: 43 00
```

| offset | type   |           value h |                                                                                    value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------: | ----------- |
|  2194F | u4     |          EB8B5A03 |                                                                                   56265707 | index       |
|  21953 | s4     |          5B000000 |                                                                                         91 | length      |
|  21957 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Megalosaurus/Megalosaurus_Character_BP.Megalosaurus_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
219B0:       DD A8 3F 85 49 00 00 00 2F 47 61 6D 65 2F
219C0: 50 72 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F
219D0: 73 2F 54 75 72 74 6C 65 2F 54 75 72 74 6C 65 5F
219E0: 43 68 61 72 61 63 74 65 72 5F 42 50 2E 54 75 72
219F0: 74 6C 65 5F 43 68 61 72 61 63 74 65 72 5F 42 50
21A00: 5F 43 00
```

| offset | type   |           value h |                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------: | ----------- |
|  219B2 | u4     |          DDA83F85 |                                                               2235541725 | index       |
|  219B6 | s4     |          49000000 |                                                                       73 | length      |
|  219BA | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Turtle/Turtle_Character_BP.Turtle_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21A00:          DF C7 A2 A4 43 00 00 00 2F 47 61 6D 65
21A10: 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E
21A20: 6F 73 2F 50 61 72 61 2F 50 61 72 61 5F 43 68 61
21A30: 72 61 63 74 65 72 5F 42 50 2E 50 61 72 61 5F 43
21A40: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------: | ----------- |
|  21A03 | u4     |          DFC7A2A4 |                                                         2762131423 | index       |
|  21A07 | s4     |          43000000 |                                                                 67 | length      |
|  21A0B | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Para/Para_Character_BP.Para_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21A40:                                           C8 7B
21A50: 02 C5 46 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D
21A60: 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 4D 61
21A70: 6E 74 61 2F 4D 61 6E 74 61 5F 43 68 61 72 61 63
21A80: 74 65 72 5F 42 50 2E 4D 61 6E 74 61 5F 43 68 61
21A90: 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                               value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------: | ----------- |
|  21A4E | u4     |          C87B02C5 |                                                            3305274312 | index       |
|  21A52 | s4     |          46000000 |                                                                    70 | length      |
|  21A56 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Manta/Manta_Character_BP.Manta_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21A90:                                     1D 72 C7 3D
21AA0: 55 00 00 00 2F 47 61 6D 65 2F 41 53 41 2F 44 69
21AB0: 6E 6F 73 2F 41 72 63 68 65 6C 6F 6E 2F 44 69 6E
21AC0: 6F 73 2F 41 72 63 68 65 6C 6F 6E 5F 43 68 61 72
21AD0: 61 63 74 65 72 5F 42 50 5F 41 53 41 2E 41 72 63
21AE0: 68 65 6C 6F 6E 5F 43 68 61 72 61 63 74 65 72 5F
21AF0: 42 50 5F 41 53 41 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  21A9C | u4     |          1D72C73D |                                                                           1036481053 | index       |
|  21AA0 | s4     |          55000000 |                                                                                   85 | length      |
|  21AA4 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/Archelon/Dinos/Archelon_Character_BP_ASA.Archelon_Character_BP_ASA_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21AF0:                            0C 19 9D DF 4F 00 00
21B00: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
21B10: 74 68 2F 44 69 6E 6F 73 2F 43 6E 69 64 61 72 69
21B20: 61 2F 43 6E 69 64 61 72 69 61 5F 43 68 61 72 61
21B30: 63 74 65 72 5F 42 50 2E 43 6E 69 64 61 72 69 61
21B40: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------: | ----------- |
|  21AF9 | u4     |          0C199DDF |                                                                     3751614732 | index       |
|  21AFD | s4     |          4F000000 |                                                                             79 | length      |
|  21B01 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Cnidaria/Cnidaria_Character_BP.Cnidaria_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21B50: 26 E4 86 D9 4C 00 00 00 2F 47 61 6D 65 2F 50 72
21B60: 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F
21B70: 54 72 69 6C 6F 62 69 74 65 2F 54 72 69 6C 6F 62
21B80: 69 74 65 5F 43 68 61 72 61 63 74 65 72 2E 54 72
21B90: 69 6C 6F 62 69 74 65 5F 43 68 61 72 61 63 74 65
21BA0: 72 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  21B50 | u4     |          26E486D9 |                                                                  3649496102 | index       |
|  21B54 | s4     |          4C000000 |                                                                          76 | length      |
|  21B58 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Trilobite/Trilobite_Character.Trilobite_Character_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21BA0:             96 FE 71 2C 4F 00 00 00 2F 47 61 6D
21BB0: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 44 69
21BC0: 6E 6F 73 2F 4C 79 73 74 72 6F 73 61 75 72 75 73
21BD0: 2F 4C 79 73 74 72 6F 5F 43 68 61 72 61 63 74 65
21BE0: 72 5F 42 50 2E 4C 79 73 74 72 6F 5F 43 68 61 72
21BF0: 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------: | ----------- |
|  21BA4 | u4     |          96FE712C |                                                                      745668246 | index       |
|  21BA8 | s4     |          4F000000 |                                                                             79 | length      |
|  21BAC | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Lystrosaurus/Lystro_Character_BP.Lystro_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21BF0:                                  C4 51 54 DC 58
21C00: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
21C10: 61 72 74 68 2F 44 69 6E 6F 73 2F 49 63 68 74 68
21C20: 79 6F 72 6E 69 73 2F 49 63 68 74 68 79 6F 72 6E
21C30: 69 73 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E
21C40: 49 63 68 74 68 79 6F 72 6E 69 73 5F 43 68 61 72
21C50: 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                                 value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------: | ----------- |
|  21BFB | u4     |          C45154DC |                                                                              3696513476 | index       |
|  21BFF | s4     |          58000000 |                                                                                      88 | length      |
|  21C03 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Ichthyornis/Ichthyornis_Character_BP.Ichthyornis_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21C50:                                  CC 35 B3 1D 46
21C60: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
21C70: 61 72 74 68 2F 44 69 6E 6F 73 2F 53 74 65 67 6F
21C80: 2F 53 74 65 67 6F 5F 43 68 61 72 61 63 74 65 72
21C90: 5F 42 50 2E 53 74 65 67 6F 5F 43 68 61 72 61 63
21CA0: 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                               value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------: | ----------- |
|  21C5B | u4     |          CC35B31D |                                                             498283980 | index       |
|  21C5F | s4     |          46000000 |                                                                    70 | length      |
|  21C63 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Stego/Stego_Character_BP.Stego_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21CA0:                            06 7E 71 EE 4C 00 00
21CB0: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
21CC0: 74 68 2F 44 69 6E 6F 73 2F 50 68 69 6F 6D 69 61
21CD0: 2F 50 68 69 6F 6D 69 61 5F 43 68 61 72 61 63 74
21CE0: 65 72 5F 42 50 2E 50 68 69 6F 6D 69 61 5F 43 68
21CF0: 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  21CA9 | u4     |          067E71EE |                                                                  4000415238 | index       |
|  21CAD | s4     |          4C000000 |                                                                          76 | length      |
|  21CB1 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Phiomia/Phiomia_Character_BP.Phiomia_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21CF0:                                        F0 E3 25
21D00: E8 47 00 00 00 2F 47 61 6D 65 2F 4D 6F 64 73 2F
21D10: 52 61 67 6E 61 72 6F 6B 2F 52 61 67 6E 61 72 6F
21D20: 6B 5F 57 50 2E 52 61 67 6E 61 72 6F 6B 5F 57 50
21D30: 3A 50 65 72 73 69 73 74 65 6E 74 4C 65 76 65 6C
21D40: 2E 44 65 65 70 5F 4F 63 65 61 6E 00
```

| offset | type   |           value h |                                                                value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------: | ----------- |
|  21CFD | u4     |          F0E325E8 |                                                             3894797296 | index       |
|  21D01 | s4     |          47000000 |                                                                     71 | length      |
|  21D05 | string | 2F4761 ... 616E00 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.Deep_Ocean | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21D40:                                     F0 9C 31 12
21D50: 45 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
21D60: 45 61 72 74 68 2F 44 69 6E 6F 73 2F 45 75 72 79
21D70: 70 74 65 72 69 64 2F 45 75 72 79 70 5F 43 68 61
21D80: 72 61 63 74 65 72 2E 45 75 72 79 70 5F 43 68 61
21D90: 72 61 63 74 65 72 5F 43 00
```

| offset | type   |           value h |                                                              value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------: | ----------- |
|  21D4C | u4     |          F09C3112 |                                                            305241328 | index       |
|  21D50 | s4     |          45000000 |                                                                   69 | length      |
|  21D54 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Eurypterid/Euryp_Character.Euryp_Character_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21D90:                            72 FD E5 5E 46 00 00
21DA0: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
21DB0: 74 68 2F 44 69 6E 6F 73 2F 4F 74 74 65 72 2F 4F
21DC0: 74 74 65 72 5F 43 68 61 72 61 63 74 65 72 5F 42
21DD0: 50 2E 4F 74 74 65 72 5F 43 68 61 72 61 63 74 65
21DE0: 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                               value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------: | ----------- |
|  21D99 | u4     |          72FDE55E |                                                            1592130930 | index       |
|  21D9D | s4     |          46000000 |                                                                    70 | length      |
|  21DA1 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Otter/Otter_Character_BP.Otter_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21DE0:                      17 66 52 30 49 00 00 00 2F
21DF0: 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68
21E00: 2F 44 69 6E 6F 73 2F 53 61 6C 6D 6F 6E 2F 53 61
21E10: 6C 6D 6F 6E 5F 43 68 61 72 61 63 74 65 72 5F 42
21E20: 50 2E 53 61 6C 6D 6F 6E 5F 43 68 61 72 61 63 74
21E30: 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------: | ----------- |
|  21DE7 | u4     |          17665230 |                                                                810706455 | index       |
|  21DEB | s4     |          49000000 |                                                                       73 | length      |
|  21DEF | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Salmon/Salmon_Character_BP.Salmon_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21E30:                         08 C1 8B 04 52 00 00 00
21E40: 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74
21E50: 68 2F 44 69 6E 6F 73 2F 4F 76 69 72 61 70 74 6F
21E60: 72 2F 4F 76 69 72 61 70 74 6F 72 5F 43 68 61 72
21E70: 61 63 74 65 72 5F 42 50 2E 4F 76 69 72 61 70 74
21E80: 6F 72 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F
21E90: 43 00
```

| offset | type   |           value h |                                                                           value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------: | ----------- |
|  21E38 | u4     |          08C18B04 |                                                                          76267784 | index       |
|  21E3C | s4     |          52000000 |                                                                                82 | length      |
|  21E40 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Oviraptor/Oviraptor_Character_BP.Oviraptor_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21E90:       01 2F 95 B1 4D 00 00 00 2F 47 61 6D 65 2F
21EA0: 4D 6F 64 73 2F 52 61 67 6E 61 72 6F 6B 2F 52 61
21EB0: 67 6E 61 72 6F 6B 5F 57 50 2E 52 61 67 6E 61 72
21EC0: 6F 6B 5F 57 50 3A 50 65 72 73 69 73 74 65 6E 74
21ED0: 4C 65 76 65 6C 2E 4E 50 43 5A 6F 6E 65 4D 61 6E
21EE0: 61 67 65 72 35 37 00
```

| offset | type   |           value h |                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------: | ----------- |
|  21E92 | u4     |          012F95B1 |                                                                   2979344129 | index       |
|  21E96 | s4     |          4D000000 |                                                                           77 | length      |
|  21E9A | string | 2F4761 ... 353700 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager57 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21EE0:                      D9 EA 92 46 55 00 00 00 2F
21EF0: 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68
21F00: 2F 44 69 6E 6F 73 2F 43 6F 65 6C 61 63 61 6E 74
21F10: 68 2F 43 6F 65 6C 5F 43 68 61 72 61 63 74 65 72
21F20: 5F 42 50 5F 4F 63 65 61 6E 2E 43 6F 65 6C 5F 43
21F30: 68 61 72 61 63 74 65 72 5F 42 50 5F 4F 63 65 61
21F40: 6E 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  21EE7 | u4     |          D9EA9246 |                                                                           1184033497 | index       |
|  21EEB | s4     |          55000000 |                                                                                   85 | length      |
|  21EEF | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Coelacanth/Coel_Character_BP_Ocean.Coel_Character_BP_Ocean_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21F40:             30 61 A9 AE 52 00 00 00 2F 47 61 6D
21F50: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 44 69
21F60: 6E 6F 73 2F 44 72 61 67 6F 6E 66 6C 79 2F 44 72
21F70: 61 67 6F 6E 66 6C 79 5F 43 68 61 72 61 63 74 65
21F80: 72 5F 42 50 2E 44 72 61 67 6F 6E 66 6C 79 5F 43
21F90: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                           value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------: | ----------- |
|  21F44 | u4     |          3061A9AE |                                                                        2930336048 | index       |
|  21F48 | s4     |          52000000 |                                                                                82 | length      |
|  21F4C | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Dragonfly/Dragonfly_Character_BP.Dragonfly_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21F90:                                           0F CF
21FA0: 35 3F 49 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21FB0: 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 41 6D
21FC0: 6D 6F 6E 69 74 65 2F 41 6D 6D 6F 6E 69 74 65 5F
21FD0: 43 68 61 72 61 63 74 65 72 2E 41 6D 6D 6F 6E 69
21FE0: 74 65 5F 43 68 61 72 61 63 74 65 72 5F 43 00
```

| offset | type   |           value h |                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------: | ----------- |
|  21F9E | u4     |          0FCF353F |                                                               1060491023 | index       |
|  21FA2 | s4     |          49000000 |                                                                       73 | length      |
|  21FA6 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Ammonite/Ammonite_Character.Ammonite_Character_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
21FE0:                                              0C
21FF0: 59 A7 FE 4D 00 00 00 2F 47 61 6D 65 2F 50 72 69
22000: 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 41
22010: 6E 67 6C 65 72 66 69 73 68 2F 41 6E 67 6C 65 72
22020: 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E 41 6E
22030: 67 6C 65 72 5F 43 68 61 72 61 63 74 65 72 5F 42
22040: 50 5F 43 00
```

| offset | type   |           value h |                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------: | ----------- |
|  21FEF | u4     |          0C59A7FE |                                                                   4272380172 | index       |
|  21FF3 | s4     |          4D000000 |                                                                           77 | length      |
|  21FF7 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Anglerfish/Angler_Character_BP.Angler_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22040:             97 66 C6 14 40 00 00 00 2F 47 61 6D
22050: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 44 69
22060: 6E 6F 73 2F 45 65 6C 2F 45 65 6C 5F 43 68 61 72
22070: 61 63 74 65 72 5F 42 50 2E 45 65 6C 5F 43 68 61
22080: 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                         value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------: | ----------- |
|  22044 | u4     |          9766C614 |                                                       348546711 | index       |
|  22048 | s4     |          40000000 |                                                              64 | length      |
|  2204C | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Eel/Eel_Character_BP.Eel_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22080:                                     F4 25 6F 92
22090: 55 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
220A0: 45 61 72 74 68 2F 44 69 6E 6F 73 2F 50 65 67 6F
220B0: 6D 61 73 74 61 78 2F 50 65 67 6F 6D 61 73 74 61
220C0: 78 5F 43 68 61 72 61 63 74 65 72 5F 42 50 2E 50
220D0: 65 67 6F 6D 61 73 74 61 78 5F 43 68 61 72 61 63
220E0: 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  2208C | u4     |          F4256F92 |                                                                           2456757748 | index       |
|  22090 | s4     |          55000000 |                                                                                   85 | length      |
|  22094 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Pegomastax/Pegomastax_Character_BP.Pegomastax_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
220E0:                            3C 7A F5 CA 4C 00 00
220F0: 00 2F 47 61 6D 65 2F 4D 6F 64 73 2F 52 61 67 6E
22100: 61 72 6F 6B 2F 52 61 67 6E 61 72 6F 6B 5F 57 50
22110: 2E 52 61 67 6E 61 72 6F 6B 5F 57 50 3A 50 65 72
22120: 73 69 73 74 65 6E 74 4C 65 76 65 6C 2E 4E 50 43
22130: 5A 6F 6E 65 4D 61 6E 61 67 65 72 33 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  220E9 | u4     |          3C7AF5CA |                                                                  3405085244 | index       |
|  220ED | s4     |          4C000000 |                                                                          76 | length      |
|  220F1 | string | 2F4761 ... 723300 | /Game/Mods/Ragnarok/Ragnarok_WP.Ragnarok_WP:PersistentLevel.NPCZoneManager3 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22130:                                        05 DF D4
22140: 55 16 00 00 00 54 75 72 74 6C 65 5F 43 68 61 72
22150: 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  2213D | u4     |          05DFD455 |            1440014085 | index       |
|  22141 | s4     |          16000000 |                    22 | length      |
|  22145 | string | 547572 ... 5F4300 | Turtle_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22150:                                  A7 B5 FF 8E 71
22160: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
22170: 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72 69
22180: 6E 74 73 2F 44 69 6E 6F 43 68 61 72 61 63 74 65
22190: 72 53 74 61 74 75 73 43 6F 6D 70 6F 6E 65 6E 74
221A0: 5F 42 50 5F 54 75 72 74 6C 65 2E 44 69 6E 6F 43
221B0: 68 61 72 61 63 74 65 72 53 74 61 74 75 73 43 6F
221C0: 6D 70 6F 6E 65 6E 74 5F 42 50 5F 54 75 72 74 6C
221D0: 65 5F 43 00
```

| offset | type   |           value h |                                                                                                          value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------: | ----------- |
|  2215B | u4     |          A7B5FF8E |                                                                                                       2399122855 | index       |
|  2215F | s4     |          71000000 |                                                                                                              113 | length      |
|  22163 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/DinoCharacterStatusComponent_BP_Turtle.DinoCharacterStatusComponent_BP_Turtle_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
221D0:             4B 52 1B CF 21 00 00 00 44 69 6E 6F
221E0: 43 68 61 72 61 63 74 65 72 53 74 61 74 75 73 5F
221F0: 42 50 5F 54 75 72 74 6C 65 5F 43 31 00
```

| offset | type   |           value h |                          value d | description |
| -----: | ------ | ----------------: | -------------------------------: | ----------- |
|  221D4 | u4     |          4B521BCF |                       3474674251 | index       |
|  221D8 | s4     |          21000000 |                               33 | length      |
|  221DC | string | 44696E ... 433100 | DinoCharacterStatus_BP_Turtle_C1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
221F0:                                        A0 9D 4B
22200: F0 16 00 00 00 48 69 62 65 72 6E 61 74 65 64 5A
22210: 6F 6E 65 56 6F 6C 75 6D 65 73 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  221FD | u4     |          A09D4BF0 |            4031487392 | index       |
|  22201 | s4     |          16000000 |                    22 | length      |
|  22205 | string | 486962 ... 657300 | HibernatedZoneVolumes | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22210:                                  6B C5 FD 58 0E
22220: 00 00 00 41 72 72 61 79 50 72 6F 70 65 72 74 79
22230: 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  2221B | u4     |          6BC5FD58 |    1493026155 | index       |
|  2221F | s4     |          0E000000 |            14 | length      |
|  22223 | string | 417272 ... 747900 | ArrayProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22230:    70 C6 A4 FA 0F 00 00 00 53 74 72 75 63 74 50
22240: 72 6F 70 65 72 74 79 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  22231 | u4     |          70C6A4FA |     4205102704 | index       |
|  22235 | s4     |          0F000000 |             15 | length      |
|  22239 | string | 537472 ... 747900 | StructProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22240:                         57 35 D2 22 14 00 00 00
22250: 48 69 62 65 72 6E 61 74 69 6F 6E 5A 6F 6E 65 49
22260: 6E 66 6F 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  22248 | u4     |          5735D222 |           584201559 | index       |
|  2224C | s4     |          14000000 |                  20 | length      |
|  22250 | string | 486962 ... 666F00 | HibernationZoneInfo | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22260:             B9 E2 6C FC 14 00 00 00 2F 53 63 72
22270: 69 70 74 2F 53 68 6F 6F 74 65 72 47 61 6D 65 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  22264 | u4     |          B9E26CFC |          4234994361 | index       |
|  22268 | s4     |          14000000 |                  20 | length      |
|  2226C | string | 2F5363 ... 6D6500 | /Script/ShooterGame | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22280: AC DF 4C 53 07 00 00 00 56 6F 6C 75 6D 65 00
```

| offset | type   |        value h |    value d | description |
| -----: | ------ | -------------: | ---------: | ----------- |
|  22280 | u4     |       ACDF4C53 | 1397546924 | index       |
|  22284 | s4     |       07000000 |          7 | length      |
|  22288 | string | 566F6C756D6500 |     Volume | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22280:                                              3B
22290: DA 82 0C 0F 00 00 00 4F 62 6A 65 63 74 50 72 6F
222A0: 70 65 72 74 79 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  2228F | u4     |          3BDA820C |      209902139 | index       |
|  22293 | s4     |          0F000000 |             15 | length      |
|  22297 | string | 4F626A ... 747900 | ObjectProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
222A0:                   CE 58 11 69 07 00 00 00 57 65
222B0: 69 67 68 74 00
```

| offset | type   |        value h |    value d | description |
| -----: | ------ | -------------: | ---------: | ----------- |
|  222A6 | u4     |       CE581169 | 1762744526 | index       |
|  222AA | s4     |       07000000 |          7 | length      |
|  222AE | string | 57656967687400 |     Weight | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
222B0:                3A 23 FD 69 0E 00 00 00 46 6C 6F
222C0: 61 74 50 72 6F 70 65 72 74 79 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  222B5 | u4     |          3A23FD69 |    1778197306 | index       |
|  222B9 | s4     |          0E000000 |            14 | length      |
|  222BD | string | 466C6F ... 747900 | FloatProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
222C0:                                  1B 9F 36 EA 0B
222D0: 00 00 00 47 65 6E 65 54 72 61 69 74 73 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  222CB | u4     |          1B9F36EA | 3929448219 | index       |
|  222CF | s4     |          0B000000 |         11 | length      |
|  222D3 | string | 47656E ... 747300 | GeneTraits | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
222D0:                                           C1 22
222E0: B7 8F 0D 00 00 00 4E 61 6D 65 50 72 6F 70 65 72
222F0: 74 79 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  222DE | u4     |          C122B78F |   2411143873 | index       |
|  222E2 | s4     |          0D000000 |           13 | length      |
|  222E6 | string | 4E616D ... 747900 | NameProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
222F0:          BA 0C 87 AD 17 00 00 00 49 6E 68 65 72
22300: 69 74 48 65 61 6C 74 68 52 6F 62 75 73 74 5B 30
22310: 5D 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  222F3 | u4     |          BA0C87AD |             2911308986 | index       |
|  222F7 | s4     |          17000000 |                     23 | length      |
|  222FB | string | 496E68 ... 305D00 | InheritHealthRobust[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22310:       5A A0 3F D7 16 00 00 00 4F 72 69 67 69 6E
22320: 61 6C 4E 50 43 56 6F 6C 75 6D 65 4E 61 6D 65 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  22312 | u4     |          5AA03FD7 |            3611271258 | index       |
|  22316 | s4     |          16000000 |                    22 | length      |
|  2231A | string | 4F7269 ... 6D6500 | OriginalNPCVolumeName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22330: 3C 2F C3 F4 0E 00 00 00 4E 50 43 5A 6F 6E 65 56
22340: 6F 6C 75 6D 65 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  22330 | u4     |          3C2FC3F4 |    4106432316 | index       |
|  22334 | s4     |          0E000000 |            14 | length      |
|  22338 | string | 4E5043 ... 6D6500 | NPCZoneVolume | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22340:                   2E BE 12 19 19 00 00 00 4C 61
22350: 73 74 54 61 6D 65 43 6F 6E 73 75 6D 65 64 46 6F
22360: 6F 64 54 69 6D 65 00
```

| offset | type   |           value h |                  value d | description |
| -----: | ------ | ----------------: | -----------------------: | ----------- |
|  22346 | u4     |          2EBE1219 |                420658734 | index       |
|  2234A | s4     |          19000000 |                       25 | length      |
|  2234E | string | 4C6173 ... 6D6500 | LastTameConsumedFoodTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22360:                      0D D9 8C 90 0F 00 00 00 44
22370: 6F 75 62 6C 65 50 72 6F 70 65 72 74 79 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  22367 | u4     |          0DD98C90 |     2425149709 | index       |
|  2236B | s4     |          0F000000 |             15 | length      |
|  2236F | string | 446F75 ... 747900 | DoubleProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22370:                                           32 6D
22380: AA 5F 17 00 00 00 4C 61 73 74 45 67 67 53 70 61
22390: 77 6E 43 68 61 6E 63 65 54 69 6D 65 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  2237E | u4     |          326DAA5F |             1605004594 | index       |
|  22382 | s4     |          17000000 |                     23 | length      |
|  22386 | string | 4C6173 ... 6D6500 | LastEggSpawnChanceTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22390:                                        0C F6 03
223A0: 9D 15 00 00 00 55 6E 74 61 6D 65 64 50 6F 6F 70
223B0: 54 69 6D 65 43 61 63 68 65 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  2239D | u4     |          0CF6039D |           2634282508 | index       |
|  223A1 | s4     |          15000000 |                   21 | length      |
|  223A5 | string | 556E74 ... 686500 | UntamedPoopTimeCache | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
223B0:                               01 9E 16 13 15 00
223C0: 00 00 52 65 71 75 69 72 65 64 54 61 6D 65 41 66
223D0: 66 69 6E 69 74 79 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  223BA | u4     |          019E1613 |            320249345 | index       |
|  223BE | s4     |          15000000 |                   21 | length      |
|  223C2 | string | 526571 ... 747900 | RequiredTameAffinity | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
223D0:                      3C 8F 30 4B 08 00 00 00 44
223E0: 69 6E 6F 49 44 31 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  223D7 | u4     |         3C8F304B | 1261473596 | index       |
|  223DB | s4     |         08000000 |          8 | length      |
|  223DF | string | 44696E6F49443100 |    DinoID1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
223E0:                      5B 9E 09 B5 0F 00 00 00 55
223F0: 49 6E 74 33 32 50 72 6F 70 65 72 74 79 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  223E7 | u4     |          5B9E09B5 |     3037306459 | index       |
|  223EB | s4     |          0F000000 |             15 | length      |
|  223EF | string | 55496E ... 747900 | UInt32Property | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
223F0:                                           FC 77
22400: 6F 78 08 00 00 00 44 69 6E 6F 49 44 32 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  223FE | u4     |         FC776F78 | 2020571132 | index       |
|  22402 | s4     |         08000000 |          8 | length      |
|  22406 | string | 44696E6F49443200 |    DinoID2 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22400:                                           61 7D
22410: 20 E8 10 00 00 00 43 6F 6C 6F 72 53 65 74 49 6E
22420: 64 69 63 65 73 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  2240E | u4     |          617D20E8 |      3894443361 | index       |
|  22412 | s4     |          10000000 |              16 | length      |
|  22416 | string | 436F6C ... 657300 | ColorSetIndices | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22420:                   B2 B4 4F 96 0D 00 00 00 42 79
22430: 74 65 50 72 6F 70 65 72 74 79 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  22426 | u4     |          B2B44F96 |   2521806002 | index       |
|  2242A | s4     |          0D000000 |           13 | length      |
|  2242E | string | 427974 ... 747900 | ByteProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22430:                                  73 02 0D 2A 0A
22440: 00 00 00 62 49 73 46 65 6D 61 6C 65 00
```

| offset | type   |           value h |   value d | description |
| -----: | ------ | ----------------: | --------: | ----------- |
|  2243B | u4     |          73020D2A | 705495667 | index       |
|  2243F | s4     |          0A000000 |        10 | length      |
|  22443 | string | 624973 ... 6C6500 | bIsFemale | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22440:                                        AA 26 82
22450: 4D 0D 00 00 00 42 6F 6F 6C 50 72 6F 70 65 72 74
22460: 79 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  2244D | u4     |          AA26824D |   1300375210 | index       |
|  22451 | s4     |          0D000000 |           13 | length      |
|  22455 | string | 426F6F ... 747900 | BoolProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22460:       E0 FF 44 55 17 00 00 00 62 53 65 72 76 65
22470: 72 49 6E 69 74 69 61 6C 69 7A 65 64 44 69 6E 6F
22480: 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  22462 | u4     |          E0FF4455 |             1430585312 | index       |
|  22466 | s4     |          17000000 |                     23 | length      |
|  2246A | string | 625365 ... 6E6F00 | bServerInitializedDino | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22480:    54 09 76 A8 1B 00 00 00 4D 79 43 68 61 72 61
22490: 63 74 65 72 53 74 61 74 75 73 43 6F 6D 70 6F 6E
224A0: 65 6E 74 00
```

| offset | type   |           value h |                    value d | description |
| -----: | ------ | ----------------: | -------------------------: | ----------- |
|  22481 | u4     |          540976A8 |                 2826307924 | index       |
|  22485 | s4     |          1B000000 |                         27 | length      |
|  22489 | string | 4D7943 ... 6E7400 | MyCharacterStatusComponent | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
224A0:             E9 21 8E 08 28 00 00 00 4C 61 73 74
224B0: 54 69 6D 65 55 70 64 61 74 65 64 43 68 61 72 61
224C0: 63 74 65 72 53 74 61 74 75 73 43 6F 6D 70 6F 6E
224D0: 65 6E 74 00
```

| offset | type   |           value h |                                 value d | description |
| -----: | ------ | ----------------: | --------------------------------------: | ----------- |
|  224A4 | u4     |          E9218E08 |                               143532521 | index       |
|  224A8 | s4     |          28000000 |                                      40 | length      |
|  224AC | string | 4C6173 ... 6E7400 | LastTimeUpdatedCharacterStatusComponent | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
224D0:             3A 61 70 79 0B 00 00 00 49 6E 73 74
224E0: 69 67 61 74 6F 72 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  224D4 | u4     |          3A617079 | 2037408058 | index       |
|  224D8 | s4     |          0B000000 |         11 | length      |
|  224DC | string | 496E73 ... 6F7200 | Instigator | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
224E0:                      D6 E9 6C 66 14 00 00 00 4C
224F0: 61 73 74 45 6E 74 65 72 53 74 61 73 69 73 54 69
22500: 6D 65 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  224E7 | u4     |          D6E96C66 |          1718413782 | index       |
|  224EB | s4     |          14000000 |                  20 | length      |
|  224EF | string | 4C6173 ... 6D6500 | LastEnterStasisTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22500:          AF 51 CE DA 15 00 00 00 4F 72 69 67 69
22510: 6E 61 6C 43 72 65 61 74 69 6F 6E 54 69 6D 65 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  22503 | u4     |          AF51CEDA |           3670954415 | index       |
|  22507 | s4     |          15000000 |                   21 | length      |
|  2250B | string | 4F7269 ... 6D6500 | OriginalCreationTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22520: 35 43 1D 08 0E 00 00 00 54 61 72 67 65 74 69 6E
22530: 67 54 65 61 6D 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  22520 | u4     |          35431D08 |     136135477 | index       |
|  22524 | s4     |          0E000000 |            14 | length      |
|  22528 | string | 546172 ... 616D00 | TargetingTeam | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22530:                   71 B2 FA F3 0C 00 00 00 49 6E
22540: 74 50 72 6F 70 65 72 74 79 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  22536 | u4     |          71B2FAF3 |  4093293169 | index       |
|  2253A | s4     |          0C000000 |          12 | length      |
|  2253E | string | 496E74 ... 747900 | IntProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22540:                               4C FC D6 49 1D 00
22550: 00 00 4E 75 6D 62 65 72 4F 66 4C 65 76 65 6C 55
22560: 70 50 6F 69 6E 74 73 41 70 70 6C 69 65 64 00
```

| offset | type   |           value h |                      value d | description |
| -----: | ------ | ----------------: | ---------------------------: | ----------- |
|  2254A | u4     |          4CFCD649 |                   1238826060 | index       |
|  2254E | s4     |          1D000000 |                           29 | length      |
|  22552 | string | 4E756D ... 656400 | NumberOfLevelUpPointsApplied | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22560:                                              46
22570: 9D 05 14 18 00 00 00 62 53 65 72 76 65 72 46 69
22580: 72 73 74 49 6E 69 74 69 61 6C 69 7A 65 64 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  2256F | u4     |          469D0514 |               335912262 | index       |
|  22573 | s4     |          18000000 |                      24 | length      |
|  22577 | string | 625365 ... 656400 | bServerFirstInitialized | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22580:                                              74
22590: 78 9B 39 13 00 00 00 42 61 73 65 43 68 61 72 61
225A0: 63 74 65 72 4C 65 76 65 6C 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  2258F | u4     |          74789B39 |          966490228 | index       |
|  22593 | s4     |          13000000 |                 19 | length      |
|  22597 | string | 426173 ... 656C00 | BaseCharacterLevel | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
225A0:                               07 06 5A F7 14 00
225B0: 00 00 43 75 72 72 65 6E 74 53 74 61 74 75 73 56
225C0: 61 6C 75 65 73 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  225AA | u4     |          07065AF7 |          4149872135 | index       |
|  225AE | s4     |          14000000 |                  20 | length      |
|  225B2 | string | 437572 ... 657300 | CurrentStatusValues | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
225C0:                   5E 27 CA 2A 14 00 00 00 50 61
225D0: 72 61 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F
225E0: 43 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  225C6 | u4     |          5E27CA2A |           717891422 | index       |
|  225CA | s4     |          14000000 |                  20 | length      |
|  225CE | string | 506172 ... 5F4300 | Para_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
225E0:       35 0F CC 3B 6D 00 00 00 2F 47 61 6D 65 2F

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
225F0: 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65
22600: 42 6C 75 65 70 72 69 6E 74 73 2F 44 69 6E 6F 43
22610: 68 61 72 61 63 74 65 72 53 74 61 74 75 73 43 6F
22620: 6D 70 6F 6E 65 6E 74 5F 42 50 5F 50 61 72 61 2E
22630: 44 69 6E 6F 43 68 61 72 61 63 74 65 72 53 74 61
22640: 74 75 73 43 6F 6D 70 6F 6E 65 6E 74 5F 42 50 5F
22650: 50 61 72 61 5F 43 00
```

| offset | type   |           value h |                                                                                                      value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------: | ----------- |
|  225E2 | u4     |          350FCC3B |                                                                                                   1003228981 | index       |
|  225E6 | s4     |          6D000000 |                                                                                                          109 | length      |
|  225EA | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/DinoCharacterStatusComponent_BP_Para.DinoCharacterStatusComponent_BP_Para_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22650:                      6A A1 5B 3B 1F 00 00 00 44
22660: 69 6E 6F 43 68 61 72 61 63 74 65 72 53 74 61 74
22670: 75 73 5F 42 50 5F 50 61 72 61 5F 43 31 00
```

| offset | type   |           value h |                        value d | description |
| -----: | ------ | ----------------: | -----------------------------: | ----------- |
|  22657 | u4     |          6AA15B3B |                      995860842 | index       |
|  2265B | s4     |          1F000000 |                             31 | length      |
|  2265F | string | 44696E ... 433100 | DinoCharacterStatus_BP_Para_C1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22670:                                           B3 75
22680: 84 5E 0B 00 00 00 53 77 69 6D 6D 65 72 5B 31 5D
22690: 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  2267E | u4     |          B375845E | 1585739187 | index       |
|  22682 | s4     |          0B000000 |         11 | length      |
|  22686 | string | 537769 ... 315D00 | Swimmer[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22690:    B0 86 94 95 15 00 00 00 50 74 65 72 6F 5F 43
226A0: 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  22691 | u4     |          B0869495 |           2509538992 | index       |
|  22695 | s4     |          15000000 |                   21 | length      |
|  22699 | string | 507465 ... 5F4300 | Ptero_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
226A0:                                           75 B8
226B0: 22 F8 6F 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D
226C0: 61 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65
226D0: 70 72 69 6E 74 73 2F 44 69 6E 6F 43 68 61 72 61
226E0: 63 74 65 72 53 74 61 74 75 73 43 6F 6D 70 6F 6E
226F0: 65 6E 74 5F 42 50 5F 50 74 65 72 6F 2E 44 69 6E
22700: 6F 43 68 61 72 61 63 74 65 72 53 74 61 74 75 73
22710: 43 6F 6D 70 6F 6E 65 6E 74 5F 42 50 5F 50 74 65
22720: 72 6F 5F 43 00
```

| offset | type   |           value h |                                                                                                        value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------: | ----------- |
|  226AE | u4     |          75B822F8 |                                                                                                     4163025013 | index       |
|  226B2 | s4     |          6F000000 |                                                                                                            111 | length      |
|  226B6 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/DinoCharacterStatusComponent_BP_Ptero.DinoCharacterStatusComponent_BP_Ptero_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22720:                A7 B1 0F 44 20 00 00 00 44 69 6E
22730: 6F 43 68 61 72 61 63 74 65 72 53 74 61 74 75 73
22740: 5F 42 50 5F 50 74 65 72 6F 5F 43 31 00
```

| offset | type   |           value h |                         value d | description |
| -----: | ------ | ----------------: | ------------------------------: | ----------- |
|  22725 | u4     |          A7B10F44 |                      1141879207 | index       |
|  22729 | s4     |          20000000 |                              32 | length      |
|  2272D | string | 44696E ... 433100 | DinoCharacterStatus_BP_Ptero_C1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22740:                                        F0 ED A2
22750: 97 0E 00 00 00 50 72 6F 74 65 63 74 69 76 65 5B
22760: 31 5D 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  2274D | u4     |          F0EDA297 |    2544037360 | index       |
|  22751 | s4     |          0E000000 |            14 | length      |
|  22755 | string | 50726F ... 315D00 | Protective[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22760:          E0 3B 8F 60 0A 00 00 00 62 49 73 46 6C
22770: 79 69 6E 67 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  22763 | u4     |          E03B8F60 | 1619999712 | index       |
|  22767 | s4     |          0A000000 |         10 | length      |
|  2276B | string | 624973 ... 6E6700 |  bIsFlying | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22770:                82 2D 55 C5 14 00 00 00 44 69 6C
22780: 6F 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43
22790: 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  22775 | u4     |          822D55C5 |          3310693762 | index       |
|  22779 | s4     |          14000000 |                  20 | length      |
|  2277D | string | 44696C ... 5F4300 | Dilo_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22790:    BE 3E A8 55 6D 00 00 00 2F 47 61 6D 65 2F 50
227A0: 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42
227B0: 6C 75 65 70 72 69 6E 74 73 2F 44 69 6E 6F 43 68
227C0: 61 72 61 63 74 65 72 53 74 61 74 75 73 43 6F 6D
227D0: 70 6F 6E 65 6E 74 5F 42 50 5F 44 69 6C 6F 2E 44
227E0: 69 6E 6F 43 68 61 72 61 63 74 65 72 53 74 61 74
227F0: 75 73 43 6F 6D 70 6F 6E 65 6E 74 5F 42 50 5F 44
22800: 69 6C 6F 5F 43 00
```

| offset | type   |           value h |                                                                                                      value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------: | ----------- |
|  22791 | u4     |          BE3EA855 |                                                                                                   1437089470 | index       |
|  22795 | s4     |          6D000000 |                                                                                                          109 | length      |
|  22799 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/DinoCharacterStatusComponent_BP_Dilo.DinoCharacterStatusComponent_BP_Dilo_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22800:                   ED 6F 5B 5C 1F 00 00 00 44 69
22810: 6E 6F 43 68 61 72 61 63 74 65 72 53 74 61 74 75
22820: 73 5F 42 50 5F 44 69 6C 6F 5F 43 31 00
```

| offset | type   |           value h |                        value d | description |
| -----: | ------ | ----------------: | -----------------------------: | ----------- |
|  22806 | u4     |          ED6F5B5C |                     1549496301 | index       |
|  2280A | s4     |          1F000000 |                             31 | length      |
|  2280E | string | 44696E ... 433100 | DinoCharacterStatus_BP_Dilo_C1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22820:                                        59 63 06
22830: BE 10 00 00 00 51 75 69 63 6B 48 69 74 74 69 6E
22840: 67 5B 30 5D 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  2282D | u4     |          596306BE |      3188089689 | index       |
|  22831 | s4     |          10000000 |              16 | length      |
|  22835 | string | 517569 ... 305D00 | QuickHitting[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22840:                99 F0 EF 61 0E 00 00 00 50 72 6F
22850: 74 65 63 74 69 76 65 5B 30 5D 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  22845 | u4     |          99F0EF61 |    1643114649 | index       |
|  22849 | s4     |          0E000000 |            14 | length      |
|  2284D | string | 50726F ... 305D00 | Protective[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22850:                                  97 99 4D 9B 16
22860: 00 00 00 4C 79 73 74 72 6F 5F 43 68 61 72 61 63
22870: 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  2285B | u4     |          97994D9B |            2605554071 | index       |
|  2285F | s4     |          16000000 |                    22 | length      |
|  22863 | string | 4C7973 ... 5F4300 | Lystro_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22870:                            F5 88 19 CC 71 00 00
22880: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
22890: 74 68 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74
228A0: 73 2F 44 69 6E 6F 43 68 61 72 61 63 74 65 72 53
228B0: 74 61 74 75 73 43 6F 6D 70 6F 6E 65 6E 74 5F 42
228C0: 50 5F 4C 79 73 74 72 6F 2E 44 69 6E 6F 43 68 61
228D0: 72 61 63 74 65 72 53 74 61 74 75 73 43 6F 6D 70
228E0: 6F 6E 65 6E 74 5F 42 50 5F 4C 79 73 74 72 6F 5F
228F0: 43 00
```

| offset | type   |           value h |                                                                                                          value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------: | ----------- |
|  22879 | u4     |          F58819CC |                                                                                                       3424225525 | index       |
|  2287D | s4     |          71000000 |                                                                                                              113 | length      |
|  22881 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/DinoCharacterStatusComponent_BP_Lystro.DinoCharacterStatusComponent_BP_Lystro_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
228F0:       81 81 04 12 21 00 00 00 44 69 6E 6F 43 68
22900: 61 72 61 63 74 65 72 53 74 61 74 75 73 5F 42 50
22910: 5F 4C 79 73 74 72 6F 5F 43 31 00
```

| offset | type   |           value h |                          value d | description |
| -----: | ------ | ----------------: | -------------------------------: | ----------- |
|  228F2 | u4     |          81810412 |                        302285185 | index       |
|  228F6 | s4     |          21000000 |                               33 | length      |
|  228FA | string | 44696E ... 433100 | DinoCharacterStatus_BP_Lystro_C1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22910:                                  06 FA 4F 02 0C
22920: 00 00 00 43 61 72 65 66 72 65 65 5B 30 5D 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  2291B | u4     |          06FA4F02 |    38795782 | index       |
|  2291F | s4     |          0C000000 |          12 | length      |
|  22923 | string | 436172 ... 305D00 | Carefree[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22920:                                              B4
22930: FC AA 1D 1B 00 00 00 49 63 68 74 68 79 6F 72 6E
22940: 69 73 5F 43 68 61 72 61 63 74 65 72 5F 42 50 5F
22950: 43 00
```

| offset | type   |           value h |                    value d | description |
| -----: | ------ | ----------------: | -------------------------: | ----------- |
|  2292F | u4     |          B4FCAA1D |                  497745076 | index       |
|  22933 | s4     |          1B000000 |                         27 | length      |
|  22937 | string | 496368 ... 5F4300 | Ichthyornis_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22950:       F3 52 97 21 7B 00 00 00 2F 47 61 6D 65 2F
22960: 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65
22970: 42 6C 75 65 70 72 69 6E 74 73 2F 44 69 6E 6F 43
22980: 68 61 72 61 63 74 65 72 53 74 61 74 75 73 43 6F
22990: 6D 70 6F 6E 65 6E 74 5F 42 50 5F 49 63 68 74 68
229A0: 79 6F 72 6E 69 73 2E 44 69 6E 6F 43 68 61 72 61
229B0: 63 74 65 72 53 74 61 74 75 73 43 6F 6D 70 6F 6E
229C0: 65 6E 74 5F 42 50 5F 49 63 68 74 68 79 6F 72 6E
229D0: 69 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                    value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  22952 | u4     |          F3529721 |                                                                                                                  563565299 | index       |
|  22956 | s4     |          7B000000 |                                                                                                                        123 | length      |
|  2295A | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/DinoCharacterStatusComponent_BP_Ichthyornis.DinoCharacterStatusComponent_BP_Ichthyornis_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
229D0:                48 71 93 8E 26 00 00 00 44 69 6E
229E0: 6F 43 68 61 72 61 63 74 65 72 53 74 61 74 75 73
229F0: 5F 42 50 5F 49 63 68 74 68 79 6F 72 6E 69 73 5F
22A00: 43 31 00
```

| offset | type   |           value h |                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------: | ----------- |
|  229D5 | u4     |          4871938E |                            2392027464 | index       |
|  229D9 | s4     |          26000000 |                                    38 | length      |
|  229DD | string | 44696E ... 433100 | DinoCharacterStatus_BP_Ichthyornis_C1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22A00:          EA 04 FB 25 09 00 00 00 41 6E 67 72 79
22A10: 5B 31 5D 00
```

| offset | type   |           value h |   value d | description |
| -----: | ------ | ----------------: | --------: | ----------- |
|  22A03 | u4     |          EA04FB25 | 637207786 | index       |
|  22A07 | s4     |          09000000 |         9 | length      |
|  22A0B | string | 416E67 ... 315D00 |  Angry[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22A10:             80 C5 CD 21 18 00 00 00 49 6E 68 65
22A20: 72 69 74 48 65 61 6C 74 68 4D 75 74 61 62 6C 65
22A30: 5B 30 5D 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  22A14 | u4     |          80C5CD21 |               567133568 | index       |
|  22A18 | s4     |          18000000 |                      24 | length      |
|  22A1C | string | 496E68 ... 305D00 | InheritHealthMutable[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22A30:             30 7E 4B 48 10 00 00 00 51 75 69 63
22A40: 6B 48 69 74 74 69 6E 67 5B 31 5D 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  22A34 | u4     |          307E4B48 |      1212907056 | index       |
|  22A38 | s4     |          10000000 |              16 | length      |
|  22A3C | string | 517569 ... 315D00 | QuickHitting[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22A40:                                     54 46 F2 05
22A50: 13 00 00 00 53 63 6F 72 63 68 65 64 43 61 72 72
22A60: 69 65 72 5B 30 5D 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  22A4C | u4     |          5446F205 |           99763796 | index       |
|  22A50 | s4     |          13000000 |                 19 | length      |
|  22A54 | string | 53636F ... 305D00 | ScorchedCarrier[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22A60:                      3E 72 CA FE 08 00 00 00 43
22A70: 6F 6C 64 5B 30 5D 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  22A67 | u4     |         3E72CAFE | 4274680382 | index       |
|  22A6B | s4     |         08000000 |          8 | length      |
|  22A6F | string | 436F6C645B305D00 |    Cold[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22A70:                      C4 AD F4 AF 13 00 00 00 62
22A80: 53 61 76 65 64 57 68 65 6E 53 74 61 73 69 73 65
22A90: 64 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  22A77 | u4     |          C4ADF4AF |         2952048068 | index       |
|  22A7B | s4     |          13000000 |                 19 | length      |
|  22A7F | string | 625361 ... 656400 | bSavedWhenStasised | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22A90:       26 22 11 63 12 00 00 00 53 6C 6F 77 4D 65
22AA0: 74 61 62 6F 6C 69 73 6D 5B 30 5D 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  22A92 | u4     |          26221163 |        1662067238 | index       |
|  22A96 | s4     |          12000000 |                18 | length      |
|  22A9A | string | 536C6F ... 305D00 | SlowMetabolism[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22AA0:                                     83 19 B6 D3
22AB0: 09 00 00 00 41 6E 67 72 79 5B 30 5D 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  22AAC | u4     |          8319B6D3 | 3551926659 | index       |
|  22AB0 | s4     |          09000000 |          9 | length      |
|  22AB4 | string | 416E67 ... 305D00 |   Angry[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22AB0:                                        49 51 95
22AC0: E0 15 00 00 00 49 6E 68 65 72 69 74 4D 65 6C 65
22AD0: 65 46 72 61 69 6C 5B 31 5D 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  22ABD | u4     |          495195E0 |           3767882057 | index       |
|  22AC1 | s4     |          15000000 |                   21 | length      |
|  22AC5 | string | 496E68 ... 315D00 | InheritMeleeFrail[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22AD0:                               3A 58 55 38 18 00
22AE0: 00 00 49 6E 68 65 72 69 74 57 65 69 67 68 74 4D
22AF0: 75 74 61 62 6C 65 5B 31 5D 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  22ADA | u4     |          3A585538 |               945117242 | index       |
|  22ADE | s4     |          18000000 |                      24 | length      |
|  22AE2 | string | 496E68 ... 315D00 | InheritWeightMutable[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22AF0:                               0A D5 D2 15 17 00
22B00: 00 00 49 6E 68 65 72 69 74 57 65 69 67 68 74 52
22B10: 6F 62 75 73 74 5B 30 5D 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  22AFA | u4     |          0AD5D215 |              366138634 | index       |
|  22AFE | s4     |          17000000 |                     23 | length      |
|  22B02 | string | 496E68 ... 305D00 | InheritWeightRobust[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22B10:                            E9 D8 80 D7 18 00 00
22B20: 00 49 6E 68 65 72 69 74 48 65 61 6C 74 68 4D 75
22B30: 74 61 62 6C 65 5B 31 5D 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  22B19 | u4     |          E9D880D7 |              3615545577 | index       |
|  22B1D | s4     |          18000000 |                      24 | length      |
|  22B21 | string | 496E68 ... 315D00 | InheritHealthMutable[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22B30:                            4A 43 B0 AF 0C 00 00
22B40: 00 46 72 65 6E 65 74 69 63 5B 30 5D 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  22B39 | u4     |          4A43B0AF |  2947564362 | index       |
|  22B3D | s4     |          0C000000 |          12 | length      |
|  22B41 | string | 467265 ... 305D00 | Frenetic[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22B40:                                        9C 4A 58
22B50: 33 17 00 00 00 49 6E 68 65 72 69 74 4D 65 6C 65
22B60: 65 4D 75 74 61 62 6C 65 5B 30 5D 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  22B4D | u4     |          9C4A5833 |              861424284 | index       |
|  22B51 | s4     |          17000000 |                     23 | length      |
|  22B55 | string | 496E68 ... 305D00 | InheritMeleeMutable[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22B60:                                     67 02 D7 38
22B70: 15 00 00 00 45 78 74 69 6E 63 74 69 6F 6E 43 61
22B80: 72 72 69 65 72 5B 30 5D 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  22B6C | u4     |          6702D738 |            953614951 | index       |
|  22B70 | s4     |          15000000 |                   21 | length      |
|  22B74 | string | 457874 ... 305D00 | ExtinctionCarrier[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22B80:                            B3 48 7C D1 0D 00 00
22B90: 00 45 78 63 69 74 61 62 6C 65 5B 31 5D 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  22B89 | u4     |          B3487CD1 |   3514583219 | index       |
|  22B8D | s4     |          0D000000 |           13 | length      |
|  22B91 | string | 457863 ... 315D00 | Excitable[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22B90:                                           7C 83
22BA0: 94 60 2A 00 00 00 43 68 61 72 61 63 74 65 72 53
22BB0: 61 76 65 64 44 79 6E 61 6D 69 63 42 61 73 65 52
22BC0: 65 6C 61 74 69 76 65 52 6F 74 61 74 69 6F 6E 00
```

| offset | type   |           value h |                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------: | ----------- |
|  22B9E | u4     |          7C839460 |                                1620345724 | index       |
|  22BA2 | s4     |          2A000000 |                                        42 | length      |
|  22BA6 | string | 436861 ... 6F6E00 | CharacterSavedDynamicBaseRelativeRotation | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22BD0: AB A1 9D 31 05 00 00 00 51 75 61 74 00
```

| offset | type   |    value h |   value d | description |
| -----: | ------ | ---------: | --------: | ----------- |
|  22BD0 | u4     |   ABA19D31 | 832414123 | index       |
|  22BD4 | s4     |   05000000 |         5 | length      |
|  22BD8 | string | 5175617400 |      Quat | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22BD0:                                        17 51 71
22BE0: 19 14 00 00 00 2F 53 63 72 69 70 74 2F 43 6F 72
22BF0: 65 55 4F 62 6A 65 63 74 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  22BDD | u4     |          17517119 |           426856727 | index       |
|  22BE1 | s4     |          14000000 |                  20 | length      |
|  22BE5 | string | 2F5363 ... 637400 | /Script/CoreUObject | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22BF0:                            AD D2 CC 11 17 00 00
22C00: 00 53 61 76 65 64 42 61 73 65 57 6F 72 6C 64 4C
22C10: 6F 63 61 74 69 6F 6E 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  22BF9 | u4     |          ADD2CC11 |              298635949 | index       |
|  22BFD | s4     |          17000000 |                     23 | length      |
|  22C01 | string | 536176 ... 6F6E00 | SavedBaseWorldLocation | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22C10:                         43 CE 04 78 07 00 00 00
22C20: 56 65 63 74 6F 72 00
```

| offset | type   |        value h |    value d | description |
| -----: | ------ | -------------: | ---------: | ----------- |
|  22C18 | u4     |       43CE0478 | 2013580867 | index       |
|  22C1C | s4     |       07000000 |          7 | length      |
|  22C20 | string | 566563746F7200 |     Vector | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22C20:                      D1 4A 34 78 08 00 00 00 4E
22C30: 75 6D 62 5B 30 5D 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  22C27 | u4     |         D14A3478 | 2016692945 | index       |
|  22C2B | s4     |         08000000 |          8 | length      |
|  22C2F | string | 4E756D625B305D00 |    Numb[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22C30:                      6E 1D E9 ED 10 00 00 00 48
22C40: 65 61 76 79 48 69 74 74 69 6E 67 5B 30 5D 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  22C37 | u4     |          6E1DE9ED |      3991477614 | index       |
|  22C3B | s4     |          10000000 |              16 | length      |
|  22C3F | string | 486561 ... 305D00 | HeavyHitting[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22C40:                                              C5
22C50: A1 22 4B 0C 00 00 00 56 61 6D 70 69 72 69 63 5B
22C60: 31 5D 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  22C4F | u4     |          C5A1224B |  1260560837 | index       |
|  22C53 | s4     |          0C000000 |          12 | length      |
|  22C57 | string | 56616D ... 315D00 | Vampiric[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22C60:          4E CB E1 6A 0C 00 00 00 53 70 72 69 6E
22C70: 74 65 72 5B 30 5D 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  22C63 | u4     |          4ECBE16A |  1793182542 | index       |
|  22C67 | s4     |          0C000000 |          12 | length      |
|  22C6B | string | 537072 ... 305D00 | Sprinter[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22C70:                      52 CD 29 9E 08 00 00 00 57
22C80: 61 72 6D 5B 30 5D 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  22C77 | u4     |         52CD299E | 2653539666 | index       |
|  22C7B | s4     |         08000000 |          8 | length      |
|  22C7F | string | 5761726D5B305D00 |    Warm[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22C80:                      25 23 F7 56 18 00 00 00 49
22C90: 6E 68 65 72 69 74 53 74 61 6D 69 6E 61 52 6F 62
22CA0: 75 73 74 5B 31 5D 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  22C87 | u4     |          2523F756 |              1459036965 | index       |
|  22C8B | s4     |          18000000 |                      24 | length      |
|  22C8F | string | 496E68 ... 315D00 | InheritStaminaRobust[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22CA0:                      CE F8 F5 72 12 00 00 00 4D
22CB0: 69 6E 65 72 61 6C 43 61 72 72 69 65 72 5B 30 5D
22CC0: 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  22CA7 | u4     |          CEF8F572 |        1928722638 | index       |
|  22CAB | s4     |          12000000 |                18 | length      |
|  22CAF | string | 4D696E ... 305D00 | MineralCarrier[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22CC0:    FD 4F E6 5A 13 00 00 00 41 62 65 72 72 61 6E
22CD0: 74 43 61 72 72 69 65 72 5B 31 5D 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  22CC1 | u4     |          FD4FE65A |         1525043197 | index       |
|  22CC5 | s4     |          13000000 |                 19 | length      |
|  22CC9 | string | 416265 ... 315D00 | AberrantCarrier[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22CD0:                                     6F E7 02 F4
22CE0: 0C 00 00 00 43 61 72 65 66 72 65 65 5B 31 5D 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  22CDC | u4     |          6FE702F4 |  4093831023 | index       |
|  22CE0 | s4     |          0C000000 |          12 | length      |
|  22CE4 | string | 436172 ... 315D00 | Carefree[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22CF0: C7 51 73 C2 0D 00 00 00 54 65 6E 61 63 69 6F 75
22D00: 73 5B 30 5D 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  22CF0 | u4     |          C75173C2 |   3262337479 | index       |
|  22CF4 | s4     |          0D000000 |           13 | length      |
|  22CF8 | string | 54656E ... 305D00 | Tenacious[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22D00:                B8 57 79 8E 08 00 00 00 4E 75 6D
22D10: 62 5B 31 5D 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  22D05 | u4     |         B857798E | 2390316984 | index       |
|  22D09 | s4     |         08000000 |          8 | length      |
|  22D0D | string | 4E756D625B315D00 |    Numb[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22D10:                4C 3E BA A0 18 00 00 00 49 6E 68
22D20: 65 72 69 74 53 74 61 6D 69 6E 61 52 6F 62 75 73
22D30: 74 5B 30 5D 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  22D15 | u4     |          4C3EBAA0 |              2696560204 | index       |
|  22D19 | s4     |          18000000 |                      24 | length      |
|  22D1D | string | 496E68 ... 305D00 | InheritStaminaRobust[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22D30:                A6 33 AC 48 15 00 00 00 49 6E 68
22D40: 65 72 69 74 4D 65 6C 65 65 46 72 61 69 6C 5B 32
22D50: 5D 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  22D35 | u4     |          A633AC48 |           1219244966 | index       |
|  22D39 | s4     |          15000000 |                   21 | length      |
|  22D3D | string | 496E68 ... 325D00 | InheritMeleeFrail[2] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22D50:       05 C8 8C 24 15 00 00 00 4F 74 74 65 72 5F
22D60: 43 68 61 72 61 63 74 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  22D52 | u4     |          05C88C24 |            613206021 | index       |
|  22D56 | s4     |          15000000 |                   21 | length      |
|  22D5A | string | 4F7474 ... 5F4300 | Otter_Character_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22D60:                                              81
22D70: 62 50 7B 6F 00 00 00 2F 47 61 6D 65 2F 50 72 69
22D80: 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75
22D90: 65 70 72 69 6E 74 73 2F 44 69 6E 6F 43 68 61 72
22DA0: 61 63 74 65 72 53 74 61 74 75 73 43 6F 6D 70 6F
22DB0: 6E 65 6E 74 5F 42 50 5F 4F 74 74 65 72 2E 44 69
22DC0: 6E 6F 43 68 61 72 61 63 74 65 72 53 74 61 74 75
22DD0: 73 43 6F 6D 70 6F 6E 65 6E 74 5F 42 50 5F 4F 74
22DE0: 74 65 72 5F 43 00
```

| offset | type   |           value h |                                                                                                        value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------: | ----------- |
|  22D6F | u4     |          8162507B |                                                                                                     2068865665 | index       |
|  22D73 | s4     |          6F000000 |                                                                                                            111 | length      |
|  22D77 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/DinoCharacterStatusComponent_BP_Otter.DinoCharacterStatusComponent_BP_Otter_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22DE0:                   AA D3 07 85 20 00 00 00 44 69
22DF0: 6E 6F 43 68 61 72 61 63 74 65 72 53 74 61 74 75
22E00: 73 5F 42 50 5F 4F 74 74 65 72 5F 43 31 00
```

| offset | type   |           value h |                         value d | description |
| -----: | ------ | ----------------: | ------------------------------: | ----------- |
|  22DE6 | u4     |          AAD30785 |                      2231882666 | index       |
|  22DEA | s4     |          20000000 |                              32 | length      |
|  22DEE | string | 44696E ... 433100 | DinoCharacterStatus_BP_Otter_C1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22E00:                                           53 45
22E10: 18 CE 18 00 00 00 49 6E 68 65 72 69 74 57 65 69
22E20: 67 68 74 4D 75 74 61 62 6C 65 5B 30 5D 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  22E0E | u4     |          534518CE |              3457697107 | index       |
|  22E12 | s4     |          18000000 |                      24 | length      |
|  22E16 | string | 496E68 ... 305D00 | InheritWeightMutable[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22E20:                                           08 80
22E30: 35 2C 11 00 00 00 45 78 6F 74 69 63 43 61 72 72
22E40: 69 65 72 5B 30 5D 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  22E2E | u4     |          0880352C |        741703688 | index       |
|  22E32 | s4     |          11000000 |               17 | length      |
|  22E36 | string | 45786F ... 305D00 | ExoticCarrier[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22E40:                      30 38 63 AA 17 00 00 00 49
22E50: 6E 68 65 72 69 74 53 74 61 6D 69 6E 61 46 72 61
22E60: 69 6C 5B 30 5D 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  22E47 | u4     |          303863AA |             2858629168 | index       |
|  22E4B | s4     |          17000000 |                     23 | length      |
|  22E4F | string | 496E68 ... 305D00 | InheritStaminaFrail[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22E60:                   4C 15 03 E5 14 00 00 00 49 6E
22E70: 68 65 72 69 74 46 6F 6F 64 46 72 61 69 6C 5B 30
22E80: 5D 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  22E66 | u4     |          4C1503E5 |          3842184524 | index       |
|  22E6A | s4     |          14000000 |                  20 | length      |
|  22E6E | string | 496E68 ... 305D00 | InheritFoodFrail[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22E80:       57 6F 87 08 08 00 00 00 43 6F 6C 64 5B 31
22E90: 5D 00
```

| offset | type   |          value h |   value d | description |
| -----: | ------ | ---------------: | --------: | ----------- |
|  22E82 | u4     |         576F8708 | 143093591 | index       |
|  22E86 | s4     |         08000000 |         8 | length      |
|  22E8A | string | 436F6C645B315D00 |   Cold[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22E90:       99 BE 4D 72 10 00 00 00 47 69 61 6E 74 73
22EA0: 6C 61 79 69 6E 67 5B 30 5D 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  22E92 | u4     |          99BE4D72 |      1917697689 | index       |
|  22E96 | s4     |          10000000 |              16 | length      |
|  22E9A | string | 476961 ... 305D00 | Giantslaying[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22EA0:                               DA 55 31 27 0D 00
22EB0: 00 00 45 78 63 69 74 61 62 6C 65 5B 30 5D 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  22EAA | u4     |          DA553127 |    657544666 | index       |
|  22EAE | s4     |          0D000000 |           13 | length      |
|  22EB2 | string | 457863 ... 305D00 | Excitable[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22EB0:                                              99
22EC0: F8 BF 45 16 00 00 00 49 6E 68 65 72 69 74 4D 65
22ED0: 6C 65 65 52 6F 62 75 73 74 5B 31 5D 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  22EBF | u4     |          99F8BF45 |            1170208921 | index       |
|  22EC3 | s4     |          16000000 |                    22 | length      |
|  22EC7 | string | 496E68 ... 315D00 | InheritMeleeRobust[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22ED0:                                        8F 04 EE
22EE0: 1D 23 00 00 00 2F 53 63 72 69 70 74 2F 53 68 6F
22EF0: 6F 74 65 72 47 61 6D 65 2E 4E 50 43 5A 6F 6E 65
22F00: 4D 61 6E 61 67 65 72 00
```

| offset | type   |           value h |                            value d | description |
| -----: | ------ | ----------------: | ---------------------------------: | ----------- |
|  22EDD | u4     |          8F04EE1D |                          502137999 | index       |
|  22EE1 | s4     |          23000000 |                                 35 | length      |
|  22EE5 | string | 2F5363 ... 657200 | /Script/ShooterGame.NPCZoneManager | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22F00:                         3E 5D CB 64 22 00 00 00
22F10: 2F 53 63 72 69 70 74 2F 53 68 6F 6F 74 65 72 47
22F20: 61 6D 65 2E 4E 50 43 5A 6F 6E 65 56 6F 6C 75 6D
22F30: 65 00
```

| offset | type   |           value h |                           value d | description |
| -----: | ------ | ----------------: | --------------------------------: | ----------- |
|  22F08 | u4     |          3E5DCB64 |                        1691049278 | index       |
|  22F0C | s4     |          22000000 |                                34 | length      |
|  22F10 | string | 2F5363 ... 6D6500 | /Script/ShooterGame.NPCZoneVolume | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22F30:       85 F4 69 E0 5D 00 00 00 2F 47 61 6D 65 2F
22F40: 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65
22F50: 42 6C 75 65 70 72 69 6E 74 73 2F 4E 50 43 5A 6F
22F60: 6E 65 4D 61 6E 61 67 65 72 42 6C 75 65 70 72 69
22F70: 6E 74 5F 4C 61 6E 64 2E 4E 50 43 5A 6F 6E 65 4D
22F80: 61 6E 61 67 65 72 42 6C 75 65 70 72 69 6E 74 5F
22F90: 4C 61 6E 64 5F 43 00
```

| offset | type   |           value h |                                                                                      value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------: | ----------- |
|  22F32 | u4     |          85F469E0 |                                                                                   3765040261 | index       |
|  22F36 | s4     |          5D000000 |                                                                                           93 | length      |
|  22F3A | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/NPCZoneManagerBlueprint_Land.NPCZoneManagerBlueprint_Land_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22F90:                      8A 65 18 D1 5D 00 00 00 2F
22FA0: 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68
22FB0: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
22FC0: 4E 50 43 5A 6F 6E 65 4D 61 6E 61 67 65 72 42 6C
22FD0: 75 65 70 72 69 6E 74 5F 43 61 76 65 2E 4E 50 43
22FE0: 5A 6F 6E 65 4D 61 6E 61 67 65 72 42 6C 75 65 70
22FF0: 72 69 6E 74 5F 43 61 76 65 5F 43 00
```

| offset | type   |           value h |                                                                                      value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------: | ----------- |
|  22F97 | u4     |          8A6518D1 |                                                                                   3508037002 | index       |
|  22F9B | s4     |          5D000000 |                                                                                           93 | length      |
|  22F9F | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/NPCZoneManagerBlueprint_Cave.NPCZoneManagerBlueprint_Cave_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
22FF0:                                     DF A6 FF F6
23000: 13 00 00 00 48 69 62 65 72 6E 61 74 65 64 45 6E
23010: 74 69 74 69 65 73 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  22FFC | u4     |          DFA6FFF6 |         4143949535 | index       |
|  23000 | s4     |          13000000 |                 19 | length      |
|  23004 | string | 486962 ... 657300 | HibernatedEntities | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23010:                      D4 9A C0 22 15 00 00 00 48
23020: 69 62 65 72 6E 61 74 69 6F 6E 43 6F 75 6E 74 49
23030: 6E 66 6F 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  23017 | u4     |          D49AC022 |            583047892 | index       |
|  2301B | s4     |          15000000 |                   21 | length      |
|  2301F | string | 486962 ... 666F00 | HibernationCountInfo | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23030:             64 47 AA AE 0A 00 00 00 43 6C 61 73
23040: 73 54 79 70 65 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  23034 | u4     |          6447AAAE | 2930394980 | index       |
|  23038 | s4     |          0A000000 |         10 | length      |
|  2303C | string | 436C61 ... 706500 |  ClassType | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23040:                   10 21 84 ED 13 00 00 00 53 6F
23050: 66 74 4F 62 6A 65 63 74 50 72 6F 70 65 72 74 79
23060: 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  23046 | u4     |          102184ED |         3984859408 | index       |
|  2304A | s4     |          13000000 |                 19 | length      |
|  2304E | string | 536F66 ... 747900 | SoftObjectProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23060:    83 5D 02 41 06 00 00 00 43 6F 75 6E 74 00
```

| offset | type   |      value h |    value d | description |
| -----: | ------ | -----------: | ---------: | ----------- |
|  23061 | u4     |     835D0241 | 1090674051 | index       |
|  23065 | s4     |     06000000 |          6 | length      |
|  23069 | string | 436F756E7400 |      Count | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23060:                                              BC
23070: 96 C3 15 10 00 00 00 46 69 72 73 74 55 70 64 61
23080: 74 65 54 69 6D 65 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  2306F | u4     |          BC96C315 |       365139644 | index       |
|  23073 | s4     |          10000000 |              16 | length      |
|  23077 | string | 466972 ... 6D6500 | FirstUpdateTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23080:                      70 5D A9 F4 0E 00 00 00 4E
23090: 75 6D 4E 50 43 53 70 61 77 6E 65 64 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  23087 | u4     |          705DA9F4 |    4104740208 | index       |
|  2308B | s4     |          0E000000 |            14 | length      |
|  2308F | string | 4E756D ... 656400 | NumNPCSpawned | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23090:                                        6E 29 9E
230A0: 96 11 00 00 00 4E 75 6D 53 70 61 77 6E 46 61 69
230B0: 6C 75 72 65 73 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  2309D | u4     |          6E299E96 |       2526947694 | index       |
|  230A1 | s4     |          11000000 |               17 | length      |
|  230A5 | string | 4E756D ... 657300 | NumSpawnFailures | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
230B0:                   A9 01 5B B1 14 00 00 00 4C 61
230C0: 73 74 49 6E 63 72 65 61 73 65 4E 50 43 54 69 6D
230D0: 65 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  230B6 | u4     |          A9015BB1 |          2975531433 | index       |
|  230BA | s4     |          14000000 |                  20 | length      |
|  230BE | string | 4C6173 ... 6D6500 | LastIncreaseNPCTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
230D0:       AE 98 58 CA 43 00 00 00 2F 47 61 6D 65 2F
230E0: 50 72 69 6D 61 6C 45 61 72 74 68 2F 53 74 72 75
230F0: 63 74 75 72 65 73 2F 54 72 69 62 75 74 65 54 65
23100: 72 6D 69 6E 61 6C 5F 31 2E 54 72 69 62 75 74 65
23110: 54 65 72 6D 69 6E 61 6C 5F 31 5F 43 00
```

| offset | type   |           value h |                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------: | ----------- |
|  230D2 | u4     |          AE9858CA |                                                         3394803886 | index       |
|  230D6 | s4     |          43000000 |                                                                 67 | length      |
|  230DA | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Structures/TributeTerminal_1.TributeTerminal_1_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23110:                                        FA 7C 26
23120: 00 15 00 00 00 4D 79 49 6E 76 65 6E 74 6F 72 79
23130: 43 6F 6D 70 6F 6E 65 6E 74 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  2311D | u4     |          FA7C2600 |              2522362 | index       |
|  23121 | s4     |          15000000 |                   21 | length      |
|  23125 | string | 4D7949 ... 6E7400 | MyInventoryComponent | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23130:                               06 A2 76 07 14 00
23140: 00 00 62 43 6F 6E 74 61 69 6E 65 72 41 63 74 69
23150: 76 61 74 65 64 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  2313A | u4     |          06A27607 |           125215238 | index       |
|  2313E | s4     |          14000000 |                  20 | length      |
|  23142 | string | 62436F ... 656400 | bContainerActivated | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23150:                   4F F0 49 E6 0D 00 00 00 4D 61
23160: 78 49 74 65 6D 43 6F 75 6E 74 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  23156 | u4     |          4FF049E6 |   3863605327 | index       |
|  2315A | s4     |          0D000000 |           13 | length      |
|  2315E | string | 4D6178 ... 6E7400 | MaxItemCount | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23160:                                  FB F5 15 53 12
23170: 00 00 00 4C 61 73 74 41 63 74 69 76 61 74 65 64
23180: 54 69 6D 65 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  2316B | u4     |          FBF51553 |        1393948155 | index       |
|  2316F | s4     |          12000000 |                18 | length      |
|  23173 | string | 4C6173 ... 6D6500 | LastActivatedTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23180:                24 43 9B B5 0C 00 00 00 53 74 72
23190: 75 63 74 75 72 65 49 44 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  23185 | u4     |          24439BB5 |  3046851364 | index       |
|  23189 | s4     |          0C000000 |          12 | length      |
|  2318D | string | 537472 ... 494400 | StructureID | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23190:                            D5 7F 36 05 13 00 00
231A0: 00 62 48 61 73 52 65 73 65 74 44 65 63 61 79 54
231B0: 69 6D 65 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  23199 | u4     |          D57F3605 |           87457749 | index       |
|  2319D | s4     |          13000000 |                 19 | length      |
|  231A1 | string | 624861 ... 6D6500 | bHasResetDecayTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
231B0:             62 86 E3 5D 0A 00 00 00 4D 61 78 48
231C0: 65 61 6C 74 68 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  231B4 | u4     |          6286E35D | 1575192162 | index       |
|  231B8 | s4     |          0A000000 |         10 | length      |
|  231BC | string | 4D6178 ... 746800 |  MaxHealth | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
231C0:                   3A 12 42 7B 3F 00 00 00 2F 47
231D0: 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F
231E0: 54 65 73 74 2F 44 72 6F 70 70 65 64 49 74 65 6D
231F0: 47 65 6E 65 72 69 63 2E 44 72 6F 70 70 65 64 49
23200: 74 65 6D 47 65 6E 65 72 69 63 5F 43 00
```

| offset | type   |           value h |                                                        value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------: | ----------- |
|  231C6 | u4     |          3A12427B |                                                     2067927610 | index       |
|  231CA | s4     |          3F000000 |                                                             63 | length      |
|  231CE | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Test/DroppedItemGeneric.DroppedItemGeneric_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23200:                                        DF 51 A7
23210: BD 07 00 00 00 4D 79 49 74 65 6D 00
```

| offset | type   |        value h |    value d | description |
| -----: | ------ | -------------: | ---------: | ----------- |
|  2320D | u4     |       DF51A7BD | 3181859295 | index       |
|  23211 | s4     |       07000000 |          7 | length      |
|  23215 | string | 4D794974656D00 |     MyItem | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23210:                                     39 28 EF 5D
23220: 0E 00 00 00 44 72 6F 70 70 65 64 42 79 4E 61 6D
23230: 65 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  2321C | u4     |          3928EF5D |    1575954489 | index       |
|  23220 | s4     |          0E000000 |            14 | length      |
|  23224 | string | 44726F ... 6D6500 | DroppedByName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23230:       80 FF 9F A8 0C 00 00 00 53 74 72 50 72 6F
23240: 70 65 72 74 79 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  23232 | u4     |          80FF9FA8 |  2829057920 | index       |
|  23236 | s4     |          0C000000 |          12 | length      |
|  2323A | string | 537472 ... 747900 | StrProperty | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23240:                   AC DE 61 D8 12 00 00 00 44 72
23250: 6F 70 70 65 64 42 79 50 6C 61 79 65 72 49 44 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  23246 | u4     |          ACDE61D8 |        3630292652 | index       |
|  2324A | s4     |          12000000 |                18 | length      |
|  2324E | string | 44726F ... 494400 | DroppedByPlayerID | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23260: 74 85 93 B2 0F 00 00 00 55 49 6E 74 36 34 50 72
23270: 6F 70 65 72 74 79 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  23260 | u4     |          748593B2 |     2996012404 | index       |
|  23264 | s4     |          0F000000 |             15 | length      |
|  23268 | string | 55496E ... 747900 | UInt64Property | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23270:                      7B 04 69 F5 11 00 00 00 57
23280: 69 6C 64 46 6F 6C 6C 6F 77 65 72 52 65 66 73 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  23277 | u4     |          7B0469F5 |       4117300347 | index       |
|  2327B | s4     |          11000000 |               17 | length      |
|  2327F | string | 57696C ... 667300 | WildFollowerRefs | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23290: DC A3 8A 81 16 00 00 00 49 6E 68 65 72 69 74 48
232A0: 65 61 6C 74 68 46 72 61 69 6C 5B 31 5D 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  23290 | u4     |          DCA38A81 |            2173346780 | index       |
|  23294 | s4     |          16000000 |                    22 | length      |
|  23298 | string | 496E68 ... 315D00 | InheritHealthFrail[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
232A0:                                           48 7B
232B0: 9D 3B 12 00 00 00 62 49 73 50 61 72 65 6E 74 57
232C0: 69 6C 64 44 69 6E 6F 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  232AE | u4     |          487B9D3B |        1000176456 | index       |
|  232B2 | s4     |          12000000 |                18 | length      |
|  232B6 | string | 624973 ... 6E6F00 | bIsParentWildDino | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
232C0:                         93 0F 9E 7D 14 00 00 00
232D0: 62 50 72 65 76 65 6E 74 48 69 62 65 72 6E 61 74
232E0: 69 6F 6E 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  232C8 | u4     |          930F9E7D |          2107510675 | index       |
|  232CC | s4     |          14000000 |                  20 | length      |
|  232D0 | string | 625072 ... 6F6E00 | bPreventHibernation | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
232E0:             AA 18 1E 26 06 00 00 00 4F 77 6E 65
232F0: 72 00
```

| offset | type   |      value h |   value d | description |
| -----: | ------ | -----------: | --------: | ----------- |
|  232E4 | u4     |     AA181E26 | 639506602 | index       |
|  232E8 | s4     |     06000000 |         6 | length      |
|  232EC | string | 4F776E657200 |     Owner | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
232F0:       E1 D3 D0 72 26 00 00 00 2F 53 63 72 69 70
23300: 74 2F 46 6F 6C 69 61 67 65 2E 49 6E 73 74 61 6E
23310: 63 65 64 46 6F 6C 69 61 67 65 41 63 74 6F 72 00
```

| offset | type   |           value h |                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------: | ----------- |
|  232F2 | u4     |          E1D3D072 |                            1926288353 | index       |
|  232F6 | s4     |          26000000 |                                    38 | length      |
|  232FA | string | 2F5363 ... 6F7200 | /Script/Foliage.InstancedFoliageActor | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23320: 08 67 09 1D 14 00 00 00 49 6E 73 74 61 6E 63 65
23330: 73 56 69 73 69 62 69 6C 69 74 79 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  23320 | u4     |          0867091D |           487155464 | index       |
|  23324 | s4     |          14000000 |                  20 | length      |
|  23328 | string | 496E73 ... 747900 | InstancesVisibility | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23330:                                     A7 26 26 B1
23340: 18 00 00 00 62 52 65 70 6C 69 63 61 74 65 54 68
23350: 69 73 43 6F 6D 70 6F 6E 65 6E 74 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  2333C | u4     |          A72626B1 |              2972067495 | index       |
|  23340 | s4     |          18000000 |                      24 | length      |
|  23344 | string | 625265 ... 6E7400 | bReplicateThisComponent | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23350:                                     27 D6 AC 9C
23360: 0C 00 00 00 53 70 72 69 6E 74 65 72 5B 31 5D 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  2335C | u4     |          27D6AC9C |  2628572711 | index       |
|  23360 | s4     |          0C000000 |          12 | length      |
|  23364 | string | 537072 ... 315D00 | Sprinter[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23370: 7B E8 06 21 0E 00 00 00 44 69 6E 6F 41 6E 63 65
23380: 73 74 6F 72 73 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  23370 | u4     |          7BE80621 |     554100859 | index       |
|  23374 | s4     |          0E000000 |            14 | length      |
|  23378 | string | 44696E ... 727300 | DinoAncestors | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23380:                   EB B4 F0 9B 13 00 00 00 44 69
23390: 6E 6F 41 6E 63 65 73 74 6F 72 73 45 6E 74 72 79
233A0: 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  23386 | u4     |          EBB4F09B |         2616243435 | index       |
|  2338A | s4     |          13000000 |                 19 | length      |
|  2338E | string | 44696E ... 727900 | DinoAncestorsEntry | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
233A0:    C0 07 D0 88 09 00 00 00 4D 61 6C 65 4E 61 6D
233B0: 65 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  233A1 | u4     |          C007D088 | 2295334848 | index       |
|  233A5 | s4     |          09000000 |          9 | length      |
|  233A9 | string | 4D616C ... 6D6500 |   MaleName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
233B0:       2D B6 B5 47 0C 00 00 00 4D 61 6C 65 44 69
233C0: 6E 6F 49 44 31 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  233B2 | u4     |          2DB6B547 |  1203090989 | index       |
|  233B6 | s4     |          0C000000 |          12 | length      |
|  233BA | string | 4D616C ... 443100 | MaleDinoID1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
233C0:                   ED 4E EA 74 0C 00 00 00 4D 61
233D0: 6C 65 44 69 6E 6F 49 44 32 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  233C6 | u4     |          ED4EEA74 |  1961512685 | index       |
|  233CA | s4     |          0C000000 |          12 | length      |
|  233CE | string | 4D616C ... 443200 | MaleDinoID2 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
233D0:                               07 A0 A3 70 0B 00
233E0: 00 00 46 65 6D 61 6C 65 4E 61 6D 65 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  233DA | u4     |          07A0A370 | 1889771527 | index       |
|  233DE | s4     |          0B000000 |         11 | length      |
|  233E2 | string | 46656D ... 6D6500 | FemaleName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
233E0:                                        03 59 58
233F0: ED 0E 00 00 00 46 65 6D 61 6C 65 44 69 6E 6F 49
23400: 44 31 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  233ED | u4     |          035958ED |    3981990147 | index       |
|  233F1 | s4     |          0E000000 |            14 | length      |
|  233F5 | string | 46656D ... 443100 | FemaleDinoID1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23400:          C3 A1 07 DE 0E 00 00 00 46 65 6D 61 6C
23410: 65 44 69 6E 6F 49 44 32 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  23403 | u4     |          C3A107DE |    3725042115 | index       |
|  23407 | s4     |          0E000000 |            14 | length      |
|  2340B | string | 46656D ... 443200 | FemaleDinoID2 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23410:                            2D 45 72 68 17 00 00
23420: 00 57 69 6C 64 46 6F 6C 6C 6F 77 69 6E 67 50 61
23430: 72 65 6E 74 52 65 66 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  23419 | u4     |          2D457268 |             1752319277 | index       |
|  2341D | s4     |          17000000 |                     23 | length      |
|  23421 | string | 57696C ... 656600 | WildFollowingParentRef | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23430:                         3D 43 E2 E9 19 00 00 00
23440: 4C 61 73 74 55 70 64 61 74 65 64 42 61 62 79 41
23450: 67 65 41 74 54 69 6D 65 00
```

| offset | type   |           value h |                  value d | description |
| -----: | ------ | ----------------: | -----------------------: | ----------- |
|  23438 | u4     |          3D43E2E9 |               3923919677 | index       |
|  2343C | s4     |          19000000 |                       25 | length      |
|  23440 | string | 4C6173 ... 6D6500 | LastUpdatedBabyAgeAtTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23450:                            0A 73 C8 34 18 00 00
23460: 00 4C 61 73 74 55 70 64 61 74 65 64 4D 61 74 69
23470: 6E 67 41 74 54 69 6D 65 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  23459 | u4     |          0A73C834 |               885551882 | index       |
|  2345D | s4     |          18000000 |                      24 | length      |
|  23461 | string | 4C6173 ... 6D6500 | LastUpdatedMatingAtTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23470:                            93 B3 AF A8 08 00 00
23480: 00 42 61 62 79 41 67 65 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  23479 | u4     |         93B3AFA8 | 2830087059 | index       |
|  2347D | s4     |         08000000 |          8 | length      |
|  23481 | string | 4261627941676500 |    BabyAge | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23480:                            AA 80 F7 81 12 00 00
23490: 00 46 6F 72 63 65 64 57 69 6C 64 42 61 62 79 41
234A0: 67 65 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  23489 | u4     |          AA80F781 |        2180481194 | index       |
|  2348D | s4     |          12000000 |                18 | length      |
|  23491 | string | 466F72 ... 676500 | ForcedWildBabyAge | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
234A0:          A5 ED B5 5A 20 00 00 00 62 49 73 41 57
234B0: 69 6C 64 46 6F 6C 6C 6F 77 65 72 4B 6E 6F 77 6E
234C0: 53 65 72 76 65 72 73 69 64 65 00
```

| offset | type   |           value h |                         value d | description |
| -----: | ------ | ----------------: | ------------------------------: | ----------- |
|  234A3 | u4     |          A5EDB55A |                      1521872293 | index       |
|  234A7 | s4     |          20000000 |                              32 | length      |
|  234AB | string | 624973 ... 646500 | bIsAWildFollowerKnownServerside | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
234C0:                                  44 B6 26 A7 08
234D0: 00 00 00 62 49 73 42 61 62 79 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  234CB | u4     |         44B626A7 | 2804332100 | index       |
|  234CF | s4     |         08000000 |          8 | length      |
|  234D3 | string | 6249734261627900 |    bIsBaby | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
234D0:                                  B2 7C 4A 70 18
234E0: 00 00 00 62 42 61 62 79 49 6E 69 74 69 61 6C 6C
234F0: 79 55 6E 63 6C 61 69 6D 65 64 00
```

| offset | type   |           value h |                 value d | description |
| -----: | ------ | ----------------: | ----------------------: | ----------- |
|  234DB | u4     |          B27C4A70 |              1883929778 | index       |
|  234DF | s4     |          18000000 |                      24 | length      |
|  234E3 | string | 624261 ... 656400 | bBabyInitiallyUnclaimed | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
234F0:                                  10 C1 36 B9 17
23500: 00 00 00 62 49 67 6E 6F 72 65 4E 50 43 43 6F 75
23510: 6E 74 56 6F 6C 75 6D 65 73 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  234FB | u4     |          10C136B9 |             3107373328 | index       |
|  234FF | s4     |          17000000 |                     23 | length      |
|  23503 | string | 624967 ... 657300 | bIgnoreNPCCountVolumes | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23510:                               80 E0 7C D3 4B 00
23520: 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61
23530: 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E
23540: 74 73 2F 50 6C 61 79 65 72 50 61 77 6E 54 65 73
23550: 74 5F 4D 61 6C 65 2E 50 6C 61 79 65 72 50 61 77
23560: 6E 54 65 73 74 5F 4D 61 6C 65 5F 43 00
```

| offset | type   |           value h |                                                                    value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------: | ----------- |
|  2351A | u4     |          80E07CD3 |                                                                 3548176512 | index       |
|  2351E | s4     |          4B000000 |                                                                         75 | length      |
|  23522 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/PlayerPawnTest_Male.PlayerPawnTest_Male_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23560:                                        3D EB 22
23570: 8C 14 00 00 00 43 75 72 72 65 6E 74 57 65 61 70
23580: 6F 6E 49 74 65 6D 49 44 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  2356D | u4     |          3DEB228C |          2351098685 | index       |
|  23571 | s4     |          14000000 |                  20 | length      |
|  23575 | string | 437572 ... 494400 | CurrentWeaponItemID | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23580:                            16 D0 7F 46 0A 00 00
23590: 00 49 74 65 6D 4E 65 74 49 44 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  23589 | u4     |          16D07F46 | 1182781462 | index       |
|  2358D | s4     |          0A000000 |         10 | length      |
|  23591 | string | 497465 ... 494400 |  ItemNetID | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23590:                                  9A 90 86 7F 08
235A0: 00 00 00 49 74 65 6D 49 44 31 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  2359B | u4     |         9A90867F | 2139525274 | index       |
|  2359F | s4     |         08000000 |          8 | length      |
|  235A3 | string | 4974656D49443100 |    ItemID1 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
235A0:                                  5A 68 D9 4C 08
235B0: 00 00 00 49 74 65 6D 49 44 32 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  235AB | u4     |         5A68D94C | 1289316442 | index       |
|  235AF | s4     |         08000000 |          8 | length      |
|  235B3 | string | 4974656D49443200 |    ItemID2 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
235B0:                                  4A 12 D8 FB 0B
235C0: 00 00 00 50 6C 61 79 65 72 4E 61 6D 65 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  235BB | u4     |          4A12D8FB | 4225241674 | index       |
|  235BF | s4     |          0B000000 |         11 | length      |
|  235C3 | string | 506C61 ... 6D6500 | PlayerName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
235C0:                                           D3 EC
235D0: ED CC 14 00 00 00 50 6C 61 74 66 6F 72 6D 50 72
235E0: 6F 66 69 6C 65 4E 61 6D 65 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  235CE | u4     |          D3ECEDCC |          3438144723 | index       |
|  235D2 | s4     |          14000000 |                  20 | length      |
|  235D6 | string | 506C61 ... 6D6500 | PlatformProfileName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
235E0:                               6F 86 1E 9A 12 00
235F0: 00 00 50 6C 61 74 66 6F 72 6D 50 72 6F 66 69 6C
23600: 65 49 44 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  235EA | u4     |          6F861E9A |        2585691759 | index       |
|  235EE | s4     |          12000000 |                18 | length      |
|  235F2 | string | 506C61 ... 494400 | PlatformProfileID | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23600:             84 48 CC 5B 10 00 00 00 55 6E 69 71
23610: 75 65 4E 65 74 49 64 52 65 70 6C 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  23604 | u4     |          8448CC5B |      1540114564 | index       |
|  23608 | s4     |          10000000 |              16 | length      |
|  2360C | string | 556E69 ... 706C00 | UniqueNetIdRepl | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23610:                                     71 8B BE E7
23620: 0F 00 00 00 2F 53 63 72 69 70 74 2F 45 6E 67 69
23630: 6E 65 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  2361C | u4     |          718BBEE7 |     3888024433 | index       |
|  23620 | s4     |          0F000000 |             15 | length      |
|  23624 | string | 2F5363 ... 6E6500 | /Script/Engine | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23630:          92 C9 62 0D 0B 00 00 00 42 6F 64 79 43
23640: 6F 6C 6F 72 73 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  23633 | u4     |          92C9620D |  224577938 | index       |
|  23637 | s4     |          0B000000 |         11 | length      |
|  2363B | string | 426F64 ... 727300 | BodyColors | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23640:                   B4 05 F2 63 0C 00 00 00 4C 69
23650: 6E 65 61 72 43 6F 6C 6F 72 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  23646 | u4     |          B405F263 |  1676805556 | index       |
|  2364A | s4     |          0C000000 |          12 | length      |
|  2364E | string | 4C696E ... 6F7200 | LinearColor | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23650:                               C2 93 DE 90 12 00
23660: 00 00 4F 72 69 67 69 6E 61 6C 48 61 69 72 43 6F
23670: 6C 6F 72 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  2365A | u4     |          C293DE90 |        2430505922 | index       |
|  2365E | s4     |          12000000 |                18 | length      |
|  23662 | string | 4F7269 ... 6F7200 | OriginalHairColor | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23670:             90 C6 A7 F9 0E 00 00 00 43 75 72 72
23680: 65 6E 74 57 65 61 70 6F 6E 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  23674 | u4     |          90C6A7F9 |    4188522128 | index       |
|  23678 | s4     |          0E000000 |            14 | length      |
|  2367C | string | 437572 ... 6F6E00 | CurrentWeapon | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23680:                               0D DD 8D C0 1B 00
23690: 00 00 53 61 76 65 64 4C 61 73 74 54 69 6D 65 48
236A0: 61 64 43 6F 6E 74 72 6F 6C 6C 65 72 00
```

| offset | type   |           value h |                    value d | description |
| -----: | ------ | ----------------: | -------------------------: | ----------- |
|  2368A | u4     |          0DDD8DC0 |                 3230522637 | index       |
|  2368E | s4     |          1B000000 |                         27 | length      |
|  23692 | string | 536176 ... 657200 | SavedLastTimeHadController | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
236A0:                                        58 63 B5
236B0: 6C 13 00 00 00 4C 69 6E 6B 65 64 50 6C 61 79 65
236C0: 72 44 61 74 61 49 44 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  236AD | u4     |          5863B56C |         1823826776 | index       |
|  236B1 | s4     |          13000000 |                 19 | length      |
|  236B5 | string | 4C696E ... 494400 | LinkedPlayerDataID | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
236C0:                         02 97 29 47 1C 00 00 00
236D0: 50 65 72 63 65 6E 74 4F 66 46 75 6C 6C 48 65 61
236E0: 64 48 61 69 72 47 72 6F 77 74 68 00
```

| offset | type   |           value h |                     value d | description |
| -----: | ------ | ----------------: | --------------------------: | ----------- |
|  236C8 | u4     |          02972947 |                  1193907970 | index       |
|  236CC | s4     |          1C000000 |                          28 | length      |
|  236D0 | string | 506572 ... 746800 | PercentOfFullHeadHairGrowth | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
236E0:                                     29 36 0D C0
236F0: 10 00 00 00 46 61 63 69 61 6C 48 61 69 72 49 6E
23700: 64 65 78 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  236EC | u4     |          29360DC0 |      3222091305 | index       |
|  236F0 | s4     |          10000000 |              16 | length      |
|  236F4 | string | 466163 ... 657800 | FacialHairIndex | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23700:             11 34 7D 1F 0E 00 00 00 48 65 61 64
23710: 48 61 69 72 49 6E 64 65 78 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  23704 | u4     |          11347D1F |     528299025 | index       |
|  23708 | s4     |          0E000000 |            14 | length      |
|  2370C | string | 486561 ... 657800 | HeadHairIndex | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23710:                               06 A4 89 5F 15 00
23720: 00 00 44 79 6E 61 6D 69 63 4D 61 74 65 72 69 61
23730: 6C 42 79 74 65 73 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  2371A | u4     |          06A4895F |           1602855942 | index       |
|  2371E | s4     |          15000000 |                   21 | length      |
|  23722 | string | 44796E ... 657300 | DynamicMaterialBytes | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23730:                      72 E7 B6 23 19 00 00 00 44
23740: 79 6E 61 6D 69 63 46 61 63 65 4D 61 74 65 72 69
23750: 61 6C 42 79 74 65 73 00
```

| offset | type   |           value h |                  value d | description |
| -----: | ------ | ----------------: | -----------------------: | ----------- |
|  23737 | u4     |          72E7B623 |                599189362 | index       |
|  2373B | s4     |          19000000 |                       25 | length      |
|  2373F | string | 44796E ... 657300 | DynamicFaceMaterialBytes | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23750:                         0A 80 C5 6A 12 00 00 00
23760: 62 47 61 76 65 49 6E 69 74 69 61 6C 49 74 65 6D
23770: 73 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  23758 | u4     |          0A80C56A |        1791328266 | index       |
|  2375C | s4     |          12000000 |                18 | length      |
|  23760 | string | 624761 ... 6D7300 | bGaveInitialItems | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23770:       04 4C EB 71 0A 00 00 00 54 72 69 62 65 4E
23780: 61 6D 65 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  23772 | u4     |          044CEB71 | 1911245828 | index       |
|  23776 | s4     |          0A000000 |         10 | length      |
|  2377A | string | 547269 ... 6D6500 |  TribeName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23780:             B4 2F 71 9B 12 00 00 00 44 69 6E 6F
23790: 41 6E 63 65 73 74 6F 72 73 4D 61 6C 65 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  23784 | u4     |          B42F719B |        2607886260 | index       |
|  23788 | s4     |          12000000 |                18 | length      |
|  2378C | string | 44696E ... 6C6500 | DinoAncestorsMale | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23790:                                           86 35
237A0: 2E 30 63 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
237B0: 73 2F 53 74 65 61 6D 70 75 6E 6B 2F 43 6F 72 65
237C0: 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73
237D0: 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
237E0: 44 61 70 70 65 72 53 68 69 72 74 2E 50 72 69 6D
237F0: 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 61 70 70 65
23800: 72 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  2379E | u4     |          86352E30 |                                                                                          808334726 | index       |
|  237A2 | s4     |          63000000 |                                                                                                 99 | length      |
|  237A6 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_DapperShirt.PrimalItemSkin_DapperShirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23800:                            C4 54 B1 4F 5D 00 00
23810: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74 65
23820: 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65 70
23830: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D
23840: 61 6C 49 74 65 6D 53 6B 69 6E 5F 42 65 72 65 74
23850: 48 61 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B
23860: 69 6E 5F 42 65 72 65 74 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                      value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------: | ----------- |
|  23809 | u4     |          C454B14F |                                                                                   1337021636 | index       |
|  2380D | s4     |          5D000000 |                                                                                           93 | length      |
|  23811 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_BeretHat.PrimalItemSkin_BeretHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23860:                                           7E 56
23870: DE F3 64 00 00 00 2F 47 61 6D 65 2F 4C 6F 73 74
23880: 43 6F 6C 6F 6E 79 2F 43 6F 72 65 42 6C 75 65 70
23890: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D
238A0: 61 6C 49 74 65 6D 53 6B 69 6E 5F 54 68 72 61 6C

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
238B0: 6C 54 65 6B 53 77 6F 72 64 2E 50 72 69 6D 61 6C
238C0: 49 74 65 6D 53 6B 69 6E 5F 54 68 72 61 6C 6C 54
238D0: 65 6B 53 77 6F 72 64 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  2386E | u4     |          7E56DEF3 |                                                                                          4091434622 | index       |
|  23872 | s4     |          64000000 |                                                                                                 100 | length      |
|  23876 | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_ThrallTekSword.PrimalItemSkin_ThrallTekSword_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
238D0:                               6C 93 CA BE 62 00
238E0: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
238F0: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
23900: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 54 72
23910: 69 6B 65 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69
23920: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
23930: 41 41 5F 54 72 69 6B 65 5F 53 6B 69 6E 50 61 63
23940: 6B 5F 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  238DA | u4     |          6C93CABE |                                                                                        3200947052 | index       |
|  238DE | s4     |          62000000 |                                                                                                98 | length      |
|  238E2 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Trike_SkinPack.PrimalItemCostume_AAA_Trike_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23940:             25 D5 44 C6 68 00 00 00 2F 47 61 6D
23950: 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E
23960: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
23970: 75 6D 65 5F 41 41 41 5F 50 61 72 61 73 61 75 72
23980: 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D 61 6C
23990: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
239A0: 50 61 72 61 73 61 75 72 5F 53 6B 69 6E 50 61 63
239B0: 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                 value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------------: | ----------- |
|  23944 | u4     |          25D544C6 |                                                                                              3326399781 | index       |
|  23948 | s4     |          68000000 |                                                                                                     104 | length      |
|  2394C | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Parasaur_SkinPack.PrimalItemCostume_AAA_Parasaur_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
239B0:             28 6C EF 82 72 00 00 00 2F 47 61 6D
239C0: 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E
239D0: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
239E0: 5F 43 68 61 72 61 63 74 65 72 53 6B 69 6E 5F 48
239F0: 65 6C 65 6E 61 5F 53 6B 69 6E 50 61 63 6B 2E 50
23A00: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 68
23A10: 61 72 61 63 74 65 72 53 6B 69 6E 5F 48 65 6C 65
23A20: 6E 61 5F 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                           value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------------: | ----------- |
|  239B4 | u4     |          286CEF82 |                                                                                                        2196728872 | index       |
|  239B8 | s4     |          72000000 |                                                                                                               114 | length      |
|  239BC | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Helena_SkinPack.PrimalItemSkin_CharacterSkin_Helena_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23A20:                                           AF 22
23A30: 41 4E 72 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
23A40: 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D
23A50: 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 68 61 72 61
23A60: 63 74 65 72 53 6B 69 6E 5F 41 6C 61 73 69 65 5F
23A70: 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D 61 6C 49
23A80: 74 65 6D 53 6B 69 6E 5F 43 68 61 72 61 63 74 65
23A90: 72 53 6B 69 6E 5F 41 6C 61 73 69 65 5F 53 6B 69
23AA0: 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                           value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------------: | ----------- |
|  23A2E | u4     |          AF22414E |                                                                                                        1312891567 | index       |
|  23A32 | s4     |          72000000 |                                                                                                               114 | length      |
|  23A36 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Alasie_SkinPack.PrimalItemSkin_CharacterSkin_Alasie_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23AA0:                         8F 86 2D 1F 54 00 00 00
23AB0: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
23AC0: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
23AD0: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 54 72 6F 6F
23AE0: 64 6F 6E 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F
23AF0: 73 74 75 6D 65 5F 41 41 41 5F 54 72 6F 6F 64 6F
23B00: 6E 5F 43 00
```

| offset | type   |           value h |                                                                             value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------: | ----------- |
|  23AA8 | u4     |          8F862D1F |                                                                           523077263 | index       |
|  23AAC | s4     |          54000000 |                                                                                  84 | length      |
|  23AB0 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Troodon.PrimalItemCostume_AAA_Troodon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23B00:             AF 6D C0 78 5E 00 00 00 2F 47 61 6D
23B10: 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E
23B20: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
23B30: 75 6D 65 5F 41 41 41 5F 53 70 69 64 65 72 5F 53
23B40: 6D 61 6C 6C 2E 50 72 69 6D 61 6C 49 74 65 6D 43
23B50: 6F 73 74 75 6D 65 5F 41 41 41 5F 53 70 69 64 65
23B60: 72 5F 53 6D 61 6C 6C 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  23B04 | u4     |          AF6DC078 |                                                                                    2025876911 | index       |
|  23B08 | s4     |          5E000000 |                                                                                            94 | length      |
|  23B0C | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Spider_Small.PrimalItemCostume_AAA_Spider_Small_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23B60:                               91 EB BB 8A 54 00
23B70: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
23B80: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
23B90: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 50 69
23BA0: 72 61 6E 68 61 2E 50 72 69 6D 61 6C 49 74 65 6D
23BB0: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 50 69 72 61
23BC0: 6E 68 61 5F 43 00
```

| offset | type   |           value h |                                                                             value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------: | ----------- |
|  23B6A | u4     |          91EBBB8A |                                                                          2327571345 | index       |
|  23B6E | s4     |          54000000 |                                                                                  84 | length      |
|  23B72 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Piranha.PrimalItemCostume_AAA_Piranha_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23BC0:                   A2 68 1D B2 5A 00 00 00 2F 47
23BD0: 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B
23BE0: 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F
23BF0: 73 74 75 6D 65 5F 41 41 41 5F 4D 6F 73 61 73 61
23C00: 75 72 75 73 2E 50 72 69 6D 61 6C 49 74 65 6D 43
23C10: 6F 73 74 75 6D 65 5F 41 41 41 5F 4D 6F 73 61 73
23C20: 61 75 72 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  23BC6 | u4     |          A2681DB2 |                                                                                2988271778 | index       |
|  23BCA | s4     |          5A000000 |                                                                                        90 | length      |
|  23BCE | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Mosasaurus.PrimalItemCostume_AAA_Mosasaurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23C20:                         8C 47 E5 33 5C 00 00 00
23C30: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
23C40: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
23C50: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4B 61 70 72
23C60: 6F 73 75 63 68 75 73 2E 50 72 69 6D 61 6C 49 74
23C70: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4B 61
23C80: 70 72 6F 73 75 63 68 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  23C28 | u4     |          8C47E533 |                                                                                   870664076 | index       |
|  23C2C | s4     |          5C000000 |                                                                                          92 | length      |
|  23C30 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Kaprosuchus.PrimalItemCostume_AAA_Kaprosuchus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23C80:                                     BF 5B 66 30
23C90: 5E 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F
23CA0: 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C
23CB0: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
23CC0: 44 75 6E 6B 6C 65 6F 73 74 65 75 73 2E 50 72 69
23CD0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
23CE0: 41 41 5F 44 75 6E 6B 6C 65 6F 73 74 65 75 73 5F
23CF0: 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  23C8C | u4     |          BF5B6630 |                                                                                     812014527 | index       |
|  23C90 | s4     |          5E000000 |                                                                                            94 | length      |
|  23C94 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Dunkleosteus.PrimalItemCostume_AAA_Dunkleosteus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23CF0:       93 22 A5 53 4E 00 00 00 2F 47 61 6D 65 2F
23D00: 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F
23D10: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
23D20: 65 5F 41 41 41 5F 44 69 6C 6F 2E 50 72 69 6D 61
23D30: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
23D40: 5F 44 69 6C 6F 5F 43 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  23CF2 | u4     |          9322A553 |                                                                    1403331219 | index       |
|  23CF6 | s4     |          4E000000 |                                                                            78 | length      |
|  23CFA | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Dilo.PrimalItemCostume_AAA_Dilo_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23D40:                         4A 57 E7 3E 4C 00 00 00
23D50: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
23D60: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
23D70: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 42 61 74 2E
23D80: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
23D90: 65 5F 41 41 41 5F 42 61 74 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  23D48 | u4     |          4A57E73E |                                                                  1055348554 | index       |
|  23D4C | s4     |          4C000000 |                                                                          76 | length      |
|  23D50 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Bat.PrimalItemCostume_AAA_Bat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23D90:                                     8F 80 A3 9D
23DA0: 79 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F
23DB0: 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65 42 6C
23DC0: 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50
23DD0: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61
23DE0: 73 74 65 6C 61 6E 64 47 68 69 6C 6C 69 65 5F 53
23DF0: 68 69 72 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53
23E00: 6B 69 6E 5F 57 61 73 74 65 6C 61 6E 64 47 68 69
23E10: 6C 6C 69 65 5F 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  23D9C | u4     |          8F80A39D |                                                                                                               2644738191 | index       |
|  23DA0 | s4     |          79000000 |                                                                                                                      121 | length      |
|  23DA4 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WastelandGhillie_Shirt.PrimalItemSkin_WastelandGhillie_Shirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23E10:                                        74 A6 61
23E20: 28 65 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
23E30: 2F 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65 42
23E40: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
23E50: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57
23E60: 61 72 6C 6F 72 64 53 68 69 72 74 2E 50 72 69 6D
23E70: 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 72 6C 6F
23E80: 72 64 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  23E1D | u4     |          74A66128 |                                                                                            677488244 | index       |
|  23E21 | s4     |          65000000 |                                                                                                  101 | length      |
|  23E25 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarlordShirt.PrimalItemSkin_WarlordShirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23E80:                               DC 3F C8 57 7F 00
23E90: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74
23EA0: 65 61 6D 70 75 6E 6B 2F 53 74 72 75 63 74 75 72
23EB0: 65 73 2F 54 69 6C 65 73 65 74 2F 50 72 69 6D 61
23EC0: 6C 49 74 65 6D 53 74 72 75 63 74 75 72 65 53 6B
23ED0: 69 6E 5F 54 69 6C 65 73 65 74 5F 53 74 65 61 6D
23EE0: 70 75 6E 6B 2E 50 72 69 6D 61 6C 49 74 65 6D 53

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23EF0: 74 72 75 63 74 75 72 65 53 6B 69 6E 5F 54 69 6C
23F00: 65 73 65 74 5F 53 74 65 61 6D 70 75 6E 6B 5F 43
23F10: 00
```

| offset | type   |           value h |                                                                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  23E8A | u4     |          DC3FC857 |                                                                                                                     1472741340 | index       |
|  23E8E | s4     |          7F000000 |                                                                                                                            127 | length      |
|  23E92 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/Structures/Tileset/PrimalItemStructureSkin_Tileset_Steampunk.PrimalItemStructureSkin_Tileset_Steampunk_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23F10:    53 63 DA 05 63 00 00 00 2F 47 61 6D 65 2F 50
23F20: 61 63 6B 73 2F 53 74 65 61 6D 70 75 6E 6B 2F 43
23F30: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74
23F40: 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B
23F50: 69 6E 5F 44 61 70 70 65 72 50 61 6E 74 73 2E 50
23F60: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 61
23F70: 70 70 65 72 50 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  23F11 | u4     |          5363DA05 |                                                                                           98198355 | index       |
|  23F15 | s4     |          63000000 |                                                                                                 99 | length      |
|  23F19 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_DapperPants.PrimalItemSkin_DapperPants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23F70:                                     52 50 77 8A
23F80: 77 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F
23F90: 53 74 65 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C
23FA0: 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50
23FB0: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 41 62
23FC0: 65 72 72 61 6E 74 47 68 69 6C 6C 69 65 5F 53 68
23FD0: 69 72 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B
23FE0: 69 6E 5F 41 62 65 72 72 61 6E 74 47 68 69 6C 6C
23FF0: 69 65 5F 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                                                value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------: | ----------- |
|  23F7C | u4     |          5250778A |                                                                                                             2323075154 | index       |
|  23F80 | s4     |          77000000 |                                                                                                                    119 | length      |
|  23F84 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_AberrantGhillie_Shirt.PrimalItemSkin_AberrantGhillie_Shirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
23FF0:                                  82 95 D8 DE 66
24000: 00 00 00 2F 47 61 6D 65 2F 4C 6F 73 74 43 6F 6C
24010: 6F 6E 79 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E
24020: 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49
24030: 74 65 6D 53 6B 69 6E 5F 54 68 72 61 6C 6C 5F 54
24040: 33 5F 53 68 69 72 74 2E 50 72 69 6D 61 6C 49 74
24050: 65 6D 53 6B 69 6E 5F 54 68 72 61 6C 6C 5F 54 33
24060: 5F 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  23FFB | u4     |          8295D8DE |                                                                                            3738736002 | index       |
|  23FFF | s4     |          66000000 |                                                                                                   102 | length      |
|  24003 | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_Thrall_T3_Shirt.PrimalItemSkin_Thrall_T3_Shirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24060:                            58 45 10 B7 62 00 00
24070: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41
24080: 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65
24090: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 53 74 65
240A0: 67 6F 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D
240B0: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
240C0: 41 5F 53 74 65 67 6F 5F 53 6B 69 6E 50 61 63 6B
240D0: 5F 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  24069 | u4     |          584510B7 |                                                                                        3071296856 | index       |
|  2406D | s4     |          62000000 |                                                                                                98 | length      |
|  24071 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Stego_SkinPack.PrimalItemCostume_AAA_Stego_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
240D0:          66 3C AA 12 62 00 00 00 2F 47 61 6D 65
240E0: 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73
240F0: 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
24100: 6D 65 5F 41 41 41 5F 4F 74 74 65 72 5F 53 6B 69
24110: 6E 50 61 63 6B 2E 50 72 69 6D 61 6C 49 74 65 6D
24120: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4F 74 74 65
24130: 72 5F 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  240D3 | u4     |          663CAA12 |                                                                                         313146470 | index       |
|  240D7 | s4     |          62000000 |                                                                                                98 | length      |
|  240DB | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Otter_SkinPack.PrimalItemCostume_AAA_Otter_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24130:                                        C0 E6 C9
24140: A8 7A 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
24150: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
24160: 6C 49 74 65 6D 53 6B 69 6E 5F 43 68 61 72 61 63
24170: 74 65 72 53 6B 69 6E 5F 47 6C 61 64 69 61 74 72
24180: 69 78 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D
24190: 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 68 61 72 61
241A0: 63 74 65 72 53 6B 69 6E 5F 47 6C 61 64 69 61 74
241B0: 72 69 78 5F 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                                   value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2413D | u4     |          C0E6C9A8 |                                                                                                                2831804096 | index       |
|  24141 | s4     |          7A000000 |                                                                                                                       122 | length      |
|  24145 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Gladiatrix_SkinPack.PrimalItemSkin_CharacterSkin_Gladiatrix_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
241B0:                                              C9
241C0: F4 2A C1 6C 00 00 00 2F 47 61 6D 65 2F 50 61 63
241D0: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
241E0: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 68 61 72
241F0: 61 63 74 65 72 53 6B 69 6E 5F 4D 65 69 79 69 6E
24200: 5F 52 65 62 65 6C 2E 50 72 69 6D 61 6C 49 74 65
24210: 6D 53 6B 69 6E 5F 43 68 61 72 61 63 74 65 72 53
24220: 6B 69 6E 5F 4D 65 69 79 69 6E 5F 52 65 62 65 6C
24230: 5F 43 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  241BF | u4     |          C9F42AC1 |                                                                                                  3240817865 | index       |
|  241C3 | s4     |          6C000000 |                                                                                                         108 | length      |
|  241C7 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Meiyin_Rebel.PrimalItemSkin_CharacterSkin_Meiyin_Rebel_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24230:          5D 5F 59 59 4E 00 00 00 2F 47 61 6D 65
24240: 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73
24250: 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
24260: 6D 65 5F 41 41 41 5F 54 6F 61 64 2E 50 72 69 6D
24270: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
24280: 41 5F 54 6F 61 64 5F 43 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  24233 | u4     |          5D5F5959 |                                                                    1499029341 | index       |
|  24237 | s4     |          4E000000 |                                                                            78 | length      |
|  2423B | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Toad.PrimalItemCostume_AAA_Toad_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24280:                            11 B6 9E B0 50 00 00
24290: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41
242A0: 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65
242B0: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 53 68 65
242C0: 65 70 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
242D0: 74 75 6D 65 5F 41 41 41 5F 53 68 65 65 70 5F 43
242E0: 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  24289 | u4     |          11B69EB0 |                                                                      2963191313 | index       |
|  2428D | s4     |          50000000 |                                                                              80 | length      |
|  24291 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Sheep.PrimalItemCostume_AAA_Sheep_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
242E0:    2E 54 02 5A 54 00 00 00 2F 47 61 6D 65 2F 50
242F0: 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50
24300: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
24310: 5F 41 41 41 5F 50 68 69 6F 6D 69 61 2E 50 72 69
24320: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
24330: 41 41 5F 50 68 69 6F 6D 69 61 5F 43 00
```

| offset | type   |           value h |                                                                             value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------: | ----------- |
|  242E1 | u4     |          2E54025A |                                                                          1510102062 | index       |
|  242E5 | s4     |          54000000 |                                                                                  84 | length      |
|  242E9 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Phiomia.PrimalItemCostume_AAA_Phiomia_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24330:                                        64 10 79
24340: 53 5C 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
24350: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
24360: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
24370: 5F 4D 69 63 72 6F 72 61 70 74 6F 72 2E 50 72 69
24380: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
24390: 41 41 5F 4D 69 63 72 6F 72 61 70 74 6F 72 5F 43
243A0: 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  2433D | u4     |          64107953 |                                                                                  1400442980 | index       |
|  24341 | s4     |          5C000000 |                                                                                          92 | length      |
|  24345 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Microraptor.PrimalItemCostume_AAA_Microraptor_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
243A0:    39 53 DE 5B 54 00 00 00 2F 47 61 6D 65 2F 50
243B0: 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50
243C0: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
243D0: 5F 41 41 41 5F 4B 61 69 72 75 6B 75 2E 50 72 69
243E0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
243F0: 41 41 5F 4B 61 69 72 75 6B 75 5F 43 00
```

| offset | type   |           value h |                                                                             value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------: | ----------- |
|  243A1 | u4     |          3953DE5B |                                                                          1541296953 | index       |
|  243A5 | s4     |          54000000 |                                                                                  84 | length      |
|  243A9 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Kairuku.PrimalItemCostume_AAA_Kairuku_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
243F0:                                        4A D6 55
24400: 13 5A 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
24410: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
24420: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
24430: 5F 44 75 6E 67 42 65 65 74 6C 65 2E 50 72 69 6D
24440: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
24450: 41 5F 44 75 6E 67 42 65 65 74 6C 65 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  243FD | u4     |          4AD65513 |                                                                                 324392522 | index       |
|  24401 | s4     |          5A000000 |                                                                                        90 | length      |
|  24405 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_DungBeetle.PrimalItemCostume_AAA_DungBeetle_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24450:                                              91
24460: DC FE 8B 50 00 00 00 2F 47 61 6D 65 2F 50 61 63
24470: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
24480: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
24490: 41 41 5F 43 6F 6D 70 79 2E 50 72 69 6D 61 6C 49
244A0: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 43
244B0: 6F 6D 70 79 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  2445F | u4     |          91DCFE8B |                                                                      2348735633 | index       |
|  24463 | s4     |          50000000 |                                                                              80 | length      |
|  24467 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Compy.PrimalItemCostume_AAA_Compy_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
244B0:                      80 30 5F 33 5E 00 00 00 2F
244C0: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
244D0: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43
244E0: 6F 73 74 75 6D 65 5F 41 41 41 5F 42 61 73 69 6C
244F0: 6F 73 61 75 72 75 73 2E 50 72 69 6D 61 6C 49 74
24500: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 42 61
24510: 73 69 6C 6F 73 61 75 72 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  244B7 | u4     |          80305F33 |                                                                                     861876352 | index       |
|  244BB | s4     |          5E000000 |                                                                                            94 | length      |
|  244BF | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Basilosaurus.PrimalItemCostume_AAA_Basilosaurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24510:                                        F9 08 9B
24520: 68 79 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24530: 2F 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65 42
24540: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
24550: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57
24560: 61 73 74 65 6C 61 6E 64 47 68 69 6C 6C 69 65 5F
24570: 50 61 6E 74 73 2E 50 72 69 6D 61 6C 49 74 65 6D
24580: 53 6B 69 6E 5F 57 61 73 74 65 6C 61 6E 64 47 68
24590: 69 6C 6C 69 65 5F 50 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2451D | u4     |          F9089B68 |                                                                                                               1754990841 | index       |
|  24521 | s4     |          79000000 |                                                                                                                      121 | length      |
|  24525 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WastelandGhillie_Pants.PrimalItemSkin_WastelandGhillie_Pants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24590:                                           F4 B5
245A0: 9F FA 65 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
245B0: 73 2F 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65
245C0: 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73
245D0: 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
245E0: 57 61 72 6C 6F 72 64 50 61 6E 74 73 2E 50 72 69
245F0: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 72 6C
24600: 6F 72 64 50 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  2459E | u4     |          F4B59FFA |                                                                                           4204770804 | index       |
|  245A2 | s4     |          65000000 |                                                                                                  101 | length      |
|  245A6 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarlordPants.PrimalItemSkin_WarlordPants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24600:                                  83 04 DA 76 73
24610: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53
24620: 74 65 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75
24630: 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72
24640: 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 53 74 65
24650: 61 6D 70 75 6E 6B 47 6F 67 67 6C 65 73 48 61 74
24660: 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
24670: 53 74 65 61 6D 70 75 6E 6B 47 6F 67 67 6C 65 73
24680: 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------: | ----------- |
|  2460B | u4     |          8304DA76 |                                                                                                         1993999491 | index       |
|  2460F | s4     |          73000000 |                                                                                                                115 | length      |
|  24613 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_SteampunkGogglesHat.PrimalItemSkin_SteampunkGogglesHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24680:                   5F 4E 5C A3 69 00 00 00 2F 47
24690: 61 6D 65 2F 50 61 63 6B 73 2F 53 74 65 61 6D 70
246A0: 75 6E 6B 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E
246B0: 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49
246C0: 74 65 6D 53 6B 69 6E 5F 44 61 70 70 65 72 48 61
246D0: 74 5F 54 61 6C 6C 2E 50 72 69 6D 61 6C 49 74 65
246E0: 6D 53 6B 69 6E 5F 44 61 70 70 65 72 48 61 74 5F
246F0: 54 61 6C 6C 5F 43 00
```

| offset | type   |           value h |                                                                                                  value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------: | ----------- |
|  24686 | u4     |          5F4E5CA3 |                                                                                               2740735583 | index       |
|  2468A | s4     |          69000000 |                                                                                                      105 | length      |
|  2468E | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_DapperHat_Tall.PrimalItemSkin_DapperHat_Tall_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
246F0:                      D9 4F D5 3B 77 00 00 00 2F
24700: 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74 65 61 6D
24710: 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65 70 72 69
24720: 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C
24730: 49 74 65 6D 53 6B 69 6E 5F 41 62 65 72 72 61 6E
24740: 74 47 68 69 6C 6C 69 65 5F 50 61 6E 74 73 2E 50
24750: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 41 62
24760: 65 72 72 61 6E 74 47 68 69 6C 6C 69 65 5F 50 61
24770: 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------: | ----------- |
|  246F7 | u4     |          D94FD53B |                                                                                                             1003835353 | index       |
|  246FB | s4     |          77000000 |                                                                                                                    119 | length      |
|  246FF | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_AberrantGhillie_Pants.PrimalItemSkin_AberrantGhillie_Pants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24770:                   7B A8 4B 09 14 00 00 00 41 6C
24780: 6C 6F 77 57 69 6C 64 42 61 62 79 54 61 6D 69 6E
24790: 67 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  24776 | u4     |          7BA84B09 |           155953275 | index       |
|  2477A | s4     |          14000000 |                  20 | length      |
|  2477E | string | 416C6C ... 6E6700 | AllowWildBabyTaming | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24790:       24 F5 6B EC 0E 00 00 00 41 67 67 72 65 73
247A0: 73 69 76 65 5B 30 5D 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  24792 | u4     |          24F56BEC |    3966498084 | index       |
|  24796 | s4     |          0E000000 |            14 | length      |
|  2479A | string | 416767 ... 305D00 | Aggressive[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
247A0:                         94 52 AB AC 13 00 00 00
247B0: 41 62 65 72 72 61 6E 74 43 61 72 72 69 65 72 5B
247C0: 30 5D 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  247A8 | u4     |          9452ABAC |         2896908948 | index       |
|  247AC | s4     |          13000000 |                 19 | length      |
|  247B0 | string | 416265 ... 305D00 | AberrantCarrier[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
247C0:          68 79 60 83 16 00 00 00 49 6E 68 65 72
247D0: 69 74 57 65 69 67 68 74 46 72 61 69 6C 5B 30 5D
247E0: 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  247C3 | u4     |          68796083 |            2204137832 | index       |
|  247C7 | s4     |          16000000 |                    22 | length      |
|  247CB | string | 496E68 ... 305D00 | InheritWeightFrail[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
247E0:    2E 8B 8D CA 16 00 00 00 49 6E 68 65 72 69 74
247F0: 46 6F 6F 64 4D 75 74 61 62 6C 65 5B 31 5D 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  247E1 | u4     |          2E8B8DCA |            3398273838 | index       |
|  247E5 | s4     |          16000000 |                    22 | length      |
|  247E9 | string | 496E68 ... 315D00 | InheritFoodMutable[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
247F0:                                              B9
24800: 41 58 E0 6B 00 00 00 2F 47 61 6D 65 2F 53 63 6F
24810: 72 63 68 65 64 45 61 72 74 68 2F 43 6F 72 65 42
24820: 6C 75 65 70 72 69 6E 74 73 2F 42 75 66 66 73 2F
24830: 42 75 66 66 5F 42 61 73 65 5F 50 65 72 73 69 73
24840: 74 65 6E 74 5F 48 65 61 74 73 74 72 6F 6B 65 2E
24850: 42 75 66 66 5F 42 61 73 65 5F 50 65 72 73 69 73
24860: 74 65 6E 74 5F 48 65 61 74 73 74 72 6F 6B 65 5F
24870: 43 00
```

| offset | type   |           value h |                                                                                                    value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------: | ----------- |
|  247FF | u4     |          B94158E0 |                                                                                                 3763880377 | index       |
|  24803 | s4     |          6B000000 |                                                                                                        107 | length      |
|  24807 | string | 2F4761 ... 5F4300 | /Game/ScorchedEarth/CoreBlueprints/Buffs/Buff_Base_Persistent_Heatstroke.Buff_Base_Persistent_Heatstroke_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24870:       49 23 C7 3F 0E 00 00 00 42 75 66 66 53 74
24880: 61 72 74 54 69 6D 65 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  24872 | u4     |          4923C73F |    1070015305 | index       |
|  24876 | s4     |          0E000000 |            14 | length      |
|  2487A | string | 427566 ... 6D6500 | BuffStartTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24880:                         12 75 28 CB 15 00 00 00
24890: 4D 79 42 75 66 66 50 65 72 73 69 73 74 65 6E 74
248A0: 44 61 74 61 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  24888 | u4     |          127528CB |           3408426258 | index       |
|  2488C | s4     |          15000000 |                   21 | length      |
|  24890 | string | 4D7942 ... 746100 | MyBuffPersistentData | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
248A0:                FC 73 9C F4 45 00 00 00 2F 47 61
248B0: 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 53
248C0: 74 72 75 63 74 75 72 65 73 2F 42 75 69 6C 64 69
248D0: 6E 67 42 61 73 65 73 2F 53 69 67 6E 5F 57 61 72
248E0: 4D 61 70 2E 53 69 67 6E 5F 57 61 72 4D 61 70 5F
248F0: 43 00
```

| offset | type   |           value h |                                                              value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------: | ----------- |
|  248A5 | u4     |          FC739CF4 |                                                           4103894012 | index       |
|  248A9 | s4     |          45000000 |                                                                   69 | length      |
|  248AD | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Structures/BuildingBases/Sign_WarMap.Sign_WarMap_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
248F0:       DE 12 34 8C 12 00 00 00 50 61 69 6E 74 69
24900: 6E 67 43 6F 6D 70 6F 6E 65 6E 74 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  248F2 | u4     |          DE12348C |        2352222942 | index       |
|  248F6 | s4     |          12000000 |                18 | length      |
|  248FA | string | 506169 ... 6E7400 | PaintingComponent | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24900:                                     77 06 83 CB
24910: 63 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F
24920: 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65 42 6C
24930: 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50
24940: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61
24950: 72 50 69 67 50 61 6E 74 73 2E 50 72 69 6D 61 6C
24960: 49 74 65 6D 53 6B 69 6E 5F 57 61 72 50 69 67 50
24970: 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  2490C | u4     |          770683CB |                                                                                         3414361719 | index       |
|  24910 | s4     |          63000000 |                                                                                                 99 | length      |
|  24914 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarPigPants.PrimalItemSkin_WarPigPants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24970:                      14 4B B3 AB 65 00 00 00 2F
24980: 47 61 6D 65 2F 50 61 63 6B 73 2F 57 61 73 74 65
24990: 6C 61 6E 64 2F 43 6F 72 65 42 6C 75 65 70 72 69
249A0: 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C
249B0: 49 74 65 6D 53 6B 69 6E 5F 4D 6F 74 6F 72 68 65
249C0: 61 64 48 61 74 2E 50 72 69 6D 61 6C 49 74 65 6D
249D0: 53 6B 69 6E 5F 4D 6F 74 6F 72 68 65 61 64 48 61
249E0: 74 5F 43 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  24977 | u4     |          144BB3AB |                                                                                           2880654100 | index       |
|  2497B | s4     |          65000000 |                                                                                                  101 | length      |
|  2497F | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_MotorheadHat.PrimalItemSkin_MotorheadHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
249E0:             F7 F6 26 65 63 00 00 00 2F 47 61 6D
249F0: 65 2F 50 61 63 6B 73 2F 53 74 65 61 6D 70 75 6E
24A00: 6B 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73
24A10: 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65
24A20: 6D 53 6B 69 6E 5F 45 6E 67 69 6E 65 65 72 48 61
24A30: 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
24A40: 5F 45 6E 67 69 6E 65 65 72 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  249E4 | u4     |          F7F62665 |                                                                                         1697052407 | index       |
|  249E8 | s4     |          63000000 |                                                                                                 99 | length      |
|  249EC | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_EngineerHat.PrimalItemSkin_EngineerHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24A40:                                              C8
24A50: 16 E1 43 63 00 00 00 2F 47 61 6D 65 2F 50 61 63
24A60: 6B 73 2F 53 74 65 61 6D 70 75 6E 6B 2F 43 6F 72
24A70: 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D
24A80: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
24A90: 5F 44 61 70 70 65 72 42 6F 6F 74 73 2E 50 72 69
24AA0: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 61 70 70
24AB0: 65 72 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  24A4F | u4     |          C816E143 |                                                                                         1138824904 | index       |
|  24A53 | s4     |          63000000 |                                                                                                 99 | length      |
|  24A57 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_DapperBoots.PrimalItemSkin_DapperBoots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24AB0:                               9C DB 20 B3 8B 00
24AC0: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74
24AD0: 65 61 6D 70 75 6E 6B 2F 44 69 6E 6F 73 2F 52 6F
24AE0: 63 6B 44 72 61 6B 65 53 74 65 61 6D 70 75 6E 6B
24AF0: 53 61 64 64 6C 65 2F 50 72 69 6D 61 6C 49 74 65
24B00: 6D 41 72 6D 6F 72 5F 52 6F 63 6B 44 72 61 6B 65
24B10: 53 61 64 64 6C 65 5F 53 74 65 61 6D 70 75 6E 6B
24B20: 2E 50 72 69 6D 61 6C 49 74 65 6D 41 72 6D 6F 72
24B30: 5F 52 6F 63 6B 44 72 61 6B 65 53 61 64 64 6C 65
24B40: 5F 53 74 65 61 6D 70 75 6E 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                                                    value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  24ABA | u4     |          9CDB20B3 |                                                                                                                                 3005275036 | index       |
|  24ABE | s4     |          8B000000 |                                                                                                                                        139 | length      |
|  24AC2 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/Dinos/RockDrakeSteampunkSaddle/PrimalItemArmor_RockDrakeSaddle_Steampunk.PrimalItemArmor_RockDrakeSaddle_Steampunk_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24B40:                                        C6 C3 17
24B50: 91 67 00 00 00 2F 47 61 6D 65 2F 41 53 41 2F 43
24B60: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 53 6B

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24B70: 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B
24B80: 69 6E 5F 47 72 61 73 73 47 68 69 6C 6C 69 65 5F
24B90: 47 6C 6F 76 65 73 2E 50 72 69 6D 61 6C 49 74 65
24BA0: 6D 53 6B 69 6E 5F 47 72 61 73 73 47 68 69 6C 6C
24BB0: 69 65 5F 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  24B4D | u4     |          C6C31791 |                                                                                             2434253766 | index       |
|  24B51 | s4     |          67000000 |                                                                                                    103 | length      |
|  24B55 | string | 2F4761 ... 5F4300 | /Game/ASA/CoreBlueprints/Skins/PrimalItemSkin_GrassGhillie_Gloves.PrimalItemSkin_GrassGhillie_Gloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24BB0:                                     48 4D 88 12
24BC0: 66 00 00 00 2F 47 61 6D 65 2F 4C 6F 73 74 43 6F
24BD0: 6C 6F 6E 79 2F 43 6F 72 65 42 6C 75 65 70 72 69
24BE0: 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C
24BF0: 49 74 65 6D 53 6B 69 6E 5F 54 68 72 61 6C 6C 5F
24C00: 54 33 5F 42 6F 6F 74 73 2E 50 72 69 6D 61 6C 49
24C10: 74 65 6D 53 6B 69 6E 5F 54 68 72 61 6C 6C 5F 54
24C20: 33 5F 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  24BBC | u4     |          484D8812 |                                                                                             310922568 | index       |
|  24BC0 | s4     |          66000000 |                                                                                                   102 | length      |
|  24BC4 | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_Thrall_T3_Boots.PrimalItemSkin_Thrall_T3_Boots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24C20:                               09 AC 61 AA 64 00
24C30: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
24C40: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
24C50: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 52 61
24C60: 70 74 6F 72 5F 53 6B 69 6E 50 61 63 6B 2E 50 72
24C70: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
24C80: 41 41 41 5F 52 61 70 74 6F 72 5F 53 6B 69 6E 50
24C90: 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  24C2A | u4     |          09AC61AA |                                                                                          2858527753 | index       |
|  24C2E | s4     |          64000000 |                                                                                                 100 | length      |
|  24C32 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Raptor_SkinPack.PrimalItemCostume_AAA_Raptor_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24C90:                   96 55 8F 2A 6C 00 00 00 2F 47
24CA0: 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B
24CB0: 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B
24CC0: 69 6E 5F 43 68 61 72 61 63 74 65 72 53 6B 69 6E
24CD0: 5F 4B 6F 72 5F 53 6B 69 6E 50 61 63 6B 2E 50 72
24CE0: 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 68 61
24CF0: 72 61 63 74 65 72 53 6B 69 6E 5F 4B 6F 72 5F 53
24D00: 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  24C96 | u4     |          96558F2A |                                                                                                   714036630 | index       |
|  24C9A | s4     |          6C000000 |                                                                                                         108 | length      |
|  24C9E | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Kor_SkinPack.PrimalItemSkin_CharacterSkin_Kor_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24D00:                               B4 90 96 FA 6C 00
24D10: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
24D20: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
24D30: 65 6D 53 6B 69 6E 5F 43 68 61 72 61 63 74 65 72
24D40: 53 6B 69 6E 5F 42 6F 62 5F 53 6B 69 6E 50 61 63
24D50: 6B 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
24D60: 5F 43 68 61 72 61 63 74 65 72 53 6B 69 6E 5F 42
24D70: 6F 62 5F 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  24D0A | u4     |          B49096FA |                                                                                                  4204171444 | index       |
|  24D0E | s4     |          6C000000 |                                                                                                         108 | length      |
|  24D12 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Bob_SkinPack.PrimalItemSkin_CharacterSkin_Bob_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24D70:                                           5C 3D
24D80: 02 96 54 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
24D90: 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D
24DA0: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
24DB0: 41 5F 56 75 6C 74 75 72 65 2E 50 72 69 6D 61 6C
24DC0: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
24DD0: 56 75 6C 74 75 72 65 5F 43 00
```

| offset | type   |           value h |                                                                             value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------: | ----------- |
|  24D7E | u4     |          5C3D0296 |                                                                          2516729180 | index       |
|  24D82 | s4     |          54000000 |                                                                                  84 | length      |
|  24D86 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Vulture.PrimalItemCostume_AAA_Vulture_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24DD0:                               87 38 92 DD 56 00
24DE0: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
24DF0: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
24E00: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 54 61
24E10: 70 65 6A 61 72 61 2E 50 72 69 6D 61 6C 49 74 65
24E20: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 54 61 70
24E30: 65 6A 61 72 61 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  24DDA | u4     |          873892DD |                                                                            3717347463 | index       |
|  24DDE | s4     |          56000000 |                                                                                    86 | length      |
|  24DE2 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Tapejara.PrimalItemCostume_AAA_Tapejara_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24E30:                         A7 FF 32 EB 56 00 00 00
24E40: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
24E50: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
24E60: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 50 75 72 6C
24E70: 6F 76 69 61 2E 50 72 69 6D 61 6C 49 74 65 6D 43
24E80: 6F 73 74 75 6D 65 5F 41 41 41 5F 50 75 72 6C 6F
24E90: 76 69 61 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  24E38 | u4     |          A7FF32EB |                                                                            3945988007 | index       |
|  24E3C | s4     |          56000000 |                                                                                    86 | length      |
|  24E40 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Purlovia.PrimalItemCostume_AAA_Purlovia_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24E90:                   65 C7 8F 73 50 00 00 00 2F 47
24EA0: 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B
24EB0: 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F
24EC0: 73 74 75 6D 65 5F 41 41 41 5F 50 61 63 68 79 2E
24ED0: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
24EE0: 65 5F 41 41 41 5F 50 61 63 68 79 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  24E96 | u4     |          65C78F73 |                                                                      1938802533 | index       |
|  24E9A | s4     |          50000000 |                                                                              80 | length      |
|  24E9E | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Pachy.PrimalItemCostume_AAA_Pachy_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24EE0:                                           F1 18
24EF0: 2F 2C 54 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
24F00: 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D
24F10: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
24F20: 41 5F 4D 61 6D 6D 6F 74 68 2E 50 72 69 6D 61 6C
24F30: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
24F40: 4D 61 6D 6D 6F 74 68 5F 43 00
```

| offset | type   |           value h |                                                                             value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------: | ----------- |
|  24EEE | u4     |          F1182F2C |                                                                           741284081 | index       |
|  24EF2 | s4     |          54000000 |                                                                                  84 | length      |
|  24EF6 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Mammoth.PrimalItemCostume_AAA_Mammoth_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24F40:                               1C D0 83 53 5A 00
24F50: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
24F60: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
24F70: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 47 61
24F80: 6C 6C 69 6D 69 6D 75 73 2E 50 72 69 6D 61 6C 49
24F90: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 47
24FA0: 61 6C 6C 69 6D 69 6D 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  24F4A | u4     |          1CD08353 |                                                                                1401147420 | index       |
|  24F4E | s4     |          5A000000 |                                                                                        90 | length      |
|  24F52 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Gallimimus.PrimalItemCostume_AAA_Gallimimus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
24FA0:                                     64 F8 CC FC
24FB0: 5C 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F
24FC0: 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C
24FD0: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
24FE0: 44 69 70 6C 6F 63 61 75 6C 75 73 2E 50 72 69 6D
24FF0: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
25000: 41 5F 44 69 70 6C 6F 63 61 75 6C 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  24FAC | u4     |          64F8CCFC |                                                                                  4241291364 | index       |
|  24FB0 | s4     |          5C000000 |                                                                                          92 | length      |
|  24FB4 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Diplocaulus.PrimalItemCostume_AAA_Diplocaulus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25010: 79 2C 0F 62 56 00 00 00 2F 47 61 6D 65 2F 50 61
25020: 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72
25030: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
25040: 41 41 41 5F 42 6F 61 46 72 69 6C 6C 2E 50 72 69
25050: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
25060: 41 41 5F 42 6F 61 46 72 69 6C 6C 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  25010 | u4     |          792C0F62 |                                                                            1645161593 | index       |
|  25014 | s4     |          56000000 |                                                                                    86 | length      |
|  25018 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_BoaFrill.PrimalItemCostume_AAA_BoaFrill_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25060:                                           EC 5A
25070: 2C 9B 5A 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
25080: 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D
25090: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
250A0: 41 5F 41 6C 6C 6F 73 61 75 72 75 73 2E 50 72 69
250B0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
250C0: 41 41 5F 41 6C 6C 6F 73 61 75 72 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  2506E | u4     |          EC5A2C9B |                                                                                2603375340 | index       |
|  25072 | s4     |          5A000000 |                                                                                        90 | length      |
|  25076 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Allosaurus.PrimalItemCostume_AAA_Allosaurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
250D0: EA 65 4F C6 5F 00 00 00 2F 47 61 6D 65 2F 50 61
250E0: 63 6B 73 2F 57 61 73 74 65 6C 61 6E 64 2F 43 6F
250F0: 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65
25100: 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
25110: 6E 5F 57 61 72 50 69 67 48 61 74 2E 50 72 69 6D
25120: 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 72 50 69
25130: 67 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                        value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------: | ----------- |
|  250D0 | u4     |          EA654FC6 |                                                                                     3327092202 | index       |
|  250D4 | s4     |          5F000000 |                                                                                             95 | length      |
|  250D8 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarPigHat.PrimalItemSkin_WarPigHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25130:                      E9 FF 78 6A 69 00 00 00 2F
25140: 47 61 6D 65 2F 50 61 63 6B 73 2F 57 61 73 74 65
25150: 6C 61 6E 64 2F 43 6F 72 65 42 6C 75 65 70 72 69
25160: 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C
25170: 49 74 65 6D 53 6B 69 6E 5F 43 72 6F 63 6F 73 61
25180: 75 72 75 73 48 61 74 2E 50 72 69 6D 61 6C 49 74
25190: 65 6D 53 6B 69 6E 5F 43 72 6F 63 6F 73 61 75 72
251A0: 75 73 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                                  value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------: | ----------- |
|  25137 | u4     |          E9FF786A |                                                                                               1786314729 | index       |
|  2513B | s4     |          69000000 |                                                                                                      105 | length      |
|  2513F | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_CrocosaurusHat.PrimalItemSkin_CrocosaurusHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
251A0:                         21 2D C1 F8 69 00 00 00

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
251B0: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74 65 61
251C0: 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65 70 72
251D0: 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61
251E0: 6C 49 74 65 6D 53 6B 69 6E 5F 45 6E 67 69 6E 65
251F0: 65 72 47 6C 6F 76 65 73 2E 50 72 69 6D 61 6C 49
25200: 74 65 6D 53 6B 69 6E 5F 45 6E 67 69 6E 65 65 72
25210: 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                                  value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------: | ----------- |
|  251A8 | u4     |          212DC1F8 |                                                                                               4173409569 | index       |
|  251AC | s4     |          69000000 |                                                                                                      105 | length      |
|  251B0 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_EngineerGloves.PrimalItemSkin_EngineerGloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25210:                            D2 E9 7F 3C 61 00 00
25220: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74 65
25230: 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65 70
25240: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D
25250: 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 79 63 6C 69
25260: 73 74 48 61 74 2E 50 72 69 6D 61 6C 49 74 65 6D
25270: 53 6B 69 6E 5F 43 79 63 6C 69 73 74 48 61 74 5F
25280: 43 00
```

| offset | type   |           value h |                                                                                          value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------: | ----------- |
|  25219 | u4     |          D2E97F3C |                                                                                       1015015890 | index       |
|  2521D | s4     |          61000000 |                                                                                               97 | length      |
|  25221 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_CyclistHat.PrimalItemSkin_CyclistHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25280:       F0 CC AE 10 64 00 00 00 2F 47 61 6D 65 2F
25290: 53 63 6F 72 63 68 65 64 45 61 72 74 68 2F 4F 75
252A0: 74 66 69 74 73 2F 50 72 69 6D 61 6C 49 74 65 6D
252B0: 53 6B 69 6E 5F 44 65 73 65 72 74 47 68 69 6C 6C
252C0: 69 65 5F 53 68 69 72 74 2E 50 72 69 6D 61 6C 49
252D0: 74 65 6D 53 6B 69 6E 5F 44 65 73 65 72 74 47 68
252E0: 69 6C 6C 69 65 5F 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  25282 | u4     |          F0CCAE10 |                                                                                           279891184 | index       |
|  25286 | s4     |          64000000 |                                                                                                 100 | length      |
|  2528A | string | 2F4761 ... 5F4300 | /Game/ScorchedEarth/Outfits/PrimalItemSkin_DesertGhillie_Shirt.PrimalItemSkin_DesertGhillie_Shirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
252E0:                                           71 2C
252F0: B1 29 65 00 00 00 2F 47 61 6D 65 2F 41 53 41 2F
25300: 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 53
25310: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53
25320: 6B 69 6E 5F 47 72 61 73 73 47 68 69 6C 6C 69 65
25330: 5F 42 6F 6F 74 73 2E 50 72 69 6D 61 6C 49 74 65
25340: 6D 53 6B 69 6E 5F 47 72 61 73 73 47 68 69 6C 6C
25350: 69 65 5F 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  252EE | u4     |          712CB129 |                                                                                            699477105 | index       |
|  252F2 | s4     |          65000000 |                                                                                                  101 | length      |
|  252F6 | string | 2F4761 ... 5F4300 | /Game/ASA/CoreBlueprints/Skins/PrimalItemSkin_GrassGhillie_Boots.PrimalItemSkin_GrassGhillie_Boots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25350:                                  E4 8C 25 0A 79
25360: 00 00 00 2F 47 61 6D 65 2F 41 53 41 2F 44 69 6E
25370: 6F 73 2F 53 68 6F 75 6C 64 65 72 44 72 61 67 6F
25380: 6E 2F 56 61 72 69 61 6E 74 73 2F 4C 6F 73 74 2F
25390: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
253A0: 65 5F 53 68 6F 75 6C 64 65 72 44 72 61 67 6F 6E
253B0: 4C 6F 73 74 2E 50 72 69 6D 61 6C 49 74 65 6D 43
253C0: 6F 73 74 75 6D 65 5F 53 68 6F 75 6C 64 65 72 44
253D0: 72 61 67 6F 6E 4C 6F 73 74 5F 43 00
```

| offset | type   |           value h |                                                                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2535B | u4     |          E48C250A |                                                                                                                170233060 | index       |
|  2535F | s4     |          79000000 |                                                                                                                      121 | length      |
|  25363 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/ShoulderDragon/Variants/Lost/PrimalItemCostume_ShoulderDragonLost.PrimalItemCostume_ShoulderDragonLost_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
253D0:                                     BD D7 D8 E1
253E0: 66 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F
253F0: 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C
25400: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
25410: 51 75 65 74 7A 61 6C 5F 53 6B 69 6E 50 61 63 6B
25420: 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
25430: 6D 65 5F 41 41 41 5F 51 75 65 74 7A 61 6C 5F 53
25440: 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  253DC | u4     |          BDD7D8E1 |                                                                                            3789084605 | index       |
|  253E0 | s4     |          66000000 |                                                                                                   102 | length      |
|  253E4 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Quetzal_SkinPack.PrimalItemCostume_AAA_Quetzal_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25440:                               8F 74 8B 8E 6E 00
25450: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
25460: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
25470: 65 6D 53 6B 69 6E 5F 43 68 61 72 61 63 74 65 72
25480: 53 6B 69 6E 5F 4A 6F 68 6E 5F 53 6B 69 6E 50 61
25490: 63 6B 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
254A0: 6E 5F 43 68 61 72 61 63 74 65 72 53 6B 69 6E 5F
254B0: 4A 6F 68 6E 5F 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                       value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------------------: | ----------- |
|  2544A | u4     |          8F748B8E |                                                                                                    2391504015 | index       |
|  2544E | s4     |          6E000000 |                                                                                                           110 | length      |
|  25452 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_John_SkinPack.PrimalItemSkin_CharacterSkin_John_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
254C0: C6 0E E8 72 6C 00 00 00 2F 47 61 6D 65 2F 50 61
254D0: 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72
254E0: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
254F0: 41 41 41 5F 41 72 67 65 6E 74 61 76 69 73 5F 53
25500: 6B 69 6E 50 61 63 6B 2E 50 72 69 6D 61 6C 49 74
25510: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 41 72
25520: 67 65 6E 74 61 76 69 73 5F 53 6B 69 6E 50 61 63
25530: 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  254C0 | u4     |          C60EE872 |                                                                                                  1927810758 | index       |
|  254C4 | s4     |          6C000000 |                                                                                                         108 | length      |
|  254C8 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Argentavis_SkinPack.PrimalItemCostume_AAA_Argentavis_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25530:             80 06 C9 AC 5C 00 00 00 2F 47 61 6D
25540: 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E
25550: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
25560: 75 6D 65 5F 41 41 41 5F 54 75 73 6F 74 65 75 74
25570: 68 69 73 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F
25580: 73 74 75 6D 65 5F 41 41 41 5F 54 75 73 6F 74 65
25590: 75 74 68 69 73 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  25534 | u4     |          8006C9AC |                                                                                  2898855552 | index       |
|  25538 | s4     |          5C000000 |                                                                                          92 | length      |
|  2553C | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Tusoteuthis.PrimalItemCostume_AAA_Tusoteuthis_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25590:                         60 6F 96 F5 4E 00 00 00
255A0: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
255B0: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
255C0: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 53 74 61 67
255D0: 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
255E0: 6D 65 5F 41 41 41 5F 53 74 61 67 5F 43 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  25598 | u4     |          606F96F5 |                                                                    4120276832 | index       |
|  2559C | s4     |          4E000000 |                                                                            78 | length      |
|  255A0 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Stag.PrimalItemCostume_AAA_Stag_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
255E0:                                           B9 BD
255F0: 36 2C 5C 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
25600: 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D
25610: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
25620: 41 5F 50 72 6F 63 6F 70 74 6F 64 6F 6E 2E 50 72
25630: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
25640: 41 41 41 5F 50 72 6F 63 6F 70 74 6F 64 6F 6E 5F
25650: 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  255EE | u4     |          B9BD362C |                                                                                   741785017 | index       |
|  255F2 | s4     |          5C000000 |                                                                                          92 | length      |
|  255F6 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Procoptodon.PrimalItemCostume_AAA_Procoptodon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25650:       8A 5A 2D 8E 58 00 00 00 2F 47 61 6D 65 2F
25660: 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F
25670: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
25680: 65 5F 41 41 41 5F 4F 76 69 72 61 70 74 6F 72 2E
25690: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
256A0: 65 5F 41 41 41 5F 4F 76 69 72 61 70 74 6F 72 5F
256B0: 43 00
```

| offset | type   |           value h |                                                                                 value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------: | ----------- |
|  25652 | u4     |          8A5A2D8E |                                                                              2385336970 | index       |
|  25656 | s4     |          58000000 |                                                                                      88 | length      |
|  2565A | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Oviraptor.PrimalItemCostume_AAA_Oviraptor_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
256B0:       58 EF 3C D9 5E 00 00 00 2F 47 61 6D 65 2F
256C0: 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F
256D0: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
256E0: 65 5F 41 41 41 5F 4C 79 73 74 72 6F 73 61 75 72
256F0: 75 73 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
25700: 74 75 6D 65 5F 41 41 41 5F 4C 79 73 74 72 6F 73
25710: 61 75 72 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  256B2 | u4     |          58EF3CD9 |                                                                                    3644649304 | index       |
|  256B6 | s4     |          5E000000 |                                                                                            94 | length      |
|  256BA | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Lystrosaurus.PrimalItemCostume_AAA_Lystrosaurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25710:                         AE B8 AA 3E 50 00 00 00
25720: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
25730: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
25740: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 45 71 75 75
25750: 73 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
25760: 75 6D 65 5F 41 41 41 5F 45 71 75 75 73 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  25718 | u4     |          AEB8AA3E |                                                                      1051375790 | index       |
|  2571C | s4     |          50000000 |                                                                              80 | length      |
|  25720 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Equus.PrimalItemCostume_AAA_Equus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25770: 5D 70 C0 A7 5C 00 00 00 2F 47 61 6D 65 2F 50 61
25780: 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72
25790: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
257A0: 41 41 41 5F 44 69 6D 6F 72 70 68 6F 64 6F 6E 2E
257B0: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
257C0: 65 5F 41 41 41 5F 44 69 6D 6F 72 70 68 6F 64 6F
257D0: 6E 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  25770 | u4     |          5D70C0A7 |                                                                                  2814406749 | index       |
|  25774 | s4     |          5C000000 |                                                                                          92 | length      |
|  25778 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Dimorphodon.PrimalItemCostume_AAA_Dimorphodon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
257D0:             9F D6 71 E4 4C 00 00 00 2F 47 61 6D
257E0: 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
257F0: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
25800: 75 6D 65 5F 41 41 41 5F 42 65 65 2E 50 72 69 6D
25810: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
25820: 41 5F 42 65 65 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  257D4 | u4     |          9FD671E4 |                                                                  3832665759 | index       |
|  257D8 | s4     |          4C000000 |                                                                          76 | length      |
|  257DC | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Bee.PrimalItemCostume_AAA_Bee_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25820:                         61 6A 9B DC 56 00 00 00
25830: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
25840: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
25850: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 41 63 68 61
25860: 74 69 6E 61 2E 50 72 69 6D 61 6C 49 74 65 6D 43
25870: 6F 73 74 75 6D 65 5F 41 41 41 5F 41 63 68 61 74
25880: 69 6E 61 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  25828 | u4     |          616A9BDC |                                                                            3701172833 | index       |
|  2582C | s4     |          56000000 |                                                                                    86 | length      |
|  25830 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Achatina.PrimalItemCostume_AAA_Achatina_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25880:                   07 C3 16 4C 65 00 00 00 2F 47
25890: 61 6D 65 2F 50 61 63 6B 73 2F 57 61 73 74 65 6C
258A0: 61 6E 64 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E
258B0: 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49
258C0: 74 65 6D 53 6B 69 6E 5F 57 61 72 50 69 67 47 6C
258D0: 6F 76 65 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53
258E0: 6B 69 6E 5F 57 61 72 50 69 67 47 6C 6F 76 65 73
258F0: 5F 43 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  25886 | u4     |          07C3164C |                                                                                           1276560135 | index       |
|  2588A | s4     |          65000000 |                                                                                                  101 | length      |
|  2588E | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarPigGloves.PrimalItemSkin_WarPigGloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
258F0:          39 EE 7C 8E 67 00 00 00 2F 47 61 6D 65
25900: 2F 50 61 63 6B 73 2F 57 61 73 74 65 6C 61 6E 64
25910: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
25920: 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D
25930: 53 6B 69 6E 5F 42 75 63 6B 65 74 66 61 63 65 48
25940: 61 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
25950: 6E 5F 42 75 63 6B 65 74 66 61 63 65 48 61 74 5F
25960: 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  258F3 | u4     |          39EE7C8E |                                                                                             2390552121 | index       |
|  258F7 | s4     |          67000000 |                                                                                                    103 | length      |
|  258FB | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_BucketfaceHat.PrimalItemSkin_BucketfaceHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25960:       6B 97 6F 8B 67 00 00 00 2F 47 61 6D 65 2F
25970: 50 61 63 6B 73 2F 53 74 65 61 6D 70 75 6E 6B 2F
25980: 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49
25990: 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53
259A0: 6B 69 6E 5F 45 6E 67 69 6E 65 65 72 42 6F 6F 74
259B0: 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
259C0: 5F 45 6E 67 69 6E 65 65 72 42 6F 6F 74 73 5F 43
259D0: 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  25962 | u4     |          6B976F8B |                                                                                             2339346283 | index       |
|  25966 | s4     |          67000000 |                                                                                                    103 | length      |
|  2596A | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_EngineerBoots.PrimalItemSkin_EngineerBoots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
259D0:    12 FB 40 0D 5F 00 00 00 2F 47 61 6D 65 2F 50
259E0: 61 63 6B 73 2F 53 74 65 61 6D 70 75 6E 6B 2F 43
259F0: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74
25A00: 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B
25A10: 69 6E 5F 42 6F 61 74 65 72 48 61 74 2E 50 72 69
25A20: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 42 6F 61 74
25A30: 65 72 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                        value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------: | ----------- |
|  259D1 | u4     |          12FB400D |                                                                                      222362386 | index       |
|  259D5 | s4     |          5F000000 |                                                                                             95 | length      |
|  259D9 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_BoaterHat.PrimalItemSkin_BoaterHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25A30:                         AD FD 11 42 64 00 00 00
25A40: 2F 47 61 6D 65 2F 53 63 6F 72 63 68 65 64 45 61
25A50: 72 74 68 2F 4F 75 74 66 69 74 73 2F 50 72 69 6D
25A60: 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 65 73 65 72
25A70: 74 47 68 69 6C 6C 69 65 5F 50 61 6E 74 73 2E 50
25A80: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 65
25A90: 73 65 72 74 47 68 69 6C 6C 69 65 5F 50 61 6E 74
25AA0: 73 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  25A38 | u4     |          ADFD1142 |                                                                                          1108475309 | index       |
|  25A3C | s4     |          64000000 |                                                                                                 100 | length      |
|  25A40 | string | 2F4761 ... 5F4300 | /Game/ScorchedEarth/Outfits/PrimalItemSkin_DesertGhillie_Pants.PrimalItemSkin_DesertGhillie_Pants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25AA0:             C7 58 96 43 78 00 00 00 2F 47 61 6D
25AB0: 65 2F 4C 6F 73 74 43 6F 6C 6F 6E 79 2F 43 6F 72
25AC0: 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D
25AD0: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
25AE0: 5F 54 68 72 61 6C 6C 5F 54 33 5F 53 68 69 72 74
25AF0: 5F 57 69 74 68 43 61 70 65 2E 50 72 69 6D 61 6C
25B00: 49 74 65 6D 53 6B 69 6E 5F 54 68 72 61 6C 6C 5F
25B10: 54 33 5F 53 68 69 72 74 5F 57 69 74 68 43 61 70
25B20: 65 5F 43 00
```

| offset | type   |           value h |                                                                                                                 value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  25AA4 | u4     |          C7589643 |                                                                                                              1133926599 | index       |
|  25AA8 | s4     |          78000000 |                                                                                                                     120 | length      |
|  25AAC | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_Thrall_T3_Shirt_WithCape.PrimalItemSkin_Thrall_T3_Shirt_WithCape_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25B20:             F7 19 CD 4D 6C 00 00 00 2F 47 61 6D
25B30: 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E
25B40: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
25B50: 75 6D 65 5F 41 41 41 5F 59 75 74 79 72 61 6E 6E
25B60: 75 73 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D
25B70: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
25B80: 41 5F 59 75 74 79 72 61 6E 6E 75 73 5F 53 6B 69
25B90: 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  25B24 | u4     |          F719CD4D |                                                                                                  1305287159 | index       |
|  25B28 | s4     |          6C000000 |                                                                                                         108 | length      |
|  25B2C | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Yutyrannus_SkinPack.PrimalItemCostume_AAA_Yutyrannus_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25B90:                         D9 E8 38 C4 62 00 00 00
25BA0: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
25BB0: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
25BC0: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 50 74 65 72
25BD0: 6F 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D 61
25BE0: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
25BF0: 5F 50 74 65 72 6F 5F 53 6B 69 6E 50 61 63 6B 5F
25C00: 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  25B98 | u4     |          D9E838C4 |                                                                                        3292063961 | index       |
|  25B9C | s4     |          62000000 |                                                                                                98 | length      |
|  25BA0 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Ptero_SkinPack.PrimalItemCostume_AAA_Ptero_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25C00:       F3 74 6E 6E 70 00 00 00 2F 47 61 6D 65 2F
25C10: 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F
25C20: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43
25C30: 68 61 72 61 63 74 65 72 53 6B 69 6E 5F 48 65 6E
25C40: 72 79 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D
25C50: 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 68 61 72 61
25C60: 63 74 65 72 53 6B 69 6E 5F 48 65 6E 72 79 5F 53
25C70: 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                         value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------: | ----------- |
|  25C02 | u4     |          F3746E6E |                                                                                                      1852732659 | index       |
|  25C06 | s4     |          70000000 |                                                                                                             112 | length      |
|  25C0A | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Henry_SkinPack.PrimalItemSkin_CharacterSkin_Henry_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25C70:                               FF F5 A1 20 64 00
25C80: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
25C90: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
25CA0: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 41 6E
25CB0: 6B 79 6C 6F 5F 53 6B 69 6E 50 61 63 6B 2E 50 72
25CC0: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
25CD0: 41 41 41 5F 41 6E 6B 79 6C 6F 5F 53 6B 69 6E 50
25CE0: 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  25C7A | u4     |          FFF5A120 |                                                                                           547485183 | index       |
|  25C7E | s4     |          64000000 |                                                                                                 100 | length      |
|  25C82 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Ankylo_SkinPack.PrimalItemCostume_AAA_Ankylo_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25CE0:                   FC F7 24 7B 52 00 00 00 2F 47
25CF0: 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B
25D00: 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F
25D10: 73 74 75 6D 65 5F 41 41 41 5F 54 75 72 74 6C 65
25D20: 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
25D30: 6D 65 5F 41 41 41 5F 54 75 72 74 6C 65 5F 43 00
```

| offset | type   |           value h |                                                                           value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------: | ----------- |
|  25CE6 | u4     |          FCF7247B |                                                                        2066020348 | index       |
|  25CEA | s4     |          52000000 |                                                                                82 | length      |
|  25CEE | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Turtle.PrimalItemCostume_AAA_Turtle_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25D40: B5 D1 E3 A8 50 00 00 00 2F 47 61 6D 65 2F 50 61
25D50: 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72
25D60: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
25D70: 41 41 41 5F 53 70 69 6E 6F 2E 50 72 69 6D 61 6C
25D80: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
25D90: 53 70 69 6E 6F 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  25D40 | u4     |          B5D1E3A8 |                                                                      2833502645 | index       |
|  25D44 | s4     |          50000000 |                                                                              80 | length      |
|  25D48 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Spino.PrimalItemCostume_AAA_Spino_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25D90:                         D2 79 B8 D7 5A 00 00 00
25DA0: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
25DB0: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
25DC0: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 50 6C 65 73
25DD0: 69 6F 73 61 75 72 2E 50 72 69 6D 61 6C 49 74 65
25DE0: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 50 6C 65
25DF0: 73 69 6F 73 61 75 72 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  25D98 | u4     |          D279B8D7 |                                                                                3619191250 | index       |
|  25D9C | s4     |          5A000000 |                                                                                        90 | length      |
|  25DA0 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Plesiosaur.PrimalItemCostume_AAA_Plesiosaur_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25DF0:                               BE BA 62 EA 56 00
25E00: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41
25E10: 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74
25E20: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4D 6F

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25E30: 73 63 68 6F 70 73 2E 50 72 69 6D 61 6C 49 74 65
25E40: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4D 6F 73
25E50: 63 68 6F 70 73 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  25DFA | u4     |          BEBA62EA |                                                                            3932338878 | index       |
|  25DFE | s4     |          56000000 |                                                                                    86 | length      |
|  25E02 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Moschops.PrimalItemCostume_AAA_Moschops_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25E50:                         EE A7 46 3D 5E 00 00 00
25E60: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F
25E70: 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D
25E80: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4B 65 6E 74
25E90: 72 6F 73 61 75 72 75 73 2E 50 72 69 6D 61 6C 49
25EA0: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4B
25EB0: 65 6E 74 72 6F 73 61 75 72 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  25E58 | u4     |          EEA7463D |                                                                                    1028040686 | index       |
|  25E5C | s4     |          5E000000 |                                                                                            94 | length      |
|  25E60 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Kentrosaurus.PrimalItemCostume_AAA_Kentrosaurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25EB0:                                           C8 D1
25EC0: 38 34 4C 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
25ED0: 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D
25EE0: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
25EF0: 41 5F 45 65 6C 2E 50 72 69 6D 61 6C 49 74 65 6D
25F00: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 45 65 6C 5F
25F10: 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  25EBE | u4     |          C8D13834 |                                                                   876138952 | index       |
|  25EC2 | s4     |          4C000000 |                                                                          76 | length      |
|  25EC6 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Eel.PrimalItemCostume_AAA_Eel_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25F10:       64 10 A2 46 5A 00 00 00 2F 47 61 6D 65 2F
25F20: 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F
25F30: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
25F40: 65 5F 41 41 41 5F 44 69 6D 65 74 72 6F 64 6F 6E
25F50: 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
25F60: 6D 65 5F 41 41 41 5F 44 69 6D 65 74 72 6F 64 6F
25F70: 6E 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  25F12 | u4     |          6410A246 |                                                                                1185026148 | index       |
|  25F16 | s4     |          5A000000 |                                                                                        90 | length      |
|  25F1A | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Dimetrodon.PrimalItemCostume_AAA_Dimetrodon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25F70:             6B E0 83 34 52 00 00 00 2F 47 61 6D
25F80: 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E
25F90: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
25FA0: 75 6D 65 5F 41 41 41 5F 42 65 61 76 65 72 2E 50
25FB0: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
25FC0: 5F 41 41 41 5F 42 65 61 76 65 72 5F 43 00
```

| offset | type   |           value h |                                                                           value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------: | ----------- |
|  25F74 | u4     |          6BE08334 |                                                                         881057899 | index       |
|  25F78 | s4     |          52000000 |                                                                                82 | length      |
|  25F7C | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Beaver.PrimalItemCostume_AAA_Beaver_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
25FC0:                                           48 3B
25FD0: A8 1B 7D 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
25FE0: 73 2F 57 61 73 74 65 6C 61 6E 64 2F 53 74 72 75
25FF0: 63 74 75 72 65 73 2F 53 6B 69 6E 73 2F 50 72 69
26000: 6D 61 6C 49 74 65 6D 53 74 72 75 63 74 75 72 65
26010: 53 6B 69 6E 5F 54 69 6C 65 73 65 74 5F 57 61 73
26020: 74 65 6C 61 6E 64 2E 50 72 69 6D 61 6C 49 74 65
26030: 6D 53 74 72 75 63 74 75 72 65 53 6B 69 6E 5F 54
26040: 69 6C 65 73 65 74 5F 57 61 73 74 65 6C 61 6E 64
26050: 5F 43 00
```

| offset | type   |           value h |                                                                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  25FCE | u4     |          483BA81B |                                                                                                                    464010056 | index       |
|  25FD2 | s4     |          7D000000 |                                                                                                                          125 | length      |
|  25FD6 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/Structures/Skins/PrimalItemStructureSkin_Tileset_Wasteland.PrimalItemStructureSkin_Tileset_Wasteland_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26050:          EC 73 B8 8D 63 00 00 00 2F 47 61 6D 65
26060: 2F 50 61 63 6B 73 2F 57 61 73 74 65 6C 61 6E 64
26070: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
26080: 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D
26090: 53 6B 69 6E 5F 57 61 72 50 69 67 42 6F 6F 74 73
260A0: 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
260B0: 57 61 72 50 69 67 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  26053 | u4     |          EC73B88D |                                                                                         2377675756 | index       |
|  26057 | s4     |          63000000 |                                                                                                 99 | length      |
|  2605B | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarPigBoots.PrimalItemSkin_WarPigBoots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
260B0:                                           A2 50
260C0: 77 FE 63 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
260D0: 73 2F 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65
260E0: 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73
260F0: 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
26100: 57 61 72 50 69 67 53 68 69 72 74 2E 50 72 69 6D
26110: 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 72 50 69
26120: 67 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------: | ----------- |
|  260BE | u4     |          A25077FE |                                                                                         4269232290 | index       |
|  260C2 | s4     |          63000000 |                                                                                                 99 | length      |
|  260C6 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarPigShirt.PrimalItemSkin_WarPigShirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26120:                            F5 57 15 C5 17 00 00
26130: 00 49 6E 68 65 72 69 74 4D 65 6C 65 65 4D 75 74
26140: 61 62 6C 65 5B 31 5D 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  26129 | u4     |          F55715C5 |             3306510325 | index       |
|  2612D | s4     |          17000000 |                     23 | length      |
|  26131 | string | 496E68 ... 315D00 | InheritMeleeMutable[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26140:                         FB B9 FB EF 0F 00 00 00
26150: 44 69 73 74 72 61 63 74 69 6E 67 5B 30 5D 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  26148 | u4     |          FBB9FBEF |     4026251771 | index       |
|  2614C | s4     |          0F000000 |             15 | length      |
|  26150 | string | 446973 ... 305D00 | Distracting[0] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26150:                                              59
26160: 25 2E 5C 17 00 00 00 49 6E 68 65 72 69 74 53 74
26170: 61 6D 69 6E 61 46 72 61 69 6C 5B 31 5D 00
```

| offset | type   |           value h |                value d | description |
| -----: | ------ | ----------------: | ---------------------: | ----------- |
|  2615F | u4     |          59252E5C |             1546528089 | index       |
|  26163 | s4     |          17000000 |                     23 | length      |
|  26167 | string | 496E68 ... 315D00 | InheritStaminaFrail[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26170:                                           0E 1F
26180: 9A CE 15 00 00 00 45 78 74 69 6E 63 74 69 6F 6E
26190: 43 61 72 72 69 65 72 5B 31 5D 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  2617E | u4     |          0E1F9ACE |           3466206990 | index       |
|  26182 | s4     |          15000000 |                   21 | length      |
|  26186 | string | 457874 ... 315D00 | ExtinctionCarrier[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26190:                                  BA DD FD D0 49
261A0: 00 00 00 2F 41 53 42 45 78 70 6F 72 74 47 75 6E
261B0: 2F 53 69 6E 67 6C 65 74 6F 6E 73 2F 53 65 72 76
261C0: 65 72 43 6F 6E 66 69 67 5F 53 69 6E 67 6C 65 74
261D0: 6F 6E 2E 53 65 72 76 65 72 43 6F 6E 66 69 67 5F
261E0: 53 69 6E 67 6C 65 74 6F 6E 5F 43 00
```

| offset | type   |           value h |                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------: | ----------- |
|  2619B | u4     |          BADDFDD0 |                                                               3506298298 | index       |
|  2619F | s4     |          49000000 |                                                                       73 | length      |
|  261A3 | string | 2F4153 ... 5F4300 | /ASBExportGun/Singletons/ServerConfig_Singleton.ServerConfig_Singleton_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
261E0:                                     EE CA 52 A4
261F0: 59 00 00 00 2F 47 61 6D 65 2F 41 53 41 2F 44 69
26200: 6E 6F 73 2F 49 63 65 57 79 76 65 72 6E 2F 42 6F
26210: 73 73 2F 42 6F 73 73 41 72 65 6E 61 4D 61 6E 61
26220: 67 65 72 5F 52 61 67 57 79 76 42 6F 73 73 2E 42
26230: 6F 73 73 41 72 65 6E 61 4D 61 6E 61 67 65 72 5F
26240: 52 61 67 57 79 76 42 6F 73 73 5F 43 00
```

| offset | type   |           value h |                                                                                  value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------: | ----------- |
|  261EC | u4     |          EECA52A4 |                                                                               2756889326 | index       |
|  261F0 | s4     |          59000000 |                                                                                       89 | length      |
|  261F4 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/IceWyvern/Boss/BossArenaManager_RagWyvBoss.BossArenaManager_RagWyvBoss_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26240:                                        67 66 E3
26250: 1D 2E 00 00 00 2F 53 63 72 69 70 74 2F 53 68 6F
26260: 6F 74 65 72 47 61 6D 65 2E 50 72 69 6D 61 6C 50
26270: 65 72 73 69 73 74 65 6E 74 57 6F 72 6C 64 44 61
26280: 74 61 00
```

| offset | type   |           value h |                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------: | ----------- |
|  2624D | u4     |          6766E31D |                                     501442151 | index       |
|  26251 | s4     |          2E000000 |                                            46 | length      |
|  26255 | string | 2F5363 ... 746100 | /Script/ShooterGame.PrimalPersistentWorldData | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26280:          DD F6 2E 9C 4E 00 00 00 2F 47 61 6D 65
26290: 2F 4D 6F 64 73 2F 52 61 67 6E 61 72 6F 6B 2F 43
262A0: 75 73 74 6F 6D 5F 41 73 73 65 74 73 2F 57 65 61
262B0: 74 68 65 72 2F 53 79 73 74 65 6D 73 2F 52 61 67
262C0: 5F 44 61 79 43 79 63 6C 65 2E 52 61 67 5F 44 61
262D0: 79 43 79 63 6C 65 5F 43 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  26283 | u4     |          DDF62E9C |                                                                    2620323549 | index       |
|  26287 | s4     |          4E000000 |                                                                            78 | length      |
|  2628B | string | 2F4761 ... 5F4300 | /Game/Mods/Ragnarok/Custom_Assets/Weather/Systems/Rag_DayCycle.Rag_DayCycle_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
262D0:                            B7 7C 4E 9B 0C 00 00
262E0: 00 43 75 72 72 65 6E 74 54 69 6D 65 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  262D9 | u4     |          B77C4E9B |  2605612215 | index       |
|  262DD | s4     |          0C000000 |          12 | length      |
|  262E1 | string | 437572 ... 6D6500 | CurrentTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
262E0:                                        3B D0 64
262F0: 68 08 00 00 00 57 61 72 6D 5B 31 5D 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  262ED | u4     |         3BD06468 | 1751437371 | index       |
|  262F1 | s4     |         08000000 |          8 | length      |
|  262F5 | string | 5761726D5B315D00 |    Warm[1] | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
262F0:                                        2E 5B 7C
26300: 1D 75 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61
26310: 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70
26320: 72 69 6E 74 73 2F 49 6E 76 65 6E 74 6F 72 69 65
26330: 73 2F 50 72 69 6D 61 6C 49 6E 76 65 6E 74 6F 72
26340: 79 42 50 5F 54 72 69 62 75 74 65 54 65 72 6D 69
26350: 6E 61 6C 31 2E 50 72 69 6D 61 6C 49 6E 76 65 6E
26360: 74 6F 72 79 42 50 5F 54 72 69 62 75 74 65 54 65
26370: 72 6D 69 6E 61 6C 31 5F 43 00
```

| offset | type   |           value h |                                                                                                              value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------------: | ----------- |
|  262FD | u4     |          2E5B7C1D |                                                                                                            494689070 | index       |
|  26301 | s4     |          75000000 |                                                                                                                  117 | length      |
|  26305 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Inventories/PrimalInventoryBP_TributeTerminal1.PrimalInventoryBP_TributeTerminal1_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26370:                               05 1A 3E 5F 0F 00
26380: 00 00 49 6E 76 65 6E 74 6F 72 79 49 74 65 6D 73
26390: 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  2637A | u4     |          051A3E5F |     1597905413 | index       |
|  2637E | s4     |          0F000000 |             15 | length      |
|  26382 | string | 496E76 ... 6D7300 | InventoryItems | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26390:    A2 D0 1B 52 0F 00 00 00 62 49 6E 69 74 69 61
263A0: 6C 69 7A 65 64 4D 65 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  26391 | u4     |          A2D01B52 |     1377554594 | index       |
|  26395 | s4     |          0F000000 |             15 | length      |
|  26399 | string | 62496E ... 4D6500 | bInitializedMe | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
263A0:                         8E 1B 47 23 21 00 00 00
263B0: 44 69 73 70 6C 61 79 44 65 66 61 75 6C 74 49 74
263C0: 65 6D 49 6E 76 65 6E 74 6F 72 79 43 6F 75 6E 74
263D0: 00
```

| offset | type   |           value h |                          value d | description |
| -----: | ------ | ----------------: | -------------------------------: | ----------- |
|  263A8 | u4     |          8E1B4723 |                        591862670 | index       |
|  263AC | s4     |          21000000 |                               33 | length      |
|  263B0 | string | 446973 ... 6E7400 | DisplayDefaultItemInventoryCount | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
263D0:    D1 31 78 87 29 00 00 00 53 61 76 65 64 46 6F
263E0: 72 63 65 44 65 66 61 75 6C 74 49 6E 76 65 6E 74
263F0: 6F 72 79 52 65 66 72 65 73 68 56 65 72 73 69 6F
26400: 6E 00
```

| offset | type   |           value h |                                  value d | description |
| -----: | ------ | ----------------: | ---------------------------------------: | ----------- |
|  263D1 | u4     |          D1317887 |                               2272801233 | index       |
|  263D5 | s4     |          29000000 |                                       41 | length      |
|  263D9 | string | 536176 ... 6F6E00 | SavedForceDefaultInventoryRefreshVersion | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26400:       8B DE 97 D8 33 00 00 00 43 6C 61 73 73 20
26410: 2F 53 63 72 69 70 74 2F 53 68 6F 6F 74 65 72 47
26420: 61 6D 65 2E 50 72 69 6D 61 6C 49 6E 76 65 6E 74
26430: 6F 72 79 43 6F 6D 70 6F 6E 65 6E 74 00
```

| offset | type   |           value h |                                            value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------: | ----------- |
|  26402 | u4     |          8BDE97D8 |                                         3633831563 | index       |
|  26406 | s4     |          33000000 |                                                 51 | length      |
|  2640A | string | 436C61 ... 6E7400 | Class /Script/ShooterGame.PrimalInventoryComponent | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26430:                                        8D 02 7F
26440: 7C 1F 00 00 00 41 63 74 69 76 65 49 6E 76 65 6E
26450: 74 6F 72 79 52 65 66 72 65 73 68 49 6E 74 65 72
26460: 76 61 6C 00
```

| offset | type   |           value h |                        value d | description |
| -----: | ------ | ----------------: | -----------------------------: | ----------- |
|  2643D | u4     |          8D027F7C |                     2088698509 | index       |
|  26441 | s4     |          1F000000 |                             31 | length      |
|  26445 | string | 416374 ... 616C00 | ActiveInventoryRefreshInterval | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26460:             28 18 D5 31 6D 00 00 00 2F 47 61 6D

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26470: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F
26480: 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65
26490: 6D 73 2F 41 72 6D 6F 72 2F 53 68 69 65 6C 64 73
264A0: 2F 50 72 69 6D 61 6C 49 74 65 6D 41 72 6D 6F 72
264B0: 5F 57 6F 6F 64 53 68 69 65 6C 64 2E 50 72 69 6D
264C0: 61 6C 49 74 65 6D 41 72 6D 6F 72 5F 57 6F 6F 64
264D0: 53 68 69 65 6C 64 5F 43 00
```

| offset | type   |           value h |                                                                                                      value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------: | ----------- |
|  26464 | u4     |          2818D531 |                                                                                                    836048936 | index       |
|  26468 | s4     |          6D000000 |                                                                                                          109 | length      |
|  2646C | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Shields/PrimalItemArmor_WoodShield.PrimalItemArmor_WoodShield_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
264D0:                            D1 B0 2A 59 07 00 00
264E0: 00 49 74 65 6D 49 44 00
```

| offset | type   |        value h |    value d | description |
| -----: | ------ | -------------: | ---------: | ----------- |
|  264D9 | u4     |       D1B02A59 | 1495970001 | index       |
|  264DD | s4     |       07000000 |          7 | length      |
|  264E1 | string | 4974656D494400 |     ItemID | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
264E0:                         E4 62 88 50 1F 00 00 00
264F0: 4C 61 73 74 41 75 74 6F 44 75 72 61 62 69 6C 69
26500: 74 79 44 65 63 72 65 61 73 65 54 69 6D 65 00
```

| offset | type   |           value h |                        value d | description |
| -----: | ------ | ----------------: | -----------------------------: | ----------- |
|  264E8 | u4     |          E4628850 |                     1351115492 | index       |
|  264EC | s4     |          1F000000 |                             31 | length      |
|  264F0 | string | 4C6173 ... 6D6500 | LastAutoDurabilityDecreaseTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26500:                                              2A
26510: 8D 88 E9 10 00 00 00 53 61 76 65 64 44 75 72 61
26520: 62 69 6C 69 74 79 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  2650F | u4     |          2A8D88E9 |      3918040362 | index       |
|  26513 | s4     |          10000000 |              16 | length      |
|  26517 | string | 536176 ... 747900 | SavedDurability | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26520:                      9C 16 AD 1C 0C 00 00 00 49
26530: 74 65 6D 56 65 72 73 69 6F 6E 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  26527 | u4     |          9C16AD1C |   481105564 | index       |
|  2652B | s4     |          0C000000 |          12 | length      |
|  2652F | string | 497465 ... 6F6E00 | ItemVersion | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26530:                                  B8 BA CD AD 55
26540: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
26550: 61 72 74 68 2F 44 69 6E 6F 73 2F 4C 79 73 74 72
26560: 6F 73 61 75 72 75 73 2F 4C 79 73 74 72 6F 5F 41
26570: 49 43 6F 6E 74 72 6F 6C 6C 65 72 5F 42 50 2E 4C
26580: 79 73 74 72 6F 5F 41 49 43 6F 6E 74 72 6F 6C 6C
26590: 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  2653B | u4     |          B8BACDAD |                                                                           2915941048 | index       |
|  2653F | s4     |          55000000 |                                                                                   85 | length      |
|  26543 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Lystrosaurus/Lystro_AIController_BP.Lystro_AIController_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26590:                         94 7F 85 F7 4F 00 00 00
265A0: 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74
265B0: 68 2F 44 69 6E 6F 73 2F 54 75 72 74 6C 65 2F 54
265C0: 75 72 74 6C 65 5F 41 49 43 6F 6E 74 72 6F 6C 6C
265D0: 65 72 5F 42 50 2E 54 75 72 74 6C 65 5F 41 49 43
265E0: 6F 6E 74 72 6F 6C 6C 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------: | ----------- |
|  26598 | u4     |          947F85F7 |                                                                     4152721300 | index       |
|  2659C | s4     |          4F000000 |                                                                             79 | length      |
|  265A0 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Turtle/Turtle_AIController_BP.Turtle_AIController_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
265E0:                                              EE
265F0: EE 11 FA 4C 00 00 00 2F 47 61 6D 65 2F 50 72 69
26600: 6D 61 6C 45 61 72 74 68 2F 44 69 6E 6F 73 2F 50
26610: 74 65 72 6F 2F 50 74 65 72 6F 5F 41 49 43 6F 6E
26620: 74 72 6F 6C 6C 65 72 5F 42 50 2E 50 74 65 72 6F
26630: 5F 41 49 43 6F 6E 74 72 6F 6C 6C 65 72 5F 42 50
26640: 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  265EF | u4     |          EEEE11FA |                                                                  4195479278 | index       |
|  265F3 | s4     |          4C000000 |                                                                          76 | length      |
|  265F7 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Ptero/Ptero_AIController_BP.Ptero_AIController_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26640:          AE E0 71 DA 49 00 00 00 2F 47 61 6D 65
26650: 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 44 69 6E
26660: 6F 73 2F 44 69 6C 6F 2F 44 69 6C 6F 5F 41 49 43
26670: 6F 6E 74 72 6F 6C 6C 65 72 5F 42 50 2E 44 69 6C
26680: 6F 5F 41 49 43 6F 6E 74 72 6F 6C 6C 65 72 5F 42
26690: 50 5F 43 00
```

| offset | type   |           value h |                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------: | ----------- |
|  26643 | u4     |          AEE071DA |                                                               3664896174 | index       |
|  26647 | s4     |          49000000 |                                                                       73 | length      |
|  2664B | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Dilo/Dilo_AIController_BP.Dilo_AIController_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26690:             90 D3 56 AB 5E 00 00 00 2F 47 61 6D
266A0: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 44 69
266B0: 6E 6F 73 2F 49 63 68 74 68 79 6F 72 6E 69 73 2F
266C0: 49 63 68 74 68 79 6F 72 6E 69 73 5F 41 49 43 6F
266D0: 6E 74 72 6F 6C 6C 65 72 5F 42 50 2E 49 63 68 74
266E0: 68 79 6F 72 6E 69 73 5F 41 49 43 6F 6E 74 72 6F
266F0: 6C 6C 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  26694 | u4     |          90D356AB |                                                                                    2874594192 | index       |
|  26698 | s4     |          5E000000 |                                                                                            94 | length      |
|  2669C | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Ichthyornis/Ichthyornis_AIController_BP.Ichthyornis_AIController_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
266F0:                               A7 5A 2D DF 4C 00
26700: 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61
26710: 72 74 68 2F 44 69 6E 6F 73 2F 4F 74 74 65 72 2F
26720: 4F 74 74 65 72 5F 41 49 43 6F 6E 74 72 6F 6C 6C
26730: 65 72 5F 42 50 2E 4F 74 74 65 72 5F 41 49 43 6F
26740: 6E 74 72 6F 6C 6C 65 72 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------: | ----------- |
|  266FA | u4     |          A75A2DDF |                                                                  3744291495 | index       |
|  266FE | s4     |          4C000000 |                                                                          76 | length      |
|  26702 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Otter/Otter_AIController_BP.Otter_AIController_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26740:                                           CF 21
26750: 74 31 55 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D
26760: 61 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65
26770: 70 72 69 6E 74 73 2F 57 65 61 70 6F 6E 73 2F 50
26780: 72 69 6D 61 6C 49 74 65 6D 5F 57 65 61 70 6F 6E
26790: 42 6F 77 2E 50 72 69 6D 61 6C 49 74 65 6D 5F 57
267A0: 65 61 70 6F 6E 42 6F 77 5F 43 00
```

| offset | type   |           value h |                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------: | ----------- |
|  2674E | u4     |          CF217431 |                                                                            829694415 | index       |
|  26752 | s4     |          55000000 |                                                                                   85 | length      |
|  26756 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItem_WeaponBow.PrimalItem_WeaponBow_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
267A0:                                  C0 64 7D 63 10
267B0: 00 00 00 43 75 73 74 6F 6D 49 74 65 6D 44 61 74
267C0: 61 73 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  267AB | u4     |          C0647D63 |      1669162176 | index       |
|  267AF | s4     |          10000000 |              16 | length      |
|  267B3 | string | 437573 ... 617300 | CustomItemDatas | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
267C0:          F6 7F 5B 83 0F 00 00 00 43 75 73 74 6F
267D0: 6D 49 74 65 6D 44 61 74 61 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  267C3 | u4     |          F67F5B83 |     2203811830 | index       |
|  267C7 | s4     |          0F000000 |             15 | length      |
|  267CB | string | 437573 ... 746100 | CustomItemData | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
267D0:                               9E D6 13 59 10 00
267E0: 00 00 43 75 73 74 6F 6D 44 61 74 61 42 79 74 65
267F0: 73 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  267DA | u4     |          9ED61359 |      1494472350 | index       |
|  267DE | s4     |          10000000 |              16 | length      |
|  267E2 | string | 437573 ... 657300 | CustomDataBytes | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
267F0:       55 3B 8F 12 15 00 00 00 43 75 73 74 6F 6D
26800: 49 74 65 6D 42 79 74 65 41 72 72 61 79 73 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  267F2 | u4     |          553B8F12 |            311376725 | index       |
|  267F6 | s4     |          15000000 |                   21 | length      |
|  267FA | string | 437573 ... 797300 | CustomItemByteArrays | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26800:                                              01
26810: 84 2F CB 0B 00 00 00 42 79 74 65 41 72 72 61 79
26820: 73 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  2680F | u4     |          01842FCB | 3408888833 | index       |
|  26813 | s4     |          0B000000 |         11 | length      |
|  26817 | string | 427974 ... 797300 | ByteArrays | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26820:       1F 5B 71 2C 14 00 00 00 43 75 73 74 6F 6D
26830: 49 74 65 6D 42 79 74 65 41 72 72 61 79 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  26822 | u4     |          1F5B712C |           745626399 | index       |
|  26826 | s4     |          14000000 |                  20 | length      |
|  2682A | string | 437573 ... 617900 | CustomItemByteArray | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26830:                                           89 F9
26840: 67 62 12 00 00 00 43 75 73 74 6F 6D 44 61 74 61
26850: 44 6F 75 62 6C 65 73 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  2683E | u4     |          89F96762 |        1650981257 | index       |
|  26842 | s4     |          12000000 |                18 | length      |
|  26846 | string | 437573 ... 657300 | CustomDataDoubles | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26850:                         FF 9F B7 6D 12 00 00 00
26860: 43 75 73 74 6F 6D 49 74 65 6D 44 6F 75 62 6C 65
26870: 73 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  26858 | u4     |          FF9FB76D |        1840750591 | index       |
|  2685C | s4     |          12000000 |                18 | length      |
|  26860 | string | 437573 ... 657300 | CustomItemDoubles | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26870:       2D ED 9E E2 08 00 00 00 44 6F 75 62 6C 65
26880: 73 00
```

| offset | type   |          value h |    value d | description |
| -----: | ------ | ---------------: | ---------: | ----------- |
|  26872 | u4     |         2DED9EE2 | 3802066221 | index       |
|  26876 | s4     |         08000000 |          8 | length      |
|  2687A | string | 446F75626C657300 |    Doubles | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26880:       3F C6 BF E9 12 00 00 00 43 75 73 74 6F 6D
26890: 44 61 74 61 53 74 72 69 6E 67 73 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  26882 | u4     |          3FC6BFE9 |        3921659455 | index       |
|  26886 | s4     |          12000000 |                18 | length      |
|  2688A | string | 437573 ... 677300 | CustomDataStrings | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26890:                                     B8 EC 92 2F
268A0: 11 00 00 00 43 75 73 74 6F 6D 44 61 74 61 46 6C
268B0: 6F 61 74 73 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  2689C | u4     |          B8EC922F |        798158008 | index       |
|  268A0 | s4     |          11000000 |               17 | length      |
|  268A4 | string | 437573 ... 747300 | CustomDataFloats | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
268B0:                17 60 D8 F3 12 00 00 00 43 75 73
268C0: 74 6F 6D 44 61 74 61 4F 62 6A 65 63 74 73 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  268B5 | u4     |          1760D8F3 |        4091043863 | index       |
|  268B9 | s4     |          12000000 |                18 | length      |
|  268BD | string | 437573 ... 747300 | CustomDataObjects | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
268C0:                                              BB
268D0: 10 5D 43 12 00 00 00 43 75 73 74 6F 6D 44 61 74
268E0: 61 43 6C 61 73 73 65 73 00
```

| offset | type   |           value h |           value d | description |
| -----: | ------ | ----------------: | ----------------: | ----------- |
|  268CF | u4     |          BB105D43 |        1130172603 | index       |
|  268D3 | s4     |          12000000 |                18 | length      |
|  268D7 | string | 437573 ... 657300 | CustomDataClasses | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
268E0:                            FE A0 50 50 10 00 00
268F0: 00 43 75 73 74 6F 6D 44 61 74 61 4E 61 6D 65 73
26900: 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  268E9 | u4     |          FEA05050 |      1347461374 | index       |
|  268ED | s4     |          10000000 |              16 | length      |
|  268F1 | string | 437573 ... 657300 | CustomDataNames | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26900:    03 ED 5D 48 14 00 00 00 55 6E 69 71 75 65 50
26910: 61 69 6E 74 69 6E 67 49 64 4D 61 70 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  26901 | u4     |          03ED5D48 |          1214115075 | index       |
|  26905 | s4     |          14000000 |                  20 | length      |
|  26909 | string | 556E69 ... 617000 | UniquePaintingIdMap | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26910:                                        F7 23 38
26920: 61 11 00 00 00 50 61 69 6E 74 69 6E 67 4B 65 79
26930: 56 61 6C 75 65 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  2691D | u4     |          F7233861 |       1631069175 | index       |
|  26921 | s4     |          11000000 |               17 | length      |
|  26925 | string | 506169 ... 756500 | PaintingKeyValue | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26930:                   87 F1 C4 03 14 00 00 00 50 61
26940: 69 6E 74 69 6E 67 52 65 76 69 73 69 6F 6E 4D 61
26950: 70 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  26936 | u4     |          87F1C403 |            63238535 | index       |
|  2693A | s4     |          14000000 |                  20 | length      |
|  2693E | string | 506169 ... 617000 | PaintingRevisionMap | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26950:       3F 30 E3 BF 0F 00 00 00 43 75 73 74 6F 6D
26960: 44 61 74 61 4E 61 6D 65 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  26952 | u4     |          3F30E3BF |     3219337279 | index       |
|  26956 | s4     |          0F000000 |             15 | length      |
|  2695A | string | 437573 ... 6D6500 | CustomDataName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26960:                            04 24 BC 58 13 00 00
26970: 00 44 72 6F 70 70 65 64 54 6F 6F 6C 74 69 70 49
26980: 6E 66 6F 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  26969 | u4     |          0424BC58 |         1488724996 | index       |
|  2696D | s4     |          13000000 |                 19 | length      |
|  26971 | string | 44726F ... 666F00 | DroppedTooltipInfo | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26980:             82 42 C1 11 16 00 00 00 43 75 73 74
26990: 6F 6D 44 61 74 61 53 6F 66 74 43 6C 61 73 73 65
269A0: 73 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  26984 | u4     |          8242C111 |             297878146 | index       |
|  26988 | s4     |          16000000 |                    22 | length      |
|  2698C | string | 437573 ... 657300 | CustomDataSoftClasses | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
269A0:       29 BB D5 3C 10 00 00 00 49 74 65 6D 43 75
269B0: 73 74 6F 6D 43 6C 61 73 73 00
```

| offset | type   |           value h |         value d | description |
| -----: | ------ | ----------------: | --------------: | ----------- |
|  269A2 | u4     |          29BBD53C |      1020640041 | index       |
|  269A6 | s4     |          10000000 |              16 | length      |
|  269AA | string | 497465 ... 737300 | ItemCustomClass | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
269B0:                               10 5F B6 4B 77 00
269C0: 00 00 42 6C 75 65 70 72 69 6E 74 47 65 6E 65 72
269D0: 61 74 65 64 43 6C 61 73 73 20 2F 47 61 6D 65 2F
269E0: 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65
269F0: 42 6C 75 65 70 72 69 6E 74 73 2F 57 65 61 70 6F
26A00: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 41 6D 6D
26A10: 6F 5F 41 72 72 6F 77 53 74 6F 6E 65 2E 50 72 69
26A20: 6D 61 6C 49 74 65 6D 41 6D 6D 6F 5F 41 72 72 6F
26A30: 77 53 74 6F 6E 65 5F 43 00
```

| offset | type   |           value h |                                                                                                                value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------: | ----------- |
|  269BA | u4     |          105FB64B |                                                                                                             1270243088 | index       |
|  269BE | s4     |          77000000 |                                                                                                                    119 | length      |
|  269C2 | string | 426C75 ... 5F4300 | BlueprintGeneratedClass /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItemAmmo_ArrowStone.PrimalItemAmmo_ArrowStone_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26A30:                            1D CB 7A CE 2A 00 00
26A40: 00 4D 61 78 54 61 6D 69 6E 67 45 66 66 65 63 74
26A50: 69 76 65 6E 65 73 73 42 61 73 65 4C 65 76 65 6C
26A60: 4D 75 6C 74 69 70 6C 69 65 72 00
```

| offset | type   |           value h |                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------: | ----------- |
|  26A39 | u4     |          1DCB7ACE |                                3464153885 | index       |
|  26A3D | s4     |          2A000000 |                                        42 | length      |
|  26A41 | string | 4D6178 ... 657200 | MaxTamingEffectivenessBaseLevelMultiplier | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26A60:                                  77 07 48 26 43
26A70: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
26A80: 61 72 74 68 2F 44 69 6E 6F 73 2F 50 61 72 61 2F
26A90: 50 61 72 61 5F 41 49 5F 42 6C 75 65 70 72 69 6E
26AA0: 74 2E 50 61 72 61 5F 41 49 5F 42 6C 75 65 70 72
26AB0: 69 6E 74 5F 43 00
```

| offset | type   |           value h |                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------: | ----------- |
|  26A6B | u4     |          77074826 |                                                          642254711 | index       |
|  26A6F | s4     |          43000000 |                                                                 67 | length      |
|  26A73 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Dinos/Para/Para_AI_Blueprint.Para_AI_Blueprint_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26AB0:                   8E 39 FB 7E 47 00 00 00 2F 47
26AC0: 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F
26AD0: 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 57
26AE0: 65 61 70 6F 6E 73 2F 57 65 61 70 53 74 6F 6E 65
26AF0: 50 69 63 6B 2E 57 65 61 70 53 74 6F 6E 65 50 69
26B00: 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------: | ----------- |
|  26AB6 | u4     |          8E39FB7E |                                                             2130393486 | index       |
|  26ABA | s4     |          47000000 |                                                                     71 | length      |
|  26ABE | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/WeapStonePick.WeapStonePick_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26B00:                5D BE 85 8F 15 00 00 00 41 73 73
26B10: 6F 63 69 61 74 65 64 50 72 69 6D 61 6C 49 74 65
26B20: 6D 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  26B05 | u4     |          5DBE858F |           2407906909 | index       |
|  26B09 | s4     |          15000000 |                   21 | length      |
|  26B0D | string | 417373 ... 656D00 | AssociatedPrimalItem | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26B20:       F8 19 C6 07 07 00 00 00 4D 79 50 61 77 6E
26B30: 00
```

| offset | type   |        value h |   value d | description |
| -----: | ------ | -------------: | --------: | ----------- |
|  26B22 | u4     |       F819C607 | 130423288 | index       |
|  26B26 | s4     |       07000000 |         7 | length      |
|  26B2A | string | 4D795061776E00 |    MyPawn | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26B30:    3B 53 18 A7 4E 00 00 00 2F 47 61 6D 65 2F 50
26B40: 72 69 6D 61 6C 45 61 72 74 68 2F 53 6F 75 6E 64
26B50: 2F 50 6C 61 79 65 72 56 6F 69 63 65 2F 50 44 41
26B60: 5F 56 6F 69 63 65 43 6F 6C 6C 65 63 74 69 6F 6E
26B70: 2E 50 44 41 5F 56 6F 69 63 65 43 6F 6C 6C 65 63
26B80: 74 69 6F 6E 5F 43 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  26B31 | u4     |          3B5318A7 |                                                                    2803389243 | index       |
|  26B35 | s4     |          4E000000 |                                                                            78 | length      |
|  26B39 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Sound/PlayerVoice/PDA_VoiceCollection.PDA_VoiceCollection_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26B80:                      64 1C BD 53 67 00 00 00 2F
26B90: 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68
26BA0: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
26BB0: 50 6C 61 79 65 72 43 68 61 72 61 63 74 65 72 53
26BC0: 74 61 74 75 73 43 6F 6D 70 6F 6E 65 6E 74 5F 42
26BD0: 50 2E 50 6C 61 79 65 72 43 68 61 72 61 63 74 65
26BE0: 72 53 74 61 74 75 73 43 6F 6D 70 6F 6E 65 6E 74
26BF0: 5F 42 50 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  26B87 | u4     |          641CBD53 |                                                                                             1404902500 | index       |
|  26B8B | s4     |          67000000 |                                                                                                    103 | length      |
|  26B8F | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/PlayerCharacterStatusComponent_BP.PlayerCharacterStatusComponent_BP_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26BF0:                   08 A7 F2 71 25 00 00 00 62 49
26C00: 6E 69 74 69 61 6C 69 7A 65 64 42 61 73 65 4C 65
26C10: 76 65 6C 4D 61 78 53 74 61 74 75 73 56 61 6C 75
26C20: 65 73 00
```

| offset | type   |           value h |                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------: | ----------- |
|  26BF6 | u4     |          08A7F271 |                           1911727880 | index       |
|  26BFA | s4     |          25000000 |                                   37 | length      |
|  26BFE | string | 62496E ... 657300 | bInitializedBaseLevelMaxStatusValues | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26C20:          98 E4 D8 BB 14 00 00 00 45 78 74 72 61
26C30: 43 68 61 72 61 63 74 65 72 4C 65 76 65 6C 00
```

| offset | type   |           value h |             value d | description |
| -----: | ------ | ----------------: | ------------------: | ----------- |
|  26C23 | u4     |          98E4D8BB |          3151553688 | index       |
|  26C27 | s4     |          14000000 |                  20 | length      |
|  26C2B | string | 457874 ... 656C00 | ExtraCharacterLevel | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26C30:                                              5D
26C40: 60 EB 5A 0F 00 00 00 55 49 6E 74 31 36 50 72 6F
26C50: 70 65 72 74 79 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  26C3F | u4     |          5D60EB5A |     1525375069 | index       |
|  26C43 | s4     |          0F000000 |             15 | length      |
|  26C47 | string | 55496E ... 747900 | UInt16Property | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26C50:                   84 44 55 B2 11 00 00 00 45 78
26C60: 70 65 72 69 65 6E 63 65 50 6F 69 6E 74 73 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  26C56 | u4     |          844455B2 |       2991932548 | index       |
|  26C5A | s4     |          11000000 |               17 | length      |
|  26C5E | string | 457870 ... 747300 | ExperiencePoints | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26C60:                                              3D
26C70: 67 A0 07 2D 00 00 00 2F 53 63 72 69 70 74 2F 53
26C80: 68 6F 6F 74 65 72 47 61 6D 65 2E 50 72 69 6D 61
26C90: 6C 49 6E 76 65 6E 74 6F 72 79 43 6F 6D 70 6F 6E
26CA0: 65 6E 74 00
```

| offset | type   |           value h |                                      value d | description |
| -----: | ------ | ----------------: | -------------------------------------------: | ----------- |
|  26C6F | u4     |          3D67A007 |                                    127952701 | index       |
|  26C73 | s4     |          2D000000 |                                           45 | length      |
|  26C77 | string | 2F5363 ... 6E7400 | /Script/ShooterGame.PrimalInventoryComponent | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26CA0:             75 BB 49 75 0A 00 00 00 49 74 65 6D
26CB0: 53 6C 6F 74 73 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  26CA4 | u4     |          75BB4975 | 1967766389 | index       |
|  26CA8 | s4     |          0A000000 |         10 | length      |
|  26CAC | string | 497465 ... 747300 |  ItemSlots | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26CB0:                   39 2C EE C3 19 00 00 00 4C 61
26CC0: 73 74 49 6E 76 65 6E 74 6F 72 79 52 65 66 72 65
26CD0: 73 68 54 69 6D 65 00
```

| offset | type   |           value h |                  value d | description |
| -----: | ------ | ----------------: | -----------------------: | ----------- |
|  26CB6 | u4     |          392CEEC3 |               3287166009 | index       |
|  26CBA | s4     |          19000000 |                       25 | length      |
|  26CBE | string | 4C6173 ... 6D6500 | LastInventoryRefreshTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26CD0:                      6A 88 E2 7A 57 00 00 00 2F
26CE0: 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68
26CF0: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
26D00: 50 6C 61 79 65 72 43 6F 6E 74 72 6F 6C 6C 65 72
26D10: 42 6C 75 65 70 72 69 6E 74 2E 50 6C 61 79 65 72
26D20: 43 6F 6E 74 72 6F 6C 6C 65 72 42 6C 75 65 70 72
26D30: 69 6E 74 5F 43 00
```

| offset | type   |           value h |                                                                                value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------: | ----------- |
|  26CD7 | u4     |          6A88E27A |                                                                             2061666410 | index       |
|  26CDB | s4     |          57000000 |                                                                                     87 | length      |
|  26CDF | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/PlayerControllerBlueprint.PlayerControllerBlueprint_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26D30:                   C6 82 30 E4 59 00 00 00 2F 47
26D40: 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F
26D50: 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 57
26D60: 65 61 70 6F 6E 73 2F 50 72 69 6D 61 6C 49 74 65
26D70: 6D 5F 57 65 61 70 6F 6E 53 70 65 61 72 2E 50 72
26D80: 69 6D 61 6C 49 74 65 6D 5F 57 65 61 70 6F 6E 53
26D90: 70 65 61 72 5F 43 00
```

| offset | type   |           value h |                                                                                  value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------: | ----------- |
|  26D36 | u4     |          C68230E4 |                                                                               3828384454 | index       |
|  26D3A | s4     |          59000000 |                                                                                       89 | length      |
|  26D3E | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItem_WeaponSpear.PrimalItem_WeaponSpear_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26D90:                      C5 B4 9C A7 0F 00 00 00 57
26DA0: 65 61 70 6F 6E 43 6C 69 70 41 6D 6D 6F 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  26D97 | u4     |          C5B49CA7 |     2812064965 | index       |
|  26D9B | s4     |          0F000000 |             15 | length      |
|  26D9F | string | 576561 ... 6D6F00 | WeaponClipAmmo | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26DA0:                                           43 4F
26DB0: 2F C9 0D 00 00 00 49 74 65 6D 51 75 61 6E 74 69
26DC0: 74 79 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  26DAE | u4     |          434F2FC9 |   3375320899 | index       |
|  26DB2 | s4     |          0D000000 |           13 | length      |
|  26DB6 | string | 497465 ... 747900 | ItemQuantity | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26DC0:          C6 81 16 03 73 00 00 00 2F 47 61 6D 65
26DD0: 2F 53 63 6F 72 63 68 65 64 45 61 72 74 68 2F 43
26DE0: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 42 75
26DF0: 66 66 73 2F 50 72 69 6D 61 6C 42 75 66 66 50 65
26E00: 72 73 69 73 74 65 6E 74 44 61 74 61 5F 48 65 61
26E10: 74 53 74 72 6F 6B 65 2E 50 72 69 6D 61 6C 42 75
26E20: 66 66 50 65 72 73 69 73 74 65 6E 74 44 61 74 61
26E30: 5F 48 65 61 74 53 74 72 6F 6B 65 5F 43 00
```

| offset | type   |           value h |                                                                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------: | ----------- |
|  26DC3 | u4     |          C6811603 |                                                                                                           51806662 | index       |
|  26DC7 | s4     |          73000000 |                                                                                                                115 | length      |
|  26DCB | string | 2F4761 ... 5F4300 | /Game/ScorchedEarth/CoreBlueprints/Buffs/PrimalBuffPersistentData_HeatStroke.PrimalBuffPersistentData_HeatStroke_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26E30:                                           B1 B7
26E40: B6 B2 13 00 00 00 46 6F 72 50 72 69 6D 61 6C 42
26E50: 75 66 66 43 6C 61 73 73 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  26E3E | u4     |          B1B7B6B2 |         2998319025 | index       |
|  26E42 | s4     |          13000000 |                 19 | length      |
|  26E46 | string | 466F72 ... 737300 | ForPrimalBuffClass | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26E50:                            95 1E E8 05 83 00 00
26E60: 00 42 6C 75 65 70 72 69 6E 74 47 65 6E 65 72 61
26E70: 74 65 64 43 6C 61 73 73 20 2F 47 61 6D 65 2F 53
26E80: 63 6F 72 63 68 65 64 45 61 72 74 68 2F 43 6F 72
26E90: 65 42 6C 75 65 70 72 69 6E 74 73 2F 42 75 66 66
26EA0: 73 2F 42 75 66 66 5F 42 61 73 65 5F 50 65 72 73
26EB0: 69 73 74 65 6E 74 5F 48 65 61 74 73 74 72 6F 6B
26EC0: 65 2E 42 75 66 66 5F 42 61 73 65 5F 50 65 72 73
26ED0: 69 73 74 65 6E 74 5F 48 65 61 74 73 74 72 6F 6B
26EE0: 65 5F 43 00
```

| offset | type   |           value h |                                                                                                                            value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  26E59 | u4     |          951EE805 |                                                                                                                           99098261 | index       |
|  26E5D | s4     |          83000000 |                                                                                                                                131 | length      |
|  26E61 | string | 426C75 ... 5F4300 | BlueprintGeneratedClass /Game/ScorchedEarth/CoreBlueprints/Buffs/Buff_Base_Persistent_Heatstroke.Buff_Base_Persistent_Heatstroke_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26EE0:             D8 DF E9 F6 19 00 00 00 46 6F 72 50
26EF0: 72 69 6D 61 6C 42 75 66 66 43 6C 61 73 73 53 74
26F00: 72 69 6E 67 00
```

| offset | type   |           value h |                  value d | description |
| -----: | ------ | ----------------: | -----------------------: | ----------- |
|  26EE4 | u4     |          D8DFE9F6 |               4142522328 | index       |
|  26EE8 | s4     |          19000000 |                       25 | length      |
|  26EEC | string | 466F72 ... 6E6700 | ForPrimalBuffClassString | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26F00:                75 D9 3B 34 2F 00 00 00 2F 53 63
26F10: 72 69 70 74 2F 53 68 6F 6F 74 65 72 47 61 6D 65
26F20: 2E 53 74 72 75 63 74 75 72 65 50 61 69 6E 74 69
26F30: 6E 67 43 6F 6D 70 6F 6E 65 6E 74 00
```

| offset | type   |           value h |                                        value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------: | ----------- |
|  26F05 | u4     |          75D93B34 |                                      876337525 | index       |
|  26F09 | s4     |          2F000000 |                                             47 | length      |
|  26F0D | string | 2F5363 ... 6E7400 | /Script/ShooterGame.StructurePaintingComponent | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26F30:                                     E2 5D 7D 59
26F40: 04 00 00 00 4B 65 79 00
```

| offset | type   |  value h |    value d | description |
| -----: | ------ | -------: | ---------: | ----------- |
|  26F3C | u4     | E25D7D59 | 1501388258 | index       |
|  26F40 | s4     | 04000000 |          4 | length      |
|  26F44 | string | 4B657900 |        Key | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26F40:                         67 BD 65 87 06 00 00 00
26F50: 56 61 6C 75 65 00
```

| offset | type   |      value h |    value d | description |
| -----: | ------ | -----------: | ---------: | ----------- |
|  26F48 | u4     |     67BD6587 | 2271591783 | index       |
|  26F4C | s4     |     06000000 |          6 | length      |
|  26F50 | string | 56616C756500 |      Value | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26F50:                   9D D7 C5 D9 7D 00 00 00 2F 47
26F60: 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F
26F70: 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49
26F80: 74 65 6D 73 2F 53 74 72 75 63 74 75 72 65 73 2F
26F90: 4D 69 73 63 2F 50 72 69 6D 61 6C 49 74 65 6D 53
26FA0: 74 72 75 63 74 75 72 65 5F 54 65 6B 52 65 70 6C
26FB0: 69 63 61 74 6F 72 2E 50 72 69 6D 61 6C 49 74 65
26FC0: 6D 53 74 72 75 63 74 75 72 65 5F 54 65 6B 52 65
26FD0: 70 6C 69 63 61 74 6F 72 5F 43 00
```

| offset | type   |           value h |                                                                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  26F56 | u4     |          9DD7C5D9 |                                                                                                                   3653621661 | index       |
|  26F5A | s4     |          7D000000 |                                                                                                                          125 | length      |
|  26F5E | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Structures/Misc/PrimalItemStructure_TekReplicator.PrimalItemStructure_TekReplicator_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26FD0:                                  33 97 01 43 0F
26FE0: 00 00 00 4F 77 6E 65 72 49 6E 76 65 6E 74 6F 72
26FF0: 79 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  26FDB | u4     |          33970143 |     1124177715 | index       |
|  26FDF | s4     |          0F000000 |             15 | length      |
|  26FE3 | string | 4F776E ... 727900 | OwnerInventory | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
26FF0:       13 FF A0 EB 09 00 00 00 62 43 61 6E 53 6C
27000: 6F 74 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  26FF2 | u4     |          13FFA0EB | 3953196819 | index       |
|  26FF6 | s4     |          09000000 |          9 | length      |
|  26FFA | string | 624361 ... 6F7400 |   bCanSlot | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27000:          A5 95 2D AD 0D 00 00 00 62 49 73 42 6C
27010: 75 65 70 72 69 6E 74 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  27003 | u4     |          A5952DAD |   2905445797 | index       |
|  27007 | s4     |          0D000000 |           13 | length      |
|  2700B | string | 624973 ... 6E7400 | bIsBlueprint | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27010:                         DE 6B 8B 93 0A 00 00 00
27020: 62 49 73 45 6E 67 72 61 6D 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  27018 | u4     |          DE6B8B93 | 2475387870 | index       |
|  2701C | s4     |          0A000000 |         10 | length      |
|  27020 | string | 624973 ... 616D00 |  bIsEngram | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27020:                               E3 40 4A C6 1B 00
27030: 00 00 62 41 6C 6C 6F 77 52 65 6D 6F 76 61 6C 46
27040: 72 6F 6D 49 6E 76 65 6E 74 6F 72 79 00
```

| offset | type   |           value h |                    value d | description |
| -----: | ------ | ----------------: | -------------------------: | ----------- |
|  2702A | u4     |          E3404AC6 |                 3326755043 | index       |
|  2702E | s4     |          1B000000 |                         27 | length      |
|  27032 | string | 62416C ... 727900 | bAllowRemovalFromInventory | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27040:                                        56 7C E4
27050: 0D 20 00 00 00 62 48 69 64 65 46 72 6F 6D 52 65
27060: 6D 6F 74 65 49 6E 76 65 6E 74 6F 72 79 44 69 73
27070: 70 6C 61 79 00
```

| offset | type   |           value h |                         value d | description |
| -----: | ------ | ----------------: | ------------------------------: | ----------- |
|  2704D | u4     |          567CE40D |                       233077846 | index       |
|  27051 | s4     |          20000000 |                              32 | length      |
|  27055 | string | 624869 ... 617900 | bHideFromRemoteInventoryDisplay | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27070:                C7 32 23 44 0F 00 00 00 62 49 73
27080: 49 6E 69 74 69 61 6C 49 74 65 6D 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  27075 | u4     |          C7322344 |     1143157447 | index       |
|  27079 | s4     |          0F000000 |             15 | length      |
|  2707D | string | 624973 ... 656D00 | bIsInitialItem | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27080:                                     61 54 51 5D
27090: 66 00 00 00 2F 47 61 6D 65 2F 45 78 74 69 6E 63
270A0: 74 69 6F 6E 2F 43 6F 72 65 42 6C 75 65 70 72 69
270B0: 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C
270C0: 49 74 65 6D 53 74 72 75 63 74 75 72 65 5F 43 72
270D0: 79 6F 46 72 69 64 67 65 2E 50 72 69 6D 61 6C 49
270E0: 74 65 6D 53 74 72 75 63 74 75 72 65 5F 43 72 79
270F0: 6F 46 72 69 64 67 65 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  2708C | u4     |          6154515D |                                                                                            1565611105 | index       |
|  27090 | s4     |          66000000 |                                                                                                   102 | length      |
|  27094 | string | 2F4761 ... 5F4300 | /Game/Extinction/CoreBlueprints/Items/PrimalItemStructure_CryoFridge.PrimalItemStructure_CryoFridge_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
270F0:                               7C A5 EB 98 66 00
27100: 00 00 2F 47 61 6D 65 2F 45 78 74 69 6E 63 74 69
27110: 6F 6E 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74
27120: 73 2F 57 65 61 70 6F 6E 73 2F 50 72 69 6D 61 6C
27130: 49 74 65 6D 5F 57 65 61 70 6F 6E 45 6D 70 74 79
27140: 43 72 79 6F 70 6F 64 2E 50 72 69 6D 61 6C 49 74
27150: 65 6D 5F 57 65 61 70 6F 6E 45 6D 70 74 79 43 72
27160: 79 6F 70 6F 64 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  270FA | u4     |          7CA5EB98 |                                                                                            2565580156 | index       |
|  270FE | s4     |          66000000 |                                                                                                   102 | length      |
|  27102 | string | 2F4761 ... 5F4300 | /Game/Extinction/CoreBlueprints/Weapons/PrimalItem_WeaponEmptyCryopod.PrimalItem_WeaponEmptyCryopod_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27160:                         31 D7 EB CF 6F 00 00 00
27170: 2F 47 61 6D 65 2F 41 53 41 2F 44 69 6E 6F 73 2F
27180: 49 63 65 57 79 76 65 72 6E 2F 42 6F 73 73 2F 50
27190: 72 69 6D 61 6C 49 74 65 6D 5F 42 6F 73 73 54 72
271A0: 69 62 75 74 65 5F 52 61 67 57 79 76 42 6F 73 73
271B0: 5F 45 61 73 79 2E 50 72 69 6D 61 6C 49 74 65 6D
271C0: 5F 42 6F 73 73 54 72 69 62 75 74 65 5F 52 61 67
271D0: 57 79 76 42 6F 73 73 5F 45 61 73 79 5F 43 00
```

| offset | type   |           value h |                                                                                                        value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------: | ----------- |
|  27168 | u4     |          31D7EBCF |                                                                                                     3488339761 | index       |
|  2716C | s4     |          6F000000 |                                                                                                            111 | length      |
|  27170 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/IceWyvern/Boss/PrimalItem_BossTribute_RagWyvBoss_Easy.PrimalItem_BossTribute_RagWyvBoss_Easy_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
271D0:                                              AE
271E0: F5 1B B6 73 00 00 00 2F 47 61 6D 65 2F 41 53 41
271F0: 2F 44 69 6E 6F 73 2F 49 63 65 57 79 76 65 72 6E
27200: 2F 42 6F 73 73 2F 50 72 69 6D 61 6C 49 74 65 6D
27210: 5F 42 6F 73 73 54 72 69 62 75 74 65 5F 52 61 67
27220: 57 79 76 42 6F 73 73 5F 4D 65 64 69 75 6D 2E 50
27230: 72 69 6D 61 6C 49 74 65 6D 5F 42 6F 73 73 54 72
27240: 69 62 75 74 65 5F 52 61 67 57 79 76 42 6F 73 73
27250: 5F 4D 65 64 69 75 6D 5F 43 00
```

| offset | type   |           value h |                                                                                                            value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------: | ----------- |
|  271DF | u4     |          AEF51BB6 |                                                                                                         3055285678 | index       |
|  271E3 | s4     |          73000000 |                                                                                                                115 | length      |
|  271E7 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/IceWyvern/Boss/PrimalItem_BossTribute_RagWyvBoss_Medium.PrimalItem_BossTribute_RagWyvBoss_Medium_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27250:                               42 92 98 F5 6F 00
27260: 00 00 2F 47 61 6D 65 2F 41 53 41 2F 44 69 6E 6F
27270: 73 2F 49 63 65 57 79 76 65 72 6E 2F 42 6F 73 73
27280: 2F 50 72 69 6D 61 6C 49 74 65 6D 5F 42 6F 73 73
27290: 54 72 69 62 75 74 65 5F 52 61 67 57 79 76 42 6F
272A0: 73 73 5F 48 61 72 64 2E 50 72 69 6D 61 6C 49 74
272B0: 65 6D 5F 42 6F 73 73 54 72 69 62 75 74 65 5F 52
272C0: 61 67 57 79 76 42 6F 73 73 5F 48 61 72 64 5F 43
272D0: 00
```

| offset | type   |           value h |                                                                                                        value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------: | ----------- |
|  2725A | u4     |          429298F5 |                                                                                                     4120416834 | index       |
|  2725E | s4     |          6F000000 |                                                                                                            111 | length      |
|  27262 | string | 2F4761 ... 5F4300 | /Game/ASA/Dinos/IceWyvern/Boss/PrimalItem_BossTribute_RagWyvBoss_Hard.PrimalItem_BossTribute_RagWyvBoss_Hard_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
272D0:    14 2F CA 0F 0A 00 00 00 53 6C 6F 74 49 6E 64
272E0: 65 78 00
```

| offset | type   |           value h |   value d | description |
| -----: | ------ | ----------------: | --------: | ----------- |
|  272D1 | u4     |          142FCA0F | 264908564 | index       |
|  272D5 | s4     |          0A000000 |        10 | length      |
|  272D9 | string | 536C6F ... 657800 | SlotIndex | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
272E0:          B9 11 82 F6 0E 00 00 00 54 65 6D 70 53
272F0: 6C 6F 74 49 6E 64 65 78 00
```

| offset | type   |           value h |       value d | description |
| -----: | ------ | ----------------: | ------------: | ----------- |
|  272E3 | u4     |          B91182F6 |    4135719353 | index       |
|  272E7 | s4     |          0E000000 |            14 | length      |
|  272EB | string | 54656D ... 657800 | TempSlotIndex | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
272F0:                            B4 57 81 6B 67 00 00
27300: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
27310: 74 68 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74
27320: 73 2F 57 65 61 70 6F 6E 73 2F 50 72 69 6D 61 6C
27330: 49 74 65 6D 5F 57 65 61 70 6F 6E 4D 65 74 61 6C
27340: 48 61 74 63 68 65 74 2E 50 72 69 6D 61 6C 49 74
27350: 65 6D 5F 57 65 61 70 6F 6E 4D 65 74 61 6C 48 61
27360: 74 63 68 65 74 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  272F9 | u4     |          B457816B |                                                                                             1803638708 | index       |
|  272FD | s4     |          67000000 |                                                                                                    103 | length      |
|  27301 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItem_WeaponMetalHatchet.PrimalItem_WeaponMetalHatchet_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27360:                         05 30 17 2D 0C 00 00 00
27370: 4C 61 73 74 55 73 65 54 69 6D 65 00
```

| offset | type   |           value h |     value d | description |
| -----: | ------ | ----------------: | ----------: | ----------- |
|  27368 | u4     |          0530172D |   756494341 | index       |
|  2736C | s4     |          0C000000 |          12 | length      |
|  27370 | string | 4C6173 ... 6D6500 | LastUseTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27370:                                     1B 09 39 5D
27380: 61 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
27390: 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72
273A0: 69 6E 74 73 2F 57 65 61 70 6F 6E 73 2F 50 72 69
273B0: 6D 61 6C 49 74 65 6D 5F 57 65 61 70 6F 6E 53 74
273C0: 6F 6E 65 50 69 63 6B 2E 50 72 69 6D 61 6C 49 74
273D0: 65 6D 5F 57 65 61 70 6F 6E 53 74 6F 6E 65 50 69
273E0: 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                          value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------: | ----------- |
|  2737C | u4     |          1B09395D |                                                                                       1564018971 | index       |
|  27380 | s4     |          61000000 |                                                                                               97 | length      |
|  27384 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItem_WeaponStonePick.PrimalItem_WeaponStonePick_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
273E0:                D1 09 E1 CB 15 00 00 00 43 72 61
273F0: 66 74 65 72 43 68 61 72 61 63 74 65 72 4E 61 6D
27400: 65 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  273E5 | u4     |          D109E1CB |           3420522961 | index       |
|  273E9 | s4     |          15000000 |                   21 | length      |
|  273ED | string | 437261 ... 6D6500 | CrafterCharacterName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27400:       BB E7 E5 B4 11 00 00 00 43 72 61 66 74 65
27410: 72 54 72 69 62 65 4E 61 6D 65 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  27402 | u4     |          BBE7E5B4 |       3034965947 | index       |
|  27406 | s4     |          11000000 |               17 | length      |
|  2740A | string | 437261 ... 6D6500 | CrafterTribeName | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27410:                                  3E A8 67 9E 11
27420: 00 00 00 41 73 73 6F 63 69 61 74 65 64 57 65 61
27430: 70 6F 6E 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  2741B | u4     |          3EA8679E |       2657593406 | index       |
|  2741F | s4     |          11000000 |               17 | length      |
|  27423 | string | 417373 ... 6F6E00 | AssociatedWeapon | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27430:             E5 B7 85 F2 5F 00 00 00 2F 47 61 6D
27440: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F
27450: 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 57 65 61
27460: 70 6F 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 5F
27470: 57 65 61 70 6F 6E 43 72 6F 73 73 62 6F 77 2E 50
27480: 72 69 6D 61 6C 49 74 65 6D 5F 57 65 61 70 6F 6E
27490: 43 72 6F 73 73 62 6F 77 5F 43 00
```

| offset | type   |           value h |                                                                                        value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------: | ----------- |
|  27434 | u4     |          E5B785F2 |                                                                                     4068849637 | index       |
|  27438 | s4     |          5F000000 |                                                                                             95 | length      |
|  2743C | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItem_WeaponCrossbow.PrimalItem_WeaponCrossbow_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27490:                                  D5 4C 1B 57 48
274A0: 00 00 00 2F 41 53 42 45 78 70 6F 72 74 47 75 6E
274B0: 2F 57 65 61 70 6F 6E 73 2F 50 72 69 6D 61 6C 49
274C0: 74 65 6D 5F 41 53 42 45 78 70 6F 72 74 47 75 6E
274D0: 2E 50 72 69 6D 61 6C 49 74 65 6D 5F 41 53 42 45
274E0: 78 70 6F 72 74 47 75 6E 5F 43 00
```

| offset | type   |           value h |                                                                 value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------: | ----------- |
|  2749B | u4     |          D54C1B57 |                                                              1461406933 | index       |
|  2749F | s4     |          48000000 |                                                                      72 | length      |
|  274A3 | string | 2F4153 ... 5F4300 | /ASBExportGun/Weapons/PrimalItem_ASBExportGun.PrimalItem_ASBExportGun_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
274E0:                                  33 B8 C1 EA 5F
274F0: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
27500: 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72 69
27510: 6E 74 73 2F 57 65 61 70 6F 6E 73 2F 50 72 69 6D
27520: 61 6C 49 74 65 6D 41 6D 6D 6F 5F 41 72 72 6F 77
27530: 53 74 6F 6E 65 2E 50 72 69 6D 61 6C 49 74 65 6D
27540: 41 6D 6D 6F 5F 41 72 72 6F 77 53 74 6F 6E 65 5F
27550: 43 00
```

| offset | type   |           value h |                                                                                        value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------: | ----------- |
|  274EB | u4     |          33B8C1EA |                                                                                     3938564147 | index       |
|  274EF | s4     |          5F000000 |                                                                                             95 | length      |
|  274F3 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItemAmmo_ArrowStone.PrimalItemAmmo_ArrowStone_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27550:       EA 18 75 AA 5D 00 00 00 2F 47 61 6D 65 2F
27560: 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65
27570: 42 6C 75 65 70 72 69 6E 74 73 2F 52 65 73 6F 75
27580: 72 63 65 73 2F 50 72 69 6D 61 6C 49 74 65 6D 52
27590: 65 73 6F 75 72 63 65 5F 48 69 64 65 2E 50 72 69
275A0: 6D 61 6C 49 74 65 6D 52 65 73 6F 75 72 63 65 5F
275B0: 48 69 64 65 5F 43 00
```

| offset | type   |           value h |                                                                                      value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------: | ----------- |
|  27552 | u4     |          EA1875AA |                                                                                   2859800810 | index       |
|  27556 | s4     |          5D000000 |                                                                                           93 | length      |
|  2755A | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Resources/PrimalItemResource_Hide.PrimalItemResource_Hide_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
275B0:                      67 A3 7A 62 6F 00 00 00 2F
275C0: 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68
275D0: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
275E0: 49 74 65 6D 73 2F 43 6F 6E 73 75 6D 61 62 6C 65
275F0: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 6E 73
27600: 75 6D 61 62 6C 65 5F 52 61 77 4D 65 61 74 2E 50
27610: 72 69 6D 61 6C 49 74 65 6D 43 6F 6E 73 75 6D 61
27620: 62 6C 65 5F 52 61 77 4D 65 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                                        value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------: | ----------- |
|  275B7 | u4     |          67A37A62 |                                                                                                     1652204391 | index       |
|  275BB | s4     |          6F000000 |                                                                                                            111 | length      |
|  275BF | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Consumables/PrimalItemConsumable_RawMeat.PrimalItemConsumable_RawMeat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27620:                                           96 C0
27630: 16 33 0D 00 00 00 43 72 65 61 74 69 6F 6E 54 69
27640: 6D 65 00
```

| offset | type   |           value h |      value d | description |
| -----: | ------ | ----------------: | -----------: | ----------- |
|  2762E | u4     |          96C01633 |    857129110 | index       |
|  27632 | s4     |          0D000000 |           13 | length      |
|  27636 | string | 437265 ... 6D6500 | CreationTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27640:          7F 7C 92 AA 11 00 00 00 4E 65 78 74 53
27650: 70 6F 69 6C 69 6E 67 54 69 6D 65 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  27643 | u4     |          7F7C92AA |       2861726847 | index       |
|  27647 | s4     |          11000000 |               17 | length      |
|  2764B | string | 4E6578 ... 6D6500 | NextSpoilingTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27650:                                     B1 BF F3 60
27660: 11 00 00 00 4C 61 73 74 53 70 6F 69 6C 69 6E 67
27670: 54 69 6D 65 00
```

| offset | type   |           value h |          value d | description |
| -----: | ------ | ----------------: | ---------------: | ----------- |
|  2765C | u4     |          B1BFF360 |       1626587057 | index       |
|  27660 | s4     |          11000000 |               17 | length      |
|  27664 | string | 4C6173 ... 6D6500 | LastSpoilingTime | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27670:                67 1C 3F 82 5F 00 00 00 2F 47 61
27680: 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43
27690: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 52 65
276A0: 73 6F 75 72 63 65 73 2F 50 72 69 6D 61 6C 49 74
276B0: 65 6D 52 65 73 6F 75 72 63 65 5F 46 6C 69 6E 74
276C0: 2E 50 72 69 6D 61 6C 49 74 65 6D 52 65 73 6F 75
276D0: 72 63 65 5F 46 6C 69 6E 74 5F 43 00
```

| offset | type   |           value h |                                                                                        value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------: | ----------- |
|  27675 | u4     |          671C3F82 |                                                                                     2185174119 | index       |
|  27679 | s4     |          5F000000 |                                                                                             95 | length      |
|  2767D | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Resources/PrimalItemResource_Flint.PrimalItemResource_Flint_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
276D0:                                     07 5E BC 4D
276E0: 6D 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
276F0: 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72
27700: 69 6E 74 73 2F 49 74 65 6D 73 2F 41 72 6D 6F 72
27710: 2F 43 6C 6F 74 68 2F 50 72 69 6D 61 6C 49 74 65
27720: 6D 41 72 6D 6F 72 5F 43 6C 6F 74 68 48 65 6C 6D

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27730: 65 74 2E 50 72 69 6D 61 6C 49 74 65 6D 41 72 6D
27740: 6F 72 5F 43 6C 6F 74 68 48 65 6C 6D 65 74 5F 43
27750: 00
```

| offset | type   |           value h |                                                                                                      value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------: | ----------- |
|  276DC | u4     |          075EBC4D |                                                                                                   1304190471 | index       |
|  276E0 | s4     |          6D000000 |                                                                                                          109 | length      |
|  276E4 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Cloth/PrimalItemArmor_ClothHelmet.PrimalItemArmor_ClothHelmet_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27750:    67 F2 74 60 13 00 00 00 62 41 6C 6C 6F 77 45
27760: 71 75 70 70 69 6E 67 49 74 65 6D 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  27751 | u4     |          67F27460 |         1618276967 | index       |
|  27755 | s4     |          13000000 |                 19 | length      |
|  27759 | string | 62416C ... 656D00 | bAllowEquppingItem | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27760:                                     3F D1 17 A7
27770: 6B 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
27780: 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72
27790: 69 6E 74 73 2F 49 74 65 6D 73 2F 41 72 6D 6F 72
277A0: 2F 43 6C 6F 74 68 2F 50 72 69 6D 61 6C 49 74 65
277B0: 6D 41 72 6D 6F 72 5F 43 6C 6F 74 68 42 6F 6F 74
277C0: 73 2E 50 72 69 6D 61 6C 49 74 65 6D 41 72 6D 6F
277D0: 72 5F 43 6C 6F 74 68 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                    value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------: | ----------- |
|  2776C | u4     |          3FD117A7 |                                                                                                 2803355967 | index       |
|  27770 | s4     |          6B000000 |                                                                                                        107 | length      |
|  27774 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Cloth/PrimalItemArmor_ClothBoots.PrimalItemArmor_ClothBoots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
277D0:                                              AD
277E0: 36 F9 92 6D 00 00 00 2F 47 61 6D 65 2F 50 72 69
277F0: 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75
27800: 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 41 72
27810: 6D 6F 72 2F 43 6C 6F 74 68 2F 50 72 69 6D 61 6C
27820: 49 74 65 6D 41 72 6D 6F 72 5F 43 6C 6F 74 68 47
27830: 6C 6F 76 65 73 2E 50 72 69 6D 61 6C 49 74 65 6D
27840: 41 72 6D 6F 72 5F 43 6C 6F 74 68 47 6C 6F 76 65
27850: 73 5F 43 00
```

| offset | type   |           value h |                                                                                                      value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------: | ----------- |
|  277DF | u4     |          AD36F992 |                                                                                                   2465805997 | index       |
|  277E3 | s4     |          6D000000 |                                                                                                          109 | length      |
|  277E7 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Cloth/PrimalItemArmor_ClothGloves.PrimalItemArmor_ClothGloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27850:             71 F2 D8 D4 6B 00 00 00 2F 47 61 6D
27860: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F
27870: 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65
27880: 6D 73 2F 41 72 6D 6F 72 2F 43 6C 6F 74 68 2F 50
27890: 72 69 6D 61 6C 49 74 65 6D 41 72 6D 6F 72 5F 43
278A0: 6C 6F 74 68 53 68 69 72 74 2E 50 72 69 6D 61 6C
278B0: 49 74 65 6D 41 72 6D 6F 72 5F 43 6C 6F 74 68 53
278C0: 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                                    value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------: | ----------- |
|  27854 | u4     |          71F2D8D4 |                                                                                                 3570987633 | index       |
|  27858 | s4     |          6B000000 |                                                                                                        107 | length      |
|  2785C | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Cloth/PrimalItemArmor_ClothShirt.PrimalItemArmor_ClothShirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
278C0:                      A4 A4 2C E1 6B 00 00 00 2F
278D0: 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68
278E0: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
278F0: 49 74 65 6D 73 2F 41 72 6D 6F 72 2F 43 6C 6F 74
27900: 68 2F 50 72 69 6D 61 6C 49 74 65 6D 41 72 6D 6F
27910: 72 5F 43 6C 6F 74 68 50 61 6E 74 73 2E 50 72 69
27920: 6D 61 6C 49 74 65 6D 41 72 6D 6F 72 5F 43 6C 6F
27930: 74 68 50 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                    value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------: | ----------- |
|  278C7 | u4     |          A4A42CE1 |                                                                                                 3777799332 | index       |
|  278CB | s4     |          6B000000 |                                                                                                        107 | length      |
|  278CF | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Cloth/PrimalItemArmor_ClothPants.PrimalItemArmor_ClothPants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27930:                               CB 92 06 48 83 00
27940: 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61
27950: 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E
27960: 74 73 2F 49 74 65 6D 73 2F 53 74 72 75 63 74 75
27970: 72 65 73 2F 4D 69 73 63 2F 50 72 69 6D 61 6C 49
27980: 74 65 6D 53 74 72 75 63 74 75 72 65 5F 53 6C 65
27990: 65 70 69 6E 67 42 61 67 5F 48 69 64 65 2E 50 72
279A0: 69 6D 61 6C 49 74 65 6D 53 74 72 75 63 74 75 72
279B0: 65 5F 53 6C 65 65 70 69 6E 67 42 61 67 5F 48 69
279C0: 64 65 5F 43 00
```

| offset | type   |           value h |                                                                                                                            value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2793A | u4     |          CB920648 |                                                                                                                         1208390347 | index       |
|  2793E | s4     |          83000000 |                                                                                                                                131 | length      |
|  27942 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Structures/Misc/PrimalItemStructure_SleepingBag_Hide.PrimalItemStructure_SleepingBag_Hide_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
279C0:                DC 00 79 E4 83 00 00 00 2F 47 61
279D0: 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43
279E0: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74
279F0: 65 6D 73 2F 53 74 72 75 63 74 75 72 65 73 2F 4D
27A00: 69 73 63 2F 50 72 69 6D 61 6C 49 74 65 6D 53 74
27A10: 72 75 63 74 75 72 65 5F 53 74 6F 72 61 67 65 42
27A20: 6F 78 5F 53 6D 61 6C 6C 2E 50 72 69 6D 61 6C 49
27A30: 74 65 6D 53 74 72 75 63 74 75 72 65 5F 53 74 6F
27A40: 72 61 67 65 42 6F 78 5F 53 6D 61 6C 6C 5F 43 00
```

| offset | type   |           value h |                                                                                                                            value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  279C5 | u4     |          DC0079E4 |                                                                                                                         3833135324 | index       |
|  279C9 | s4     |          83000000 |                                                                                                                                131 | length      |
|  279CD | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Structures/Misc/PrimalItemStructure_StorageBox_Small.PrimalItemStructure_StorageBox_Small_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27A50: 14 31 9D 7C 67 00 00 00 2F 47 61 6D 65 2F 50 72
27A60: 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C
27A70: 75 65 70 72 69 6E 74 73 2F 57 65 61 70 6F 6E 73
27A80: 2F 50 72 69 6D 61 6C 49 74 65 6D 5F 57 65 61 70
27A90: 6F 6E 53 74 6F 6E 65 48 61 74 63 68 65 74 2E 50
27AA0: 72 69 6D 61 6C 49 74 65 6D 5F 57 65 61 70 6F 6E
27AB0: 53 74 6F 6E 65 48 61 74 63 68 65 74 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  27A50 | u4     |          14319D7C |                                                                                             2090676500 | index       |
|  27A54 | s4     |          67000000 |                                                                                                    103 | length      |
|  27A58 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItem_WeaponStoneHatchet.PrimalItem_WeaponStoneHatchet_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27AB0:                                              F3
27AC0: 9D 6F A1 5D 00 00 00 2F 47 61 6D 65 2F 50 72 69
27AD0: 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75
27AE0: 65 70 72 69 6E 74 73 2F 52 65 73 6F 75 72 63 65
27AF0: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 52 65 73 6F
27B00: 75 72 63 65 5F 57 6F 6F 64 2E 50 72 69 6D 61 6C
27B10: 49 74 65 6D 52 65 73 6F 75 72 63 65 5F 57 6F 6F
27B20: 64 5F 43 00
```

| offset | type   |           value h |                                                                                      value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------: | ----------- |
|  27ABF | u4     |          F39D6FA1 |                                                                                   2708446707 | index       |
|  27AC3 | s4     |          5D000000 |                                                                                           93 | length      |
|  27AC7 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Resources/PrimalItemResource_Wood.PrimalItemResource_Wood_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27B20:             C6 26 70 CC 61 00 00 00 2F 47 61 6D
27B30: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F
27B40: 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 52 65 73
27B50: 6F 75 72 63 65 73 2F 50 72 69 6D 61 6C 49 74 65
27B60: 6D 52 65 73 6F 75 72 63 65 5F 54 68 61 74 63 68
27B70: 2E 50 72 69 6D 61 6C 49 74 65 6D 52 65 73 6F 75
27B80: 72 63 65 5F 54 68 61 74 63 68 5F 43 00
```

| offset | type   |           value h |                                                                                          value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------: | ----------- |
|  27B24 | u4     |          C62670CC |                                                                                       3429902022 | index       |
|  27B28 | s4     |          61000000 |                                                                                               97 | length      |
|  27B2C | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Resources/PrimalItemResource_Thatch.PrimalItemResource_Thatch_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27B80:                                        F9 17 B0
27B90: E6 61 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61
27BA0: 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70
27BB0: 72 69 6E 74 73 2F 52 65 73 6F 75 72 63 65 73 2F
27BC0: 50 72 69 6D 61 6C 49 74 65 6D 52 65 73 6F 75 72
27BD0: 63 65 5F 46 69 62 65 72 73 2E 50 72 69 6D 61 6C
27BE0: 49 74 65 6D 52 65 73 6F 75 72 63 65 5F 46 69 62
27BF0: 65 72 73 5F 43 00
```

| offset | type   |           value h |                                                                                          value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------: | ----------- |
|  27B8D | u4     |          F917B0E6 |                                                                                       3870300153 | index       |
|  27B91 | s4     |          61000000 |                                                                                               97 | length      |
|  27B95 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Resources/PrimalItemResource_Fibers.PrimalItemResource_Fibers_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27BF0:                   C4 45 DD 4C BA 00 00 00 2F 47
27C00: 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F
27C10: 53 74 72 75 63 74 75 72 65 73 2F 53 6B 69 6E 73
27C20: 2F 57 69 6E 74 65 72 57 6F 6E 64 65 72 6C 61 6E
27C30: 64 2F 47 69 6E 67 65 72 62 72 65 61 64 2F 53 74
27C40: 72 75 63 74 75 72 65 42 50 2F 50 72 69 6D 61 6C
27C50: 49 74 65 6D 53 74 72 75 63 74 75 72 65 53 6B 69
27C60: 6E 5F 54 69 6C 65 73 65 74 5F 47 69 6E 67 65 72
27C70: 62 72 65 61 64 5F 46 75 72 6E 69 74 75 72 65 2E
27C80: 50 72 69 6D 61 6C 49 74 65 6D 53 74 72 75 63 74
27C90: 75 72 65 53 6B 69 6E 5F 54 69 6C 65 73 65 74 5F
27CA0: 47 69 6E 67 65 72 62 72 65 61 64 5F 46 75 72 6E
27CB0: 69 74 75 72 65 5F 43 00
```

| offset | type   |           value h |                                                                                                                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  27BF6 | u4     |          C445DD4C |                                                                                                                                                                                1289569732 | index       |
|  27BFA | s4     |          BA000000 |                                                                                                                                                                                       186 | length      |
|  27BFE | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Structures/Skins/WinterWonderland/Gingerbread/StructureBP/PrimalItemStructureSkin_Tileset_Gingerbread_Furniture.PrimalItemStructureSkin_Tileset_Gingerbread_Furniture_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27CB0:                         3D 69 D4 95 13 00 00 00
27CC0: 49 73 55 6E 6C 6F 63 6B 65 64 43 6F 73 6D 65 74
27CD0: 69 63 00
```

| offset | type   |           value h |            value d | description |
| -----: | ------ | ----------------: | -----------------: | ----------- |
|  27CB8 | u4     |          3D69D495 |         2513725757 | index       |
|  27CBC | s4     |          13000000 |                 19 | length      |
|  27CC0 | string | 497355 ... 696300 | IsUnlockedCosmetic | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27CD0:          6A 9F 51 AC A0 00 00 00 2F 47 61 6D 65
27CE0: 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 53 74 72
27CF0: 75 63 74 75 72 65 73 2F 53 6B 69 6E 73 2F 57 69
27D00: 6E 74 65 72 57 6F 6E 64 65 72 6C 61 6E 64 2F 47
27D10: 69 6E 67 65 72 62 72 65 61 64 2F 53 74 72 75 63
27D20: 74 75 72 65 42 50 2F 50 72 69 6D 61 6C 49 74 65
27D30: 6D 53 74 72 75 63 74 75 72 65 53 6B 69 6E 5F 47
27D40: 69 6E 67 65 72 62 72 65 61 64 5F 54 72 65 65 2E
27D50: 50 72 69 6D 61 6C 49 74 65 6D 53 74 72 75 63 74
27D60: 75 72 65 53 6B 69 6E 5F 47 69 6E 67 65 72 62 72
27D70: 65 61 64 5F 54 72 65 65 5F 43 00
```

| offset | type   |           value h |                                                                                                                                                         value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  27CD3 | u4     |          6A9F51AC |                                                                                                                                                      2891030378 | index       |
|  27CD7 | s4     |          A0000000 |                                                                                                                                                             160 | length      |
|  27CDB | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Structures/Skins/WinterWonderland/Gingerbread/StructureBP/PrimalItemStructureSkin_Gingerbread_Tree.PrimalItemStructureSkin_Gingerbread_Tree_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27D70:                                  0D E2 04 9B AC
27D80: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
27D90: 61 72 74 68 2F 53 74 72 75 63 74 75 72 65 73 2F
27DA0: 53 6B 69 6E 73 2F 57 69 6E 74 65 72 57 6F 6E 64
27DB0: 65 72 6C 61 6E 64 2F 47 69 6E 67 65 72 62 72 65
27DC0: 61 64 2F 53 74 72 75 63 74 75 72 65 42 50 2F 50
27DD0: 72 69 6D 61 6C 49 74 65 6D 53 74 72 75 63 74 75
27DE0: 72 65 53 6B 69 6E 5F 47 69 6E 67 65 72 62 72 65
27DF0: 61 64 5F 54 72 69 62 65 74 6F 77 65 72 2E 50 72
27E00: 69 6D 61 6C 49 74 65 6D 53 74 72 75 63 74 75 72
27E10: 65 53 6B 69 6E 5F 47 69 6E 67 65 72 62 72 65 61
27E20: 64 5F 54 72 69 62 65 74 6F 77 65 72 5F 43 00
```

| offset | type   |           value h |                                                                                                                                                                     value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  27D7B | u4     |          0DE2049B |                                                                                                                                                                  2600788493 | index       |
|  27D7F | s4     |          AC000000 |                                                                                                                                                                         172 | length      |
|  27D83 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Structures/Skins/WinterWonderland/Gingerbread/StructureBP/PrimalItemStructureSkin_Gingerbread_Tribetower.PrimalItemStructureSkin_Gingerbread_Tribetower_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27E20:                                              AD
27E30: 6D EC 64 98 00 00 00 2F 47 61 6D 65 2F 50 72 69
27E40: 6D 61 6C 45 61 72 74 68 2F 53 74 72 75 63 74 75
27E50: 72 65 73 2F 53 6B 69 6E 73 2F 57 69 6E 74 65 72
27E60: 57 6F 6E 64 65 72 6C 61 6E 64 2F 47 69 6E 67 65
27E70: 72 62 72 65 61 64 2F 53 74 72 75 63 74 75 72 65
27E80: 42 50 2F 50 72 69 6D 61 6C 49 74 65 6D 53 74 72
27E90: 75 63 74 75 72 65 53 6B 69 6E 5F 47 69 61 6E 74
27EA0: 4C 6F 6C 69 70 6F 70 2E 50 72 69 6D 61 6C 49 74
27EB0: 65 6D 53 74 72 75 63 74 75 72 65 53 6B 69 6E 5F
27EC0: 47 69 61 6E 74 4C 6F 6C 69 70 6F 70 5F 43 00
```

| offset | type   |           value h |                                                                                                                                                 value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  27E2F | u4     |          AD6DEC64 |                                                                                                                                              1693216173 | index       |
|  27E33 | s4     |          98000000 |                                                                                                                                                     152 | length      |
|  27E37 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Structures/Skins/WinterWonderland/Gingerbread/StructureBP/PrimalItemStructureSkin_GiantLolipop.PrimalItemStructureSkin_GiantLolipop_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27EC0:                                              73
27ED0: 83 1C E5 A6 00 00 00 2F 47 61 6D 65 2F 50 72 69
27EE0: 6D 61 6C 45 61 72 74 68 2F 53 74 72 75 63 74 75
27EF0: 72 65 73 2F 53 6B 69 6E 73 2F 57 69 6E 74 65 72
27F00: 57 6F 6E 64 65 72 6C 61 6E 64 2F 47 69 6E 67 65
27F10: 72 62 72 65 61 64 2F 53 74 72 75 63 74 75 72 65
27F20: 42 50 2F 50 72 69 6D 61 6C 49 74 65 6D 53 74 72
27F30: 75 63 74 75 72 65 53 6B 69 6E 5F 54 69 6C 65 73
27F40: 65 74 5F 47 69 6E 67 65 72 62 72 65 61 64 2E 50
27F50: 72 69 6D 61 6C 49 74 65 6D 53 74 72 75 63 74 75
27F60: 72 65 53 6B 69 6E 5F 54 69 6C 65 73 65 74 5F 47
27F70: 69 6E 67 65 72 62 72 65 61 64 5F 43 00
```

| offset | type   |           value h |                                                                                                                                                               value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  27ECF | u4     |          73831CE5 |                                                                                                                                                            3843851123 | index       |
|  27ED3 | s4     |          A6000000 |                                                                                                                                                                   166 | length      |
|  27ED7 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Structures/Skins/WinterWonderland/Gingerbread/StructureBP/PrimalItemStructureSkin_Tileset_Gingerbread.PrimalItemStructureSkin_Tileset_Gingerbread_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27F70:                                        7C 10 F4
27F80: EF 64 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61
27F90: 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70
27FA0: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 41 72 6D 6F
27FB0: 72 2F 53 6B 69 6E 2F 50 72 69 6D 61 6C 49 74 65
27FC0: 6D 53 6B 69 6E 5F 53 61 6E 74 61 48 61 74 2E 50
27FD0: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 53 61
27FE0: 6E 74 61 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  27F7D | u4     |          7C10F4EF |                                                                                          4025749628 | index       |
|  27F81 | s4     |          64000000 |                                                                                                 100 | length      |
|  27F85 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/PrimalItemSkin_SantaHat.PrimalItemSkin_SantaHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
27FE0:                            A2 53 22 56 94 00 00
27FF0: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
28000: 74 68 2F 53 74 72 75 63 74 75 72 65 73 2F 53 6B
28010: 69 6E 73 2F 57 69 6E 74 65 72 57 6F 6E 64 65 72
28020: 6C 61 6E 64 2F 47 69 6E 67 65 72 62 72 65 61 64
28030: 2F 53 74 72 75 63 74 75 72 65 42 50 2F 50 72 69
28040: 6D 61 6C 49 74 65 6D 53 74 72 75 63 74 75 72 65
28050: 53 6B 69 6E 5F 44 69 6E 6F 43 6F 6F 6B 69 65 2E
28060: 50 72 69 6D 61 6C 49 74 65 6D 53 74 72 75 63 74
28070: 75 72 65 53 6B 69 6E 5F 44 69 6E 6F 43 6F 6F 6B
28080: 69 65 5F 43 00
```

| offset | type   |           value h |                                                                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  27FE9 | u4     |          A2532256 |                                                                                                                                          1445090210 | index       |
|  27FED | s4     |          94000000 |                                                                                                                                                 148 | length      |
|  27FF1 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/Structures/Skins/WinterWonderland/Gingerbread/StructureBP/PrimalItemStructureSkin_DinoCookie.PrimalItemStructureSkin_DinoCookie_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28080:                D1 99 83 96 6E 00 00 00 2F 47 61
28090: 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43
280A0: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74
280B0: 65 6D 73 2F 41 72 6D 6F 72 2F 53 6B 69 6E 2F 50
280C0: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 6F
280D0: 73 74 75 6D 65 5F 53 61 6E 74 61 2E 50 72 69 6D
280E0: 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 6F 73 74 75
280F0: 6D 65 5F 53 61 6E 74 61 5F 43 00
```

| offset | type   |           value h |                                                                                                       value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------------------: | ----------- |
|  28085 | u4     |          D1998396 |                                                                                                    2525206993 | index       |
|  28089 | s4     |          6E000000 |                                                                                                           110 | length      |
|  2808D | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/PrimalItemSkin_Costume_Santa.PrimalItemSkin_Costume_Santa_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
280F0:                                  54 5D AF 72 83
28100: 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45
28110: 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72 69
28120: 6E 74 73 2F 49 74 65 6D 73 2F 41 72 6D 6F 72 2F
28130: 53 6B 69 6E 2F 44 65 61 72 4A 61 6E 65 2F 50 72
28140: 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 68 61
28150: 72 61 63 74 65 72 53 6B 69 6E 5F 48 65 6E 72 79
28160: 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
28170: 43 68 61 72 61 63 74 65 72 53 6B 69 6E 5F 48 65
28180: 6E 72 79 5F 43 00
```

| offset | type   |           value h |                                                                                                                            value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  280FB | u4     |          545DAF72 |                                                                                                                         1924095316 | index       |
|  280FF | s4     |          83000000 |                                                                                                                                131 | length      |
|  28103 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemSkin_CharacterSkin_Henry.PrimalItemSkin_CharacterSkin_Henry_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28180:                   BE D7 F6 8C 77 00 00 00 2F 47
28190: 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F
281A0: 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49
281B0: 74 65 6D 73 2F 41 72 6D 6F 72 2F 53 6B 69 6E 2F
281C0: 44 65 61 72 4A 61 6E 65 2F 50 72 69 6D 61 6C 49
281D0: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 41
281E0: 6E 6B 79 6C 6F 2E 50 72 69 6D 61 6C 49 74 65 6D
281F0: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 41 6E 6B 79
28200: 6C 6F 5F 43 00
```

| offset | type   |           value h |                                                                                                                value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------: | ----------- |
|  28186 | u4     |          BED7F68C |                                                                                                             2364987326 | index       |
|  2818A | s4     |          77000000 |                                                                                                                    119 | length      |
|  2818E | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Ankylo.PrimalItemCostume_AAA_Ankylo_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28200:                8A 1A 11 49 7F 00 00 00 2F 47 61
28210: 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43
28220: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74
28230: 65 6D 73 2F 41 72 6D 6F 72 2F 53 6B 69 6E 2F 44
28240: 65 61 72 4A 61 6E 65 2F 50 72 69 6D 61 6C 49 74
28250: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 44 6F
28260: 65 64 69 63 75 72 75 73 2E 50 72 69 6D 61 6C 49
28270: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 44
28280: 6F 65 64 69 63 75 72 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  28205 | u4     |          8A1A1149 |                                                                                                                     1225857674 | index       |
|  28209 | s4     |          7F000000 |                                                                                                                            127 | length      |
|  2820D | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Doedicurus.PrimalItemCostume_AAA_Doedicurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28280:                                     58 1F 6A 88
28290: 79 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
282A0: 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72
282B0: 69 6E 74 73 2F 49 74 65 6D 73 2F 41 72 6D 6F 72
282C0: 2F 53 6B 69 6E 2F 44 65 61 72 4A 61 6E 65 2F 50
282D0: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
282E0: 5F 41 41 41 5F 51 75 65 74 7A 61 6C 2E 50 72 69
282F0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
28300: 41 41 5F 51 75 65 74 7A 61 6C 5F 43 00
```

| offset | type   |           value h |                                                                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2828C | u4     |          581F6A88 |                                                                                                               2288656216 | index       |
|  28290 | s4     |          79000000 |                                                                                                                      121 | length      |
|  28294 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Quetzal.PrimalItemCostume_AAA_Quetzal_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28300:                                        79 37 B8
28310: 39 7B 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61
28320: 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70
28330: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 41 72 6D 6F
28340: 72 2F 53 6B 69 6E 2F 44 65 61 72 4A 61 6E 65 2F
28350: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
28360: 65 5F 41 41 41 5F 53 61 75 72 6F 70 6F 64 2E 50
28370: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
28380: 5F 41 41 41 5F 53 61 75 72 6F 70 6F 64 5F 43 00
```

| offset | type   |           value h |                                                                                                                    value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2830D | u4     |          7937B839 |                                                                                                                  968374137 | index       |
|  28311 | s4     |          7B000000 |                                                                                                                        123 | length      |
|  28315 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Sauropod.PrimalItemCostume_AAA_Sauropod_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28390: 0C 70 B8 F4 75 00 00 00 2F 47 61 6D 65 2F 50 72
283A0: 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
283B0: 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 41
283C0: 72 6D 6F 72 2F 53 6B 69 6E 2F 44 65 61 72 4A 61
283D0: 6E 65 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
283E0: 74 75 6D 65 5F 41 41 41 5F 53 74 65 67 6F 2E 50
283F0: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
28400: 5F 41 41 41 5F 53 74 65 67 6F 5F 43 00
```

| offset | type   |           value h |                                                                                                              value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------------: | ----------- |
|  28390 | u4     |          0C70B8F4 |                                                                                                           4105728012 | index       |
|  28394 | s4     |          75000000 |                                                                                                                  117 | length      |
|  28398 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Stego.PrimalItemCostume_AAA_Stego_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28400:                                        13 78 F7
28410: 00 7F 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61
28420: 6C 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70
28430: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 41 72 6D 6F
28440: 72 2F 53 6B 69 6E 2F 44 65 61 72 4A 61 6E 65 2F
28450: 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D
28460: 65 5F 41 41 41 5F 41 72 67 65 6E 74 61 76 69 73
28470: 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
28480: 6D 65 5F 41 41 41 5F 41 72 67 65 6E 74 61 76 69
28490: 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2840D | u4     |          1378F700 |                                                                                                                       16218131 | index       |
|  28411 | s4     |          7F000000 |                                                                                                                            127 | length      |
|  28415 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Argentavis.PrimalItemCostume_AAA_Argentavis_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28490:             F3 18 B3 C9 85 00 00 00 2F 47 61 6D
284A0: 65 2F 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F
284B0: 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65
284C0: 6D 73 2F 41 72 6D 6F 72 2F 53 6B 69 6E 2F 44 65
284D0: 61 72 4A 61 6E 65 2F 50 72 69 6D 61 6C 49 74 65
284E0: 6D 53 6B 69 6E 5F 43 68 61 72 61 63 74 65 72 53
284F0: 6B 69 6E 5F 41 6C 61 73 69 65 2E 50 72 69 6D 61
28500: 6C 49 74 65 6D 53 6B 69 6E 5F 43 68 61 72 61 63
28510: 74 65 72 53 6B 69 6E 5F 41 6C 61 73 69 65 5F 43
28520: 00
```

| offset | type   |           value h |                                                                                                                              value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  28494 | u4     |          F318B3C9 |                                                                                                                           3383957747 | index       |
|  28498 | s4     |          85000000 |                                                                                                                                  133 | length      |
|  2849C | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemSkin_CharacterSkin_Alasie.PrimalItemSkin_CharacterSkin_Alasie_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28520:    08 0F BF 5E 83 00 00 00 2F 47 61 6D 65 2F 50
28530: 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42
28540: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
28550: 41 72 6D 6F 72 2F 53 6B 69 6E 2F 44 65 61 72 4A
28560: 61 6E 65 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F
28570: 73 74 75 6D 65 5F 41 41 41 5F 4D 65 73 6F 70 69
28580: 74 68 65 63 75 73 2E 50 72 69 6D 61 6C 49 74 65
28590: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4D 65 73
285A0: 6F 70 69 74 68 65 63 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                            value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  28521 | u4     |          080FBF5E |                                                                                                                         1589579528 | index       |
|  28525 | s4     |          83000000 |                                                                                                                                131 | length      |
|  28529 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Mesopithecus.PrimalItemCostume_AAA_Mesopithecus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
285A0:                                     11 98 D3 73
285B0: 7D 00 00 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C
285C0: 45 61 72 74 68 2F 43 6F 72 65 42 6C 75 65 70 72
285D0: 69 6E 74 73 2F 49 74 65 6D 73 2F 41 72 6D 6F 72
285E0: 2F 53 6B 69 6E 2F 44 65 61 72 4A 61 6E 65 2F 50
285F0: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
28600: 5F 41 41 41 5F 4D 65 67 61 6C 61 6E 69 61 2E 50
28610: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
28620: 5F 41 41 41 5F 4D 65 67 61 6C 61 6E 69 61 5F 43
28630: 00
```

| offset | type   |           value h |                                                                                                                      value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  285AC | u4     |          1198D373 |                                                                                                                   1943246865 | index       |
|  285B0 | s4     |          7D000000 |                                                                                                                          125 | length      |
|  285B4 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Megalania.PrimalItemCostume_AAA_Megalania_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28630:    2F A6 82 F0 79 00 00 00 2F 47 61 6D 65 2F 50
28640: 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42
28650: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
28660: 41 72 6D 6F 72 2F 53 6B 69 6E 2F 44 65 61 72 4A
28670: 61 6E 65 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F
28680: 73 74 75 6D 65 5F 41 41 41 5F 44 61 65 6F 64 6F
28690: 6E 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
286A0: 75 6D 65 5F 41 41 41 5F 44 61 65 6F 64 6F 6E 5F
286B0: 43 00
```

| offset | type   |           value h |                                                                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  28631 | u4     |          2FA682F0 |                                                                                                               4035094063 | index       |
|  28635 | s4     |          79000000 |                                                                                                                      121 | length      |
|  28639 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemCostume_AAA_Daeodon.PrimalItemCostume_AAA_Daeodon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
286B0:       E7 CD CE C9 7F 00 00 00 2F 47 61 6D 65 2F
286C0: 50 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65
286D0: 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73
286E0: 2F 41 72 6D 6F 72 2F 53 6B 69 6E 2F 44 65 61 72
286F0: 4A 61 6E 65 2F 50 72 69 6D 61 6C 49 74 65 6D 53
28700: 6B 69 6E 5F 43 68 61 72 61 63 74 65 72 53 6B 69
28710: 6E 5F 4B 6F 72 2E 50 72 69 6D 61 6C 49 74 65 6D
28720: 53 6B 69 6E 5F 43 68 61 72 61 63 74 65 72 53 6B
28730: 69 6E 5F 4B 6F 72 5F 43 00
```

| offset | type   |           value h |                                                                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  286B2 | u4     |          E7CDCEC9 |                                                                                                                     3385773543 | index       |
|  286B6 | s4     |          7F000000 |                                                                                                                            127 | length      |
|  286BA | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Armor/Skin/DearJane/PrimalItemSkin_CharacterSkin_Kor.PrimalItemSkin_CharacterSkin_Kor_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28730:                            72 62 CA FF 5F 00 00
28740: 00 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72
28750: 74 68 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74
28760: 73 2F 49 74 65 6D 73 2F 4E 6F 74 65 73 2F 50 72
28770: 69 6D 61 6C 49 74 65 6D 5F 53 74 61 72 74 69 6E
28780: 67 4E 6F 74 65 2E 50 72 69 6D 61 6C 49 74 65 6D
28790: 5F 53 74 61 72 74 69 6E 67 4E 6F 74 65 5F 43 00
```

| offset | type   |           value h |                                                                                        value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------: | ----------- |
|  28739 | u4     |          7262CAFF |                                                                                     4291453554 | index       |
|  2873D | s4     |          5F000000 |                                                                                             95 | length      |
|  28741 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Notes/PrimalItem_StartingNote.PrimalItem_StartingNote_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
287A0: 2D 43 E5 D2 09 00 00 00 49 6E 69 74 44 61 74 61
287B0: 00
```

| offset | type   |           value h |    value d | description |
| -----: | ------ | ----------------: | ---------: | ----------- |
|  287A0 | u4     |          2D43E5D2 | 3538240301 | index       |
|  287A4 | s4     |          09000000 |          9 | length      |
|  287A8 | string | 496E69 ... 746100 |   InitData | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
287B0:    76 69 5A CB 4F 00 00 00 2F 47 61 6D 65 2F 50
287C0: 72 69 6D 61 6C 45 61 72 74 68 2F 43 6F 72 65 42
287D0: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
287E0: 4E 6F 74 65 73 2F 50 72 69 6D 61 6C 49 74 65 6D
287F0: 5F 4E 6F 74 65 2E 50 72 69 6D 61 6C 49 74 65 6D
28800: 5F 4E 6F 74 65 5F 43 00
```

| offset | type   |           value h |                                                                        value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------: | ----------- |
|  287B1 | u4     |          76695ACB |                                                                     3411700086 | index       |
|  287B5 | s4     |          4F000000 |                                                                             79 | length      |
|  287B9 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Items/Notes/PrimalItem_Note.PrimalItem_Note_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28800:                         CB E7 49 35 59 00 00 00
28810: 2F 47 61 6D 65 2F 50 72 69 6D 61 6C 45 61 72 74
28820: 68 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73
28830: 2F 57 65 61 70 6F 6E 73 2F 50 72 69 6D 61 6C 49
28840: 74 65 6D 5F 57 65 61 70 6F 6E 54 6F 72 63 68 2E
28850: 50 72 69 6D 61 6C 49 74 65 6D 5F 57 65 61 70 6F
28860: 6E 54 6F 72 63 68 5F 43 00
```

| offset | type   |           value h |                                                                                  value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------: | ----------- |
|  28808 | u4     |          CBE74935 |                                                                                894035915 | index       |
|  2880C | s4     |          59000000 |                                                                                       89 | length      |
|  28810 | string | 2F4761 ... 5F4300 | /Game/PrimalEarth/CoreBlueprints/Weapons/PrimalItem_WeaponTorch.PrimalItem_WeaponTorch_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28860:                            90 81 CB 15 6A 00 00
28870: 00 2F 47 61 6D 65 2F 4C 6F 73 74 43 6F 6C 6F 6E
28880: 79 2F 53 74 72 75 63 74 75 72 65 73 2F 53 6B 69
28890: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 74 72
288A0: 75 63 74 75 72 65 53 6B 69 6E 5F 54 69 6C 65 73
288B0: 65 74 5F 4C 43 2E 50 72 69 6D 61 6C 49 74 65 6D
288C0: 53 74 72 75 63 74 75 72 65 53 6B 69 6E 5F 54 69
288D0: 6C 65 73 65 74 5F 4C 43 5F 43 00
```

| offset | type   |           value h |                                                                                                   value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------: | ----------- |
|  28869 | u4     |          9081CB15 |                                                                                                 365658512 | index       |
|  2886D | s4     |          6A000000 |                                                                                                       106 | length      |
|  28871 | string | 2F4761 ... 5F4300 | /Game/LostColony/Structures/Skins/PrimalItemStructureSkin_Tileset_LC.PrimalItemStructureSkin_Tileset_LC_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
288D0:                                  F0 88 C9 CA 0F
288E0: 00 00 00 49 73 41 75 74 6F 55 6E 6C 6F 63 6B 65
288F0: 64 00
```

| offset | type   |           value h |        value d | description |
| -----: | ------ | ----------------: | -------------: | ----------- |
|  288DB | u4     |          F088C9CA |     3402205424 | index       |
|  288DF | s4     |          0F000000 |             15 | length      |
|  288E3 | string | 497341 ... 656400 | IsAutoUnlocked | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
288F0:       05 8F 8B 2B 6A 00 00 00 2F 47 61 6D 65 2F
28900: 4C 6F 73 74 43 6F 6C 6F 6E 79 2F 43 6F 72 65 42
28910: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
28920: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 53
28930: 6E 6F 77 47 68 69 6C 6C 69 65 5F 53 68 69 72 74
28940: 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
28950: 53 6E 6F 77 47 68 69 6C 6C 69 65 5F 53 68 69 72
28960: 74 5F 43 00
```

| offset | type   |           value h |                                                                                                   value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------: | ----------- |
|  288F2 | u4     |          058F8B2B |                                                                                                 730566405 | index       |
|  288F6 | s4     |          6A000000 |                                                                                                       106 | length      |
|  288FA | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_SnowGhillie_Shirt.PrimalItemSkin_SnowGhillie_Shirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28960:             CD C4 CB 79 6A 00 00 00 2F 47 61 6D
28970: 65 2F 4C 6F 73 74 43 6F 6C 6F 6E 79 2F 43 6F 72
28980: 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D
28990: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
289A0: 5F 53 6E 6F 77 47 68 69 6C 6C 69 65 5F 50 61 6E
289B0: 74 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
289C0: 6E 5F 53 6E 6F 77 47 68 69 6C 6C 69 65 5F 50 61
289D0: 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                   value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------: | ----------- |
|  28964 | u4     |          CDC4CB79 |                                                                                                2043397325 | index       |
|  28968 | s4     |          6A000000 |                                                                                                       106 | length      |
|  2896C | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_SnowGhillie_Pants.PrimalItemSkin_SnowGhillie_Pants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
289D0:                   F0 E1 01 07 6C 00 00 00 2F 47
289E0: 61 6D 65 2F 4C 6F 73 74 43 6F 6C 6F 6E 79 2F 43

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
289F0: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74
28A00: 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B
28A10: 69 6E 5F 53 6E 6F 77 47 68 69 6C 6C 69 65 5F 48
28A20: 65 6C 6D 65 74 2E 50 72 69 6D 61 6C 49 74 65 6D
28A30: 53 6B 69 6E 5F 53 6E 6F 77 47 68 69 6C 6C 69 65
28A40: 5F 48 65 6C 6D 65 74 5F 43 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  289D6 | u4     |          F0E10107 |                                                                                                   117563888 | index       |
|  289DA | s4     |          6C000000 |                                                                                                         108 | length      |
|  289DE | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_SnowGhillie_Helmet.PrimalItemSkin_SnowGhillie_Helmet_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28A40:                               5C BE 78 26 6C 00
28A50: 00 00 2F 47 61 6D 65 2F 4C 6F 73 74 43 6F 6C 6F
28A60: 6E 79 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74
28A70: 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74
28A80: 65 6D 53 6B 69 6E 5F 53 6E 6F 77 47 68 69 6C 6C
28A90: 69 65 5F 47 6C 6F 76 65 73 2E 50 72 69 6D 61 6C
28AA0: 49 74 65 6D 53 6B 69 6E 5F 53 6E 6F 77 47 68 69
28AB0: 6C 6C 69 65 5F 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  28A4A | u4     |          5CBE7826 |                                                                                                   645447260 | index       |
|  28A4E | s4     |          6C000000 |                                                                                                         108 | length      |
|  28A52 | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_SnowGhillie_Gloves.PrimalItemSkin_SnowGhillie_Gloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28AB0:                                           B4 2E
28AC0: E1 3C 5E 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
28AD0: 73 2F 46 72 6F 6E 74 69 65 72 2F 43 6F 72 65 42
28AE0: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
28AF0: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 42
28B00: 6F 77 6C 65 72 48 61 74 2E 50 72 69 6D 61 6C 49
28B10: 74 65 6D 53 6B 69 6E 5F 42 6F 77 6C 65 72 48 61
28B20: 74 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  28ABE | u4     |          B42EE13C |                                                                                    1021390516 | index       |
|  28AC2 | s4     |          5E000000 |                                                                                            94 | length      |
|  28AC6 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_BowlerHat.PrimalItemSkin_BowlerHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28B20:             CE 5F CB 36 64 00 00 00 2F 47 61 6D
28B30: 65 2F 50 61 63 6B 73 2F 46 72 6F 6E 74 69 65 72
28B40: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
28B50: 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D
28B60: 53 6B 69 6E 5F 44 72 69 66 74 65 72 42 6F 6F 74
28B70: 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
28B80: 5F 44 72 69 66 74 65 72 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  28B24 | u4     |          CE5FCB36 |                                                                                           919297998 | index       |
|  28B28 | s4     |          64000000 |                                                                                                 100 | length      |
|  28B2C | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_DrifterBoots.PrimalItemSkin_DrifterBoots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28B90: 43 3E 57 EC 66 00 00 00 2F 47 61 6D 65 2F 50 61
28BA0: 63 6B 73 2F 46 72 6F 6E 74 69 65 72 2F 43 6F 72
28BB0: 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D
28BC0: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
28BD0: 5F 44 72 69 66 74 65 72 47 6C 6F 76 65 73 2E 50
28BE0: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 72
28BF0: 69 66 74 65 72 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  28B90 | u4     |          433E57EC |                                                                                            3965140547 | index       |
|  28B94 | s4     |          66000000 |                                                                                                   102 | length      |
|  28B98 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_DrifterGloves.PrimalItemSkin_DrifterGloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28BF0:                                           12 43
28C00: A9 90 60 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
28C10: 73 2F 46 72 6F 6E 74 69 65 72 2F 43 6F 72 65 42
28C20: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
28C30: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44
28C40: 72 69 66 74 65 72 48 61 74 2E 50 72 69 6D 61 6C
28C50: 49 74 65 6D 53 6B 69 6E 5F 44 72 69 66 74 65 72
28C60: 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                         value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------: | ----------- |
|  28BFE | u4     |          1243A990 |                                                                                      2427011858 | index       |
|  28C02 | s4     |          60000000 |                                                                                              96 | length      |
|  28C06 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_DrifterHat.PrimalItemSkin_DrifterHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28C60:                   92 DF EC B8 64 00 00 00 2F 47
28C70: 61 6D 65 2F 50 61 63 6B 73 2F 46 72 6F 6E 74 69
28C80: 65 72 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74
28C90: 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74
28CA0: 65 6D 53 6B 69 6E 5F 44 72 69 66 74 65 72 50 61
28CB0: 6E 74 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B
28CC0: 69 6E 5F 44 72 69 66 74 65 72 50 61 6E 74 73 5F
28CD0: 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  28C66 | u4     |          92DFECB8 |                                                                                          3102531474 | index       |
|  28C6A | s4     |          64000000 |                                                                                                 100 | length      |
|  28C6E | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_DrifterPants.PrimalItemSkin_DrifterPants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28CD0:       12 CC 12 6A 64 00 00 00 2F 47 61 6D 65 2F
28CE0: 50 61 63 6B 73 2F 46 72 6F 6E 74 69 65 72 2F 43
28CF0: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74
28D00: 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B
28D10: 69 6E 5F 44 72 69 66 74 65 72 53 68 69 72 74 2E
28D20: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44
28D30: 72 69 66 74 65 72 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  28CD2 | u4     |          12CC126A |                                                                                          1779616786 | index       |
|  28CD6 | s4     |          64000000 |                                                                                                 100 | length      |
|  28CDA | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_DrifterShirt.PrimalItemSkin_DrifterShirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28D30:                                           E9 22
28D40: 0E 5D 62 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
28D50: 73 2F 46 72 6F 6E 74 69 65 72 2F 43 6F 72 65 42
28D60: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
28D70: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43
28D80: 34 5F 44 79 6E 61 6D 69 74 65 2E 50 72 69 6D 61
28D90: 6C 49 74 65 6D 53 6B 69 6E 5F 43 34 5F 44 79 6E
28DA0: 61 6D 69 74 65 5F 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  28D3E | u4     |          E9220E5D |                                                                                        1561207529 | index       |
|  28D42 | s4     |          62000000 |                                                                                                98 | length      |
|  28D46 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_C4_Dynamite.PrimalItemSkin_C4_Dynamite_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28DA0:                         D6 2E 2F D0 60 00 00 00
28DB0: 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 46 72 6F 6E
28DC0: 74 69 65 72 2F 43 6F 72 65 42 6C 75 65 70 72 69
28DD0: 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C
28DE0: 49 74 65 6D 53 6B 69 6E 5F 52 61 6E 63 68 65 72
28DF0: 48 61 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B
28E00: 69 6E 5F 52 61 6E 63 68 65 72 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                         value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------: | ----------- |
|  28DA8 | u4     |          D62E2FD0 |                                                                                      3492753110 | index       |
|  28DAC | s4     |          60000000 |                                                                                              96 | length      |
|  28DB0 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_RancherHat.PrimalItemSkin_RancherHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28E10: C3 D7 EB 1C 64 00 00 00 2F 47 61 6D 65 2F 50 61
28E20: 63 6B 73 2F 46 72 6F 6E 74 69 65 72 2F 43 6F 72
28E30: 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D
28E40: 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
28E50: 5F 52 75 73 74 6C 65 72 42 6F 6F 74 73 2E 50 72
28E60: 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 52 75 73
28E70: 74 6C 65 72 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  28E10 | u4     |          C3D7EB1C |                                                                                           485218243 | index       |
|  28E14 | s4     |          64000000 |                                                                                                 100 | length      |
|  28E18 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_RustlerBoots.PrimalItemSkin_RustlerBoots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28E70:                                     C0 68 17 76
28E80: 66 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F
28E90: 46 72 6F 6E 74 69 65 72 2F 43 6F 72 65 42 6C 75
28EA0: 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72
28EB0: 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 52 75 73
28EC0: 74 6C 65 72 47 6C 6F 76 65 73 2E 50 72 69 6D 61
28ED0: 6C 49 74 65 6D 53 6B 69 6E 5F 52 75 73 74 6C 65
28EE0: 72 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  28E7C | u4     |          C0681776 |                                                                                            1981245632 | index       |
|  28E80 | s4     |          66000000 |                                                                                                   102 | length      |
|  28E84 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_RustlerGloves.PrimalItemSkin_RustlerGloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28EE0:                               DA 8B 60 75 60 00
28EF0: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 46 72
28F00: 6F 6E 74 69 65 72 2F 43 6F 72 65 42 6C 75 65 70
28F10: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D
28F20: 61 6C 49 74 65 6D 53 6B 69 6E 5F 52 75 73 74 6C
28F30: 65 72 48 61 74 2E 50 72 69 6D 61 6C 49 74 65 6D
28F40: 53 6B 69 6E 5F 52 75 73 74 6C 65 72 48 61 74 5F
28F50: 43 00
```

| offset | type   |           value h |                                                                                         value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------: | ----------- |
|  28EEA | u4     |          DA8B6075 |                                                                                      1969261530 | index       |
|  28EEE | s4     |          60000000 |                                                                                              96 | length      |
|  28EF2 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_RustlerHat.PrimalItemSkin_RustlerHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28F50:       9F 57 CC 92 64 00 00 00 2F 47 61 6D 65 2F
28F60: 50 61 63 6B 73 2F 46 72 6F 6E 74 69 65 72 2F 43
28F70: 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74
28F80: 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B
28F90: 69 6E 5F 52 75 73 74 6C 65 72 50 61 6E 74 73 2E
28FA0: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 52
28FB0: 75 73 74 6C 65 72 50 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  28F52 | u4     |          9F57CC92 |                                                                                          2462865311 | index       |
|  28F56 | s4     |          64000000 |                                                                                                 100 | length      |
|  28F5A | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_RustlerPants.PrimalItemSkin_RustlerPants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
28FB0:                                           1F 44
28FC0: 32 40 64 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
28FD0: 73 2F 46 72 6F 6E 74 69 65 72 2F 43 6F 72 65 42
28FE0: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
28FF0: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 52
29000: 75 73 74 6C 65 72 53 68 69 72 74 2E 50 72 69 6D
29010: 61 6C 49 74 65 6D 53 6B 69 6E 5F 52 75 73 74 6C
29020: 65 72 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  28FBE | u4     |          1F443240 |                                                                                          1077036063 | index       |
|  28FC2 | s4     |          64000000 |                                                                                                 100 | length      |
|  28FC6 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_RustlerShirt.PrimalItemSkin_RustlerShirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29020:                               B9 2E EB 42 83 00

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29030: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 46 72
29040: 6F 6E 74 69 65 72 2F 53 74 72 75 63 74 75 72 65
29050: 73 2F 46 72 6F 6E 74 69 65 72 2F 53 6B 69 6E 73
29060: 2F 50 72 69 6D 61 6C 49 74 65 6D 53 74 72 75 63
29070: 74 75 72 65 53 6B 69 6E 5F 54 69 6C 65 73 65 74
29080: 5F 46 72 6F 6E 74 69 65 72 2E 50 72 69 6D 61 6C
29090: 49 74 65 6D 53 74 72 75 63 74 75 72 65 53 6B 69
290A0: 6E 5F 54 69 6C 65 73 65 74 5F 46 72 6F 6E 74 69
290B0: 65 72 5F 43 00
```

| offset | type   |           value h |                                                                                                                            value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2902A | u4     |          B92EEB42 |                                                                                                                         1122709177 | index       |
|  2902E | s4     |          83000000 |                                                                                                                                131 | length      |
|  29032 | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/Structures/Frontier/Skins/PrimalItemStructureSkin_Tileset_Frontier.PrimalItemStructureSkin_Tileset_Frontier_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
290B0:                44 90 44 AF 62 00 00 00 2F 47 61
290C0: 6D 65 2F 50 61 63 6B 73 2F 46 72 6F 6E 74 69 65
290D0: 72 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73
290E0: 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65
290F0: 6D 53 6B 69 6E 5F 53 69 6E 69 73 74 65 72 48 61
29100: 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
29110: 5F 53 69 6E 69 73 74 65 72 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  290B5 | u4     |          449044AF |                                                                                        2940506180 | index       |
|  290B9 | s4     |          62000000 |                                                                                                98 | length      |
|  290BD | string | 2F4761 ... 5F4300 | /Game/Packs/Frontier/CoreBlueprints/Items/PrimalItemSkin_SinisterHat.PrimalItemSkin_SinisterHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29110:                                              A0
29120: 98 57 97 64 00 00 00 2F 47 61 6D 65 2F 53 63 6F
29130: 72 63 68 65 64 45 61 72 74 68 2F 4F 75 74 66 69
29140: 74 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
29150: 6E 5F 44 65 73 65 72 74 47 68 69 6C 6C 69 65 5F
29160: 42 6F 6F 74 73 2E 50 72 69 6D 61 6C 49 74 65 6D
29170: 53 6B 69 6E 5F 44 65 73 65 72 74 47 68 69 6C 6C
29180: 69 65 5F 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  2911F | u4     |          A0985797 |                                                                                          2539100320 | index       |
|  29123 | s4     |          64000000 |                                                                                                 100 | length      |
|  29127 | string | 2F4761 ... 5F4300 | /Game/ScorchedEarth/Outfits/PrimalItemSkin_DesertGhillie_Boots.PrimalItemSkin_DesertGhillie_Boots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29180:                                  B3 75 9E A7 66
29190: 00 00 00 2F 47 61 6D 65 2F 53 63 6F 72 63 68 65
291A0: 64 45 61 72 74 68 2F 4F 75 74 66 69 74 73 2F 50
291B0: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 65
291C0: 73 65 72 74 47 68 69 6C 6C 69 65 5F 47 6C 6F 76
291D0: 65 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
291E0: 6E 5F 44 65 73 65 72 74 47 68 69 6C 6C 69 65 5F
291F0: 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  2918B | u4     |          B3759EA7 |                                                                                            2812179891 | index       |
|  2918F | s4     |          66000000 |                                                                                                   102 | length      |
|  29193 | string | 2F4761 ... 5F4300 | /Game/ScorchedEarth/Outfits/PrimalItemSkin_DesertGhillie_Gloves.PrimalItemSkin_DesertGhillie_Gloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
291F0:                            DD 11 9D A4 66 00 00
29200: 00 2F 47 61 6D 65 2F 53 63 6F 72 63 68 65 64 45
29210: 61 72 74 68 2F 4F 75 74 66 69 74 73 2F 50 72 69
29220: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 65 73 65
29230: 72 74 47 68 69 6C 6C 69 65 5F 48 65 6C 6D 65 74
29240: 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
29250: 44 65 73 65 72 74 47 68 69 6C 6C 69 65 5F 48 65
29260: 6C 6D 65 74 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  291F9 | u4     |          DD119DA4 |                                                                                            2761757149 | index       |
|  291FD | s4     |          66000000 |                                                                                                   102 | length      |
|  29201 | string | 2F4761 ... 5F4300 | /Game/ScorchedEarth/Outfits/PrimalItemSkin_DesertGhillie_Helmet.PrimalItemSkin_DesertGhillie_Helmet_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29260:                      D2 7A 59 D9 6A 00 00 00 2F
29270: 47 61 6D 65 2F 4C 6F 73 74 43 6F 6C 6F 6E 79 2F
29280: 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49
29290: 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53
292A0: 6B 69 6E 5F 53 6E 6F 77 47 68 69 6C 6C 69 65 5F
292B0: 42 6F 6F 74 73 2E 50 72 69 6D 61 6C 49 74 65 6D
292C0: 53 6B 69 6E 5F 53 6E 6F 77 47 68 69 6C 6C 69 65
292D0: 5F 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                   value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------: | ----------- |
|  29267 | u4     |          D27A59D9 |                                                                                                3646520018 | index       |
|  2926B | s4     |          6A000000 |                                                                                                       106 | length      |
|  2926F | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_SnowGhillie_Boots.PrimalItemSkin_SnowGhillie_Boots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
292D0:                            42 FE 68 A3 66 00 00
292E0: 00 2F 47 61 6D 65 2F 4C 6F 73 74 43 6F 6C 6F 6E
292F0: 79 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73
29300: 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65
29310: 6D 53 6B 69 6E 5F 54 68 72 61 6C 6C 5F 54 33 5F
29320: 50 61 6E 74 73 2E 50 72 69 6D 61 6C 49 74 65 6D
29330: 53 6B 69 6E 5F 54 68 72 61 6C 6C 5F 54 33 5F 50
29340: 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  292D9 | u4     |          42FE68A3 |                                                                                            2741567042 | index       |
|  292DD | s4     |          66000000 |                                                                                                   102 | length      |
|  292E1 | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_Thrall_T3_Pants.PrimalItemSkin_Thrall_T3_Pants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29340:                      C1 13 75 E5 68 00 00 00 2F
29350: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
29360: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43
29370: 6F 73 74 75 6D 65 5F 41 41 41 5F 53 61 75 72 6F
29380: 70 6F 64 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69
29390: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
293A0: 41 41 5F 53 61 75 72 6F 70 6F 64 5F 53 6B 69 6E
293B0: 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                 value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------------: | ----------- |
|  29347 | u4     |          C11375E5 |                                                                                              3849655233 | index       |
|  2934B | s4     |          68000000 |                                                                                                     104 | length      |
|  2934F | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Sauropod_SkinPack.PrimalItemCostume_AAA_Sauropod_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
293B0:                      AE 2D D3 32 70 00 00 00 2F
293C0: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
293D0: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53
293E0: 6B 69 6E 5F 43 68 61 72 61 63 74 65 72 53 6B 69
293F0: 6E 5F 4E 65 72 76 61 5F 53 6B 69 6E 50 61 63 6B
29400: 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
29410: 43 68 61 72 61 63 74 65 72 53 6B 69 6E 5F 4E 65
29420: 72 76 61 5F 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                         value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------: | ----------- |
|  293B7 | u4     |          AE2DD332 |                                                                                                       852700590 | index       |
|  293BB | s4     |          70000000 |                                                                                                             112 | length      |
|  293BF | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Nerva_SkinPack.PrimalItemSkin_CharacterSkin_Nerva_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29420:                                              86
29430: 56 23 A1 74 00 00 00 2F 47 61 6D 65 2F 50 61 63
29440: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
29450: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
29460: 41 41 5F 47 69 67 61 6E 6F 74 6F 73 61 75 72 75
29470: 73 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D 61
29480: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
29490: 5F 47 69 67 61 6E 6F 74 6F 73 61 75 72 75 73 5F
294A0: 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                             value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2942F | u4     |          865623A1 |                                                                                                          2703447686 | index       |
|  29433 | s4     |          74000000 |                                                                                                                 116 | length      |
|  29437 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Giganotosaurus_SkinPack.PrimalItemCostume_AAA_Giganotosaurus_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
294A0:                                  51 5E 24 69 72
294B0: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41
294C0: 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49
294D0: 74 65 6D 53 6B 69 6E 5F 43 68 61 72 61 63 74 65
294E0: 72 53 6B 69 6E 5F 4D 65 69 79 69 6E 5F 4E 65 77
294F0: 41 72 6D 6F 72 2E 50 72 69 6D 61 6C 49 74 65 6D
29500: 53 6B 69 6E 5F 43 68 61 72 61 63 74 65 72 53 6B
29510: 69 6E 5F 4D 65 69 79 69 6E 5F 4E 65 77 41 72 6D
29520: 6F 72 5F 43 00
```

| offset | type   |           value h |                                                                                                           value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------------: | ----------- |
|  294AB | u4     |          515E2469 |                                                                                                        1763991121 | index       |
|  294AF | s4     |          72000000 |                                                                                                               114 | length      |
|  294B3 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Meiyin_NewArmor.PrimalItemSkin_CharacterSkin_Meiyin_NewArmor_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29520:                50 97 86 34 5A 00 00 00 2F 47 61
29530: 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69
29540: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
29550: 74 75 6D 65 5F 41 41 41 5F 54 69 74 61 6E 6F 73
29560: 61 75 72 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F
29570: 73 74 75 6D 65 5F 41 41 41 5F 54 69 74 61 6E 6F
29580: 73 61 75 72 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  29525 | u4     |          50978634 |                                                                                 881235792 | index       |
|  29529 | s4     |          5A000000 |                                                                                        90 | length      |
|  2952D | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Titanosaur.PrimalItemCostume_AAA_Titanosaur_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29580:                      7C 90 C3 0D 56 00 00 00 2F
29590: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
295A0: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43
295B0: 6F 73 74 75 6D 65 5F 41 41 41 5F 53 63 6F 72 70
295C0: 69 6F 6E 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F
295D0: 73 74 75 6D 65 5F 41 41 41 5F 53 63 6F 72 70 69
295E0: 6F 6E 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  29587 | u4     |          7C90C30D |                                                                             230920316 | index       |
|  2958B | s4     |          56000000 |                                                                                    86 | length      |
|  2958F | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Scorpion.PrimalItemCostume_AAA_Scorpion_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
295E0:                6E 3B 75 76 4E 00 00 00 2F 47 61
295F0: 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69
29600: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
29610: 74 75 6D 65 5F 41 41 41 5F 50 65 6C 61 2E 50 72
29620: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
29630: 41 41 41 5F 50 65 6C 61 5F 43 00
```

| offset | type   |           value h |                                                                       value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------: | ----------- |
|  295E5 | u4     |          6E3B7576 |                                                                    1987394414 | index       |
|  295E9 | s4     |          4E000000 |                                                                            78 | length      |
|  295ED | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Pela.PrimalItemCostume_AAA_Pela_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29630:                                  BB EE 2F 1E 5C
29640: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41
29650: 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49
29660: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 4D

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29670: 65 67 61 74 68 65 72 69 75 6D 2E 50 72 69 6D 61
29680: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
29690: 5F 4D 65 67 61 74 68 65 72 69 75 6D 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  2963B | u4     |          BBEE2F1E |                                                                                   506457787 | index       |
|  2963F | s4     |          5C000000 |                                                                                          92 | length      |
|  29643 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Megatherium.PrimalItemCostume_AAA_Megatherium_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29690:                                              1A
296A0: 3D C9 E1 58 00 00 00 2F 47 61 6D 65 2F 50 61 63
296B0: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
296C0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
296D0: 41 41 5F 49 67 75 61 6E 6F 64 6F 6E 2E 50 72 69
296E0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
296F0: 41 41 5F 49 67 75 61 6E 6F 64 6F 6E 5F 43 00
```

| offset | type   |           value h |                                                                                 value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------: | ----------- |
|  2969F | u4     |          1A3DC9E1 |                                                                              3788061978 | index       |
|  296A3 | s4     |          58000000 |                                                                                      88 | length      |
|  296A7 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Iguanodon.PrimalItemCostume_AAA_Iguanodon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
296F0:                                              30
29700: 7C 5D 60 54 00 00 00 2F 47 61 6D 65 2F 50 61 63
29710: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
29720: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
29730: 41 41 5F 44 6F 6C 70 68 69 6E 2E 50 72 69 6D 61
29740: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
29750: 5F 44 6F 6C 70 68 69 6E 5F 43 00
```

| offset | type   |           value h |                                                                             value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------: | ----------- |
|  296FF | u4     |          307C5D60 |                                                                          1616739376 | index       |
|  29703 | s4     |          54000000 |                                                                                  84 | length      |
|  29707 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Dolphin.PrimalItemCostume_AAA_Dolphin_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29750:                                  F1 A8 7A 2F 5A
29760: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41
29770: 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49
29780: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 43
29790: 6F 65 6C 61 63 61 6E 74 68 2E 50 72 69 6D 61 6C
297A0: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
297B0: 43 6F 65 6C 61 63 61 6E 74 68 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  2975B | u4     |          F1A87A2F |                                                                                 796567793 | index       |
|  2975F | s4     |          5A000000 |                                                                                        90 | length      |
|  29763 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Coelacanth.PrimalItemCostume_AAA_Coelacanth_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
297B0:                                        EC 08 56
297C0: 84 56 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
297D0: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
297E0: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
297F0: 5F 42 61 72 79 6F 6E 79 78 2E 50 72 69 6D 61 6C
29800: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
29810: 42 61 72 79 6F 6E 79 78 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  297BD | u4     |          EC085684 |                                                                            2220230892 | index       |
|  297C1 | s4     |          56000000 |                                                                                    86 | length      |
|  297C5 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Baryonyx.PrimalItemCostume_AAA_Baryonyx_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29810:                                  23 ED BF CA 7B
29820: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 57
29830: 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65 42 6C 75
29840: 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72
29850: 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 73
29860: 74 65 6C 61 6E 64 47 68 69 6C 6C 69 65 5F 48 65
29870: 6C 6D 65 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53
29880: 6B 69 6E 5F 57 61 73 74 65 6C 61 6E 64 47 68 69
29890: 6C 6C 69 65 5F 48 65 6C 6D 65 74 5F 43 00
```

| offset | type   |           value h |                                                                                                                    value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2981B | u4     |          23EDBFCA |                                                                                                                 3401575715 | index       |
|  2981F | s4     |          7B000000 |                                                                                                                        123 | length      |
|  29823 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WastelandGhillie_Helmet.PrimalItemSkin_WastelandGhillie_Helmet_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29890:                                           3F 4D
298A0: 55 FF 61 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
298B0: 73 2F 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65
298C0: 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73
298D0: 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
298E0: 57 61 72 6C 6F 72 64 48 61 74 2E 50 72 69 6D 61
298F0: 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 72 6C 6F 72
29900: 64 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                          value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------: | ----------- |
|  2989E | u4     |          3F4D55FF |                                                                                       4283780415 | index       |
|  298A2 | s4     |          61000000 |                                                                                               97 | length      |
|  298A6 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarlordHat.PrimalItemSkin_WarlordHat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29900:                      7E E8 C4 C8 6D 00 00 00 2F
29910: 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74 65 61 6D
29920: 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65 70 72 69
29930: 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C
29940: 49 74 65 6D 53 6B 69 6E 5F 53 74 65 61 6D 70 75
29950: 6E 6B 47 6C 61 73 73 65 73 2E 50 72 69 6D 61 6C
29960: 49 74 65 6D 53 6B 69 6E 5F 53 74 65 61 6D 70 75
29970: 6E 6B 47 6C 61 73 73 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                                      value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------: | ----------- |
|  29907 | u4     |          7EE8C4C8 |                                                                                                   3368347774 | index       |
|  2990B | s4     |          6D000000 |                                                                                                          109 | length      |
|  2990F | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_SteampunkGlasses.PrimalItemSkin_SteampunkGlasses_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29970:                                     C2 B0 AB D0
29980: 16 00 00 00 41 63 63 65 73 73 6F 72 79 53 6C 6F
29990: 74 4F 76 65 72 72 69 64 65 00
```

| offset | type   |           value h |               value d | description |
| -----: | ------ | ----------------: | --------------------: | ----------- |
|  2997C | u4     |          C2B0ABD0 |            3500912834 | index       |
|  29980 | s4     |          16000000 |                    22 | length      |
|  29984 | string | 416363 ... 646500 | AccessorySlotOverride | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29990:                               EC 46 87 45 15 00
299A0: 00 00 45 50 72 69 6D 61 6C 45 71 75 69 70 6D 65
299B0: 6E 74 54 79 70 65 00
```

| offset | type   |           value h |              value d | description |
| -----: | ------ | ----------------: | -------------------: | ----------- |
|  2999A | u4     |          EC468745 |           1166493420 | index       |
|  2999E | s4     |          15000000 |                   21 | length      |
|  299A2 | string | 455072 ... 706500 | EPrimalEquipmentType | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
299B0:                      47 03 26 BD 21 00 00 00 45
299C0: 50 72 69 6D 61 6C 45 71 75 69 70 6D 65 6E 74 54
299D0: 79 70 65 3A 3A 41 63 63 65 73 73 6F 72 79 30 00
```

| offset | type   |           value h |                          value d | description |
| -----: | ------ | ----------------: | -------------------------------: | ----------- |
|  299B7 | u4     |          470326BD |                       3173385031 | index       |
|  299BB | s4     |          21000000 |                               33 | length      |
|  299BF | string | 455072 ... 793000 | EPrimalEquipmentType::Accessory0 | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
299E0: 41 0E 5E D9 6B 00 00 00 2F 47 61 6D 65 2F 50 61
299F0: 63 6B 73 2F 53 74 65 61 6D 70 75 6E 6B 2F 43 6F
29A00: 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65
29A10: 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
29A20: 6E 5F 44 61 70 70 65 72 48 61 74 5F 53 68 6F 72
29A30: 74 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
29A40: 5F 44 61 70 70 65 72 48 61 74 5F 53 68 6F 72 74
29A50: 5F 43 00
```

| offset | type   |           value h |                                                                                                    value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------: | ----------- |
|  299E0 | u4     |          410E5ED9 |                                                                                                 3646819905 | index       |
|  299E4 | s4     |          6B000000 |                                                                                                        107 | length      |
|  299E8 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_DapperHat_Short.PrimalItemSkin_DapperHat_Short_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29A50:          45 40 53 F8 79 00 00 00 2F 47 61 6D 65
29A60: 2F 50 61 63 6B 73 2F 53 74 65 61 6D 70 75 6E 6B
29A70: 2F 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F
29A80: 49 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D
29A90: 53 6B 69 6E 5F 41 62 65 72 72 61 6E 74 47 68 69
29AA0: 6C 6C 69 65 5F 48 65 6C 6D 65 74 2E 50 72 69 6D
29AB0: 61 6C 49 74 65 6D 53 6B 69 6E 5F 41 62 65 72 72
29AC0: 61 6E 74 47 68 69 6C 6C 69 65 5F 48 65 6C 6D 65
29AD0: 74 5F 43 00
```

| offset | type   |           value h |                                                                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  29A53 | u4     |          454053F8 |                                                                                                               4166205509 | index       |
|  29A57 | s4     |          79000000 |                                                                                                                      121 | length      |
|  29A5B | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_AberrantGhillie_Helmet.PrimalItemSkin_AberrantGhillie_Helmet_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29AD0:             09 CA AE 5F 65 00 00 00 2F 47 61 6D
29AE0: 65 2F 41 53 41 2F 43 6F 72 65 42 6C 75 65 70 72
29AF0: 69 6E 74 73 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
29B00: 6C 49 74 65 6D 53 6B 69 6E 5F 47 72 61 73 73 47
29B10: 68 69 6C 6C 69 65 5F 53 68 69 72 74 2E 50 72 69
29B20: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 47 72 61 73
29B30: 73 47 68 69 6C 6C 69 65 5F 53 68 69 72 74 5F 43
29B40: 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  29AD4 | u4     |          09CAAE5F |                                                                                           1605290505 | index       |
|  29AD8 | s4     |          65000000 |                                                                                                  101 | length      |
|  29ADC | string | 2F4761 ... 5F4300 | /Game/ASA/CoreBlueprints/Skins/PrimalItemSkin_GrassGhillie_Shirt.PrimalItemSkin_GrassGhillie_Shirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29B40:    B0 26 28 30 62 00 00 00 2F 47 61 6D 65 2F 4C
29B50: 6F 73 74 43 6F 6C 6F 6E 79 2F 43 6F 72 65 42 6C
29B60: 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50
29B70: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 54 68
29B80: 72 61 6C 6C 5F 54 33 5F 48 61 74 2E 50 72 69 6D
29B90: 61 6C 49 74 65 6D 53 6B 69 6E 5F 54 68 72 61 6C
29BA0: 6C 5F 54 33 5F 48 61 74 5F 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  29B41 | u4     |          B0262830 |                                                                                         807937712 | index       |
|  29B45 | s4     |          62000000 |                                                                                                98 | length      |
|  29B49 | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_Thrall_T3_Hat.PrimalItemSkin_Thrall_T3_Hat_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29BA0:                                  85 43 B9 58 62
29BB0: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41
29BC0: 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49
29BD0: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 53
29BE0: 61 62 65 72 5F 53 6B 69 6E 50 61 63 6B 2E 50 72
29BF0: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
29C00: 41 41 41 5F 53 61 62 65 72 5F 53 6B 69 6E 50 61
29C10: 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  29BAB | u4     |          8543B958 |                                                                                        1488536453 | index       |
|  29BAF | s4     |          62000000 |                                                                                                98 | length      |
|  29BB3 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Saber_SkinPack.PrimalItemCostume_AAA_Saber_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29C10:                A0 88 69 DD 70 00 00 00 2F 47 61
29C20: 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69
29C30: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
29C40: 74 75 6D 65 5F 41 41 41 5F 4D 65 73 6F 70 69 74
29C50: 68 65 63 75 73 5F 53 6B 69 6E 50 61 63 6B 2E 50
29C60: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
29C70: 5F 41 41 41 5F 4D 65 73 6F 70 69 74 68 65 63 75
29C80: 73 5F 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                         value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------: | ----------- |
|  29C15 | u4     |          A08869DD |                                                                                                      3714680992 | index       |
|  29C19 | s4     |          70000000 |                                                                                                             112 | length      |
|  29C1D | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Mesopithecus_SkinPack.PrimalItemCostume_AAA_Mesopithecus_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29C80:                                        81 4D ED
29C90: 6A 6C 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
29CA0: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29CB0: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
29CC0: 5F 44 6F 65 64 69 63 75 72 75 73 5F 53 6B 69 6E
29CD0: 50 61 63 6B 2E 50 72 69 6D 61 6C 49 74 65 6D 43
29CE0: 6F 73 74 75 6D 65 5F 41 41 41 5F 44 6F 65 64 69
29CF0: 63 75 72 75 73 5F 53 6B 69 6E 50 61 63 6B 5F 43
29D00: 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  29C8D | u4     |          814DED6A |                                                                                                  1793936769 | index       |
|  29C91 | s4     |          6C000000 |                                                                                                         108 | length      |
|  29C95 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Doedicurus_SkinPack.PrimalItemCostume_AAA_Doedicurus_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29D00:    9C 8C 8E 71 5C 00 00 00 2F 47 61 6D 65 2F 50
29D10: 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50
29D20: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43 68
29D30: 61 72 61 63 74 65 72 53 6B 69 6E 5F 4A 61 6E 65
29D40: 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
29D50: 43 68 61 72 61 63 74 65 72 53 6B 69 6E 5F 4A 61
29D60: 6E 65 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  29D01 | u4     |          9C8C8E71 |                                                                                  1905167516 | index       |
|  29D05 | s4     |          5C000000 |                                                                                          92 | length      |
|  29D09 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Jane.PrimalItemSkin_CharacterSkin_Jane_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29D60:                DF E4 37 F7 5A 00 00 00 2F 47 61
29D70: 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69
29D80: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
29D90: 74 75 6D 65 5F 41 41 41 5F 54 68 79 6C 61 63 6F
29DA0: 6C 65 6F 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F
29DB0: 73 74 75 6D 65 5F 41 41 41 5F 54 68 79 6C 61 63
29DC0: 6F 6C 65 6F 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  29D65 | u4     |          DFE437F7 |                                                                                4147635423 | index       |
|  29D69 | s4     |          5A000000 |                                                                                        90 | length      |
|  29D6D | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Thylacoleo.PrimalItemCostume_AAA_Thylacoleo_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29DC0:                      D3 26 E2 AC 50 00 00 00 2F
29DD0: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
29DE0: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43
29DF0: 6F 73 74 75 6D 65 5F 41 41 41 5F 53 61 72 63 6F
29E00: 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
29E10: 6D 65 5F 41 41 41 5F 53 61 72 63 6F 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  29DC7 | u4     |          D326E2AC |                                                                      2900502227 | index       |
|  29DCB | s4     |          50000000 |                                                                              80 | length      |
|  29DCF | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Sarco.PrimalItemCostume_AAA_Sarco_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29E10:                                              99
29E20: 7E B7 D5 5A 00 00 00 2F 47 61 6D 65 2F 50 61 63
29E30: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
29E40: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
29E50: 41 41 5F 50 65 67 6F 6D 61 73 74 61 78 2E 50 72
29E60: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
29E70: 41 41 41 5F 50 65 67 6F 6D 61 73 74 61 78 5F 43
29E80: 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  29E1F | u4     |          997EB7D5 |                                                                                3585572505 | index       |
|  29E23 | s4     |          5A000000 |                                                                                        90 | length      |
|  29E27 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Pegomastax.PrimalItemCostume_AAA_Pegomastax_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29E80:    4E DD 98 15 5E 00 00 00 2F 47 61 6D 65 2F 50
29E90: 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50
29EA0: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
29EB0: 5F 41 41 41 5F 4D 65 67 61 6C 6F 73 61 75 72 75
29EC0: 73 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
29ED0: 75 6D 65 5F 41 41 41 5F 4D 65 67 61 6C 6F 73 61
29EE0: 75 72 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  29E81 | u4     |          4EDD9815 |                                                                                     362339662 | index       |
|  29E85 | s4     |          5E000000 |                                                                                            94 | length      |
|  29E89 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Megalosaurus.PrimalItemCostume_AAA_Megalosaurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29EE0:                      E8 15 77 E0 5C 00 00 00 2F
29EF0: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
29F00: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43
29F10: 6F 73 74 75 6D 65 5F 41 41 41 5F 49 63 68 74 68
29F20: 79 6F 72 6E 69 73 2E 50 72 69 6D 61 6C 49 74 65
29F30: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 49 63 68
29F40: 74 68 79 6F 72 6E 69 73 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  29EE7 | u4     |          E81577E0 |                                                                                  3765900776 | index       |
|  29EEB | s4     |          5C000000 |                                                                                          92 | length      |
|  29EEF | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Ichthyornis.PrimalItemCostume_AAA_Ichthyornis_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29F40:                                  CE BA 9F 7D 56
29F50: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41
29F60: 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49
29F70: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 44
29F80: 69 72 65 77 6F 6C 66 2E 50 72 69 6D 61 6C 49 74
29F90: 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 44 69
29FA0: 72 65 77 6F 6C 66 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  29F4B | u4     |          CEBA9F7D |                                                                            2107620046 | index       |
|  29F4F | s4     |          56000000 |                                                                                    86 | length      |
|  29F53 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Direwolf.PrimalItemCostume_AAA_Direwolf_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
29FA0:                            35 8B 70 80 62 00 00
29FB0: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41
29FC0: 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65
29FD0: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 43 68 61
29FE0: 6C 69 63 6F 74 68 65 72 69 75 6D 2E 50 72 69 6D
29FF0: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
2A000: 41 5F 43 68 61 6C 69 63 6F 74 68 65 72 69 75 6D
2A010: 5F 43 00
```

| offset | type   |           value h |                                                                                           value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------: | ----------- |
|  29FA9 | u4     |          358B7080 |                                                                                        2154859317 | index       |
|  29FAD | s4     |          62000000 |                                                                                                98 | length      |
|  29FB1 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Chalicotherium.PrimalItemCostume_AAA_Chalicotherium_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A010:          E8 2B BD 7C 5E 00 00 00 2F 47 61 6D 65
2A020: 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73
2A030: 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
2A040: 6D 65 5F 41 41 41 5F 41 72 74 68 72 6F 70 6C 75
2A050: 65 72 61 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F
2A060: 73 74 75 6D 65 5F 41 41 41 5F 41 72 74 68 72 6F
2A070: 70 6C 75 65 72 61 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  2A013 | u4     |          E82BBD7C |                                                                                    2092772328 | index       |
|  2A017 | s4     |          5E000000 |                                                                                            94 | length      |
|  2A01B | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Arthropluera.PrimalItemCostume_AAA_Arthropluera_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A070:                            F4 3D 4E 04 7B 00 00
2A080: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 57 61 73
2A090: 74 65 6C 61 6E 64 2F 43 6F 72 65 42 6C 75 65 70
2A0A0: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D
2A0B0: 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 73 74 65
2A0C0: 6C 61 6E 64 47 68 69 6C 6C 69 65 5F 47 6C 6F 76
2A0D0: 65 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
2A0E0: 6E 5F 57 61 73 74 65 6C 61 6E 64 47 68 69 6C 6C
2A0F0: 69 65 5F 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                    value d | description |
| -----: | ------ | ----------------: | -------------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2A079 | u4     |          F43D4E04 |                                                                                                                   72236532 | index       |
|  2A07D | s4     |          7B000000 |                                                                                                                        123 | length      |
|  2A081 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WastelandGhillie_Gloves.PrimalItemSkin_WastelandGhillie_Gloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A0F0:                                     F5 B1 A9 D5
2A100: 67 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F
2A110: 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65 42 6C
2A120: 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50
2A130: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61
2A140: 72 6C 6F 72 64 47 6C 6F 76 65 73 2E 50 72 69 6D
2A150: 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 72 6C 6F
2A160: 72 64 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  2A0FC | u4     |          F5B1A9D5 |                                                                                             3584668149 | index       |
|  2A100 | s4     |          67000000 |                                                                                                    103 | length      |
|  2A104 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarlordGloves.PrimalItemSkin_WarlordGloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A160:                                  D6 C4 1C E3 67
2A170: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53
2A180: 74 65 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75
2A190: 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72
2A1A0: 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 45 6E 67
2A1B0: 69 6E 65 65 72 53 68 69 72 74 2E 50 72 69 6D 61
2A1C0: 6C 49 74 65 6D 53 6B 69 6E 5F 45 6E 67 69 6E 65
2A1D0: 65 72 53 68 69 72 74 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  2A16B | u4     |          D6C41CE3 |                                                                                             3810313430 | index       |
|  2A16F | s4     |          67000000 |                                                                                                    103 | length      |
|  2A173 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_EngineerShirt.PrimalItemSkin_EngineerShirt_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A1D0:                               DE 6C 39 65 67 00
2A1E0: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74
2A1F0: 65 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65
2A200: 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69
2A210: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 61 70 70
2A220: 65 72 48 61 74 5F 4D 65 64 2E 50 72 69 6D 61 6C
2A230: 49 74 65 6D 53 6B 69 6E 5F 44 61 70 70 65 72 48
2A240: 61 74 5F 4D 65 64 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  2A1DA | u4     |          DE6C3965 |                                                                                             1698262238 | index       |
|  2A1DE | s4     |          67000000 |                                                                                                    103 | length      |
|  2A1E2 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_DapperHat_Med.PrimalItemSkin_DapperHat_Med_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A240:                            B1 5E 17 1D 79 00 00
2A250: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74 65
2A260: 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65 70
2A270: 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D
2A280: 61 6C 49 74 65 6D 53 6B 69 6E 5F 41 62 65 72 72
2A290: 61 6E 74 47 68 69 6C 6C 69 65 5F 47 6C 6F 76 65
2A2A0: 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E
2A2B0: 5F 41 62 65 72 72 61 6E 74 47 68 69 6C 6C 69 65
2A2C0: 5F 47 6C 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2A249 | u4     |          B15E171D |                                                                                                                488070833 | index       |
|  2A24D | s4     |          79000000 |                                                                                                                      121 | length      |
|  2A251 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_AberrantGhillie_Gloves.PrimalItemSkin_AberrantGhillie_Gloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A2C0:                               14 4F 9D 0C 65 00
2A2D0: 00 00 2F 47 61 6D 65 2F 41 53 41 2F 43 6F 72 65
2A2E0: 42 6C 75 65 70 72 69 6E 74 73 2F 53 6B 69 6E 73

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A2F0: 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
2A300: 47 72 61 73 73 47 68 69 6C 6C 69 65 5F 50 61 6E
2A310: 74 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
2A320: 6E 5F 47 72 61 73 73 47 68 69 6C 6C 69 65 5F 50
2A330: 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  2A2CA | u4     |          144F9D0C |                                                                                            211635988 | index       |
|  2A2CE | s4     |          65000000 |                                                                                                  101 | length      |
|  2A2D2 | string | 2F4761 ... 5F4300 | /Game/ASA/CoreBlueprints/Skins/PrimalItemSkin_GrassGhillie_Pants.PrimalItemSkin_GrassGhillie_Pants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A330:                      64 EA AA 5D 68 00 00 00 2F
2A340: 47 61 6D 65 2F 4C 6F 73 74 43 6F 6C 6F 6E 79 2F
2A350: 43 6F 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49
2A360: 74 65 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53
2A370: 6B 69 6E 5F 54 68 72 61 6C 6C 5F 54 33 5F 47 6C
2A380: 6F 76 65 73 2E 50 72 69 6D 61 6C 49 74 65 6D 53
2A390: 6B 69 6E 5F 54 68 72 61 6C 6C 5F 54 33 5F 47 6C
2A3A0: 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                                 value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------------------: | ----------- |
|  2A337 | u4     |          64EAAA5D |                                                                                              1571482212 | index       |
|  2A33B | s4     |          68000000 |                                                                                                     104 | length      |
|  2A33F | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_Thrall_T3_Gloves.PrimalItemSkin_Thrall_T3_Gloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A3A0:                      AE 3F D0 7E 76 00 00 00 2F
2A3B0: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
2A3C0: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53
2A3D0: 6B 69 6E 5F 43 68 61 72 61 63 74 65 72 53 6B 69
2A3E0: 6E 5F 52 6F 63 6B 77 65 6C 6C 5F 53 6B 69 6E 50
2A3F0: 61 63 6B 2E 50 72 69 6D 61 6C 49 74 65 6D 53 6B
2A400: 69 6E 5F 43 68 61 72 61 63 74 65 72 53 6B 69 6E
2A410: 5F 52 6F 63 6B 77 65 6C 6C 5F 53 6B 69 6E 50 61
2A420: 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                               value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2A3A7 | u4     |          AE3FD07E |                                                                                                            2127577006 | index       |
|  2A3AB | s4     |          76000000 |                                                                                                                   118 | length      |
|  2A3AF | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Rockwell_SkinPack.PrimalItemSkin_CharacterSkin_Rockwell_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A420:                1D A2 CE BC 72 00 00 00 2F 47 61
2A430: 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69
2A440: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
2A450: 6E 5F 43 68 61 72 61 63 74 65 72 53 6B 69 6E 5F
2A460: 4D 65 69 79 69 6E 5F 53 6B 69 6E 50 61 63 6B 2E
2A470: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 43
2A480: 68 61 72 61 63 74 65 72 53 6B 69 6E 5F 4D 65 69
2A490: 79 69 6E 5F 53 6B 69 6E 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                           value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------------: | ----------- |
|  2A425 | u4     |          1DA2CEBC |                                                                                                        3167658525 | index       |
|  2A429 | s4     |          72000000 |                                                                                                               114 | length      |
|  2A42D | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Meiyin_SkinPack.PrimalItemSkin_CharacterSkin_Meiyin_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A490:                                              8A
2A4A0: 70 25 CA 60 00 00 00 2F 47 61 6D 65 2F 50 61 63
2A4B0: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
2A4C0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
2A4D0: 41 41 5F 44 6F 64 6F 5F 53 6B 69 6E 50 61 63 6B
2A4E0: 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
2A4F0: 6D 65 5F 41 41 41 5F 44 6F 64 6F 5F 53 6B 69 6E
2A500: 50 61 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                         value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------: | ----------- |
|  2A49F | u4     |          8A7025CA |                                                                                      3391451274 | index       |
|  2A4A3 | s4     |          60000000 |                                                                                              96 | length      |
|  2A4A7 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Dodo_SkinPack.PrimalItemCostume_AAA_Dodo_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A500:                      CF FB A0 89 5E 00 00 00 2F
2A510: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
2A520: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53
2A530: 6B 69 6E 5F 43 68 61 72 61 63 74 65 72 53 6B 69
2A540: 6E 5F 43 68 61 76 61 2E 50 72 69 6D 61 6C 49 74
2A550: 65 6D 53 6B 69 6E 5F 43 68 61 72 61 63 74 65 72
2A560: 53 6B 69 6E 5F 43 68 61 76 61 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  2A507 | u4     |          CFFBA089 |                                                                                    2309028815 | index       |
|  2A50B | s4     |          5E000000 |                                                                                            94 | length      |
|  2A50F | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemSkin_CharacterSkin_Chava.PrimalItemSkin_CharacterSkin_Chava_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A560:                                        B8 BE A4
2A570: C4 64 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
2A580: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
2A590: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
2A5A0: 5F 54 68 65 72 69 7A 69 6E 6F 73 61 75 72 75 73
2A5B0: 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
2A5C0: 6D 65 5F 41 41 41 5F 54 68 65 72 69 7A 69 6E 6F
2A5D0: 73 61 75 72 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  2A56D | u4     |          B8BEA4C4 |                                                                                          3299131064 | index       |
|  2A571 | s4     |          64000000 |                                                                                                 100 | length      |
|  2A575 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Therizinosaurus.PrimalItemCostume_AAA_Therizinosaurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A5D0:                            6A D1 1E 32 52 00 00
2A5E0: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41
2A5F0: 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65
2A600: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 53 61 6C
2A610: 6D 6F 6E 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F
2A620: 73 74 75 6D 65 5F 41 41 41 5F 53 61 6C 6D 6F 6E
2A630: 5F 43 00
```

| offset | type   |           value h |                                                                           value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------: | ----------- |
|  2A5D9 | u4     |          6AD11E32 |                                                                         840880490 | index       |
|  2A5DD | s4     |          52000000 |                                                                                82 | length      |
|  2A5E1 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Salmon.PrimalItemCostume_AAA_Salmon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A630:          E8 61 89 72 64 00 00 00 2F 47 61 6D 65
2A640: 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73
2A650: 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
2A660: 6D 65 5F 41 41 41 5F 50 61 72 61 63 65 72 61 74
2A670: 68 65 72 69 75 6D 2E 50 72 69 6D 61 6C 49 74 65
2A680: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 50 61 72
2A690: 61 63 65 72 61 74 68 65 72 69 75 6D 5F 43 00
```

| offset | type   |           value h |                                                                                             value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------: | ----------- |
|  2A633 | u4     |          E8618972 |                                                                                          1921606120 | index       |
|  2A637 | s4     |          64000000 |                                                                                                 100 | length      |
|  2A63B | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Paraceratherium.PrimalItemCostume_AAA_Paraceratherium_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A690:                                              F8
2A6A0: 56 22 A9 58 00 00 00 2F 47 61 6D 65 2F 50 61 63
2A6B0: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
2A6C0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
2A6D0: 41 41 5F 4D 65 67 61 6C 6F 64 6F 6E 2E 50 72 69
2A6E0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
2A6F0: 41 41 5F 4D 65 67 61 6C 6F 64 6F 6E 5F 43 00
```

| offset | type   |           value h |                                                                                 value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------: | ----------- |
|  2A69F | u4     |          F85622A9 |                                                                              2837599992 | index       |
|  2A6A3 | s4     |          58000000 |                                                                                      88 | length      |
|  2A6A7 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Megalodon.PrimalItemCostume_AAA_Megalodon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A6F0:                                              D6
2A700: 09 B1 B3 58 00 00 00 2F 47 61 6D 65 2F 50 61 63
2A710: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
2A720: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
2A730: 41 41 5F 48 79 61 65 6E 6F 64 6F 6E 2E 50 72 69
2A740: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
2A750: 41 41 5F 48 79 61 65 6E 6F 64 6F 6E 5F 43 00
```

| offset | type   |           value h |                                                                                 value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------: | ----------- |
|  2A6FF | u4     |          D609B1B3 |                                                                              3014724054 | index       |
|  2A703 | s4     |          58000000 |                                                                                      88 | length      |
|  2A707 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Hyaenodon.PrimalItemCostume_AAA_Hyaenodon_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A750:                                              DB
2A760: 3D 81 71 56 00 00 00 2F 47 61 6D 65 2F 50 61 63
2A770: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
2A780: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
2A790: 41 41 5F 44 69 72 65 42 65 61 72 2E 50 72 69 6D
2A7A0: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
2A7B0: 41 5F 44 69 72 65 42 65 61 72 5F 43 00
```

| offset | type   |           value h |                                                                               value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------: | ----------- |
|  2A75F | u4     |          DB3D8171 |                                                                            1904295387 | index       |
|  2A763 | s4     |          56000000 |                                                                                    86 | length      |
|  2A767 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_DireBear.PrimalItemCostume_AAA_DireBear_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A7B0:                                        A8 22 1C
2A7C0: 38 50 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
2A7D0: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
2A7E0: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
2A7F0: 5F 43 61 72 6E 6F 2E 50 72 69 6D 61 6C 49 74 65
2A800: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 43 61 72
2A810: 6E 6F 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  2A7BD | u4     |          A8221C38 |                                                                       941367976 | index       |
|  2A7C1 | s4     |          50000000 |                                                                              80 | length      |
|  2A7C5 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Carno.PrimalItemCostume_AAA_Carno_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A810:                91 77 56 28 60 00 00 00 2F 47 61
2A820: 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69
2A830: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
2A840: 74 75 6D 65 5F 41 41 41 5F 41 72 63 68 61 65 6F
2A850: 70 74 65 72 79 78 2E 50 72 69 6D 61 6C 49 74 65
2A860: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 41 72 63
2A870: 68 61 65 6F 70 74 65 72 79 78 5F 43 00
```

| offset | type   |           value h |                                                                                         value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------: | ----------- |
|  2A815 | u4     |          91775628 |                                                                                       676755345 | index       |
|  2A819 | s4     |          60000000 |                                                                                              96 | length      |
|  2A81D | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Archaeopteryx.PrimalItemCostume_AAA_Archaeopteryx_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A870:                                        E3 B3 27
2A880: 14 79 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
2A890: 2F 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65 42
2A8A0: 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F
2A8B0: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57
2A8C0: 61 73 74 65 6C 61 6E 64 47 68 69 6C 6C 69 65 5F
2A8D0: 42 6F 6F 74 73 2E 50 72 69 6D 61 6C 49 74 65 6D
2A8E0: 53 6B 69 6E 5F 57 61 73 74 65 6C 61 6E 64 47 68
2A8F0: 69 6C 6C 69 65 5F 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                  value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2A87D | u4     |          E3B32714 |                                                                                                                338146275 | index       |
|  2A881 | s4     |          79000000 |                                                                                                                      121 | length      |
|  2A885 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WastelandGhillie_Boots.PrimalItemSkin_WastelandGhillie_Boots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A8F0:                                           A8 35
2A900: B8 74 65 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B
2A910: 73 2F 57 61 73 74 65 6C 61 6E 64 2F 43 6F 72 65
2A920: 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65 6D 73

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A930: 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F
2A940: 57 61 72 6C 6F 72 64 42 6F 6F 74 73 2E 50 72 69
2A950: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 57 61 72 6C
2A960: 6F 72 64 42 6F 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  2A8FE | u4     |          A835B874 |                                                                                           1958229416 | index       |
|  2A902 | s4     |          65000000 |                                                                                                  101 | length      |
|  2A906 | string | 2F4761 ... 5F4300 | /Game/Packs/Wasteland/CoreBlueprints/Items/PrimalItemSkin_WarlordBoots.PrimalItemSkin_WarlordBoots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A960:                                  73 24 67 8B 67
2A970: 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53
2A980: 74 65 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75
2A990: 65 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72
2A9A0: 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 45 6E 67
2A9B0: 69 6E 65 65 72 50 61 6E 74 73 2E 50 72 69 6D 61
2A9C0: 6C 49 74 65 6D 53 6B 69 6E 5F 45 6E 67 69 6E 65
2A9D0: 65 72 50 61 6E 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  2A96B | u4     |          7324678B |                                                                                             2338792563 | index       |
|  2A96F | s4     |          67000000 |                                                                                                    103 | length      |
|  2A973 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_EngineerPants.PrimalItemSkin_EngineerPants_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2A9D0:                               F7 30 02 91 65 00
2A9E0: 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74
2A9F0: 65 61 6D 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65
2AA00: 70 72 69 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69
2AA10: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 44 61 70 70
2AA20: 65 72 47 6C 6F 76 65 73 2E 50 72 69 6D 61 6C 49
2AA30: 74 65 6D 53 6B 69 6E 5F 44 61 70 70 65 72 47 6C
2AA40: 6F 76 65 73 5F 43 00
```

| offset | type   |           value h |                                                                                              value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------: | ----------- |
|  2A9DA | u4     |          F7300291 |                                                                                           2432839927 | index       |
|  2A9DE | s4     |          65000000 |                                                                                                  101 | length      |
|  2A9E2 | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_DapperGloves.PrimalItemSkin_DapperGloves_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AA40:                      21 4C 60 20 77 00 00 00 2F
2AA50: 47 61 6D 65 2F 50 61 63 6B 73 2F 53 74 65 61 6D
2AA60: 70 75 6E 6B 2F 43 6F 72 65 42 6C 75 65 70 72 69
2AA70: 6E 74 73 2F 49 74 65 6D 73 2F 50 72 69 6D 61 6C
2AA80: 49 74 65 6D 53 6B 69 6E 5F 41 62 65 72 72 61 6E
2AA90: 74 47 68 69 6C 6C 69 65 5F 42 6F 6F 74 73 2E 50
2AAA0: 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 41 62
2AAB0: 65 72 72 61 6E 74 47 68 69 6C 6C 69 65 5F 42 6F
2AAC0: 6F 74 73 5F 43 00
```

| offset | type   |           value h |                                                                                                                value d | description |
| -----: | ------ | ----------------: | ---------------------------------------------------------------------------------------------------------------------: | ----------- |
|  2AA47 | u4     |          214C6020 |                                                                                                              543181857 | index       |
|  2AA4B | s4     |          77000000 |                                                                                                                    119 | length      |
|  2AA4F | string | 2F4761 ... 5F4300 | /Game/Packs/Steampunk/CoreBlueprints/Items/PrimalItemSkin_AberrantGhillie_Boots.PrimalItemSkin_AberrantGhillie_Boots_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AAC0:                   69 15 8E EA 67 00 00 00 2F 47
2AAD0: 61 6D 65 2F 41 53 41 2F 43 6F 72 65 42 6C 75 65
2AAE0: 70 72 69 6E 74 73 2F 53 6B 69 6E 73 2F 50 72 69
2AAF0: 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 47 72 61 73
2AB00: 73 47 68 69 6C 6C 69 65 5F 48 65 6C 6D 65 74 2E
2AB10: 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69 6E 5F 47
2AB20: 72 61 73 73 47 68 69 6C 6C 69 65 5F 48 65 6C 6D
2AB30: 65 74 5F 43 00
```

| offset | type   |           value h |                                                                                                value d | description |
| -----: | ------ | ----------------: | -----------------------------------------------------------------------------------------------------: | ----------- |
|  2AAC6 | u4     |          69158EEA |                                                                                             3935180137 | index       |
|  2AACA | s4     |          67000000 |                                                                                                    103 | length      |
|  2AACE | string | 2F4761 ... 5F4300 | /Game/ASA/CoreBlueprints/Skins/PrimalItemSkin_GrassGhillie_Helmet.PrimalItemSkin_GrassGhillie_Helmet_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AB30:                4A F6 BD B4 70 00 00 00 2F 47 61
2AB40: 6D 65 2F 4C 6F 73 74 43 6F 6C 6F 6E 79 2F 43 6F
2AB50: 72 65 42 6C 75 65 70 72 69 6E 74 73 2F 49 74 65
2AB60: 6D 73 2F 50 72 69 6D 61 6C 49 74 65 6D 53 6B 69
2AB70: 6E 5F 54 68 72 61 6C 6C 5F 54 33 5F 53 68 69 72
2AB80: 74 5F 43 61 70 65 2E 50 72 69 6D 61 6C 49 74 65
2AB90: 6D 53 6B 69 6E 5F 54 68 72 61 6C 6C 5F 54 33 5F
2ABA0: 53 68 69 72 74 5F 43 61 70 65 5F 43 00
```

| offset | type   |           value h |                                                                                                         value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------------: | ----------- |
|  2AB35 | u4     |          4AF6BDB4 |                                                                                                      3032348234 | index       |
|  2AB39 | s4     |          70000000 |                                                                                                             112 | length      |
|  2AB3D | string | 2F4761 ... 5F4300 | /Game/LostColony/CoreBlueprints/Items/PrimalItemSkin_Thrall_T3_Shirt_Cape.PrimalItemSkin_Thrall_T3_Shirt_Cape_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2ABA0:                                        AC 8C 48
2ABB0: BD 5E 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
2ABC0: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
2ABD0: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
2ABE0: 5F 52 65 78 5F 53 6B 69 6E 50 61 63 6B 2E 50 72
2ABF0: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
2AC00: 41 41 41 5F 52 65 78 5F 53 6B 69 6E 50 61 63 6B
2AC10: 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  2ABAD | u4     |          AC8C48BD |                                                                                    3175648428 | index       |
|  2ABB1 | s4     |          5E000000 |                                                                                            94 | length      |
|  2ABB5 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Rex_SkinPack.PrimalItemCostume_AAA_Rex_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AC10:          1C DD 0D E8 6A 00 00 00 2F 47 61 6D 65
2AC20: 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73
2AC30: 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
2AC40: 6D 65 5F 41 41 41 5F 4D 65 67 61 6C 61 6E 69 61
2AC50: 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D 61 6C
2AC60: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
2AC70: 4D 65 67 61 6C 61 6E 69 61 5F 53 6B 69 6E 50 61
2AC80: 63 6B 5F 43 00
```

| offset | type   |           value h |                                                                                                   value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------------------: | ----------- |
|  2AC13 | u4     |          1CDD0DE8 |                                                                                                3893222684 | index       |
|  2AC17 | s4     |          6A000000 |                                                                                                       106 | length      |
|  2AC1B | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Megalania_SkinPack.PrimalItemCostume_AAA_Megalania_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AC80:                88 87 69 E9 66 00 00 00 2F 47 61
2AC90: 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69
2ACA0: 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
2ACB0: 74 75 6D 65 5F 41 41 41 5F 44 61 65 6F 64 6F 6E
2ACC0: 5F 53 6B 69 6E 50 61 63 6B 2E 50 72 69 6D 61 6C
2ACD0: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
2ACE0: 44 61 65 6F 64 6F 6E 5F 53 6B 69 6E 50 61 63 6B
2ACF0: 5F 43 00
```

| offset | type   |           value h |                                                                                               value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------: | ----------- |
|  2AC85 | u4     |          888769E9 |                                                                                            3916007304 | index       |
|  2AC89 | s4     |          66000000 |                                                                                                   102 | length      |
|  2AC8D | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Daeodon_SkinPack.PrimalItemCostume_AAA_Daeodon_SkinPack_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2ACF0:          16 B1 02 1C 5C 00 00 00 2F 47 61 6D 65
2AD00: 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73
2AD10: 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
2AD20: 6D 65 5F 41 41 41 5F 57 6F 6F 6C 6C 79 52 68 69
2AD30: 6E 6F 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73
2AD40: 74 75 6D 65 5F 41 41 41 5F 57 6F 6F 6C 6C 79 52
2AD50: 68 69 6E 6F 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  2ACF3 | u4     |          16B1021C |                                                                                   469938454 | index       |
|  2ACF7 | s4     |          5C000000 |                                                                                          92 | length      |
|  2ACFB | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_WoollyRhino.PrimalItemCostume_AAA_WoollyRhino_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AD50:                      04 DA 4C 2A 5A 00 00 00 2F
2AD60: 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41 2F 53
2AD70: 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65 6D 43
2AD80: 6F 73 74 75 6D 65 5F 41 41 41 5F 54 65 72 72 6F
2AD90: 72 42 69 72 64 2E 50 72 69 6D 61 6C 49 74 65 6D
2ADA0: 43 6F 73 74 75 6D 65 5F 41 41 41 5F 54 65 72 72
2ADB0: 6F 72 42 69 72 64 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  2AD57 | u4     |          04DA4C2A |                                                                                 709679620 | index       |
|  2AD5B | s4     |          5A000000 |                                                                                        90 | length      |
|  2AD5F | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_TerrorBird.PrimalItemCostume_AAA_TerrorBird_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2ADB0:                            81 A7 33 C5 5E 00 00
2ADC0: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41
2ADD0: 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65
2ADE0: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 52 68 79
2ADF0: 6E 69 6F 67 6E 61 74 68 61 2E 50 72 69 6D 61 6C
2AE00: 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F
2AE10: 52 68 79 6E 69 6F 67 6E 61 74 68 61 5F 43 00
```

| offset | type   |           value h |                                                                                       value d | description |
| -----: | ------ | ----------------: | --------------------------------------------------------------------------------------------: | ----------- |
|  2ADB9 | u4     |          81A733C5 |                                                                                    3308496769 | index       |
|  2ADBD | s4     |          5E000000 |                                                                                            94 | length      |
|  2ADC1 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Rhyniognatha.PrimalItemCostume_AAA_Rhyniognatha_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AE10:                                              65
2AE20: 87 B5 6B 5A 00 00 00 2F 47 61 6D 65 2F 50 61 63
2AE30: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
2AE40: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
2AE50: 41 41 5F 50 61 63 68 79 72 68 69 6E 6F 2E 50 72
2AE60: 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F
2AE70: 41 41 41 5F 50 61 63 68 79 72 68 69 6E 6F 5F 43
2AE80: 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  2AE1F | u4     |          6587B56B |                                                                                1807058789 | index       |
|  2AE23 | s4     |          5A000000 |                                                                                        90 | length      |
|  2AE27 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Pachyrhino.PrimalItemCostume_AAA_Pachyrhino_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AE80:    58 FF 6E F2 50 00 00 00 2F 47 61 6D 65 2F 50
2AE90: 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50
2AEA0: 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65
2AEB0: 5F 41 41 41 5F 4D 61 6E 74 61 2E 50 72 69 6D 61
2AEC0: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41
2AED0: 5F 4D 61 6E 74 61 5F 43 00
```

| offset | type   |           value h |                                                                         value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------: | ----------- |
|  2AE81 | u4     |          58FF6EF2 |                                                                      4067360600 | index       |
|  2AE85 | s4     |          50000000 |                                                                              80 | length      |
|  2AE89 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Manta.PrimalItemCostume_AAA_Manta_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AED0:                            2C B0 9E BE 5C 00 00
2AEE0: 00 2F 47 61 6D 65 2F 50 61 63 6B 73 2F 41 41 41
2AEF0: 2F 53 6B 69 6E 73 2F 50 72 69 6D 61 6C 49 74 65
2AF00: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 48 65 73
2AF10: 70 65 72 6F 72 6E 69 73 2E 50 72 69 6D 61 6C 49
2AF20: 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 48
2AF30: 65 73 70 65 72 6F 72 6E 69 73 5F 43 00
```

| offset | type   |           value h |                                                                                     value d | description |
| -----: | ------ | ----------------: | ------------------------------------------------------------------------------------------: | ----------- |
|  2AED9 | u4     |          2CB09EBE |                                                                                  3198070828 | index       |
|  2AEDD | s4     |          5C000000 |                                                                                          92 | length      |
|  2AEE1 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Hesperornis.PrimalItemCostume_AAA_Hesperornis_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AF30:                                        81 52 78
2AF40: 7F 5A 00 00 00 2F 47 61 6D 65 2F 50 61 63 6B 73
2AF50: 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69 6D 61
2AF60: 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41 41

       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AF70: 5F 44 69 70 6C 6F 64 6F 63 75 73 2E 50 72 69 6D
2AF80: 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41 41
2AF90: 41 5F 44 69 70 6C 6F 64 6F 63 75 73 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  2AF3D | u4     |          8152787F |                                                                                2138591873 | index       |
|  2AF41 | s4     |          5A000000 |                                                                                        90 | length      |
|  2AF45 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Diplodocus.PrimalItemCostume_AAA_Diplodocus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2AF90:                                              24
2AFA0: B4 A1 70 6C 00 00 00 2F 47 61 6D 65 2F 50 61 63
2AFB0: 6B 73 2F 41 41 41 2F 53 6B 69 6E 73 2F 50 72 69
2AFC0: 6D 61 6C 49 74 65 6D 43 6F 73 74 75 6D 65 5F 41
2AFD0: 41 41 5F 43 61 72 63 68 61 72 6F 64 6F 6E 74 6F
2AFE0: 73 61 75 72 75 73 2E 50 72 69 6D 61 6C 49 74 65
2AFF0: 6D 43 6F 73 74 75 6D 65 5F 41 41 41 5F 43 61 72
2B000: 63 68 61 72 6F 64 6F 6E 74 6F 73 61 75 72 75 73
2B010: 5F 43 00
```

| offset | type   |           value h |                                                                                                     value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------------------------: | ----------- |
|  2AF9F | u4     |          24B4A170 |                                                                                                  1889645604 | index       |
|  2AFA3 | s4     |          6C000000 |                                                                                                         108 | length      |
|  2AFA7 | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Carcharodontosaurus.PrimalItemCostume_AAA_Carcharodontosaurus_C | value       |

## Name Entry

```
       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
2B010:          D1 49 75 94 5A 00 00 00 2F 47 61 6D 65
2B020: 2F 50 61 63 6B 73 2F 41 41 41 2F 53 6B 69 6E 73
2B030: 2F 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74 75
2B040: 6D 65 5F 41 41 41 5F 41 6E 67 6C 65 72 66 69 73
2B050: 68 2E 50 72 69 6D 61 6C 49 74 65 6D 43 6F 73 74
2B060: 75 6D 65 5F 41 41 41 5F 41 6E 67 6C 65 72 66 69
2B070: 73 68 5F 43 00
```

| offset | type   |           value h |                                                                                   value d | description |
| -----: | ------ | ----------------: | ----------------------------------------------------------------------------------------: | ----------- |
|  2B013 | u4     |          D1497594 |                                                                                2490714577 | index       |
|  2B017 | s4     |          5A000000 |                                                                                        90 | length      |
|  2B01B | string | 2F4761 ... 5F4300 | /Game/Packs/AAA/Skins/PrimalItemCostume_AAA_Anglerfish.PrimalItemCostume_AAA_Anglerfish_C | value       |

# Tail

```

```
