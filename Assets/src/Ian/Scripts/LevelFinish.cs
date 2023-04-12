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
    private GameObject gameOver;
    private GameObject platMan;
    private RaycastHit2D[] colls;
    private Vector2 rayLoc;
    private bool platforms = true;

    void Start(){
        rayLoc = new Vector2(transform.position.x + transform.localScale.x/2, transform.position.y);
        platMan = GameObject.Find("UserPlatformManager");
        Transform[] trs = GameObject.Find("Canvas").GetComponentsInChildren<Transform>(true);
        foreach(Transform t in trs){
            if(t.name == "GameOverScreen"){
                gameOver = t.gameObject;
            }
        }
    }

    void FixedUpdate(){
        colls = Physics2D.RaycastAll(rayLoc, new Vector2(0,1));
        foreach(RaycastHit2D hit in colls){
            if(hit.collider.gameObject.tag == "Hero"){
                Time.timeScale = 0;
                platMan.SetActive(false);
                gameOver.SetActive(true);
                platforms = false;
            }
        }
        colls = Physics2D.RaycastAll(rayLoc, new Vector2(0,-1));
        foreach(RaycastHit2D hit in colls){
            if(hit.collider.gameObject.tag == "Hero"){
                Time.timeScale = 0;
                platMan.SetActive(false);
                gameOver.SetActive(true);
                platforms = false;
            }
        }
    }

    public bool CanPlacePlatforms()
    {
        return platforms;
    }
}
