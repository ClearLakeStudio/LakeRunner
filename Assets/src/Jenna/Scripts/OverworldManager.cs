/*
 * Filename: OverworldManager.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Listens for user input when selecting levels.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * Listens for user input in the "Overworld" scene.
 *
 * Member Variables:
 * levels -- public GameObject array to hold all of the level GameObjects.
 * levelMenus -- public GameObject array to hold all of the level menu UI elements.
 * canvas -- public Canvas to reference the Canvas.
 * objectSprites -- public Sprite array to hold an array of object sprites.
 * overworld -- public OverworldMap to reference OverworldMap script.
 * datastore -- public LevelDatastore to reference stored data.
 * map -- private Map to reference static type.
 * raycaster -- private GraphicRaycaster to raycast UI elements.
 * pointerEventData -- private PointerEventData to register clicks on Canvas.
 * eventSystem -- private EventSystem to reference EventSystem.
 * activeMenu -- private bool false if inactive and true if active.
 */
public class OverworldManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] levelMenus;
    public Canvas canvas;
    public Sprite[] objectSprites;
    public OverworldMap overworld;
    public LevelDatastore datastore;

    private Map map;
    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;
    private bool activeMenu = false;

    void Start()
    {
        datastore = new LevelDatastore(5);

        // UI element raycast
        raycaster = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = canvas.GetComponent<EventSystem>();

        // static and dynamic binding
        map = gameObject.AddComponent<OverworldMap>();
        overworld = gameObject.AddComponent<OverworldMap>();
        overworld.OverworldMapInit(levels, levelMenus);
        map.LoadObjects(objectSprites);

        datastore.PrintLevelStatus();
    }

    void Update()
    {
        // check for user input
        if (Input.GetMouseButtonDown(0)) {
            if (activeMenu == false) {
                // physics raycaster
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null) {
                    //Debug.Log(hit.collider.name);
                    activeMenu = overworld.SelectLevel(hit.collider.name);
                }
            } else {
                // graphics raycaster
                pointerEventData = new PointerEventData(eventSystem);
                pointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                raycaster.Raycast(pointerEventData, results);

                if (results.Count == 0) {
                    overworld.DeselectLevel();
                    activeMenu = false;
                }
            }
        }
    }

    /*
     * Gets the next level the hero/player will play.
     *
     * Returns:
     * int -- a range between and including 1-5, one for each level.
     */
    public int GetHeroLevel()
    {
        return datastore.GetNextLevel();
    }
}
