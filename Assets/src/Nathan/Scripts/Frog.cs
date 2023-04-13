using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField]
    private float leapX;
    [SerializeField]
    private float leapY;
    protected override void EnemyAttack()
    {
        if(hero.GetPosition().x < this.GetPosition().x){
            rb.velocity = new Vector2(rb.velocity.x - leapX, rb.velocity.y + leapY);
            sprite.flipX = true;
        }
        if(hero.GetPosition().x > this.GetPosition().x){
            rb.velocity = new Vector2(rb.velocity.x + leapX, rb.velocity.y + leapY);
            sprite.flipX = false;
        }
    }

}
