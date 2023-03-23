/*
 * Filename:  ItemManager.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "ItemManager" class.
 */

using UnityEngine;

/*
 * This class is the interface that allows for other systems (namely
 * the inventory system) to interact with item objects.
 *
 * Member Variables:
 */
public class ItemManager : MonoBehaviour
{
    public KeyCode sunglassesKey = KeyCode.Alpha1;
    public KeyCode slippersKey = KeyCode.Alpha2;
    public KeyCode brainBlastBarKey = KeyCode.Alpha3;

    public void Update()
    {
        // check for user input
        if (Input.GetKeyDown(sunglassesKey)) {
            // query the inventory to ensure that the player has the item
            // if (inventory.ExistsInInventory(ItemType.Sunglasses == true) {
            //     // call the item's effect
            // } else {
            //     // play "denial" sound
            // }

            ActivateItemEffect(ItemType.Sunglasses);
        } else if (Input.GetKeyDown(slippersKey)) {
            ActivateItemEffect(ItemType.Slippers);
        } else if (Input.GetKeyDown(brainBlastBarKey)) {
            ActivateItemEffect(ItemType.BrainBlastBar);
        }
    }

    /*
     * This function should be called whenever the effect of an item needs
     * to execute. This function does not check for whether the item
     * currently exists in the inventory system, so it could be called
     * even if no items exist in the inventory.
     *
     * Parameters:
     * itemType-- ItemType of the item whose effect needs to run
     */
    public void ActivateItemEffect(ItemType itemType)
    {
        Item item = gameObject.GetComponent<Item>();

        switch (itemType) {
            case ItemType.Sunscreen:
                item = gameObject.AddComponent<Sunscreen>();
                break;
            case ItemType.AloeVera:
                item = gameObject.AddComponent<AloeVera>();
                break;
            case ItemType.Sunglasses:
                item = gameObject.AddComponent<Sunglasses>();
                break;
            case ItemType.BrainBlastBar:
                item = gameObject.AddComponent<BrainBlastBar>();
                break;
            case ItemType.Slippers:
                item = gameObject.AddComponent<Slippers>();
                break;
            default:
                break;
        }
        item.UseEffect();
        Destroy(item);
    }
}
