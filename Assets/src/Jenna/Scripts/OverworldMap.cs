/*
 * Filename: OverworldMap.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Keeps track of all the levels in the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Displays an overview of all the game levels.
 * Also displays a specific level menu, which shows the hero's current inventory and the player's
 *     current high score for that level.
 */
public class OverworldMap : Map
{
    // hero variables
    private GameObject hero;
    private int hero_current_level = 1;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        /*
        var gameObject = new GameObject();
        gameObject.AddComponent<Lake>();
        level1 = gameObject.GetComponent<Lake>();
        SelectLevel();
        */
    }

    /*
     * Gets all GameObjects with the "Level" tag and stores them in an array.
     * Each level is added a "Lake" component.
     */
    public void OverworldMapInit()
    {
        levels = GameObject.FindGameObjectsWithTag("Level");
        levelCount = levels.Length;

        foreach (GameObject level in levels) {
            level.GetComponent<Lake>().lakeName = level.name;
        }
    }

    /*
     * Is called when the user clicks on a GameObject.
     * Checks if clicked GameObject is a level.
     *
     * Returns:
     * bool -- true if the GameObject is a level, false if it is not.
     */
    public bool SelectLevel(string levelName)
    {
        foreach (GameObject level in levels) {
            if (level.name == levelName) {
                level.GetComponent<Lake>().OpenLevelMenu();
                return true;
            }
        }

        return false;
    }

    public int GetHeroLevel()
    {
        return hero_current_level;
    }
}
