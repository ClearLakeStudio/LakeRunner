using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SScreenBar : MonoBehaviour {


    public Slider ssSlider;
    private GameManager gm;
    public int sScreen;

    // Start is called before the first frame update
    public void Start() {
        if(gm == null){
    //        gm = GameManager.Instance;
        }
        sSlider = GetComponent<Slider>();

        sScreen = 100;
        sSlider.sScreen = sScreen;
        sSlider.value = sScreen;
        
    }

    public void SetSScreen(int sScreen){
        sSlider.maxValue = sScreen;
        sSlider.value = sScreen;
    }

    /*   public void pickUpSS(){
        sSlider.value += 1;
        if(sSlider.used){
            sSlider.value -= 1;
        }
    }  */

}
