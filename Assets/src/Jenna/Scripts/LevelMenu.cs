using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 *
 */
public class LevelMenu : MonoBehaviour, ISubscriber
{
    public GameObject menu;
    public Text menuName;
    public Button menuButton;
    public Text menuButtonText;

    private string levelName;
    private string sceneName;
    private bool unlocked = false;

    void Start()
    {
        menuButton.onClick.AddListener(LoadLevel);
    }

    void Update() {}

    /*
     *
     */
    public void Init(string levelName)
    {
        this.levelName = levelName;
        this.sceneName = levelName.Replace(" ", "");

        if (levelName == "Level 1") {
            unlocked = true;
        }
    }

    /*
     *
     */
    public void Update(IPublisher publisher)
    {
        // check if level menu is active
        if ((publisher as Lake).activeLevelMenu) {
            ActivateMenu(true);

            // reactivate animation coroutines
            gameObject.GetComponent<AnimateMenu>().Play();
            menuButton.GetComponent<AnimateMenu>().Play();
        } else {
            ActivateMenu(false);
        }

        unlocked = (publisher as Lake).unlocked;  // check if level is unlocked
        if (unlocked) {
            menuButtonText.text = "Start";
        } else {
            menuButtonText.text = "Locked";
        }
    }

    /*
     *
     */
    public void ActivateMenu(bool activate)
    {
        //gameObject.GetComponent<AnimateMenu>().enabled = false;
        //gameObject.GetComponent<AnimateMenu>().enabled = activate;
        menu.SetActive(activate);
    }

    /*
     *
     */
    public void LoadLevel()
    {
        if (unlocked) {
            SceneManager.LoadScene(sceneName);
        } else {
            //Debug.Log(sceneName);
        }
    }
}
