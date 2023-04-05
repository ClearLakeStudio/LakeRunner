/*
 * Filename: Lake.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Stores information about each lake level.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Holds statistics about individual levels and loads them.
 *
 * Member variables:
 * lakeName -- public string to store the name of the level.
 * levelMenu -- public GameObject to reference the level menu panel.
 * levelName -- public Text to reference the level name in the level menu panel.
 * startButton -- public Button to reference the start button.
 */
public class Lake : MonoBehaviour
{
    public bool levelMenuIsActive = false;
    public bool levelIsLoaded = false;
    public string lakeName;
    public GameObject levelMenu;
    public Text levelName;
    public Button startButton;

    private string levelScene;

    void Start()
    {
        startButton.onClick.AddListener(LoadLevel);
    }

    void Update()
    {

    }

    /*
     * Open the level menu by activating the level menu panel.
     */
    public void OpenLevelMenu()
    {
        levelName.text = this.lakeName;
        this.levelScene = this.lakeName.Replace(" ", "");
        Debug.Log(this.levelScene);
        levelMenu.SetActive(true);
    }

    /*
     * Load the level associated with this Lake object.
     */
    public void LoadLevel()
    {
        if (levelName.text == lakeName) {
            SceneManager.LoadScene(levelScene);
        }
    }
}
