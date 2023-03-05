using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{
    private Vector3 heroPos;
    private GameObject[] allTerrains;
    private float terrPos;

    void OnBecameInvisible(){
        heroPos = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>().position;
        allTerrains = GameObject.FindGameObjectsWithTag("Terrain");
        foreach(GameObject terr in allTerrains){
            terrPos = terr.GetComponent<Transform>().position.x;
            if(terrPos < (heroPos.x - 10)){
                Destroy(terr);
            }
        }
    }
}