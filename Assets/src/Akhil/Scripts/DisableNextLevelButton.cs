using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableNextLevelButton : ChangeScene
{
    public GameObject NextLevelButton;
    public virtual void DisplayNextLevelButton () {
        //UnityEngine.UI.Button button = GameObject.Find("NextLevel").GetComponent<UnityEngine.UI.Button>();
        NextLevelButton.SetActive(false);
        Debug.Log("button disabled");
    }
}
