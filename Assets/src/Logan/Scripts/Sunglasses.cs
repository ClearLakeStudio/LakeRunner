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
    public override IEnumerator UseEffect()
    {
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        Camera heroCamera = cameraObject.GetComponent<Camera>();

        heroCamera.orthographicSize *= 4;
        Debug.Log("Sunglasses were used");

        float elapsedTime = 0f;
        while (elapsedTime < effectTime) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        heroCamera.orthographicSize /= 4;
    }
}
