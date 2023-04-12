using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : DisableNextLevelButton
{
  public override void DisplayNextLevelButton (){
    //UnityEngine.UI.Button button = GameObject.Find("NextLevel").GetComponent<UnityEngine.UI.Button>();
    NextLevelButton.SetActive(false);
    Debug.Log("button enabled");
  }

}
