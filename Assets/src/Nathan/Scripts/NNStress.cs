using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNStress : MonoBehaviour
{
    private Hero hero;
    private Rigidbody2D rb;
    private float speed;
    private float waitTime = 5;

    void Start()
    {
        speed = 5;
        hero = gameObject.GetComponent<Hero>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }  

    void FixedUpdate()
    {
        if(Time.time % waitTime==0){
            reset();
        }
    }

    void OnGUI(){
        GUI.Label(new Rect(Screen.width/8, Screen.height/10, 300, 300), "Speed = " + speed.ToString()); 
    }
    void reset(){
        speed = speed + 5;
        gameObject.transform.position = new Vector3(0,0,0);
        rb.velocity = new Vector2(0,0);
        hero.movementSpeed = speed;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Finish"){
            Time.timeScale = 0;
        }
        else if(other.tag == "Respawn")
        {
            reset();
        }
    }
}