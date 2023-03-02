using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slippers : MonoBehaviour
{
    
    public int SlprCount = 0;
    public Text SlprText;

    void Update() {
        SlprText.text = SlprCount.ToString();
    }
    public void pickUpSlpr() {       // <<---- call these func in the item collectible script 
        SlprCount++;
    }
    public void useSlpr () {          
        SlprCount--;
    }

}
