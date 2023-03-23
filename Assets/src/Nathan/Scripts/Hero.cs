/*
 * Filename: Hero.cs
 * Developer: Nathan
 * Purpose: Defines the Hero class including the hero's behaviors.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float jumpForce;
    public float movementSpeed;

    private Rigidbody2D rb;
    //private Animator anim;
    //private SpriteRenderer sprite;

    [SerializeField]
    private float stepJump;
    [SerializeField]
    private float stepTimer;
    [SerializeField]
    private float jumpTimer;
    [SerializeField]
    private float limHighY;
    [SerializeField]
    private float limLowY;

    //Awake is called when the object is initialized.
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
        gameObject.tag = "Hero";
    }

    //Start is called before the first call of Update
    void Start()
    {
        //nothing
    }

    // Update is called once per frame
    void Update()
    {
        //nothing
    }

    //FixedUpdate should be used for physics based calls, since it is independent of framerate and scaled by time effects.
    void FixedUpdate() 
    {
        if((Time.fixedTime%jumpTimer==0) && (Time.fixedTime!=0)){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+jumpForce);
        }
        if((Time.fixedTime%stepTimer==0) && (Time.fixedTime!=0)){
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y+stepJump);
        }
        if(rb.simulated && (rb.position.y < limLowY) || (rb.position.y > limHighY)){
            rb.simulated = false;
            Debug.Log("(NN) Hero frozen, out of bounds");
        }
    }

    //OnTriggerEnter2D is called whenever the object collides with a trigger.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("(NN) Collision with enemy");
            other.GetComponent<Enemy>().Collide();
        }
    }

    //Public position setting function. Since component transform is public.
    public Vector2 GetPosition(){
        return rb.position;
    }

    //Public position setting function. (redundant since component transform is public)
    public void SetPosition(Vector2 setpos){
        rb.position = setpos;
    }
}