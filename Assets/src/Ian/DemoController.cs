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
    private PlatformManager platScript;
    private OverworldManager overScript;
    private Vector2 platLocation;
    private float secCount = 0.0f;
    private float totalCount = 5.0f;
    private bool inDemo = false;

    // Start is called before the first frame update
    void Start()
    {
        overMan = GameObject.FindWithTag("OverworldManager");
        overScript = overMan.GetComponent<OverworldManager>();
        platLocation = new Vector2(0,0);
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
            if(heroPos.x > platLocation.x)
            {
                platLocation = demo.FillGap(heroPos);
            }
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
            pM = GameObject.Find("UserPlatformManager").GetComponent<PlatformManager>();
            ch = ChunkGroup.GetChunkGroup();
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
            pB.floating = true;
            pM.MakePlat(pB,(int)Time.time);
        }

        public Vector2 FillGap(Vector2 heroPos){
            Vector2 topLeftLoc = heroPos; 
            GameObject nextChunk = ch.GetNextChunk(heroPos);
            GameObject curChunk = ch.GetCurChunk(heroPos);

            float distX = 0.0f;
            float distY = 0.0f;
            float curXPos = 0.0f;
            float curYPos = 0.0f;
            float nextXPos = 0.0f;
            float nextYPos = 0.0f;
            float curWidth = 0.0f;
            float curHeight = 0.0f;
            float nextWidth = 0.0f;
            float nextHeight = 0.0f;

            if(nextChunk != null)
            {
                if(nextChunk.name.Contains("TerrainStair") || curChunk.name.Contains("TerrainStair"))
                {
                    return topLeftLoc;
                }
                nextWidth = nextChunk.GetComponent<Collider2D>().bounds.size.x;
                nextHeight = nextChunk.GetComponent<Collider2D>().bounds.size.y;
                curXPos = curChunk.transform.position.x;
                curYPos = curChunk.transform.position.y;
                nextXPos = nextChunk.transform.position.x;
                nextYPos = nextChunk.transform.position.y;
                curWidth = curChunk.GetComponent<Collider2D>().bounds.size.x;
                curHeight = curChunk.GetComponent<Collider2D>().bounds.size.y;
                distX = (nextXPos - nextWidth/2) - (curXPos + curWidth/2);
                distY = (nextYPos + nextHeight/2) - (curYPos + curHeight/2);
            }

            //Chunks are not meeting, gap must be filled
            if(distX > 0.5f)
            {
                //Player must be built up to next platform
                if(distY > .5)
                {
                    topLeftLoc = new Vector2(curXPos+(curWidth/2),curYPos + curHeight/2);
                    for(int i = 0; i <= distY * 2; i++){
                        CreatePlatform(topLeftLoc,distX/(distY * 2));
                        topLeftLoc.x += distX/(distY * 2);
                        topLeftLoc.y += 0.5f;
                    }
                }
                //Player may be built across on same level
                else
                {
                    topLeftLoc = new Vector2(curXPos+curWidth/2.0f,curYPos+curHeight/2);
                    CreatePlatform(topLeftLoc,distX);
                }
            }
            //Player must be built up a level, but not across a gap
            else if (distY > .5)
            {
                distX = (curXPos + curWidth/2) - (curXPos - curWidth/2);
                topLeftLoc = new Vector2((curXPos-curWidth/2),curYPos+curHeight/2);
                for(int i = 0; i < distY * 2; i++)
                {
                    CreatePlatform(topLeftLoc,distX/(distY*2));
                    topLeftLoc.x += distX/(distY * 2);
                    topLeftLoc.y += 0.5f;
                }
            }
            return topLeftLoc;
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
        }    

        public GameObject GetNextChunk(Vector2 pos)
        {
            for(int i = 0; i < allChunks.Count; i++)
            {
                if(allChunks[i] != null)
                {
                    if(allChunks[i].transform.position.x > pos.x)
                    {
                        if(i+1 >= allChunks.Count)
                        {
                            return null;
                        }
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