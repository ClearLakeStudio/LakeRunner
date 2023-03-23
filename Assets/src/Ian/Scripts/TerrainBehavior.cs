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

    void Awake()
    {
        terrPos = transform.position.x;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}