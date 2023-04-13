/*
 * FileName: GameManager.cs
 * Developer: Zaiden Espe
 * Purpose: To load in the initial gameobjects and update objects as the game runs. Also detect mouse clicking.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlatBox // stores basic platform creation info
{
    public float posX;
    public float posY;
    public float width;
    public float height;
    public bool valid;
    public bool floating;
}

public class GameManager : MonoBehaviour
{
    // store references to gameObjects to initialize
    public GameObject platManager;
    public GameObject chunkManager;
    public GameObject hero;

    // store references to scripts
    PlatformManager pM;
    LoadLevel cM;

    // store moues data value
    Vector3 mousePos; // stores position of mouse at critical points
    Vector3[] boxCorners;
    bool mouseHold; // whether or not mouse is currently being held
    float lastClickTime, doubleClickTime = 0.2f; // double click info
    bool doubleClick; // store whether a double click occured when placing platforms

    // store hero position value
    Vector3 heroPos;

    // Start is called before the first frame update
    void Start()
    {
        boxCorners = new Vector3[2];
        mouseHold = false;
        doubleClick = false;

        heroPos = new Vector3();

        pM = platManager.GetComponent<PlatformManager>(); // assign script reference in platformmanager.cs
        cM = chunkManager.GetComponent<LoadLevel>(); // assign script reference in loadlevel.cs


    }

    // Update is called once per frame
    void Update()
    {
        // mouse detection
        ReceivePlatformInput();

        // update hero position
        heroPos = hero.transform.position;

        // call chunk creation function
        cM.CreateNewChunk(new Vector3(heroPos.x, -4.25f, heroPos.z));
    }

    void ReceivePlatformInput()
    {
        if (Input.GetMouseButton(0) && mouseHold == false) // beginning hold
        {
            mouseHold = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = Camera.main.nearClipPlane;
            boxCorners[0] = new Vector3(mousePos.x, mousePos.y, mousePos.z);
            if ((Time.time - lastClickTime) <= doubleClickTime)
            {
                doubleClick = true;
            }
            else
            {
                doubleClick = false;
            }
            lastClickTime = Time.time;


        }
        if (!Input.GetMouseButton(0) && mouseHold == true) // releasing hold
        {
            mouseHold = false;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = Camera.main.nearClipPlane;
            boxCorners[1] = mousePos;
            PlatBox p = pM.CheckPlatValidity(boxCorners);
            // Platform p = new Platform(boxCorners, currBuildMaterial);
            // get rid of if p.valid = true
            // then delete Preview object
            if (p.valid == true)
            {
                if (!doubleClick) // dont make falling
                {
                    // BaseDecorator temp = new Floating(p);
                    p.floating = true;
                    pM.MakePlat(p);
                }
                else // make falling
                {
                    // BaseDecorator temp = new Floating(p);
                    p.floating = false;
                    pM.MakePlat(p);
                }
            }
            else
            {
                pM.DestroyPreVPlat();
            }
        }
        if (Input.GetMouseButton(0) && mouseHold == true) // get where mouse hold currently is to make preview box
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = Camera.main.nearClipPlane;
            boxCorners[1] = new Vector3(mousePos.x, mousePos.y, mousePos.z);
            PlatBox p = pM.CheckPlatValidity(boxCorners);
            // Platform p = new Platform(boxCorners, currBuildMaterial);
            // do not check if valid, Preview will do it itself
            // destroy PV Plat no matter what, do before creating preview platform
            if (p.valid == true)
            {
                // if (temp == NULL){
                //  BaseDecorator pV = Instance(p);
                // } else {
                //  pv.update(p);
                // }
                pM.MakePreVPlat(p); // creates preview platform
            }
            else
            {
                pM.DestroyPreVPlat();
            }
        }
    }
}
