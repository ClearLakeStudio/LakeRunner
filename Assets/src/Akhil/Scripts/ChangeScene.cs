using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///**** Dynamic Binding ********
class DisNxtBt 
{ 
  public virtual bool DisplayNextLevelButton () 
  {
    return false;
    Debug.Log("button disabled");
  }
}
class EbNxtBt : DisNxtBt
{
  public override bool DisplayNextLevelButton ()
  {
    return true;
    Debug.Log("button enabled");
  }
}

public class ChangeScene : MonoBehaviour 
{
  // ****** Singleton Pattern ******
  private static ChangeScene instance;
  public static ChangeScene Instance()
  {
    if (instance == null)
    {
      instance = FindObjectOfType<ChangeScene>();
    }
    return instance;
  }
  public GameObject NextLevelButtn;
  public GameObject gameOverUI;
  bool finishGame = true;
  bool button = true;

  private DisNxtBt d;

  public void gameOver()
  {

    if (finishGame == true) {
      d = new DisNxtBt();
      button = d.DisplayNextLevelButton();
    }
    else if(finishGame == false){
      d = new EbNxtBt();
      button = d.DisplayNextLevelButton();
    }

    Time.timeScale = 0;
    Debug.Log("Time Freeze");
    gameOverUI.SetActive(true);

    if (button == false)
    {
      Debug.Log("button enabled");
      NextLevelButtn.SetActive(false);
    }
    else 
    {
      Debug.Log("button diabled");
      NextLevelButtn.SetActive(true);
    }

  }
  public void nextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    Debug.Log("next level");
  }

  public void restart()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Debug.Log("restart");
  }
  public void mainMenu()
  {
    SceneManager.LoadScene("MainMenu");
    Debug.Log("MainMenu");
  }

  public void MoveToScene( int SceneID ) 
  {
    SceneManager.LoadScene (SceneID);
  }

  public void Quit() 
  {
    Application.Quit();
    Debug.Log("Quit");
  }
}




