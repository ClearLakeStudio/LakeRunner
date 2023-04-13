/*
 * Filename: Entity.cs
 * Developer: Nathan
 * Purpose: Defines the Abstract Entity superclass.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    //private Animator anim;
    //private SpriteRenderer sprite;
    private Vector2 gameBoundaryLow;
    private Vector2 gameBoundaryHigh;

    //Awake is called when the object is initialized.
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
        EntityAwake();
        EntitySetBounds();
    }

    //FixedUpdate Is called for every physics frame (framerate independant, timescale dependant)
    void FixedUpdate() 
    {
        EntityFixedUpdate();
        if(rb.simulated && (rb.position.y < gameBoundaryLow.y || rb.position.y > gameBoundaryHigh.y)){
            EntityOutOfBounds();
        }
    }

    //OnTriggerEnter2D is called whenever the object collides with a trigger.
    void OnTriggerEnter2D(Collider2D other)
    {
        EntityCollision(other);
    }


    //Public position getting function. (redundant since component transform is public)
    public Vector2 GetPosition()
    {
        return rb.position;
    }

    //Public position setting function. (redundant since component transform is public)
    public void SetPosition(Vector2 setpos)
    {
        rb.position = setpos;
    }

    protected abstract void EntityAwake();

    protected virtual void EntityCollision(Collider2D other)
    {
        //nothing
    }

    protected virtual void EntityFixedUpdate()
    {
        //nothing
    }

    //if GameManager has boundaries, then get them. Else the boundaries are set here
    protected virtual void EntitySetBounds()
    {
        //gameBoundaryLow = Vector2.negativeInfinity;
        gameBoundaryLow = new Vector2(-100,-100);
        //gameBoundaryHigh = Vector2.positiveInfinity;
        gameBoundaryHigh = new Vector2(10000,100);

        var gm = GameObject.Find("GameManager").GetComponent("GameManager");
        var glb = gm.GetType().GetMethod("GetLowerBoundary");
        var gub = gm.GetType().GetMethod("GetUpperBoundary");
        if((glb != null)&&(gub != null)){
            var lower = glb.Invoke(gm,null);
            var upper = gub.Invoke(gm,null);
            if(lower is Vector2 && upper is Vector2)
            {
                gameBoundaryLow = (Vector2)lower;
                gameBoundaryHigh = (Vector2)upper;
            }
        }   
    }

    protected virtual void EntityOutOfBounds()
    {
        rb.simulated = false;
        Debug.Log("(NN) Entity frozen, out of bounds");
    }
}