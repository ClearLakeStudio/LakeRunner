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
    private static OverworldMap overworldMap;
    private GameObject[] levelMenus;
    // hero variables
    private GameObject hero;
    private int heroCurrentLevel = 1;

    void Awake()
    {
        // implement Singleton pattern
        if (overworldMap == null) {
            overworldMap = this;
        }
    }

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    /*
     *
     */
    public void OverworldMapInit(GameObject[] levels, GameObject[] levelMenus)
    {
        this.levels = levels;
        this.levelMenus = levelMenus;
        this.levelCount = this.levels.Length;

        for (int i = 0; i < levelCount; i++) {
            levels[i].AddComponent<Lake>();
            LevelMenu menu = levelMenus[i].GetComponent<LevelMenu>();
            levels[i].GetComponent<Lake>().Subscribe(menu);
        }
    }

    /*
     * Is called when the user clicks on a GameObject.
     * Checks if clicked GameObject is a level.
     *
     * Returns:
     * bool -- true if the GameObject is a level, false if it is not.
     */
    public void SelectLevel(string levelName)
    {
        foreach (GameObject level in levels) {
            if (level.name == levelName) {
                level.GetComponent<Lake>().OpenLevelMenu();
            } else {
                level.GetComponent<Lake>().CloseLevelMenu();
            }
        }
    }

    /*
     * Gets the next level the hero/player will play.
     *
     * Returns:
     * int -- heroCurrentLevel stores a range between and including 1-5, one for each level.
     */
    public int GetHeroLevel()
    {
        return heroCurrentLevel;
    }
}
