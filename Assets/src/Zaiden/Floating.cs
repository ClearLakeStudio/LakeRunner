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
    Platform basePlatForm;

    public GameObject floatPlatform;

    public Floating(Platform p)
    {
        basePlatForm = p;
        basePlatForm.CheckValidity();
        if (basePlatForm.GetValid())
        {
            Vector2 position = basePlatForm.GetPosition();
            SetThisPlatform(Instantiate(floatPlatform, new Vector3(position[0], position[1], 0), Quaternion.identity));
            GetThisPlatform().transform.localScale = new Vector3(basePlatForm.GetWidth(), basePlatForm.GetHeight(), 1);
        }
    }
}
