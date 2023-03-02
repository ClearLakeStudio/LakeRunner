using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  <<------ attach this script to the player and then attach the text corresponding to this script to there
public class SunGlasses : MonoBehaviour 
{

    public int SGlassCount = 0;     
    public Text SGlassText;

    void Update() 
    {
        SGlassText.text = SGlassCount.ToString();
        Debug.Log("Akhil : Sunglass bar update");
    }

    // <<---- call these func in the item collectible script 
    public void pickUpSGlass() 
    {       
        SGlassCount++;
        Debug.Log("Akhil : Sunglasses Pickup");
    }
    
    public void useSGlass() 
    {          
        SGlassCount--;
        Debug.Log("Akhil : Sunglass Use");
    }

}
