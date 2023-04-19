/*
    Filename: LevelFinish.cs
    Developer: Ian King
    Purpose: Respond to the hero reaching the level finish
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    public ChangeScene changeScene;
    
    private GameObject gameOver;
    private GameObject platMan;
    private LevelDatastore levData;
    private RaycastHit2D[] colls;
    private Vector2 rayLoc;
    private bool platforms;

    void Awake(){
        rayLoc = new Vector2(transform.position.x + transform.localScale.x/2, transform.position.y);
        platMan = GameObject.Find("UserPlatformManager");
        platforms = true;
        levData = new LevelDatastore();
        if(GameObject.Find("Canvas"))
        {
            Transform[] trs = GameObject.Find("Canvas").GetComponentsInChildren<Transform>(true);
            foreach(Transform t in trs)
            {
                if(t.name == "GameOverScreen"){
                    gameOver = t.gameObject;
                }
            }
        }
    }

    void FixedUpdate(){
        colls = Physics2D.RaycastAll(rayLoc, new Vector2(0,1));
        foreach(RaycastHit2D hit in colls){
            if(hit.collider.gameObject.tag == "Hero"){
                platMan.SetActive(false);
                gameOver.GetComponent<ChangeScene>().GameOver();
                gameOver.GetComponent<ChangeScene>().FinishGame = true;
                platforms = false;
                levData.FinishLevel(SceneManager.GetActiveScene().name);
            }
        }
        colls = Physics2D.RaycastAll(rayLoc, new Vector2(0,-1));
        foreach(RaycastHit2D hit in colls){
            if(hit.collider.gameObject.tag == "Hero"){
                platMan.SetActive(false);
                gameOver.GetComponent<ChangeScene>().GameOver();
                gameOver.GetComponent<ChangeScene>().FinishGame = true;
                platforms = false;
                levData.FinishLevel(SceneManager.GetActiveScene().name);
            }
        }
    }

    public bool CanPlacePlatforms()
    {
        return platforms;
    }
}
