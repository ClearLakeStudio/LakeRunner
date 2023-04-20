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
    - I designed and implemented the items and item effects.
    - In this case, I overestimated myself by about 11 hours. The reason why is because as I got familiar with Unity and C#, I learned a lot and ended up
    going back and rewriting some code just for the fun of it. If I was already familiary with Unity and C# by the time I begin working on this project,
    I think I would have even been a little bit below my original estimation.
    - Whenever a scene is started, the ItemManager runs and creates the Item Pools in the scene hierarchy. In order for an item to be shown, it has to be
    retrieved or spawned using the GetPooledObject() method or SpawnItem() method. Ian calls my SpawnItem method in each scene because he was the one who designed
    the levels. Whenever an item collides with the Hero, a function runs (depending on the parent class of the item) that either stores the item in the inventory
    (if space is available) or activates the item's effect immediately.

- technical (20):
    - test plan (4):
        - What am I testing?
            - Whether the proper flags are set when an item is collected.
            - Whether the inventory is properly updated when an item is collided with
            - Whether an item effect runs whenever the effect is activated
            - Whether all of the item pools are created at scene startup
            - Whether the correct tag is set when an item is created
            - Whether all of the items in an item pool are of the correct type
        - Why am I testing those things?
            - To ensure proper interaction between my feature and others

    - well-documented prefab (3):
        - See ![BrainBlastBar.txt](../../prefabs/Logan/BrainBlastBar.txt)

    - dynamic binding (3):
        - Super class: Item.cs
        - Sub class: Sunglasses.cs
        - Virtual function: UseEffect()

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
        - Object Pool: One object pool for each type of object. Decided on an object pool rather than a thread pool because We'll need a maximum of a few hundred items.
