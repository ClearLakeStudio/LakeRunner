/*
 * Filename:  Sunglasses.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "Sunglasses" class.
 */

using UnityEngine;

/*
 * This file extends the InventoryItem class specifically for the
 * Sunglasses
 *
 * Member Variables:
 */
public class Sunglasses : InventoryItem
{
    public override void UseEffect()
    {
        Debug.Log("Sunglasses were used");
    }
}
