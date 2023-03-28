/*
    Filename: DemoController.cs
    Developer: Ian King
    Purpose: Control the AI that will play through demo mode
*/

using Facade;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoController : MonoBehaviour
{
    /*  Needed:
    *   - Find current and next 3? terrain
    *   - Compare distance from top right edge of one terrain COLLIDER to top left edge of next
    *   - If x-distance > 1?
    *       - If y-distance > 1? then draw stairs
    *       - Else draw platform from top right corner of platform to left edge of next, minimum height
    *   - Item interactions as needed
    *
    *   Checking distances:
    *   - Iterate through terrain pieces one at a time based on relation to player location
    *       - Store last terrain location
    *       - If player moves onto last terrain and no next terrain is found: 
    *           - Make sure finish line is not behind player
    *           - Begin drawing certain length platforms until next terrain is found or player passes finish
    */
    
    private GameObject platMan;
    private GameObject overMan;
    private GameObject hero;
    private PlatformManager platScript;
    private OverworldManager overScript;
    private float secCount = 0.0f;
    private float totalCount = 5.0f;
    private bool inDemo = false;

    // Start is called before the first frame update
    void Start()
    {
        overMan = GameObject.FindWithTag("OverworldManager");
        overScript = overMan.GetComponent<OverworldManager>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            secCount = 0;
        }
        if(!inDemo)
        {
            secCount += Time.deltaTime;
            if(secCount >= totalCount)
            {
                inDemo = true;
                SceneManager.LoadScene(overScript.GetHeroLevel());
                platMan = GameObject.Find("UserPlatformManager");
                //platScript = platMan.GetComponent<PlatformManager>();
            }
        }
        else
        {
            //Demo functions go here
            if(Input.anyKey)
            {
                inDemo = false;
                SceneManager.LoadScene("Overworld");
            }

            Vector2 heroPos = GameObject.FindWithTag("Hero").transform.position;
            DemoFacade demo = DemoFacade.GetDemoFacade();
            demo.FillGap(heroPos);
        }
    }
}

namespace Facade
{
    //Facade/Singleton to incorporate Chunk and PlatformManager classes
    public class DemoFacade
    {
        private static object locker = new object();
        private PlatformManager pM;
        private ChunkGroup ch;
        private PlatBox pB;
        static DemoFacade instance;

        protected DemoFacade()
        {
            //HOW DO YOU INITIALIZE PLATFORMMANAGER???
            //pM = ;
            ch = ChunkGroup.GetChunkGroup();
            pB = new PlatBox{
                posX = 0,
                posY = 0,
                width = 0,
                height = 0,
                valid = true,
                floating = true
            };
        }

        public static DemoFacade GetDemoFacade()
        {
            if(instance == null)
            {
                lock(locker)
                {
                    if(instance == null)
                    {
                        instance = new DemoFacade();
                    }
                }
            }
            return instance;
        }

        public Vector2 GetNextChunkPos(Vector2 pos){
            return ch.GetNextChunk(pos).transform.position;
        }

        public Vector2 GetCurChunkPos(Vector2 pos){
            return ch.GetCurChunk(pos).transform.position;
        }

        public void CreatePlatform(Vector2 topLeft, float width){
            Vector3[] loc = {new Vector3(topLeft.x,topLeft.y,0),new Vector3(topLeft.x + width, topLeft.y-1,0)};
            pB = pM.CheckPlatValidity(loc);
            pM.MakePlat(pB,0);
        }

        public void FillGap(Vector2 heroPos){
            GameObject nextChunk = ch.GetNextChunk(heroPos);
            GameObject curChunk = ch.GetCurChunk(heroPos);
            float distX = nextChunk.transform.position.x - curChunk.transform.position.x;
            float distY = nextChunk.transform.position.y - curChunk.transform.position.y;
            Debug.Log("nextChunk = " + nextChunk + " and curChunk = " + curChunk);
            
            //Chunks are not meeting, gap must be filled
            if(distX > 0)
            {
                float curXPos = curChunk.transform.position.x;
                float curYPos = curChunk.transform.position.y;
                float curWidth = curChunk.GetComponent<Collider2D>().bounds.size.x;
                float curHeight = curChunk.GetComponent<Collider2D>().bounds.size.y;
                //Player must be built up to next platform
                if(distY > .5)
                {
                    Vector2 topLeftLoc = new Vector2(curXPos-(curWidth/2),curYPos + 0.5f);
                    for(int i = 0; i < distY * 2; i++){
                        Debug.Log("Demo making platform");
                        CreatePlatform(topLeftLoc,distY/distX);
                        topLeftLoc.x += distX/(distY * 2);
                        topLeftLoc.y += 0.5f;
                    }
                }
                //Player may be built across on same level
                else
                {
                    Vector2 topLeftLoc = new Vector2(curXPos-(curWidth/2),curYPos);
                    CreatePlatform(topLeftLoc,distX);
                }
            }
        }
    }

    public class ChunkGroup
    {
        private List<GameObject> allChunks = new List<GameObject>();
        private GameObject obj;
        private Vector2 pos;
        private float width;
        private float height;

        static ChunkGroup instance;
        private static object locker = new object();

        public static ChunkGroup GetChunkGroup()
        {
            if(instance == null)
            {
                lock(locker)
                {
                    if(instance == null)
                    {
                        instance = new ChunkGroup();
                    }
                }
            }
            return instance;
        }

        //Constructor for ChunkGroup from existing terrain
        protected ChunkGroup()
        {
            GameObject[] allTerrain;
            //NEEDS TO BE SORTED BY X-POS
            allTerrain = GameObject.FindGameObjectsWithTag("Terrain");
            Array.Sort(allTerrain, new xPosSort());
            for(int i = 0; i < allTerrain.Length; i++)
            {
                AddChunk(allTerrain[i]);
            } 
        }

        //Constructor for a ChunkGroup with member
        public void AddChunk(GameObject o){
            Collider2D col = o.GetComponent<Collider2D>();
            if(!col)
            {
                col = o.transform.GetChild(0).gameObject.GetComponent<Collider2D>();
            }
            Vector2 dimensions = col.bounds.size;
            
            obj = o;
            pos = o.transform.position;
            width = dimensions.x;
            height = dimensions.y;
            foreach(GameObject chunk in allChunks)
            {
                if(chunk.name == o.name)
                {
                    return;
                }
            }
            allChunks.Add(o);
            Debug.Log("Chunk pos = " + o.transform.position);
        }    

        public GameObject GetNextChunk(Vector2 pos)
        {
            for(int i = 0; i < allChunks.Count; i++)
            {
                if(allChunks[i] != null)
                {
                    if(allChunks[i].transform.position.x > pos.x)
                    {
                        return allChunks[i + 1];
                    }
                }
            }
            return null;
        }

        public GameObject GetCurChunk(Vector2 pos)
        {
            foreach(GameObject chunk in allChunks)
            {
                if(chunk != null){
                    if(chunk.transform.position.x > pos.x)
                    {
                        return chunk;
                    }
                }
            }
            return null;
        }

        public void SpawnChunk(ChunkGroup ch)
        {
            MonoBehaviour.Instantiate(ch.GetObj(), ch.GetPos(), Quaternion.identity);
        }

        public Vector2 GetPos()
        {
            return pos;
        }

        public float GetWidth()
        {
            return width;
        }

        public float GetHeight()
        {
            return height;
        }

        public GameObject GetObj()
        {
            return obj;
        }
    }

    class xPosSort : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            return (new CaseInsensitiveComparer()).Compare(((GameObject)obj1).transform.position.x, ((GameObject)obj2).transform.position.x);
        }
    }
}