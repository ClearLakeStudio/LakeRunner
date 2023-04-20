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
 * Holds statistics about individual levels and notifies level menu subscribers when changed.
 *
 * Member variables:
 * activeLevelMenu -- public bool false when inactive and true when active.
 * unlocked -- public bool false when locked (cannot be played) and true when unlocked.
 * subscribers -- ISubscriber list to hold all subscribers.
 * datastore -- LevelDatastore to access stored data.
 */
public class Lake : MonoBehaviour, IPublisher
{
    [HideInInspector]
    public bool activeLevelMenu = false;
    [HideInInspector]
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
     * Adds subscriber to subscribers list.
     *
     * Parameters:
     * subscriber -- ISubscriber object to be subscribed to the Lake.
     */
    public void Subscribe(ISubscriber subscriber)
    {
        this.subscribers.Add(subscriber);
        subscriber.Init(gameObject.name);
        Debug.Log("Added new level menu.");
    }

    /*
     * Removes subscriber from subscribers list.
     *
     * Parameters:
     * subscriber -- ISubscriber object to be subscribed to the Lake.
     */
    public void Unsubscribe(ISubscriber subscriber)
    {
        this.subscribers.Remove(subscriber);
        Debug.Log("Removed a level menu.");
    }

    /*
     * Notifies each subscriber of changes in the Lake object.
     */
    public void Notify()
    {
        foreach (var subscriber in subscribers) {
            subscriber.Update(this);
        }
    }

    /*
     * Tells level menu subscriber to activate their UI panel.
     */
    public void OpenLevelMenu()
    {
        this.activeLevelMenu = true;
        Notify();
    }

    /*
     * Tells level menu subscriber to deactivate their UI panel.
     */
    public void CloseLevelMenu()
    {
        this.activeLevelMenu = false;
        Notify();
    }

    /*
     * Tells level menu subscriber to unlock level.
     */
    public void UnlockLevel()
    {
        this.unlocked = true;
        Notify();
    }
}
