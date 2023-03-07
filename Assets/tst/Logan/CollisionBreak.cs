using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBreak : MonoBehaviour
{
    void Update()
    {
    }

    //void OnCollisionEnter2D(Collision2D collision)
    void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
    }
}
