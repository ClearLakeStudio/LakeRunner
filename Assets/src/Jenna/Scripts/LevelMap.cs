/*
 * Filename: LevelMap.cs
 * Developer: Jenna-Luz Pura
 * Purpose:
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Display a collection of all entities within a certain level.
 *
 * Member variables:
 */
public class LevelMap : Map
{
    //private int startPos = 0;
    //private int endPos = 100;

    void Start()
    {
        Debug.Log("JP Set initial hero position.");
    }

    void Update()
    {

    }

    /*
     * Updates the hero, item, and enemy positions on the map.
     *
     * Parameters:
     * heroPos -- Vector2 holds the updated position of the hero.
     *
     * Returns:
     * int -- 1 if updated successfully, 0 if not.
     */
    public int UpdateLevelMap(Vector2 heroPos)
    {
        Debug.Log("JP Updating heroPos");

        return 1;
    }
}
