using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunGlasses : MonoBehaviour {

    public int SGlassCount = 0;     //  <<------ attach this script to the player and then attach the text corresponding to this script to there
    public Text SGlassText;

    void Update() {
        SGlassText.text = SGlassCount.ToString();
    }
    public void pickUpSGlass() {       // <<---- call these func in the item collectible script 
        SGlassCount++;
    }
    public void useSGlass () {          
        SGlassCount--;
    }

}
