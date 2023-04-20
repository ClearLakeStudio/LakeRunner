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
    private LevelDatastore datastore;
    private GameObject[] levelMenus;
    // hero variables
    private GameObject hero;
    private Vector3[] heroPos;

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

    void Start()
    {
        //hero = GameObject.FindGameObjectWithTag("Hero");
    }

    /*
     * Initializes the overworld map.
     * All of the levels are stored in the Levels array.
     * All of the level menus are stored in the levelMenus array.
     * Each levelMenu object is Subscribed to their correspoding level.
     */
    public void OverworldMapInit(GameObject[] levels, GameObject[] levelMenus)
    {
        this.levels = levels;
        this.levelMenus = levelMenus;
        this.levelCount = this.levels.Length;

        for (int i = 0; i < levelCount; i++) {
            LevelMenu menu = levelMenus[i].GetComponent<LevelMenu>();
            levels[i].GetComponent<Lake>().Subscribe(menu);
        }
    }

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
     *
     */
    public void DeselectLevel()
    {
        foreach (GameObject level in levels) {
            level.GetComponent<Lake>().CloseLevelMenu();
        }
    }
}
