/*
 * Filename: Falling.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines the falling decorator. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : BaseDecorator
{
    Platform basePlatForm;

    public GameObject fallPlatform;

    public Falling(Platform p)
    {
        basePlatForm = p;
        basePlatForm.CheckValidity();
        if (basePlatForm.GetValid())
        {
            Vector2 position = basePlatForm.GetPosition();
            SetThisPlatform(Instantiate(fallPlatform, new Vector3(position[0], position[1], 0), Quaternion.identity));
            GetThisPlatform().transform.localScale = new Vector3(basePlatForm.GetWidth(), basePlatForm.GetHeight(), 1);
        }
    }

}
