using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BBar : MonoBehaviour {


    public int BBarCount;
    public Text BBarText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        BBarText.text = BBarCount.ToString();
        
    }
}
