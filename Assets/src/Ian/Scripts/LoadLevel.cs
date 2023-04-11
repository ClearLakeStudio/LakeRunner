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

    private ItemManager items;
    private Vector2 randLoc;
    private float chunkTime;
    private float[] itemRate = {1.0f, 1.0f, 1.0f, 1.0f, 1.0f};
    private float randFloat;
    private float terrLength;

    void Start()
    {
        //Create timer to check whether a chunk has been loaded in the past two seconds. This prevents framerate-dependent chunk loading.
        chunkTime = 0.0f;
        items = GameObject.FindWithTag("ItemManager").GetComponent<ItemManager>();
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
            randFloat = UnityEngine.Random.Range(0.0f,10.0f);
            if (lastTerrainLoc.x - heroPos.x < (5 * terrLength))
            {
                Instantiate(terrain, lastTerrainLoc, Quaternion.identity);  
                lastTerrainLoc = new Vector2(lastTerrainLoc.x + terrLength, lastTerrainLoc.y);
                if(randFloat < 1.0f)
                {
                    //New randFloat, if less than certain number - item commonness, repeat for every item with else-if
                    //Adjust each commonness by -0.2 for each time a different item is spawned
                    randFloat = UnityEngine.Random.Range(0.0f,10.0f);
                    items.SpawnItem(null, new Vector2(lastTerrainLoc.x, lastTerrainLoc.y + 1));
                    // if(randFloat < 2.0 - itemRate[0])
                    // {
                    //     SpawnItem(AloeVera, new Vector2(lastTerrainLoc.x + 1, lastTerrainLoc.y));
                    //     for(int i = 1; i <= 5; i++)
                    //     {
                    //         itemRate[i] -= 0.2f;
                    //     }
                    //     itemRate[0] += 0.2f;
                    // }
                    // else if(randFloat < 4.0 - itemRate[1])
                    // {
                    //     SpawnItem(Sunscreen, new Vector2(lastTerrainLoc.x + 1, lastTerrainLoc.y));
                    //     for(int i = 0; i <= 5; i++)
                    //     {
                    //         itemRate[i] -= 0.2f;
                    //     }
                    //     itemRate[1] += 0.4f;
                    // }
                    // else if(randFloat < 5.0 - itemRate[2])
                    // {
                    //     SpawnItem(Sunglasses, new Vector2(lastTerrainLoc.x + 1, lastTerrainLoc.y));
                    //     for(int i = 0; i <= 5; i++)
                    //     {
                    //         itemRate[i] -= 0.2f;
                    //     }
                    //     itemRate[2] += 0.4f;
                    // }
                    // else if(randFloat < 6.0 - itemRate[3])
                    // {
                    //     SpawnItem(BrainBlastBar, new Vector2(lastTerrainLoc.x + 1, lastTerrainLoc.y));
                    //     for(int i = 0; i <= 5; i++)
                    //     {
                    //         itemRate[i] -= 0.2f;
                    //     }
                    //     itemRate[3] += 0.4f;
                    // }
                    // else if(randFloat < 7.0 - itemRate[4])
                    // {
                    //     SpawnItem(Slippers, new Vector2(lastTerrainLoc.x + 1, lastTerrainLoc.y));
                    //     for(int i = 0; i <= 5; i++)
                    //     {
                    //         itemRate[i] -= 0.2f;
                    //     }
                    //     itemRate[4] += 0.4f;
                    // }
                }
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