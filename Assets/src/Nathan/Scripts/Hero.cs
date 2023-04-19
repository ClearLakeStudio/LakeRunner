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

    private HealthBar healthbar;
    private SunSbar shieldbar;
    private GameObject gameOver;

    private float health;
    private float shield;
    private bool jumpQueued;
    private float lastX;

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
        else if(newHealth <= 0){
            health = 0;
            healthbar.updateHealth((int)health);
            Debug.Log("(NN) Hero Health Depleated");
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
        else{
            health = newHealth;
        }
        healthbar.updateHealth((int)health);
    }

    public float GetHealth(){
        return health;
    }

    public void SetShield(float newShield)
    {
        if(newShield >= 100 ){
            shield = 100;
        }
        else if(newShield <= 0){
            shield = 0;
            Debug.Log("(NN) Hero Shield Depleated");
        }
        else{
            shield = newShield;
        }
        shieldbar.updateSunS((int)shield);
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
        healthbar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        shieldbar = GameObject.Find("SunScreen").GetComponent<SunSbar>();
        lastX = rb.position.x;

        Transform[] trs = GameObject.Find("Canvas").GetComponentsInChildren<Transform>(true);
        foreach(Transform t in trs){
            if(t.name == "GameOverScreen"){
                gameOver = t.gameObject;
            }
        }
    }

    //FixedUpdate should be used for physics based calls, since it is independent of framerate and scaled by time effects.
    protected override void EntityFixedUpdate() 
    {
        if(jumpQueued || ((Time.fixedTime % jumpTimer == 0) && (Time.fixedTime != 0))){
            jumpQueued = false;
            rb.velocity = new Vector2(rb.velocity.x + movementSpeed/2, rb.velocity.y/2 + jumpForce);
        }
        else if((Time.fixedTime % stepTimer == 0) && (Time.fixedTime != 0)){
            rb.velocity = new Vector2(rb.velocity.x/3 + movementSpeed, rb.velocity.y/2 + stepJump);
            if(rb.position.x < lastX + 1){
                Debug.Log("Sun damage");
                if(shield > 0){
                    SetShield(shield - 5);
                }
                else{
                    SetHealth(health - 5);
                }
            }
            lastX = rb.position.x;
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
        gameOver.SetActive(true);
        Debug.Log("(NN) Time frozen, Hero out of bounds");
    }
}