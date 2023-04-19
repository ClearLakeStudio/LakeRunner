using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// **** Facade Design pattern ****
public class HealthBar : MonoBehaviour 
{
    public Slider healthSlider; 
    public int maxHealth = 100;   

    public void SetMaxHealth(int maxHealth)
    {  
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        Debug.Log("Akhil : Max health set");
    }

    public void updateHealth (int health) 
    {
        healthSlider.value = health;         
        Debug.Log("Akhil : health update");
    }

}
