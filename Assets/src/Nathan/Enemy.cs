/*
 * Filename: Enemy.cs
 * Developer: Nathan
 * Purpose: Defines the Enemy class including all enemy behaviors.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enemy class relates unity components and the behavior of the enemies
 */
public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        //nothing
    }

    //FixedUpdate should be used for physics based calls, since it is independent of framerate and scaled by time effects.
    void FixedUpdate() 
    {
        //nothing
    }

}