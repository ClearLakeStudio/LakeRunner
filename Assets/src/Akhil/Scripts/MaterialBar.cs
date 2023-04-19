/*
 * FileName: MaterialBar.cs
 * Developer: Akhil
 * Purpose: Instantiating and Showing the Players Material resource on the screen
 * which is used for drawing platforms for the player to move
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * this class has the functions to 
 * initialize and update the amount of resources player is having
 * and returns the current value to the gamemanager for calculations of the usage
*/
public class MaterialBar : MonoBehaviour 
{   
    // this slider will show his resource material levels
    public Slider matSlider;

    // initial value of the players resource material
    public int maxMat = 100;   
    // this variable will return the current level
    public int currentMat = 0;
 
    // function to set the max value when scene loads
    public void SetMaxMat(int maxMat)
    {
        matSlider.maxValue = maxMat;
        matSlider.value = maxMat;            
        Debug.Log("Akhil : Max material resource set");
    }

    // func to update the value and change the level on the bar 
    public void UpdateMaterial(int material) 
    {     
        matSlider.value = material;
        currentMat = material;
        Debug.Log("Akhil : Material resource update");
    }

    // func to tell the gamemanager about the resource material available
    public int RetCurrentMat() 
    {
        return currentMat;
    }
}


