/*
 * Filename: Preview.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines the preview platform decorator. Uses singleton pattern to ensure only one preview ever exists
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : BaseDecorator
{
    private static Preview instance = null;
    Platform basePlatForm;

    public GameObject floatPlatform;

    private Preview(Platform p)
    {
        SetBasePlatform(p);
        GetBasePlatform().CheckValidity();
        if (GetBasePlatform().GetValid())
        {
            Vector2 position = GetBasePlatform().GetPosition();
            SetThisPlatform(Instantiate(floatPlatform, new Vector3(position[0], position[1], 0), Quaternion.identity));
            GetThisPlatform().transform.localScale = new Vector3(GetBasePlatform().GetWidth(), GetBasePlatform().GetHeight(), 1);
        }
    }

    public static Preview Instance(Platform p)
    {
        if (instance == null)
        {
            instance = new Preview(p);
        }
        return instance;
    }

    public void UpdateBox(Platform p) // takes in a new platform and updates the PV platform's location
    {
        SetBasePlatform(p);
        GetBasePlatform().CheckValidity();
        if (GetBasePlatform().GetValid())
        {
            Vector2 position = GetBasePlatform().GetPosition();
            GetThisPlatform().transform.position = new Vector3(position[0], position[1], 0);
            GetThisPlatform().transform.localScale = new Vector3(GetBasePlatform().GetWidth(), GetBasePlatform().GetHeight(), 1);
        }
    }

    /*
     * this is where i will override the collision function that works on falling and floating
     * will just have it return without doing anything so nothing as affected
     * 
     * 
    */

}
