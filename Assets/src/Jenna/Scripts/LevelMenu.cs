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

    void Start()
    {
        menuButton.onClick.AddListener(LoadLevel);
    }

    void Update() {}

    public void Update(IPublisher publisher)
    {
        if ((publisher as Lake).activeLevelMenu) {
            ActivateMenu(true);
        } else {
            ActivateMenu(false);
        }
    }

    public void ActivateMenu(bool activate)
    {
        menu.SetActive(activate);
    }

    public void LoadLevel()
    {
        Debug.Log("Load level");
    }
}
