/*
 * Filename:  BrainBlastBar.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "BrainBlastBar" class.
 */

using System.Collections;
using UnityEngine;

/*
 * This file extends the InventoryItem class specifically for the
 * BrainBlastBar
 *
 * Member Variables:
 */
public class BrainBlastBar : InventoryItem
{
    public override IEnumerator UseEffect()
    {
        // Store the original x velocity of the runner
        // Set runner's velocity to be negative x velocity
        // After a period of time elapses, restore x velocity back to original

        GameObject heroObject = GameObject.FindGameObjectWithTag("Hero");
        Hero heroScript = heroObject.GetComponent<Hero>();

        effectIsActive = true;
        heroScript.movementSpeed *= -1;
        Debug.Log("BrainBlastBar was used");

        float elapsedTime = 0f;
        while (elapsedTime < effectTime) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        heroScript.movementSpeed *= -1;
        effectIsActive = false;
    }

    public void Update()
    {
    }
}
