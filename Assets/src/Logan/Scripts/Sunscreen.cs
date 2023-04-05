/*
 * Filename:  Sunscreen.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "Sunscreen" class.
 */

using System.Collections;
using UnityEngine;

/*
 * This file implements the effect of the Sunscreen item
 * which is to increase the player's sunscreen bar
 *
 * Member Variables:
 */
public class Sunscreen : AttributeItem
{
    public float healthIncrease = 25f;

    public override IEnumerator UseEffect()
    {
        float currentHealth;

        GameObject heroObject = GameObject.FindGameObjectWithTag("Hero");
        Hero heroScript = heroObject.GetComponent<Hero>();

        currentHealth = heroScript.GetHealth();
        heroScript.SetHealth(currentHealth + healthIncrease);
        Debug.Log("Sunscreen was used");
        yield return null;
    }
}
