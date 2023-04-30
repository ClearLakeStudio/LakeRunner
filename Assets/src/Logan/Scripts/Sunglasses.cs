/*
 * Filename:  Sunglasses.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "Sunglasses" class.
 */

using System.Collections;
using UnityEngine;

/*
 * This file extends the InventoryItem class specifically for the
 * Sunglasses
 *
 * Member Variables:
 */
public class Sunglasses : InventoryItem
{
    private static bool effectIsActive = false;

    public new static bool GetEffectIsActive()
    {
        return effectIsActive;
    }

    protected override void Awake()
    {
        this.SetType(ItemType.Sunglasses);
        gameObject.tag = "Sunglasses";
    }

    public override IEnumerator UseEffect()
    {
        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        effectIsActive = true;
        camera.orthographicSize *= 4;
        Debug.Log("Sunglasses were used");

        float elapsedTime = 0f;
        while (elapsedTime < effectTime) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        camera.orthographicSize /= 4;
        effectIsActive = false;
    }
}
