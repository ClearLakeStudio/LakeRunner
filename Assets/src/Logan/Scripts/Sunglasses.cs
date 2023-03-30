/*
 * Filename:  Sunglasses.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "Sunglasses" class.
 */

using UnityEngine;

/*
 * This file extends the InventoryItem class specifically for the
 * Sunglasses
 *
 * Member Variables:
 */
public class Sunglasses : InventoryItem
{
    private GameObject cameraObject;
    private Camera heroCamera;

    public override void UseEffect()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        heroCamera = cameraObject.GetComponent<Camera>();

        heroCamera.orthographicSize *= 4;
        Debug.Log("Sunglasses were used");
    }
}
