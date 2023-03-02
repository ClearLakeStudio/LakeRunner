using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunSbar : MonoBehaviour
{
    public Slider SunScreenSlider;

    // init the max material building resource in the player script
    public int maxSunS;        

    // call this func in the player script start func 
    public void SetSunS(int maxSunS)
    {
        SunScreenSlider.maxValue = maxSunS;
        SunScreenSlider.value = maxSunS;           
        Debug.Log("Akhil : Max SunScreen set");
    }

    // call this func in material use or update func 
    public void updateSunS(int sunScrnbar) 
    {       
        SunScreenSlider.value = sunScrnbar;
        Debug.Log("Akhil : Sunscreen bar update");
    }
}
