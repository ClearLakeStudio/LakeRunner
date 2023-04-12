using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
  public GameObject gameOverUI;
  bool finishGame = false;

  DisableNextLevelButton d = new DisableNextLevelButton();
  DisableNextLevelButton e = new EnableNextLevelButton();

  //make an object of this script in the gamemanager or player script and attach gameoverScreen to it.
  // for game over screen call this func like this when the player finishes
  // ChangeScene.gameOver();
  // also create a bool and set it to true after this is called
  public void gameOver()
  {
    if (finishGame == false){
      d.DisplayNextLevelButton();
      Debug.Log("button enabled");
    }
    else {
      e.DisplayNextLevelButton();
      Debug.Log("button diabled");
    }
    gameOverUI.SetActive(true);
  }
  public void nextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    Debug.Log("next level");
  }

  public void restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Debug.Log("restart");
  }
  public void mainMenu()
  {
    SceneManager.LoadScene(1);
    Debug.Log("menu");
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