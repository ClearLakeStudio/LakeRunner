/*
 * FileName: SunSbar.cs
 * Developer: Akhil
 * Purpose: Instantiating and Showing the Players SunScreen levels on the screen
 * which is there to protect his health from preventing sun damage
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * this class has the functions to 
 * initialize and update the amount of Sun Screen player is having
*/
public class SunSbar : MonoBehaviour
{
    // this slider will show his sun screen levels
    public Slider SunScreenSlider;

    // initial value of the players sun screen
    public int maxSunS = 100;        

    // function to set the max value when scene loads
    public void SetSunS(int maxSunS)
    {
        SunScreenSlider.maxValue = maxSunS;
        SunScreenSlider.value = maxSunS;           
        Debug.Log("Akhil : Max SunScreen set");
    }

    // func to update the value and change the level on the bar 
    public void UpdateSunS(int sunScrnbar) 
    {       
        SunScreenSlider.value = sunScrnbar;
        Debug.Log("Akhil : Sunscreen bar update");
    }
}
