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
    public void MakePlat(Vector3[] pos, int time)
    {
        Debug.Log("Zaiden: making platform.");
        // two lines of code below will work for click and drag
        float xPos = (pos[1].x + pos[0].x) / 2;
        float yPos = (pos[1].y + pos[0].y) / 2;
        GameObject newPlat = Instantiate(Platform, new Vector3(xPos, yPos, 0), Quaternion.identity);
        newPlat.transform.localScale = new Vector3((pos[1].x - pos[0].x), (pos[1].y - pos[0].y), 1);
    }
}
