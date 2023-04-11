using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            locked = false;
        }
    }

    /*
     *
     */
    public void Update(IPublisher publisher)
    {
        ActivateMenu((publisher as Lake).activeLevelMenu);  // check if level menu is active
        unlocked = (publisher as Lake).unlocked;
    }

    /*
     *
     */
    public void ActivateMenu(bool activate)
    {
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
            Debug.Log(sceneName);
        }
    }
}
