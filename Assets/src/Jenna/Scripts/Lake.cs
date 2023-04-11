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
public class Lake : MonoBehaviour, IPublisher
{
    /*
    public bool levelMenuIsActive = false;
    public bool levelIsLoaded = false;
    public string lakeName;
    public GameObject levelMenu;
    public Text levelName;
    public Button startButton;

    private string levelScene;
    */

    public bool activeLevelMenu = false;

    private List<ISubscriber> subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)
    {
        this.subscribers.Add(subscriber);
        Debug.Log("Added new level menu.");
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        this.subscribers.Remove(subscriber);
        Debug.Log("Removed a level menu.");
    }

    public void Notify()
    {
        foreach (var subscriber in subscribers) {
            subscriber.Update(this);
        }
    }

    /*
     * Open the level menu by activating the level menu panel.
     */
    public void OpenLevelMenu()
    {
        this.activeLevelMenu = true;
        Notify();
    }

    public void CloseLevelMenu()
    {
        this.activeLevelMenu = false;
        Notify();
    }
    /*
     * Load the level associated with this Lake object.
     */
    /*
    public void LoadLevel()
    {
        if (levelName.text == lakeName) {
            SceneManager.LoadScene(levelScene);
        }
    }
    */
}
