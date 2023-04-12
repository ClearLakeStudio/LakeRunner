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
    public GameObject gameManager;


    private float health;
    private float shield;
    private bool jumpQueued;

    [SerializeField]
    private float stepJump;
    [SerializeField]
    private float stepTimer;
    [SerializeField]
    private float jumpTimer;

    // public functions
    public void Jump()
    {
        jumpQueued = true;
    }
    public void SetHealth(float newHealth)
    {
        if(newHealth >= 100 ){
            health = 100;
        }
        else if(newHealth < 0){
            health = 0;
            Debug.Log("Zero Health");
        }
        else{
            health = newHealth;
        }
    }

    public float GetHealth(){
        return health;
    }

    public void SetShield(float newShield)
    {
        if(newShield >= 100 ){
            shield = 100;
        }
        else if(newShield < 0){
            shield = 0;
            Debug.Log("Zero Health");
        }
        else{
            shield = newShield;
        }
    }

    public float GetShield(){
        return shield;
    }

    //protected/private functions
    protected override void EntityAwake()
    {
        gameObject.tag = "Hero";
        health = 100;
        shield = 100;
        gameManager = GameObject.Find("GameManager");
    }

    //FixedUpdate should be used for physics based calls, since it is independent of framerate and scaled by time effects.
    protected override void EntityFixedUpdate() 
    {
        if(jumpQueued || ((Time.fixedTime%jumpTimer==0) && (Time.fixedTime!=0))){
            jumpQueued = false;
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
        gameManager.GetComponent<ChangeScene>().gameOver();
        Debug.Log("(NN) Time frozen, Hero out of bounds");
    }
}