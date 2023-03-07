using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKStressCont : MonoBehaviour
{
    private GameObject chunkMan;
    public float interval;
    private float timer;
    private float fps;
    private Vector3 heroPos;
    private float frameCount;
    private float timeCount;
    private float lastFramerate;
    private float refreshTime;
    private int fpsDrop;
    private int terrNum;

    // Start is called before the first frame update
    void Start()
    {
        chunkMan = GameObject.Find("ChunkManager");
        timer = 0;
        heroPos = new Vector3(0,0,0);
        frameCount = 0;
        timeCount = 0.0f;
        lastFramerate = 0.0f;
        refreshTime = 0.5f;
        fpsDrop = 0;
        terrNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCount < refreshTime)
        {
            timeCount += Time.deltaTime;
            frameCount++;
        }
        else
        {
            lastFramerate = (float)frameCount/timeCount;
            frameCount = 0;
            timeCount = 0.0f;
        }
        fps = lastFramerate;
        if(fps < 300 && timer == 0 && fpsDrop <= 5)
            fpsDrop++;
        if(fpsDrop >= 5)
            Time.timeScale = 0;
        timer += Time.deltaTime;
        if(timer >= interval){
            chunkMan.GetComponent<LoadLevel>().SendMessage("CreateRandomChunk",heroPos);
            terrNum++;
            timer = 0;
        }
    }

    void OnGUI(){
        GUI.Label(new Rect(Screen.width/8, Screen.height / 10, 300, 300), "FRAME RATE = " + fps.ToString()); 
        GUI.Label(new Rect(Screen.width - (Screen.width/4), Screen.height / 10, 300, 300), "INTERVAL = " + interval);
        GUI.Label(new Rect(Screen.width - (Screen.width/4), Screen.height - (Screen.height / 10), 300, 300), "DROPS BELOW 300 fps = " + fpsDrop);
        GUI.Label(new Rect(Screen.width/8, Screen.height - (Screen.height / 10), 300, 300), "Terrain Pieces = " + terrNum);
    }
}