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
 *
 * Member Variables:
 * heroPos -- public Vector3 array to hold hero position on overworld based on the next level.
 * overworldMap -- private static OverworldMap to ensure only one instance exists.
 * datastore -- private LevelDatastore to access stored data.
 * levelMenus -- private GameObject array to hold all levelMenu UI panel elements.
 * hero -- private GameObject to display the hero sprite on the overworld.
 */
public class OverworldMap : Map
{
    public Vector3[] heroPos;

    private static OverworldMap overworldMap;
    private LevelDatastore datastore;
    private GameObject[] levelMenus;
    private GameObject hero;

    void Awake()
    {
        // implement Singleton pattern
        if (overworldMap == null) {
            overworldMap = this;
        }

        datastore = new LevelDatastore();
        heroPos = new Vector3[5] {
            new Vector3(-5.5f, 3.75f, 0f),
            new Vector3(-4.5f, 2.25f, 0f),
            new Vector3(-2.85f, 0.45f, 0f),
            new Vector3(-0.85f, -0.65f, 0f),
            new Vector3(1.9f, -1.2f, 0f)
        };
    }

    /*
     * Initializes the overworld map.
     * All of the levels are stored in the Levels array.
     * All of the level menus are stored in the levelMenus array.
     * Each levelMenu object is Subscribed to their correspoding level.
     *
     * Parameters:
     * levels -- GameObject array to hold all levels.
     * levelMenus -- GameObject array to hold all level menu UI panels.
     */
    public void OverworldMapInit(GameObject[] levels, GameObject[] levelMenus)
    {
        this.levels = levels;
        this.levelMenus = levelMenus;
        this.levelCount = this.levels.Length;

        // subscriber level menus to appropriate lake/level.
        for (int i = 0; i < levelCount; i++) {
            LevelMenu menu = levelMenus[i].GetComponent<LevelMenu>();
            levels[i].GetComponent<Lake>().Subscribe(menu);
        }
    }

    /*
     * Loads the hero onto the overworld map according to the next level.
     *
     * Parameters:
     * objectSprites -- Sprite array to hold sprites for each object.
     */
    public override void LoadObjects(Sprite[] objectSprites)
    {
        Debug.Log("Loading objects in Overworld Map");

        int nextLevel = datastore.GetNextLevel();

        // load hero
        hero = new GameObject("Hero");
        hero.transform.position = heroPos[nextLevel - 1];
        hero.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        hero.AddComponent<SpriteRenderer>();
        hero.GetComponent<SpriteRenderer>().sortingOrder = 1;
        hero.GetComponent<SpriteRenderer>().sprite = objectSprites[0];
    }

    /*
     * Is called when the user clicks on a GameObject.
     * Checks if clicked GameObject is a level.
     *
     * Parameters:
     * levelName -- string to hold the name of the selected level.
     *
     * Returns:
     * found -- bool false if level is not found, true if it is found.
     */
    public bool SelectLevel(string levelName)
    {
        bool found = false;

        foreach (GameObject level in levels) {
            if (level.name == levelName) {
                found = true;
                level.GetComponent<Lake>().OpenLevelMenu();
            } else {
                level.GetComponent<Lake>().CloseLevelMenu();
            }
        }

        return found;
    }

    /*
     * Called when users clicks off of the level menu.
     * All level menus are closed.
     */
    public void DeselectLevel()
    {
        foreach (GameObject level in levels) {
            level.GetComponent<Lake>().CloseLevelMenu();
        }
    }
}
