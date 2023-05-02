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
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Hero" || other.tag == "Ambush" || other.tag == "Frog" || other.tag == "AngrySentientCoconut")
        {
            Debug.Log("Floating Collision with entity");
            Rigidbody2D rB = other.attachedRigidbody;
            rB.velocity = new Vector2(rB.velocity.x * 0.98f, rB.velocity.y+0.5f); // push up
        }
    }
}
