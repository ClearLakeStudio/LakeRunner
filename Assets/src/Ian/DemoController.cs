/*
    Filename: DemoController.cs
    Developer: Ian King
    Purpose: Control the AI that will play through demo mode
*/

using Facade;
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
            demo.GetNextChunkPos(heroPos);
            demo.FillGap(heroPos);
        }
    }
}

namespace Facade
{
    //Facade/Singleton to incorporate Chunk and PlatformManager classes
    public class DemoFacade
    {
        private PlatformManager pM;
        private ChunkGroup ch;
        static DemoFacade instance;
        private static object locker = new object();

        protected DemoFacade()
        {
            //HOW DO YOU INITIALIZE PLATFORMMANAGER???
            //pM = ;
            ch = new ChunkGroup();
            Debug.Log("Type of ch = " + ch.GetType());
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
            return ch.GetNextChunk(pos).GetPos();
        }

        public Vector2 GetCurChunkPos(Vector2 pos){
            return ch.GetCurChunk(pos).GetPos();
        }

        public void CreatePlatform(Vector2 topLeft, float width){
            Vector3[] loc = {new Vector3(topLeft.x,topLeft.y,0),new Vector3(topLeft.x + width, topLeft.y-1,0)};
            PlatBox pTemp = pM.CheckPlatValidity(loc);
            pM.MakePlat(pTemp,0);
        }

        public void FillGap(Vector2 heroPos){
            ChunkGroup nextChunk = ch.GetNextChunk(heroPos);
            ChunkGroup curChunk = ch.GetCurChunk(heroPos);
            float distX = nextChunk.GetPos().x - curChunk.GetPos().x;
            float distY = nextChunk.GetPos().y - curChunk.GetPos().y;
            
            //Chunks are not meeting, gap must be filled
            if(distX > 0)
            {
                //Player must be built up to next platform
                if(distY > .5)
                {
                    Vector2 topLeftLoc = new Vector2(curChunk.GetPos().x-(curChunk.GetWidth()/2),curChunk.GetPos().y + 0.5f);
                    for(int i = 0; i < distY * 2; i++){
                        CreatePlatform(topLeftLoc,distY/distX);
                        topLeftLoc.x += distX/(distY * 2);
                        topLeftLoc.y += 0.5f;
                    }
                }
                //Player may be built across on same level
                else
                {
                    Vector2 topLeftLoc = new Vector2(curChunk.GetPos().x-(curChunk.GetWidth()/2),curChunk.GetPos().y);
                    CreatePlatform(topLeftLoc,distX);
                }
            }
        }
    }

    public class ChunkGroup
    {
        private List<ChunkGroup> allChunks = new List<ChunkGroup>();
        private GameObject obj;
        private Vector2 pos;
        private float width;
        private float height;

        //Constructor for ChunkGroup from existing terrain
        public ChunkGroup()
        {
            GameObject[] allTerrain;
            ChunkGroup chunk;
            Vector2 dimensions;
            //NEEDS TO BE SORTED BY X-POS
            allTerrain = GameObject.FindGameObjectsWithTag("Terrain");
            for(int i = 0; i < allTerrain.Length; i++)
            {
                Collider2D col = allTerrain[i].GetComponent<Collider2D>();
                if(!col)
                {
                    col = allTerrain[i].transform.GetChild(0).gameObject.GetComponent<Collider2D>();
                }
                dimensions = col.bounds.size;
                chunk = new ChunkGroup(allTerrain[i], allTerrain[i].transform.position, dimensions.x, dimensions.y);
            } 
        }

        //Constructor for a ChunkGroup with member
        public ChunkGroup(GameObject o, Vector2 p, float w, float h){
            obj = o;
            pos = p;
            width = w;
            height = h;
            foreach(ChunkGroup chunk in allChunks)
            {
                if(chunk.GetObj() == o)
                {
                    return;
                }
            }
            allChunks.Add(this);
            Debug.Log("Chunk pos = " + this.GetPos());
        }    

        public ChunkGroup GetNextChunk(Vector2 pos){
            foreach(ChunkGroup chunk in allChunks)
            {
                if(chunk.GetPos().x > pos.x)
                {
                    return chunk;
                }
            }
            return null;
        }

        public ChunkGroup GetCurChunk(Vector2 pos){
            foreach(ChunkGroup chunk in allChunks)
            {
                if(chunk.GetPos(). x > pos.x)
                {
                    return chunk;
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
}