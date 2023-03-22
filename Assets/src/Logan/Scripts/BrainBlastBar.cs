/*
 * Filename:  BrainBlastBar.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "BrainBlastBar" class.
 */

using UnityEngine;

/*
 * This file extends the InventoryItem class specifically for the
 * BrainBlastBar
 *
 * Member Variables:
 */
public class BrainBlastBar : InventoryItem
{
    public override void UseEffect()
    {
        // Store the original x velocity of the runner
        // Set runner's velocity to be negative x velocity
        // After a period of time elapses, restore x velocity back to original
        Debug.Log("BrainBlastBar was used");
    }
}
