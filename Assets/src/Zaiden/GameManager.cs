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
    public GameObject chunkManager;
    public GameObject hero;
    public GameObject healthBar;
    //public GameObject matBar;
    //public GameObject sunscreenBar;
    //public GameObject autoPlat; // reference to automatically-made platforms (need a better naming convention for later)

    // store references to scripts
    PlatformManager pM;
    LoadLevel cM;
    HealthBar hB;
    //MaterialBar mB;
    //SunSbar ssB; // would like to have SunScreen edited to include bar at the end

    // store moues data value
    Vector3 mousePos; // stores position of mouse at critical points
    Vector3[] boxCorners;
    bool mouseHold; // whether or not mouse is currently being held

    // store hero position value
    Vector3 heroPos;

    // Start is called before the first frame update
    void Start()
    {
        boxCorners = new Vector3[2];
        mouseHold = false;

        heroPos = new Vector3();

        pM = platManager.GetComponent<PlatformManager>(); // assign script reference in platformmanager.cs
        cM = chunkManager.GetComponent<LoadLevel>(); // assign script reference in loadlevel.cs
        hB = healthBar.GetComponent<HealthBar>(); // assign script reference in HealthBar.cs
        //mB = matBar.GetComponent<MaterialBar>(); // assign script reference in MatBar.cs
        //ssB = sunscreenBar.GetComponent<SunSbar>(); // assign script reference in SunScreen.cs

        // initial calls, will be removed later and moved to hero script
        hB.SetMaxHealth(10);
        //mB.SetMaxMat(100);
        //ssB.SetSunS(10);

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

        // update hero position
        heroPos = hero.transform.position;

        // call chunk creation function
        cM.CreateNewChunk(new Vector3(heroPos.x, -4.25f, heroPos.z));
        

    }
}
