/*
    Filename: IKStressCont.cs
    Developer: Ian King
    Purpose: Define behavior of terrain (such as deletion upon exit from screen space)
*/

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
    private int frameUsed;

    void Awake()
    {
        hero = GameObject.Find("Hero");
        frameUsed = 0;
    }

    void Update()
    {
        frameUsed = 0;
    }

    void OnBecameInvisible()
    {
        //heroPos = hero.GetComponent<Transform>().position;
        if (gameObject != null)
        {
            terrPos = GetComponent<Transform>().position.x;
            if (terrPos < (heroPos.x - 10) && frameUsed == 0)
            {
                Destroy(gameObject);
                frameUsed = 1;
            }
        }
    }
}