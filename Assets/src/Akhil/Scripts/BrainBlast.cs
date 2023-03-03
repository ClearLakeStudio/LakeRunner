using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  <<------ attach this script to the player and then attach the text corresponding to this script to there
public class BrainBlast : MonoBehaviour 
{

    public int BBarCount = 0;
    public Text BBarText;

    void Update() 
    {
        BBarText.text = BBarCount.ToString();
        Debug.Log("Akhil : Brain Blast bar update");
    }
    
    // <<---- call these func in the item collectible script 
    public void pickUpBBar() 
    {
        BBarCount++;
        Debug.Log("Akhil : Brain Blast bar pickup");
    }

    public void useBBar() 
    {          
        BBarCount--;
        Debug.Log("Akhil : Brain blast bar used");
    }
}