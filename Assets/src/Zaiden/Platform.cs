/*
 * Filename: Platform.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines the decorator platform class. It is included in all the other types 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector2 position;
    private float width;
    private float height;
    private int currPBM; // stores how much build material the player had when the platform was initialized
    private bool valid;

    public Platform(Vector2[] pos, int currPlayerBuildMaterial)
    {
        if (pos[1].x > pos[0].x)
        {
            width = Mathf.Ceil(pos[1].x - pos[0].x);
        }
        else
        {
            width = Mathf.Floor(pos[1].x - pos[0].x);
        }
        if (pos[1].y > pos[0].y)
        {
            height = Mathf.Ceil(pos[1].y - pos[0].y);
        }
        else
        {
            height = Mathf.Floor(pos[1].y - pos[0].y);
        }
        position[0] = pos[0].x + width / 2;
        position[1] = pos[0].y + height / 2;
        currPBM = currPlayerBuildMaterial;
    }

    public void CheckValidity()
    {
        valid = true;
        if (Mathf.Abs(width * height) < 2) // cannot just make a 1x1 or 2x1 or 1x2 platform
        {
            valid = false;
        }
        if (width * height * 2 > currPBM)  // when I implement the current build material i will set valid=false;
        {
            valid = true;
        }
    }

    public Vector2 GetPosition()
    {
        return position;
    }
    
    public float GetWidth()
    {
        return width;
    }

    public float GetHeight()
    {
        return height;
    }

    public bool GetValid()
    {
        return valid;
    }
}

