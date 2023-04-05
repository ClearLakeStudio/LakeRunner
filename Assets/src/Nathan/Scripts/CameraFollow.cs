using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject target;
    public float Speed = 2.0f;
    public float x_offset = 6;
    public float y_offset = 1;


    void Awake()
    {
        target = GameObject.Find("Hero");
    }

    void Update()
    {
        float interpolation = Speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        if(target){
            position.x = Mathf.Lerp(this.transform.position.x, target.transform.position.x+x_offset, interpolation);
            position.y = Mathf.Lerp(this.transform.position.y, target.transform.position.y+y_offset, interpolation);
        }
        
        this.transform.position = position;  
    }
}
