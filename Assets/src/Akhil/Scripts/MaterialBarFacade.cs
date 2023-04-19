/*
 * FileName: MaterialBarFacade.cs
 * Developer: Akhil
 * Purpose: Instantiating and Showing the Players current material resource on the screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is a Sub-class of the class MaterialBar
public class SetMaxMaterial : MaterialBar
{
    // Function to initiate max Material resource at the begging of the game
    public void SetMaxMat(int maxMat)
    {  
        matSlider.maxValue = maxMat;
        matSlider.value = maxMat;
        Debug.Log("Akhil : Max Material resource set");
    }
}

// This is a Sub-class of the class MaterialBar
public class UpdateMaterial : MaterialBar 
{
    // function to Show the level of Material resource when it changes
    public void UpdateMat(int material) 
    {
        matSlider.value = material;         
        Debug.Log("Akhil : material resource update");
    }
}

/*
* This class is a Facade pattern
* it is the face for the things the player is doing
* This class is used to show the players current Material resource which constantly
* changes due to drawing platforms
*/
public class MaterialBarFacade : MonoBehaviour
{
    // This slider shows the level of Material resource on the screen
    public Slider matSlider; 

    // creating an object of the first sub-class 
    public SetMaxMaterial S;
    // creating an object of the second sub-class 
    public UpdateMaterial U;

    //this initializes the bar with max value when the level begins
    public int maxMat = 100;   
    
    // this func calls the func in the class to set max valuse when it starts
    public void SetMaxMatPlayer()
    {
        S.SetMaxMat(maxMat);
    }

    // this func calls the func in the class to update with the latest available resource
    public void UpdateMaterialPlayer(int material)
    {
        U.UpdateMat(material);
    }   
}
