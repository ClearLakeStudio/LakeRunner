using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  <<------ attach this script to the player and then attach the text corresponding to this script to there 
public class SlipperHUD : MonoBehaviour
{
   
    public int SlprCount = 0;
    public Text SlprText;

    void Update() 
    {
        SlprText.text = SlprCount.ToString();
        Debug.Log("Akhil : Slipper bar update");
    }

    // <<---- call these func in the item collectible script 
    public void pickUpSlpr() 
    {      
        SlprCount++;
        Debug.Log("Akhil : Slipper pickup");
    }

    public void useSlpr() 
    {          
        SlprCount--;
        Debug.Log("Akhil : Slipper use");
    }

}
