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

    public AudioClip pop;
    AudioSource aud;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("popping", true);
        rb.gravityScale = 0;
        AudioSource.PlayClipAtPoint(pop, transform.position);
        rb.velocity = Vector2.zero;
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }

}
