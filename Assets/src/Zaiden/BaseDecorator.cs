/*
 * Filename: BaseDecorator.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines the basic abstract decorator class. Includes necessary data and methods for all decorators.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDecorator : MonoBehaviour
{
    private GameObject thisPlatform;
    private Platform basePlatform;

    public GameObject GetThisPlatform()
    {
        return thisPlatform;
    }

    public void SetThisPlatform(GameObject p)
    {
        thisPlatform = p;
    }

    public Platform GetBasePlatform()
    {
        return basePlatform;
    }

    public void SetBasePlatform(Platform p)
    {
        basePlatform = p;
    }
    /*
     * will include this function in the future
    void OnColliderEnter2D(Collider other)
    {
        if (other.tag == "Hero" || other.tag == )
        {
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.1f)); // push the hero upwards when in contact with bubble
            // i need to add that it pushes the player in the x direction that matches their velocity here aswell
        }
    }
    */
}
