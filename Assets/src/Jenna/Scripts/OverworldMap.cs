/*
 * Filename: OverworldMap.cs
 * Developer: Jenna-Luz Pura
 * Purpose:
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Displays an overview of all the game levels.
 * Also displays a specific level menu, which shows the hero's current inventory and the player's
 *     current high score for that level.
 *
 * Member variables:
 */
public class OverworldMap : Map
{
    private OverworldLevel level;
    void Start()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<OverworldLevel>();
        level = gameObject.GetComponent<OverworldLevel>();
        SelectLevel();
    }

    public void SelectLevel()
    {
        level.OpenLevelMenu();
    }
}

/* notes to self
 * inventory, high score (on start, get inventory, high score, and player position)
 */
