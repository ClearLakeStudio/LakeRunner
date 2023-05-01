/*
 * Filename: Floating.cs
 * Developer: Zaiden Espe
 * Purpose: This file defines floating platform decorator.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    // use awake to play sound upon instantiation
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero" || other.tag == "Ambush" || other.tag == "Frog" || other.tag == "AngrySentientCoconut")
        {
            Debug.Log("Floating Collision with entity");
            Rigidbody2D rB = other.GetComponent<Rigidbody2D>();
            int direction = (int)(rB.velocity.x / Mathf.Abs(rB.velocity.x)); // get direction of hero
            rB.AddForce(new Vector2(direction * 0.1f, 0.1f)); // push in x axis direction and up
        }
    }
}
