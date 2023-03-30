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
    public float effectTime = 5;
    private GameObject heroObject;
    private Hero heroScript;

    public override void UseEffect()
    {
        // Store the original x velocity of the runner
        // Set runner's velocity to be negative x velocity
        // After a period of time elapses, restore x velocity back to original

        heroObject = GameObject.FindGameObjectWithTag("Hero");
        heroScript = heroObject.GetComponent<Hero>();
        heroScript.movementSpeed *= -1;
        Debug.Log("BrainBlastBar was used");
    }

    public void Update()
    {
    }
}
