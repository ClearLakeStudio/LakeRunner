/*
 * Filename:  InventoryItem.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "InventoryItem" class.
 */

using UnityEngine;

/*
 * This class extends the Item class specifically for
 * items that will be held in the player's
 * inventory such as the BrainBlastBar
 *
 * Member Variables:
 */
public class InventoryItem: Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero") {
            if (ItemManager.instance.UpdateInventory(this.type)) {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            this.Collected();
            ItemManager.instance.ReturnPooledObject(gameObject);
            }
        }
    }
}
