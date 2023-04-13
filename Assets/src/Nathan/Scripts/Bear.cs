/*
 * Filename: Bear.cs
 * Developer: Nathan
 * Purpose: Defines the Bear class behavior.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{
    [SerializeField]
    private float offset;
    [SerializeField]
    private float leapX;

    //strategy pattern for enemy attacks
    protected override void EnemyAttack()
    {
        if(hero.GetPosition().x + offset < this.GetPosition().x){
            rb.velocity = new Vector2(rb.velocity.x/2 - leapX, rb.velocity.y);
            sprite.flipX = true;
        }
        if(hero.GetPosition().x + offset > this.GetPosition().x){
            rb.velocity = new Vector2(rb.velocity.x/2 + leapX, rb.velocity.y);
            sprite.flipX = false;
        }
    }

    //prototype pattern, returns a copy of itself
    public override Object EntityClone(Vector3 position)
    {
        return Instantiate(gameObject, position, Quaternion.identity);
    }
}
