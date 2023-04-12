using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNextLevelButton : DisableNextLevelButton
{
  public override void DisplayNextLevelButton (){
    //UnityEngine.UI.Button button = GameObject.Find("NextLevel").GetComponent<UnityEngine.UI.Button>();
    NextLevelButton.SetActive(true);
    Debug.Log("button enabled");
  }
}
