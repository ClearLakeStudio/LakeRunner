/*
 * Filename: Enemy.cs
 * Developer: Nathan
 * Purpose: Defines the Enemy superclass, deciding how often enemies attack asnd setting up referances.
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
    public float attacktimer;

    protected Hero hero = null;

    protected override void EntityAwake()
    {
        gameObject.tag = "Enemy";
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
            Debug.Log("Enemy at:" + GetPosition());
        }
    }

    //Strategy pattern for enemy attacks
    protected virtual void EnemyAttack()
    {
        //nothing
    }
}