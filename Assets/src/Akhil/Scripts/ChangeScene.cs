using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
  public GameObject gameOverUI;

  //make an object of this script in the gamemanager or player script and attach gameoverScreen to it.
  // for game over screen call this func like this when the player finishes
  // ChangeScene.gameOver();
  // aslo create a bool and set it to true after this is called
  public void gameOver()
  {
    gameOverUI.SetActive(true);
  }
  public void nextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
  public void mainMenu()
  {
    SceneManager.LoadScene(1);
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