# Jenna-Luz Pura - Overworld & Inter-level Mapping System

## Overview of Feature
#### Overworld System
The Overworld provides a comphrehensive view of the progression of the levels.
A specific order of the levels is outlined.
Once the player selects a new level, the highest score for this level (if any) is displayed.
The Surfer's current inventory is also displayed.
Once the player has successfully completed all of the levels, they will be able to access the infinite runner level in the Overworld.

#### Inter-level Map
When the Surfer is in a level, a miniature map in the corner of the screen will appear.
This map captures the area between the start and end lake.
Enemy entities will be shown as well as locations of items (but the map will not specificy what type of item it is).
If the Surfer has Bummed-Out within this level, the location of where he did will be denoted as an 'X' on the map.
If the Surfer is running in the infinite runner level, the map will cover a fixed area at a time, focusing on the location of the Surfer.

While the Surfer moves throughout the level, his location will be updated on the map.
If the Surfer picks up an item, the item's location will no longer be reflected on the map.
If the Surfer destroys an enemy entity, their location will no longer be reflected on the map.

## Coding Tasks
- Design Overworld Map
  - Place responsive & animated Runner NPC
  - Place animated Enemy NPCs
- Design level stages
- Design level selection menu
  - Display high score (if any)
  - Display current Runner NPC inventory
- Design Inter-level Map
  - Accurately and consistently reflect the location of...
    - Runner NPC (the Surfer)
    - Enemy NPCs
    - Items
    - Last Bummed-Out
