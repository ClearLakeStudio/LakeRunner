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
    public float healthIncrease = 25f;
    private GameObject heroObject;
    private Hero heroScript;

    public override void UseEffect()
    {
        float currentHealth;

        heroObject = GameObject.FindGameObjectWithTag("Hero");
        heroScript = heroObject.GetComponent<Hero>();

        currentHealth = heroScript.GetHealth();
        heroScript.SetHealth(currentHealth + healthIncrease);
        Debug.Log("Sunscreen was used");
    }
}
