/*
 * Filename: Frog.cs
 * Developer: Nathan
 * Purpose: Defines the Frog class behavior.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambush : Enemy
{
    public Frog frog;
    public Bear bear;

    private Object newClone;

    protected override void EntityCollision(Collider2D other)
    {
        Debug.Log("Ambush triggered");
        if(other.tag == "Hero"){
            var value = Random.value;
            if(value < 0.5){
                newClone = frog.EntityClone(new Vector3(hero.GetPosition().x + 20, hero.GetPosition().y + 2, 0));
            }
            else{
                newClone = bear.EntityClone(new Vector3(hero.GetPosition().x + 20, hero.GetPosition().y + 2, 0));
            }
            Destroy(gameObject, 0.2f);
        }
    }

    //prototype pattern, returns a copy of itself
    public override Object EntityClone(Vector3 position)
    {
        return Instantiate(gameObject, position, Quaternion.identity);
    }
}
