using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Microsoft.CSharp;

///**** Dynamic Binding ********
class DisNxtBt 
{  
  public GameObject NextLevelButton;
  public virtual void DisplayNextLevelButton () 
  {
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

  private DisNxtBt d = new DisNxtBt();
  private EbNxtBt e = new EbNxtBt();
  private DisableNextLevelButton Dbu;
  private NextLevelButton Nbu;

  void Start()
  {
    Dbu = gameObject.AddComponent<DisableNextLevelButton>() as DisableNextLevelButton;
    Dbu.d = d;
    Nbu = gameObject.AddComponent<NextLevelButton>() as NextLevelButton;
    Nbu.e = e;
    dynamic dynamicD = d;
    dynamic dynamicE = e;
    d.DisplayNextLevelButton();
  }

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
    dynamic dynamicD = d;
    dynamic dynamicE = e;
    /// To call this func use this method to call it    
    //*******   ChangeScene.Instance.gameOver(); ******

    //d.DisplayNextLevelButton();
    d.DisplayNextLevelButton();
    Debug.Log("Button set");
    gameOverUI.SetActive(true);
    if (finishGame == false)
    {
      //d.DisplayNextLevelButton();
      d.DisplayNextLevelButton();
      Debug.Log("button enabled");
    }
    else 
    {
      //e.DisplayNextLevelButton();
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
    SceneManager.LoadScene(1)
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