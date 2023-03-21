using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D col){
        Debug.Log("Colliding with object.");
        if(col.gameObject.tag == "Hero"){
            Time.timeScale = 0;
            Debug.Log("Level Finished");
        }
    }
}
