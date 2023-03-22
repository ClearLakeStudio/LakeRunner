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
        Item item = gameObject.AddComponent<Item>();

        switch (itemType) {
            case ItemType.Sunscreen:
                item = gameObject.AddComponent<AttributeItem>();
                break;
            case ItemType.AloeVera:
                item = gameObject.AddComponent<AttributeItem>();
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
