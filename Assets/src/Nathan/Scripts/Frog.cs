/*
 * Filename: Frog.cs
 * Developer: Nathan
 * Purpose: Defines the Frog class behavior.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField]
    private float leapX;
    [SerializeField]
    private float leapY;

    //strategy pattern for enemy attacks
    protected override void EnemyAttack()
    {
        if(hero.GetPosition().x < this.GetPosition().x){
            rb.velocity = new Vector2(rb.velocity.x/2 - leapX, rb.velocity.y + leapY);
            sprite.flipX = true;
        }
        if(hero.GetPosition().x > this.GetPosition().x){
            rb.velocity = new Vector2(rb.velocity.x/2 + leapX, rb.velocity.y + leapY);
            sprite.flipX = false;
        }
    }

    //prototype pattern, returns a copy of itself
    public override Object EntityClone(Vector3 position)
    {
        return Instantiate(gameObject, position, Quaternion.identity);
    }
}
