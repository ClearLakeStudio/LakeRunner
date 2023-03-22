/*
 * Filename:  Sunscreen.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "Sunscreen" class.
 */

using UnityEngine;

/*
 * This file implements the effect of the Sunscreen item
 * which is to increase the player's sunscreen bar
 *
 * Member Variables:
 */
public class Sunscreen : AttributeItem
{
    public override void UseEffect()
    {
        Debug.Log("Sunscreen was used");
    }
}
