/*
    Filename: LevelFinish.cs
    Developer: Ian King
    Purpose: Respond to the hero reaching the level finish
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    private RaycastHit2D[] colls;
    private Vector2 rayLoc;

    void Start(){
        rayLoc = new Vector2(transform.position.x + transform.localScale.x/2, transform.position.y);
    }

    void FixedUpdate(){
        colls = Physics2D.RaycastAll(rayLoc, new Vector2(0,1));
        foreach(RaycastHit2D hit in colls){
            if(hit.collider.gameObject.tag == "Hero"){
                Time.timeScale = 0;
                Debug.Log("Level Finished");
            }
        }
        colls = Physics2D.RaycastAll(rayLoc, new Vector2(0,-1));
        foreach(RaycastHit2D hit in colls){
            if(hit.collider.gameObject.tag == "Hero"){
                Time.timeScale = 0;
                Debug.Log("Level Finished");
            }
        }
    }
}
