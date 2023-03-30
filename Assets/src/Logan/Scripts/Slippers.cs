/*
 * Filename:  Slippers.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "Slippers" class.
 */

using UnityEngine;

/*
 * This file extends the InventoryItem class specifically for the
 * Slippers
 *
 * Member Variables:
 */
public class Slippers : InventoryItem
{
    private GameObject heroObject;
    private Hero heroScript;

    public override void UseEffect()
    {
        heroObject = GameObject.FindGameObjectWithTag("Hero");
        heroScript = heroObject.GetComponent<Hero>();
        // need some way to jump the hero up
        // heroScript.jumpForce += 1;
        Debug.Log("Slippers were used");
    }
}
