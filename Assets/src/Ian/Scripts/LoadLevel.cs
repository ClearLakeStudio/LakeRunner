/*
    Filename: LoadLevel.cs
    Developer: Ian King
    Purpose: Load random chunks in Infinite Runner mode
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public GameObject terrain;
    public Vector2 lastTerrainLoc;
    public bool isInfinite;

    private GameObject[] allTerrains;
    private Vector2 randLoc;
    private float terrLength;
    private float chunkTime;

    void Start()
    {
        //Create timer to check whether a chunk has been loaded in the past two seconds. This prevents framerate-dependent chunk loading.
        chunkTime = 0.0f;
        terrLength = 5.12f;
        lastTerrainLoc = new Vector2(-1,-1);
        if (isInfinite)
        {
            for (int i = 0; i < 10; i++)
            {
                    Instantiate(terrain, lastTerrainLoc, Quaternion.identity);
                    lastTerrainLoc = new Vector2(lastTerrainLoc.x + terrLength, lastTerrainLoc.y);
            }
        }
    }

    void Update()
    {
        //Subtract the seconds since last frame from the chunk loading timer. If this puts the timer below 0, set it to 0.
        if (chunkTime > 0)
        {
            chunkTime--;
        }
        if (chunkTime < 0)
        {
            chunkTime = 0;
        }
    }

    /*  This function will spawn the first three chunks of the level immediately. It will then check whether 
        the hero has reached the end of a chunk and, if so, spawn another chunk past the current final chunk. */
    public void CreateNewChunk(Vector3 heroPos)
    {
        if (isInfinite)
        {
            if (lastTerrainLoc.x - heroPos.x < (5 * terrLength))
            {
                Instantiate(terrain, lastTerrainLoc, Quaternion.identity);  
                lastTerrainLoc = new Vector2(lastTerrainLoc.x + terrLength, lastTerrainLoc.y);
                chunkTime = 5;
            }
        }
    }

    public void CreateRandomChunk(Vector3 heroPos)
    {
        System.Random rnd = new System.Random();
        int randX = rnd.Next(-10, 10);
        int randY = rnd.Next(-5,5);
        randLoc = new Vector2(heroPos.x + randX - 0.5f, heroPos.y + randY - 0.5f);
        Instantiate(terrain,randLoc,Quaternion.identity);
    }
}