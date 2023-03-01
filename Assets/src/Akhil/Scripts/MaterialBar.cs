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
        Debug.Log("Akhil : Max material resource set");
    }

    public void updateMaterial (int material) {
        matSlider.value = material;
        Debug.Log("Akhil : Material resource update");
    }
}
