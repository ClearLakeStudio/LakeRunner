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
    protected override void Awake()
    {
        this.SetType(ItemType.Sunglasses);
    }

    public override IEnumerator UseEffect()
    {
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        Camera heroCamera = cameraObject.GetComponent<Camera>();

        effectIsActive = true;
        heroCamera.orthographicSize *= 4;
        Debug.Log("Sunglasses were used");

        float elapsedTime = 0f;
        while (elapsedTime < effectTime) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        heroCamera.orthographicSize /= 4;
        effectIsActive = false;
    }
}
