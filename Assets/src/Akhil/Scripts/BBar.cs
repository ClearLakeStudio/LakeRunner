using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BBar : MonoBehaviour {


    public int BBarCount;
    public Text BBarText;

    void Update() {
        BBarText.text = BBarCount.ToString();
        
    }
}


// attach this script to the gamemanager script and then attach the textObject to this script