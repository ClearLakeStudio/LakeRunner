/*
 * Filename: Floating.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines floating platform decorator.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : BaseDecorator
{

    public GameObject floatPlatform;

    public Floating(Platform p)
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
}
