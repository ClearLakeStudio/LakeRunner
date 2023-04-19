/*
    Filename: LoadLevel.cs
    Developer: Ian King
    Purpose: Load random chunks in Infinite Runner mode
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public GameObject terrain;
    public bool isInfinite;

    private List<GameObject> infTerrPool = new List<GameObject>();
    private List<GameObject> infTerr;
    private ItemManager items;
    private TerrColor nextColor = TerrColor.Green;
    private TerrParent theChild;
    private Vector2 randLoc;
    private Vector2 lastTerrainLoc;
    private float randColor;
    private float randFloat;
    private float randTerr;
    private float terrLength;
    private int curLevel;

    void Start()
    {
        //Create timer to check whether a chunk has been loaded in the past two seconds. This prevents framerate-dependent chunk loading.
        curLevel = SceneManager.GetActiveScene().buildIndex;
        items = GameObject.FindWithTag("ItemManager").GetComponent<ItemManager>();
        terrLength = 5.12f;
        lastTerrainLoc = new Vector2(-1,-1);
        if (isInfinite)
        {
            //infTerr = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            for (int i = 0; i < 10; i++)
            {
                Instantiate(terrain, lastTerrainLoc, Quaternion.identity);
                lastTerrainLoc = new Vector2(lastTerrainLoc.x + terrLength, lastTerrainLoc.y);
            }
            foreach(GameObject nextOne in FindObjectsOfType(typeof(GameObject),true) as GameObject[])
            {
                if(nextOne.tag == "Terrain" && !nextOne.name.Contains("Clone"))
                {
                    infTerrPool.Add(nextOne);
                }
            }
        }
        else
        {
            curLevel = SceneManager.GetActiveScene().buildIndex; 
            switch (curLevel)
            {
                case 1:
                    //Create items here
                    items.SpawnItem(ItemType.Sunscreen, new Vector2(56, 50));
                    items.SpawnItem(ItemType.AloeVera, new Vector2(126, 50));
                    break;
                case 2:
                    items.SpawnItem(ItemType.Sunglasses, new Vector2(15, 5));
                    items.SpawnItem(ItemType.Slippers, new Vector2(61, 5));
                    break;
                case 3:
                    items.SpawnItem(ItemType.BrainBlastBar, new Vector2(30,0));
                    items.SpawnItem(ItemType.Sunscreen, new Vector2(110,0));
                    break;
                case 4:
                    items.SpawnItem(ItemType.Sunglasses, new Vector2(45,5));
                    items.SpawnItem(ItemType.AloeVera, new Vector2(150,10));
                    break;
                case 5:
                    items.SpawnItem(ItemType.Slippers, new Vector2(25,3));
                    items.SpawnItem(ItemType.Sunscreen, new Vector2(75,3));
                    items.SpawnItem(ItemType.BrainBlastBar, new Vector2(95,3));
                    break;
                default:
                    Debug.Log("LoadLevel - " + curLevel + " is Invalid level index.");
                    break;
            }
        }
    }

    /*  This function will spawn the first three chunks of the level immediately. It will then check whether 
        the hero has reached the end of a chunk and, if so, spawn another chunk past the current final chunk. */
    public void CreateNewChunk(Vector3 heroPos)
    {
        if (isInfinite)
        {
            randFloat = UnityEngine.Random.Range(0.0f,10.0f);
            randTerr = UnityEngine.Random.Range(0.0f,4.0f);
            randColor = UnityEngine.Random.Range(0.0f,10.0f);
            if(randColor < 0.5f)
            {
                nextColor = TerrColor.Green;
            }
            else if(randColor < 1.0f)
            {
                nextColor = TerrColor.Sand;
            }
            else if(randColor < 1.5f)
            {
                nextColor = TerrColor.Stone;
            }
            if (lastTerrainLoc.x - heroPos.x < (10 * terrLength))
            {
                if(randTerr <= 2.0f)
                {
                    //Set to parent chunk
                    foreach(GameObject nextTerr in infTerrPool)
                    {
                        if(nextTerr.name.Contains("Terrain") && nextTerr.name.Contains(nextColor.ToString()))
                        {
                            terrain = nextTerr;
                            break;
                        }
                    }
                    theChild = new TerrParent(terrain,nextColor);
                }
                else if (randTerr <= 2.5f)
                {
                    //Set to high chunk
                    foreach(GameObject nextTerr in infTerrPool)
                    {
                        if(nextTerr.name.Contains("High") && nextTerr.name.Contains(nextColor.ToString()))
                        {
                            terrain = nextTerr;
                            lastTerrainLoc.y += 3;
                            break;
                        }
                    }
                    theChild = new TerrHigh(terrain,nextColor);
                }
                else if (randTerr <= 3.0f)
                {
                    //Set to stair chunk
                    foreach(GameObject nextTerr in infTerrPool)
                    {
                        if(nextTerr.name.Contains("Stair") && nextTerr.name.Contains(nextColor.ToString()))
                        {
                            terrain = nextTerr;
                            lastTerrainLoc.y += 2.5f;
                            break;
                        }
                    }
                    theChild = new TerrStair(terrain,nextColor);
                }
                else
                {
                    //Create no chunk, adjust lastTerrLoc
                    lastTerrainLoc.x += terrLength;
                    return;
                }
                theChild.SetPos(lastTerrainLoc);
                if(theChild.CreateChunk() != 0)
                {
                    Debug.Log("LoadLevel - Chunk creation error.");
                    return;
                }
                lastTerrainLoc.x += terrLength;
                if(randFloat < 1.0f)
                {
                    randFloat = UnityEngine.Random.Range(0.0f,10.0f);
                    items.SpawnItem(null, new Vector2(lastTerrainLoc.x, lastTerrainLoc.y + 5));
                }
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

public enum TerrColor
{
    Undefined   = -1,
    Green   = 0,
    Sand    = 1,
    Stone   = 2,
}

public class TerrParent
{
    private GameObject terr;
    public Vector2 terrPos;
    private TerrColor color;

    public TerrParent(GameObject nextTerr,TerrColor c=TerrColor.Green)
    {
        terr = nextTerr;
        color = c;
    }

    public virtual void SetPos(Vector2 newPos)
    {
        terrPos = newPos;
    }

    //Should return -1 for error, 0 for success
    public virtual int CreateChunk()
    {
        GameObject thisTerr = UnityEngine.Object.Instantiate(terr,terrPos,Quaternion.identity);
        if(thisTerr)
        {
            thisTerr.GetComponent<TerrainBehavior>().enabled = true;
            return 0;
        }
        else
            return -1;
    }

    // public void SetPos(Vector2 newPos)
    // {
    //     terrPos = newPos;
    // }

    // //Should return -1 for error, 0 for success
    // public int CreateChunk()
    // {
    //     GameObject thisTerr = UnityEngine.Object.Instantiate(terr,terrPos,Quaternion.identity);
    //     if(thisTerr)
    //     {
    //         thisTerr.GetComponent<TerrainBehavior>().enabled = true;
    //         return 0;
    //     }
    //     else
    //         return -1;
    // }
}

public class TerrHigh : TerrParent
{
    private GameObject terr;
    public Vector2 terrPos;
    private TerrColor color;

    public TerrHigh(GameObject nextTerr,TerrColor c=TerrColor.Green) : base(nextTerr,c)
    {
        terr = nextTerr;
        color = c;
    }

    public override void SetPos(Vector2 newPos)
    {
        terrPos = new Vector2(newPos.x,newPos.y - 1);
    }

    public override int CreateChunk()
    {
        GameObject thisTerr = UnityEngine.Object.Instantiate(terr,terrPos,Quaternion.identity);
        if(thisTerr)
        {
            thisTerr.GetComponent<TerrainBehavior>().enabled = true;
            return 0;
        }
        else
            return -1;
    }

    // public void SetPos(Vector2 newPos)
    // {
    //     terrPos = new Vector2(newPos.x,newPos.y - 1);
    // }

    // public int CreateChunk()
    // {
    //     GameObject thisTerr = UnityEngine.Object.Instantiate(terr,terrPos,Quaternion.identity);
    //     if(thisTerr)
    //     {
    //         thisTerr.GetComponent<TerrainBehavior>().enabled = true;
    //         return 0;
    //     }
    //     else
    //         return -1;
    // }
}

public class TerrStair : TerrParent
{
    private GameObject terr;
    public Vector2 terrPos;
    private TerrColor color;

    public TerrStair(GameObject nextTerr,TerrColor c=TerrColor.Green) : base(nextTerr,c)
    {
        terr = nextTerr;
        color = c;
    }

    public override void SetPos(Vector2 newPos)
    {
        terrPos = new Vector2(newPos.x,newPos.y - 0.75f);
    }

    public override int CreateChunk()
    {
        GameObject thisTerr = UnityEngine.Object.Instantiate(terr,terrPos,Quaternion.identity);
        if(thisTerr)
        {
            thisTerr.GetComponent<TerrainBehavior>().enabled = true;
            return 0;
        }
        else
            return -1;
    }

    // public void SetPos(Vector2 newPos)
    // {
    //     terrPos = new Vector2(newPos.x,newPos.y - 0.75f);
    // }

    // public int CreateChunk()
    // {
    //     GameObject thisTerr = UnityEngine.Object.Instantiate(terr,terrPos,Quaternion.identity);
    //     if(thisTerr)
    //     {
    //         thisTerr.GetComponent<TerrainBehavior>().enabled = true;
    //         return 0;
    //     }
    //     else
    //         return -1;
    // }
}