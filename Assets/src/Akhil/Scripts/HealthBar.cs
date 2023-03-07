using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider healthSlider;
    // <===== init the max health in the player script
    public int maxHealth = 100;   

    // <<==== call this func in the player script start func  
    public void SetMaxHealth(int maxHealth)
    {  
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        Debug.Log("Akhil : Max health set");
    }

    // <<==== call this func in damage or update func  
    public void updateHealth (int health) 
    {
        healthSlider.value = health;         
        Debug.Log("Akhil : health update");
    }

}
