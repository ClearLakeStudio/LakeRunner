/*
 * FileName: HealthBar.cs
 * Developer: Akhil
 * Purpose: Instantiating and Showing the Players current health on the screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is a Sub-class of the class Healthbar
public class SetMaxHlth : HealthBar
{
    // Function to initiate max health at the begging of the game
    public void SetMaxHealth(int maxHealth)
    {  
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        Debug.Log("Akhil : Max health set");
    }
}

// This is a Sub-class of the class Healthbar
public class updateHlth : HealthBar 
{
    // function to Show the level of health when it changes
    public void UpdateHealth(int health) 
    {
        healthSlider.value = health;         
        Debug.Log("Akhil : health update");
    }
}

/*
* This class is a Facade pattern
* it is the face for the things happening to the player
* This class is used to show the players current health which is constantly affected by something
*/
public class HealthBarFacade : MonoBehaviour
{
    // This slider is the level of health on the screen
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
        U.UpdateHealth(updatedhealth);
    }   
}
