/*
 * Filename: Hero.cs
 * Developer: Nathan
 * Purpose: Defines the Hero class including the hero's behaviors.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        gameObject.tag = "Hero";
    }

    // Update is called once per frame
    void Update()
    {
        //nothing
    }

    //FixedUpdate should be used for physics based calls, since it is independent of framerate and scaled by time effects.
    void FixedUpdate() 
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Collision with enemy");
        }
    }
}