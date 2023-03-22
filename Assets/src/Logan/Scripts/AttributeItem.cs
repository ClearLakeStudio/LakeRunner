/*
 * Filename:  AttributeItem.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "AttributeItem" class.
 */

using UnityEngine;

/*
 * This file extends the Item class specifically for attribute
 * items such as Sunscreen and AloeVera
 *
 * Member Variables:
 */
public class AttributeItem : Item
{
    public override ItemType Collected()
    {
        GameObject itemManagerObject = GameObject.FindWithTag("ItemManager");
        ItemManager itemManagerComp = itemManagerObject.GetComponent<ItemManager>();

        this.isCollected = true;
        Debug.Log(this.type.ToString() + " was collected.");
        itemManagerComp.ActivateItemEffect(this.type);
        return this.type;
    }
}
