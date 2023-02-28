using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour{
    private float chunkTime;
    public GameObject platform;

    void Start() {
        //Create timer to check whether a chunk has been loaded in the past two seconds. This prevents framerate-dependent chunk loading.
        chunkTime = 0.0f;
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
    void CreateNewChunk(Vector3 heroPos) {
        if(heroPos.x < 10){
            Instantiate(platform,new Vector2(heroPos.x, heroPos.y), Quaternion.identity);
            Instantiate(platform,new Vector2(heroPos.x + 25, heroPos.y), Quaternion.identity);
            Instantiate(platform,new Vector2(heroPos.x + 50, heroPos.y), Quaternion.identity);
            Debug.Log("Ian - Load first three chunks at " + heroPos.x + ", " + (heroPos.x + 25) + ", and " + (heroPos.x + 50));
        } else if(((heroPos.x % 25) < .1) && chunkTime == 0){ 
            Instantiate(platform,new Vector2(heroPos.x + 25, heroPos.y), Quaternion.identity);
            Debug.Log("Ian - Load next chunk in level at x-value " + (heroPos.x + 25) +" and y-value " + heroPos.y);
            chunkTime = 100;
        }
    }
}