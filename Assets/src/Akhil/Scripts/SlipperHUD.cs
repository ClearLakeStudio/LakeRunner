using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlipperHUD : MonoBehaviour
{
   //  <<------ attach this script to the player and then attach the text corresponding to this script to there 
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
