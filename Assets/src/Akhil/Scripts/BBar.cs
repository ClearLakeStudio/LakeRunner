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


// attach this file to the gamemanager file