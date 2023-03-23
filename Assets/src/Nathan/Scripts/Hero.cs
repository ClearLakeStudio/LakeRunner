/*
 * Filename: Hero.cs
 * Developer: Nathan
 * Purpose: Defines the Hero class including the hero's behaviors.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    public float jumpForce;
    public float movementSpeed;

    [SerializeField]
    private float stepJump;
    [SerializeField]
    private float stepTimer;
    [SerializeField]
    private float jumpTimer;

    protected override void EntitySetTag(){
        gameObject.tag = "Hero";
    }

    //FixedUpdate should be used for physics based calls, since it is independent of framerate and scaled by time effects.
    protected override void EntityFixedUpdate() 
    {
        if((Time.fixedTime%jumpTimer==0) && (Time.fixedTime!=0)){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+jumpForce);
        }
        if((Time.fixedTime%stepTimer==0) && (Time.fixedTime!=0)){
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y+stepJump);
        }
    }

    //Collision is called whenever the object collides with a trigger.
    protected override void EntityCollision(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("(NN) Collision with enemy");
        }
    }

    protected override void EntityOutOfBounds() 
    {   
        Time.timeScale = 0;
        Debug.Log("(NN) Time frozen, Hero out of bounds");
    }

}