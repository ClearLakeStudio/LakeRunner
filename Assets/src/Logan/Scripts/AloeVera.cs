/*
 * Filename:  AloeVera.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "AloeVera" class.
 */

using System.Collections;
using UnityEngine;

/*
 * This file implements the effect of the Aloe Vera item
 * which is to increase the player's health
 *
 * Member Variables:
 */
public class AloeVera : AttributeItem
{
    public float healthIncrease = 25f;

    protected override void Awake()
    {
        this.SetType(ItemType.AloeVera);
        gameObject.tag = "Aloe Vera";
    }

    public override IEnumerator UseEffect()
    {
        float currentHealth;
        Hero hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();

        currentHealth = hero.GetHealth();
        hero.SetHealth(currentHealth + healthIncrease);
        Debug.Log("Aloe Vera was used");
        yield return null;

    }
}
