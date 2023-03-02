using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunGlasses : MonoBehaviour {

    public int SGlassCount = 0;
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
