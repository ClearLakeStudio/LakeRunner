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

    protected override void EntitySetTag()
    {
        gameObject.tag = "Enemy";
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

}