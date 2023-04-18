using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMaxHlth : HealthBar
{
    public void SetMaxHealth(int maxHealth)
    {  
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        Debug.Log("Akhil : Max health set");
    }
}
public class updateHlth : HealthBar 
{
    public void updateHealth (int health) 
    {
        healthSlider.value = health;         
        Debug.Log("Akhil : health update");
    }
}

public class HealthBarFacade : MonoBehaviour
{
    public Slider healthSlider; 

    public SetMaxHlth S;
    public updateHlth U;

    public int maxHealth = 100;   
    
    public void SetMaxHealthPlayer()
    {
        S.SetMaxHealth(maxHealth);
    }

    public void updateHealthPlayer(int updatedhealth)
    {
        U.updateHealth(updatedhealth);
    }
    
}
