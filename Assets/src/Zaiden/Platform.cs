/*
 * Filename: Platform.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines the abstract platform class, will be abstract, not for MVP tho
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum platType
    {
        floating = 0,
        falling = 1,
        bouncy = 2,
    }

    private Vector3 position;
    private int time;
    private platType pType;

    public GameObject platform;


    // checks the validity of platform coordinates. returns true if valid placement, false otherwise
    public bool CheckPlatValidity(Vector3[] pos)
    {
        Debug.Log("Zaiden: checking platform validity");
        Debug.Log("Zaiden: coordinate1: (" + pos[0].x + ", " + pos[0].y + ").");
        Debug.Log("Zaiden: coordinate2: (" + pos[1].x + ", " + pos[1].y + ").");
        return true;
    }

    // instantiate and then place the platform at its position in the game
    // in the future will also call draw functions
    // may just be moved into specific platform classes though
    public void MakePlat(Vector3[] pos, platType type, int time)
    {
        Debug.Log("Zaiden: making platform.");
        //pType = 0; // will make constructor at some point
        //time = 0; // ''
        float xPos = (pos[0].x + pos[1].x)/2;
        float yPos = (pos[0].y - pos[1].y)/2;
        Instantiate(platform, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}
