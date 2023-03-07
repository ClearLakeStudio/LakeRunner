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

    // Start is called before the first frame update
    void Start()
    {
        chunkMan = GameObject.Find("ChunkManager");
        timer = 0;
        heroPos = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        fps = 1.0f / Time.deltaTime;
        timer += Time.deltaTime;
        if(timer >= interval){
            chunkMan.GetComponent<LoadLevel>().SendMessage("CreateRandomChunk",heroPos);
            timer = 0;
        }
    }

    void OnGUI(){
        GUI.Label(new Rect(Screen.width/8, Screen.height / 10, 300, 300), "FRAME RATE = " + fps.ToString()); 
        GUI.Label(new Rect(Screen.width - (Screen.width/4), Screen.height / 10, 300, 300), "INTERVAL = " + interval);
    }
}
