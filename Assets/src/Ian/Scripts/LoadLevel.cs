using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour{
    private float chunkTime;
    public GameObject platform;
    private bool firstSpawned;
    private int offset;

    void Start() {
        //Create timer to check whether a chunk has been loaded in the past two seconds. This prevents framerate-dependent chunk loading.
        chunkTime = 0.0f;
        firstSpawned = false;
        offset = 2;
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
        if(heroPos.x < .1 && !firstSpawned){
            for(int i = 0; i < 20; i++){
                Instantiate(platform,new Vector2(heroPos.x + i * offset, heroPos.y),Quaternion.identity);
            }
            firstSpawned = true;
        } else if(((heroPos.x % offset) < .1) && chunkTime == 0){ 
            Instantiate(platform,new Vector2(heroPos.x + 19*offset, heroPos.y), Quaternion.identity);
            Debug.Log("Ian - Load next chunk in level at x-value " + (heroPos.x + 19*offset) +" and y-value " + heroPos.y);
            chunkTime = 100;
        }
    }
}