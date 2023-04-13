# Item Manager

Manages the item pools and item effect activation in the scene.

## Design Patterns Implemented:

1. Singleton Pattern
    * This class contains a static reference to itself. The first instance of the class that is instantiated is assigned to that reference. No other instantiation of the class afterward will be able to interact with that instance reference.

2. Object Pools
    * This class creates object pools filled with the different types of items that are found in the ItemCollection prefab that is passed in. The core data structure that keeps track of the pools is a dictionary of lists.
      The dictionary is indexed by the ItemType enum value of the object that is stored in the relevant list. For example, the ItemType.Sunglasses is the key into the dictionary for the the Sunglasses object pool.
      With the help of the GetPooledObject() method SpawnItem() method, and ReturnPooledObject() method, any script can get a reference to an object in any of the pools and manipulate it.

## Dynamic Binding:

* In the ActivateItemEffect() method, I use dynamic binding to avoid a messy switch statement. All item objects that should be pooled must inherit from the Item class and override the virtual function "UseEffect()".
  First, we fetch a reference to the item object whose effect needs to be activated. Then, we create an "Item" object that will dynamically bind to the item object reference we found earlier. Lastly, the "UseEffect()" method is called and the item object is returned to its object pool.
  This is dynamic binding because an object with the static type of "Item" is dynamically attaching to sub-class objects that override the "UseEffect()" method.

## Public Fields:

* AudioClip deniedSound
    * The audio clip that will play when the player tries to use an item that is not stored in their inventory.

* InventoryScript inventory
    * This is where you should put the script that keeps track of the player's inventory.

* KeyCode sunglassesKey
    * The key that the player should press if they want to use the Sunglasses item.
    * Default key is Alpha1

* KeyCode slippersKey
    * The key that the player should press if they want to use the Slippers item.
    * Default key is Alpha2

* KeyCode brainBlastBarKey
    * The key that the player should press if they want to use the Brain Blast Bar item.
    * Default key is Alpha3

* GameObject itemCollection
    * This should be a prefab that has all of the desired items that should be organized into pools as children.

* int numberOfObjectsInPool
    * This is how you control the size of the item pools.
    * Default value is 100

## Public Methods:

* GameObject GetPooledObject(ItemType desiredType)
    *

* bool ReturnPooledObject(GameObject returnedObj)
    *

* void ActivateItemEffect(ItemType itemType)
    *

* void SpawnItem(ItemType? itemType = null, Vector2? pos = null)
    *

## Dependencies:

* An implementation of the ItemType enumerator.
