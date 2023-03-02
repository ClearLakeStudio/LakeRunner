using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunSbar : MonoBehaviour
{
    public Slider SunScreenSlider;
    public int maxSunS;        // <<===== init the max material building resource in the player script

    public void SetSunS(int maxSunS){
        SunScreenSlider.maxValue = maxSunS;
        SunScreenSlider.value = maxSunS;            // <<==== call this func in the player script start func 
        Debug.Log("Akhil : Max SunScreen set");
    }

    public void updateSunS (int SunScrnbar) {       // <<==== call this func in material use or update func 
        SunScreenSlider.value = SunScrnbar;
        Debug.Log("Akhil : Sunscreen bar update");
    }
}
