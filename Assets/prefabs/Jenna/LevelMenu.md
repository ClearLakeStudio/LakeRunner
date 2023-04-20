# Level Menu
Add this to your Canvas to create a menu for each of your game levels!

## Componenets
It is a UI panel with the following UI elements:
- Level Name: __Legacy Text__ to display the name of the level.
- Start Button: __Button__ to start the level.
  - Start Button Text: __Legacy Text__ to display the state of the level.
    - If the user has not advanced far enough in the game to play the level, it will display **LOCKED**. Even if the user clicks the button, they cannot play the level.
    - If the user has advanced far enough in the game to play the level, it will display **START**.

Attached to the main UI panel are scripts [Animate Menu](#animate-menu-script) and [Level Menu](#level-menu-script).

Attached to the start button is the script [Animate Menu](#animate-menu-script).

## Animate Menu Script
With game objects, sprite animations are highly supported. However, I found no built in method to animate UI panels in a similar fashion. This scripts will allow for UI elements to be similarly animated.

### Public Members
- Sprites
  - An array where each frame of the aniamtion can be added.
- Fps (frames per second)
  - A float the set the frames per second.
  
### Public Methods
- void Play()
  - Starts the animation according to the Fps and in order of the Sprites array.

## Level Menu Script
This script is used in conjunction with script Lake which is attached to prefab [Level](Level.md).

### Public Members
- Menu
  - A reference to __LevelMenu__.
- Menu Name
  - A reference to __Level Name__.
- Menu Button
  - A reference to __Start Button__.
- Menu Button Text
  - A reference to __Start Button Text__.
  
### Public Methods
- void Update(IPublisher publisher)
  - If the Lake object (level) was clicked, then the method Play() is called on the level menu and start button. This will start the animation of both elements.

## Sprites
### Level Name

### Start Button
