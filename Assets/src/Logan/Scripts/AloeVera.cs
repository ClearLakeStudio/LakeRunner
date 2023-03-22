/*
 * Filename:  AloeVera.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "AloeVera" class.
 */

using UnityEngine;

/*
 * This file implements the effect of the Aloe Vera item
 * which is to increase the player's health
 *
 * Member Variables:
 */
public class AloeVera : AttributeItem
{
    public override void UseEffect()
    {
        Debug.Log("Aloe Vera was used");
    }
}
