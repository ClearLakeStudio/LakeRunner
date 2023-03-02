/*
 * FileName: GameManager.cs
 * Developer: Zaiden Espe
 * Purpose: To load in the initial gameobjects and update objects as the game runs. Also detect mouse clicking.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // store references to gameObjects to initialize
    public GameObject platManager;

    // store references to scripts
    PlatformManager pM;

    // store moues data value
    Vector3 mousePos; // stores position of mouse at critical points
    Vector3[] boxCorners;
    bool mouseHold; // whether or not mouse is currently being held

    // Start is called before the first frame update
    void Start()
    {
        boxCorners = new Vector3[2];
        mouseHold = false;
        pM = platManager.GetComponent<PlatformManager>(); // assign script reference

        // instantiate game objects here
    }

    // Update is called once per frame
    void Update()
    {
        // need to write mouse detection function
        if (Input.GetMouseButton(0) && mouseHold == false) // beginning hold
        {
            mouseHold = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = Camera.main.nearClipPlane;
            Debug.Log(mousePos.x + " " + mousePos.y + " " + mousePos.z + ".");
            boxCorners[0] = new Vector3(mousePos.x, mousePos.y, mousePos.z);
        }
        if (!Input.GetMouseButton(0) && mouseHold == true) // releasing hold
        {
            mouseHold = false;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = Camera.main.nearClipPlane;
            boxCorners[1] = mousePos;
            if (pM.CheckPlatValidity(boxCorners))
            {
                pM.MakePlat(boxCorners, 0); 
            }
        }
    }
}
