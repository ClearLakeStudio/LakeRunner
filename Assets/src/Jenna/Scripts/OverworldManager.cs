/*
 * Filename: OverworldManager.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Listens for user input when selecting levels.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Listens for user input in the "Overworld" scene.
 *
 * Member Variables:
 * levelMenu -- public  GameObject to reference the level menu panel.
 * overworld -- private OverworldMap to access stored levels.
 * funcReturn -- private bool to hold return value of certain methods.
 */
public class OverworldManager : MonoBehaviour
{
    public GameObject levelMenu;

    private OverworldMap overworld;
    private bool funcReturn;

    void Start()
    {
        overworld = gameObject.AddComponent<OverworldMap>();
        overworld.OverworldMapInit();
    }

    void Update()
    {
        // check for user input
        if (levelMenu.activeSelf == false) {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null) {
                    funcReturn = overworld.SelectLevel(hit.collider.name);
                }
            }
        }
    }
}
