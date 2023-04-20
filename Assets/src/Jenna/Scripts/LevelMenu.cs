/*
 * Filename: LevelMenu.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Attached to level menu UI elements and subscribes to Lakes.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 *
 * Member Variables:
 * menu -- public GameObject to reference the menu name UI panel.
 * menuName -- public Text to reference the menu name text.
 * menuButton -- public Button to reference the start UI button.
 * menuButtonText -- public Text to reference the start button text.
 * levelName -- public string to hold the name of the level it is subscribed to.
 * unlocked -- public bool false if locked and true if unlocked.
 */
public class LevelMenu : MonoBehaviour, ISubscriber
{
    public GameObject menu;
    public Text menuName;
    public Button menuButton;
    public Text menuButtonText;
    [HideInInspector]
    public string levelName;
    [HideInInspector]
    public bool unlocked = false;

    void Start()
    {
        // if button is clicked, then LoadLevel() is called.
        menuButton.onClick.AddListener(LoadLevel);
    }

    /*
     * Sets the levelName to the passed levelName parameter.
     * If it is the first level, then it is unlocked.
     *
     * Parameters:
     * levelName -- string to hold the name of the level.
     */
    public void Init(string levelName)
    {
        this.levelName = levelName;

        if (levelName == "Level 1") {
            unlocked = true;
        }
    }

    void Update() {}  // here to distinguish between user defined and MonoBehaviour method

    /*
     * Updates member variables according the publisher member variables.
     *
     * Parameters:
     * published -- IPublisher object that is updated.
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
     * If active is true, then menu UI element is activated. If not, then it is deactivated.
     *
     * Parameters:
     * active -- bool false if inactive and true if active.
     */
    public void ActivateMenu(bool activate)
    {
        menu.SetActive(activate);
    }

    /*
     * If this method is called, then the start button was clicked.
     * If unlocked is true, then scene with name levelName is loaded.
     */
    public void LoadLevel()
    {
        if (unlocked) {
            SceneManager.LoadScene(levelName);
        }
    }
}
