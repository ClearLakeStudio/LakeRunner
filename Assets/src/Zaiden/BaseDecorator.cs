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

    public GameObject GetThisPlatform()
    {
        return thisPlatform;
    }

    public void SetThisPlatform(GameObject p)
    {
        thisPlatform = p;
    }
}
