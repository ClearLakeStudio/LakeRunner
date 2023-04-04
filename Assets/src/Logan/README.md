# Logan Finley - Item/Powerup/Collectibles

## Overview of Feature

I am responsible for the items that the player can use to manipulate the Surfer's abilities. This includes:
- Designing/sourcing item sprites
- Animating the items
- Deciding how the item affects the character and the environment


## Coding Tasks
- to be finished later...
- An example of a task

## Oral exam notes

- contribution (10):
    - ...

- technical (20):
    - test plan (4):
        - What am I testing?
            - ...
        - Why am I testing those things?
            - ...

    - well-documented prefab (3):
        - See ../../prefabs/Logan/BrainBlastBar.txt

    - dynamic binding (3):
        - Super class:
        - Sub class:
        - Virtual function:

    - copyright (4):
        - The sprite for the BrainBlastBar was taken from Super Mario World for the SNES.
        - How does it violate copyright?
            - Super Mario World for the SNES was released 33 years ago in 1990, which means that the work is still protected under copyright.
        - What did I have to do to integrate it with my code?
        - What are the legal implications if you market your code with the re-used portion?
        - Fair use argument for being legally allowed to use the sprite:
            - Fair use says that you must modify 20% of a work in order to claim it is being used fairly.
            The original sprite has 418 colored pixels. I changed 152 pixels (approximately 36%) to qualify.
            I changed the color of the pixels to purple, my favorite color, which is a representation of my personality.
            The original sprite is only a small portion of the original game from which it was taken, and is not easily recognizable.

    - patterns (6):
        - Singleton: ItemManager (only one can exist at a time)
        - Builder/decorator/template/facade
        - Object Pool: One object pool for each type of object. Decided on an object pool rather than a thread pool because We'll need a maximum of a few hundred items.
