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
        gameObject.tag = "BrainBlastBar";
    }

    public override IEnumerator UseEffect()
    {
        GameObject heroObj = GameObject.FindGameObjectWithTag("Hero");
        Hero hero = heroObj.GetComponent<Hero>();

        Vector3 scaleChange = new Vector3(-heroObj.transform.localScale.x, heroObj.transform.localScale.y, heroObj.transform.localScale.z);

        effectIsActive = true;
        heroObj.transform.localScale = scaleChange;
        hero.movementSpeed *= -1;
        Debug.Log("BrainBlastBar was used");

        float elapsedTime = 0f;
        while (elapsedTime < effectTime) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        scaleChange = new Vector3(-heroObj.transform.localScale.x, heroObj.transform.localScale.y, heroObj.transform.localScale.z);
        heroObj.transform.localScale = scaleChange;
        hero.movementSpeed *= -1;
        effectIsActive = false;
    }
}
