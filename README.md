# NoMovementPenalty

A Valheim mod that disables all movement speed penalties caused by equipment.

## Mod not running
![nomod](https://user-images.githubusercontent.com/342276/217718349-e7c5cb57-48d5-4bd0-8652-28f3f36f2b80.png)


## Mod running w/no armor movement speed buffs (any item less than 0 is set to 0)
![withmodnobuffs](https://user-images.githubusercontent.com/342276/217718355-8e408bdc-76b9-409c-84d0-bb4b7f49c11e.png)


## Mod running w/+12% movement speed enchanted armor (Epic Loot)
![withmodwithbuffs](https://user-images.githubusercontent.com/342276/218336498-e0fb61f3-048c-45fb-9cb0-aeb69b5dd7cd.png)


## Config toggles (all enabled by default)
```
## Settings file was created by plugin NoMovementPenalty v1.0.4
## Plugin GUID: posixone_NoMovementPenalty

[1-Global]

## Set this to true to enable and false to disable this mod.
# Setting type: Boolean
# Default value: true
modEnable = true

[2-Toggles]

## Set this to true to enable NoMovementPenalty for the equipped right-handed item.
# Setting type: Boolean
# Default value: true
rightItemEnable = true

## Set this to true to enable NoMovementPenalty for the equipped left-handed item.
# Setting type: Boolean
# Default value: true
leftItemEnable = true

## Set this to true to enable NoMovementPenalty for the equipped helmet item.
# Setting type: Boolean
# Default value: true
helmetItemEnable = true

## Set this to true to enable NoMovementPenalty for the equipped chest item.
# Setting type: Boolean
# Default value: true
chestItemEnable = true

## Set this to true to enable NoMovementPenalty for the equipped leg item.
# Setting type: Boolean
# Default value: true
legItemEnable = true

## Set this to true to enable NoMovementPenalty for the equipped shoulder item.
# Setting type: Boolean
# Default value: true
shoulderItemEnable = true

## Set this to true to enable NoMovementPenalty for the equipped utility item.
# Setting type: Boolean
# Default value: true
utilityItemEnable = true
```

## Changelog

- 1.0.4 Updated to support Ashlands release. Note: this version will not work on game versions prior to 0.218.9. 
- 1.0.3 Added a config file to toggle the mod entirely or toggle individual slots for inclusion. E.g., do not apply "NoMovementPenalty" to right-item and/or left-item, etc...
- 1.0.2 Changed up the evaluations and calculations to display current movement penalties/buffs in the tool-tip.
- 1.0.1 Considers each equipment item independently allowing for positive integers (speed buffs/enchantments/epic loot/potions, etc...)
- 1.0.0 Initial release keeps movement penalty at 0.
