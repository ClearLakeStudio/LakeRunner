using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject target;
    public float speed = 2.0f;

    void Awake()
    {
        target = GameObject.Find("Hero");
    }

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        if(target){
            position.y = Mathf.Lerp(this.transform.position.y, target.transform.position.y+1, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, target.transform.position.x+6, interpolation);
        }
        
        this.transform.position = position;  
    }
}
