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
 * activeLevelMenu -- public bool to store the state of the level menu.
 * subscribers --- private List<ISubscriber> to store all subscribers to the lake for the observer pattern.
 */
public class Lake : MonoBehaviour, IPublisher
{
    public bool activeLevelMenu = false;
    public bool unlocked = false;

    private List<ISubscriber> subscribers = new List<ISubscriber>();
    private LevelDatastore datastore;

    void Start()
    {
        datastore = new LevelDatastore();
        unlocked = datastore.GetLevelStatus(gameObject.name);
        Debug.Log(gameObject.name + " unlocked " + unlocked);
    }

    /*
     *
     */
    public void Subscribe(ISubscriber subscriber)
    {
        this.subscribers.Add(subscriber);
        subscriber.Init(gameObject.name);
        Debug.Log("Added new level menu.");
    }

    /*
     *
     */
    public void Unsubscribe(ISubscriber subscriber)
    {
        this.subscribers.Remove(subscriber);
        Debug.Log("Removed a level menu.");
    }

    /*
     *
     */
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

    /*
     *
     */
    public void CloseLevelMenu()
    {
        this.activeLevelMenu = false;
        Notify();
    }

    /*
     *
     */
    public void UnlockLevel()
    {
        this.unlocked = true;
        Notify();
    }
}
