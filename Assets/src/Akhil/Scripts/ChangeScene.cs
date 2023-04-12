using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour 
{


  class DisNxtBt 
  {  
    public GameObject NextLevelButton;
    public virtual void DisplayNextLevelButton () {
      //UnityEngine.UI.Button button = GameObject.Find("NextLevel").GetComponent<UnityEngine.UI.Button>();
      NextLevelButton.SetActive(false);
      Debug.Log("button disabled");
    }
  } 

  class EbNxtBt : DisNxtBt
  {
    public override void DisplayNextLevelButton ()
    {
      //UnityEngine.UI.Button button = GameObject.Find("NextLevel").GetComponent<UnityEngine.UI.Button>();
      NextLevelButton.SetActive(true);
      Debug.Log("button enabled");
    }
  }

  private DisNxtBt d = new DisNxtBt();
  private EbNxtBt e = new EbNxtBt();



  // public DisableNextLevelButton Dbu;
  // public NextLevelButton Nbu;
 
  public GameObject gameOverUI;
  bool finishGame = true;

  // void Start()
  // {
  //   // DisableNextLevelButton Dbu = gameObject.AddComponent<DisableNextLevelButton>() as DisableNextLevelButton;
  //   // NextLevelButton Nbu = gameObject.AddComponent<NextLevelButton>() as NextLevelButton;
  // }
  // void update()
  // {
  //   if (finishGame == false){
  //     //d.DisplayNextLevelButton();
  //     //Dbu.DisplayNextLevelButton();
  //     Debug.Log("button enabled");
  //   }
  //   else {
  //     //e.DisplayNextLevelButton();
  //     //Nbu.DisplayNextLevelButton();
  //     Debug.Log("button diabled");
  //   }
  // }
  

  //public DisableNextLevelButton e = new NextLevelButton();

  public void gameOver()
  {
    d.DisplayNextLevelButton();
    Debug.Log("Button set");
    gameOverUI.SetActive(true);
    if (finishGame == false){
      d.DisplayNextLevelButton();
      Debug.Log("button enabled");
    }
    else {
      e.DisplayNextLevelButton();
      Debug.Log("button diabled");
    }
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