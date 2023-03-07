using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKStressCont : MonoBehaviour
{
    private GameObject chunkMan;
    public float interval;
    private float timer;
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
        timer += Time.deltaTime;
        if(timer >= interval){
            chunkMan.GetComponent<LoadLevel>().SendMessage("CreateRandomChunk",heroPos);
            timer = 0;
        }
    }
}
