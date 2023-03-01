using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialBar : MonoBehaviour {

    public Slider matSlider;
    public int maxMat;        // <<===== init the max material building resource in the player script

    public void SetMaxMat(int maxMat){
        matSlider.maxValue = maxMat;
        matSlider.value = maxMat;            // <<==== call this func in the player script start func 
        Debug.Log("Akhil : Max material resource set");
    }

    public void updateMaterial (int material) {       // <<==== call this func in material use or update func 
        matSlider.value = material;
        Debug.Log("Akhil : Material resource update");
    }
}
