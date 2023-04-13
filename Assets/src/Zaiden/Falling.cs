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

    public GameObject fallPlatform;

    public Falling(Platform p)
    {
        SetBasePlatform(p);
        GetBasePlatform().CheckValidity();
        if (GetBasePlatform().GetValid())
        {
            Vector2 position = GetBasePlatform().GetPosition();
            SetThisPlatform(Instantiate(fallPlatform, new Vector3(position[0], position[1], 0), Quaternion.identity));
            GetThisPlatform().transform.localScale = new Vector3(GetBasePlatform().GetWidth(), GetBasePlatform().GetHeight(), 1);
        }
    }

    /*
     * will need to add onto/override collision function here to kill enemies when it falls onto them 
     * 
     * 
    */

}
