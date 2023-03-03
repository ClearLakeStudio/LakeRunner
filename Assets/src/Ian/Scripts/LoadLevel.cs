using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour{
    private float chunkTime;
    public GameObject platform;
    private float platLength;
    private Vector2 lastPlatformLoc;

    void Start() {
        //Create timer to check whether a chunk has been loaded in the past two seconds. This prevents framerate-dependent chunk loading.
        chunkTime = 0.0f;
        platLength = 3;
        lastPlatformLoc = new Vector2(-1,-1);
        for(int i = 0; i < 20; i++){
                lastPlatformLoc = new Vector2(lastPlatformLoc.x + platLength, lastPlatformLoc.y);
                Instantiate(platform, lastPlatformLoc, Quaternion.identity);
            }
    }

    void FixedUpdate() {
        //Subtract the seconds since last fram from the chunk loading timer. If this puts the timer below 0, set it to 0.
        if(chunkTime > 0){
            chunkTime--;
        }
        if(chunkTime < 0){
            chunkTime = 0;
        }
    }

    /*  This function will spawn the first three chunks of the level immediately. It will then check whether 
        the hero has reached the end of a chunk and, if so, spawn another chunk past the current final chunk. */
    public void CreateNewChunk(Vector3 heroPos) {
        if(((heroPos.x % platLength) < .05) && chunkTime == 0){ 
            lastPlatformLoc = new Vector2(lastPlatformLoc.x + platLength, lastPlatformLoc.y);
            Instantiate(platform, lastPlatformLoc, Quaternion.identity);
            Debug.Log("Ian - Load next chunk in level at x-value " + (lastPlatformLoc.x + platLength) +" and y-value " + lastPlatformLoc.y);
            chunkTime = 100;
        }
    }
}