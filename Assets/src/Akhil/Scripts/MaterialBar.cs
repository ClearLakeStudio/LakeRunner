using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialBar : MonoBehaviour 
{

    // <<===== init the max material building resource in the player script
    
    public Slider matSlider;
    public int maxMat;   

    // <<==== call this func in the player script start func  
    public void SetMaxMat(int maxMat)
    {
        matSlider.maxValue = maxMat;
        matSlider.value = maxMat;            
        Debug.Log("Akhil : Max material resource set");
    }

    // <<==== call this func in material use or update func 
    public void updateMaterial (int material) 
    {     
        matSlider.value = material;
        Debug.Log("Akhil : Material resource update");
    }
}
