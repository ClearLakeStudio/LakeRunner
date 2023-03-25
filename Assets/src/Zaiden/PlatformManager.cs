/*
 * Filename: PlatformManager.cs
 * Developer: Zaiden Espe
 * Purpose: To store a management class for the player-drawn platforms
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

// this class is to handle platform creation and call the actual instances of the platforms
public class PlatformManager : MonoBehaviour
{
    public GameObject Platform;
    public GameObject pvPlatform;

    GameObject pvPlat;

    public void Start()
    {
        pvPlat = null;
    }

    // checks the validity of platform coordinates. returns true if valid placement, false otherwise
    public PlatBox CheckPlatValidity(Vector3[] pos)
    {
        /*
        Debug.Log("Zaiden: checking platform validity");
        Debug.Log("Zaiden: coordinate1: (" + pos[0].x + ", " + pos[0].y + ").");
        Debug.Log("Zaiden: coordinate2: (" + pos[1].x + ", " + pos[1].y + ").");
        */
        float width;
        float height;
        //float xAnch = Mathf.Ceil(pos[0].x+100f) - 100f; // so negatives do not become an issue, the floor always affects in one way
        //float yAnch = Mathf.Floor(pos[0].y + 100f) - 100f;
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
        } else
        {
            height = Mathf.Floor(pos[1].y - pos[0].y);
        }
        float xPos = pos[0].x + width/2;
        float yPos = pos[0].y + height/2;

        bool valid = true;
        if (Mathf.Abs(width * height) < 2) // cannot just make a 1x1 or 2x1 or 1x2 platform
        {
            valid = false;
        }

        PlatBox p;
        p.posX = xPos;
        p.posY = yPos;
        p.width = width;
        p.height = height;
        p.valid = valid;
        p.floating = false;

        return p;
    }

    // instantiate and then place the platform at its position in the game
    // in the future will also call draw functions
    // may just be moved into specific platform classes though
    public void MakePlat(PlatBox p, int time)
    {
        DestroyPreVPlat();      
        Debug.Log("Zaiden: making platform.");
        GameObject newPlat = Instantiate(Platform, new Vector3(p.posX, p.posY, 0), Quaternion.identity);
        newPlat.transform.localScale = new Vector3(p.width, p.height, 1);
    }

    // used to make the previewplatform
    public void MakePreVPlat(PlatBox p)
    {
        DestroyPreVPlat();
        pvPlat = Instantiate(pvPlatform, new Vector3(p.posX, p.posY, 0), Quaternion.identity) as GameObject;
        pvPlat.transform.localScale = new Vector3(p.width, p.height, 1);
    }

    // used to destroy preview platform as necessary
    public void DestroyPreVPlat()
    {
        if (pvPlat != null)
        {
            Destroy(pvPlat);
        }
    }
}
