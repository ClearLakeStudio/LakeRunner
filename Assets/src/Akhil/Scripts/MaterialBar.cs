using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialBar : MonoBehaviour {
    
    public Slider matSlider;
    public int maxMat;

    public void SetMaxMat(int maxMat){
        matSlider.maxValue = maxMat;
        matSlider.value = maxMat;
    }

    public void changeMat (int material) {
        slider.value = material;
    }
}
