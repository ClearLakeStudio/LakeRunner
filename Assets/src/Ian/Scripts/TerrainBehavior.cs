using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{
    private Vector3 heroPos;
    private GameObject hero;
    private GameObject[] allTerrains;
    private float terrPos;

    void Awake(){
        hero = GameObject.Find("Hero");
    }

    void OnBecameInvisible(){
        heroPos = hero.GetComponent<Transform>().position;
        if (gameObject != null) {
            terrPos = GetComponent<Transform>().position.x;
            if(terrPos < (heroPos.x - 10)){
                Destroy(gameObject);
            }
        }
    }
}