/*
 * Filename: LevelMap.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Defines the methods used for the inter-level map.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Display a collection of all entities within a certain level.
 *
 */
public class LevelMap : Map
{
    public GameObject map;
    public Sprite[] objectSprites;
    public GameObject hero;

    private LevelDatastore datastore;
    private GameObject miniHero;

    void Start()
    {
        //Debug.Log("JP Set initial hero position");
        //datastore = new LevelDatastore();
        //datastore.FinishLevel(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Overworld");

        LoadObjects(objectSprites);
    }

    void Update()
    {
        UpdateObjects();
    }

    public override void LoadObjects(Sprite[] objectSprites)
    {
        Debug.Log("JP Loading objects in Level Map");

        // load hero
        miniHero = new GameObject("Mini Hero");
        miniHero.transform.SetParent(map.transform, false);
        Destroy(miniHero.GetComponent<Transform>());
        miniHero.AddComponent<RectTransform>();
        miniHero.AddComponent<CanvasRenderer>();
        miniHero.GetComponent<RectTransform>().localPosition = new Vector3(-28f, 28f, 0f);
        miniHero.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        miniHero.AddComponent<Image>();
        miniHero.GetComponent<Image>().sprite = objectSprites[0];
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
    public void UpdateObjects()
    {
        Debug.Log("JP Updating heroPos");
    }
}
