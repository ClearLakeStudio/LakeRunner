using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour{
    private float chunkTime;

    //Create timer to check whether a chunk has been loaded in the past two seconds. This prevents framerate-dependent chunk loading.
    void Start(){
        chunkTime = 0.0f;
    }

    //Subtract the seconds since last fram from the chunk loading timer. If this puts the timer below 0, set it to 0.
    void Update(){
        if(chunkTime > 0){
            chunkTime -= Time.deltaTime;
        }
        if(chunkTime < 0){
            chunkTime = 0;
        }
    }

    /*  This function will spawn the first three chunks of the level immediately. It will then check whether 
        the hero has reached the end of a chunk and, if so, spawn another chunk past the current final chunk. */
    void CreateNewChunk(Vector3 heroPos) {
        if(heroPos.x < 10){
            Debug.Log("Ian - Load first three chunks at " + heroPos.x + ", " + (heroPos.x + 25) + ", and " + (heroPos.x + 50));
        } else if(((heroPos.x) % 25) < .1 && chunkTime){ 
            Debug.Log("Ian - Load next chunk in level at x-value " + heroPos.x +" and y-value " + heroPos.y);
            chunkTime = 2;
        }
    }
}