# Brain Blast Bar

Inherits from the AttributeItem class, which inherits from the Item class

## Public Fields:

* AudioClip collectSound
    * The audio clip that will execute when the item is collected.

* bool isCollected
    * Keeps track of whether the item is currently stored in the inventory.

## Public Methods:

* IEnumerator UseEffect()
    * Must be executed as a coroutine. Reverses the direction of the Hero GameObject for a period of time.
    * There must exist a GameObject in the hierarchy with a tag of "Hero" to which is attached a script of the type "Hero" that has a transform component.

* ItemType Colleted()
    * When executed, will activate its own effect through the scene's ItemManager GameObject.
    * There must exist a GameObject in the hierarchy with a tag of "ItemManager" to which is attached a script of the type "ItemManager" that contains the method "ActivateItemEffect()".
    * Returns the ItemType enum value associated with the object that this method is being called on.

* ItemType GetItemType()
    * Returns the ItemType enum value associated with the object that this method is being called on.

* void SetType(ItemType desiredType)
    * Assigns the type of the item that this method is called on to be equal to the desiredType passed in.

* static bool GetEffectIsActive()
    * A static method that returns whether any object of type "BrainBlastBar" are currently activated.

## Dependencies:

* A GameObject with the tag of "Hero" must exist in the hierarchy scene.
    * That object must also contain a "Hero" script component.
        * That script must contain the "GetShield()" and "SetShield()" methods.

* A GameObject with the tag of "ItemManager" must exist in the hierarchy of the scene.
    * That object must also contain a "ItemManager" script component.
        * That script must contain the "ActivateItemEffect()" method.

* An implementation of the ItemType enumerator.

## Images

![](BrainBlastBar.gif)
