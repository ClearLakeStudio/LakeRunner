/*
 * Filename:  Slippers.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "Slippers" class.
 */

using System.Collections;
using UnityEngine;

/*
 * This file extends the InventoryItem class specifically for the
 * Slippers
 *
 * Member Variables:
 */
public class Slippers : InventoryItem
{
    public override IEnumerator UseEffect()
    {
        GameObject heroObject = GameObject.FindGameObjectWithTag("Hero");
        Hero heroScript = heroObject.GetComponent<Hero>();
        effectIsActive = true;
        heroScript.Jump();
        // detect hero touching ground
        effectIsActive = false;

        Debug.Log("Slippers were used");
        yield return null;
    }
}
