/*
 * FileName: HealthBar.cs
 * Developer: Akhil
 * Purpose: Instantiating and Showing the Players current health on the screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* This class is a Facade pattern
* it is the face for the things happening to the player
* This class is used to show the players current health which is constantly affected by something
*/
public class HealthBar : MonoBehaviour 
{
    // This slider is the level of health on the screen
    public Slider healthSlider; 
    public int maxHealth = 100;   

    // Function to initiate max health at the begging of the game
    public void SetMaxHealth(int maxHealth)
    {  
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        Debug.Log("Akhil : Max health set");
    }

    // function to Show the level of health when it changes
    public void UpdateHealth(int health) 
    {
        healthSlider.value = health;         
        Debug.Log("Akhil : health update");
    }
}
