/*
 * Filename: LevelMap.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Defines the methods used for the inter-level map.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Display a collection of all entities within a certain level.
 *
 */
public class LevelMap : Map
{
    void Start()
    {
        Debug.Log("JP Set initial hero position");
    }

    void Update()
    {

    }

    public override void LoadObjects()
    {
        Debug.Log("Loading objects in Level Map");
    }

    /*
     * Update the hero's position on the inter-level map.
     *
     * Parameters:
     * heroPos -- Vector2 passes the current position of the hero.
     *
     * Returns:
     * int -- 1 upon success, 0 upon failure.
     */
    public int UpdateLevelMap(Vector2 heroPos)
    {
        Debug.Log("JP Updating heroPos");

        return 1;
    }
}
