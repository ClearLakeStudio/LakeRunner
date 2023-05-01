/*
 * Filename: Falling.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines the falling decorator. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // use awake to play sound upon instantiation
    public void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("popping", true);
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        anim.Play("poppingbubble");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
