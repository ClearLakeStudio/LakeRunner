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
    private float terrPos;
    private GameObject heroObj;
    private Vector2 heroPos;

    void Awake()
    {
        heroObj = GameObject.FindWithTag("Hero");
        terrPos = transform.position.x;
    }

    void Update()
    {
        heroPos = heroObj.transform.position;
        if(transform.position.x < (heroPos.x - 40.0f))
        {
            Destroy(gameObject);
        }
    }
}