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
public class Enemy : Entity
{
    [SerializeField]
    protected float attacktimer;

    protected Hero hero = null;

    protected override void EntityAwake()
    {
        gameObject.tag = "DefaultEnemy";
        hero = GameObject.Find("Hero").GetComponent<Hero>();
    }

    //EntityOutOfBounds destroys enemies when called
    protected override void EntityOutOfBounds() 
    {   
        Destroy(gameObject);
        Debug.Log("(NN) Enemy destroyed, out of bounds");
    }

    protected override void EntityCollision(Collider2D other)
    {
        Debug.Log("(NN) Enemy acknowledged collision");
    }

    protected override void EntityFixedUpdate()
    {
        if((Time.fixedTime % attacktimer == 0) && (Time.fixedTime!=0)){
            EnemyAttack();
        }
    }

    //All Enemies have some form of attack action, even if it is to do nothing.
    protected virtual void EnemyAttack()
    {
        //nothing
    }
}