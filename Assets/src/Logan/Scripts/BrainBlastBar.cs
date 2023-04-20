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
    private static bool effectIsActive = false;

    public new static bool GetEffectIsActive()
    {
        return effectIsActive;
    }

    protected override void Awake()
    {
        this.SetType(ItemType.BrainBlastBar);
    }

    public override IEnumerator UseEffect()
    {
        Hero hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();

        effectIsActive = true;
        hero.movementSpeed *= -1;
        Debug.Log("BrainBlastBar was used");

        float elapsedTime = 0f;
        while (elapsedTime < effectTime) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        hero.movementSpeed *= -1;
        effectIsActive = false;
    }
}
