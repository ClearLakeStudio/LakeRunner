/*
 * Filename: Falling.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines the falling decorator. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public void OnColliderEnter2D(Collider other)
    {
        if (other.tag == "Hero" || other.tag == "Ambush" || other.tag == "Frog" || other.tag == "AngrySentientCoconut")
        {
            Rigidbody2D rB = other.GetComponent<Rigidbody2D>();
            int direction = (int)(rB.velocity.x / Mathf.Abs(rB.velocity.x)); // get direction of hero
            rB.AddForce(new Vector2(direction * 0.1f, 0.1f)); // push in x axis direction and up
        }
    }

}
