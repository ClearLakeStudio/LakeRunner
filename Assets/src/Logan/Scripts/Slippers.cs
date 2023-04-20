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
    private static bool effectIsActive = false;

    public new static bool GetEffectIsActive()
    {
        return effectIsActive;
    }

    protected override void Awake()
    {
        this.SetType(ItemType.Slippers);
    }

    public override IEnumerator UseEffect()
    {
        Hero hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();

        effectIsActive = true;
        hero.Jump();
        Debug.Log("Slippers were used");

        float elapsedTime = 0f;
        while (elapsedTime < effectTime) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        effectIsActive = false;
    }
}
