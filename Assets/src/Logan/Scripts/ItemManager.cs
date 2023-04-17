/*
 * Filename:  ItemManager.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "ItemManager" class.
 */

using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is the interface that allows for other systems (namely
 * the inventory system) to interact with item objects.
 *
 * Member Variables:
 */
public class ItemManager : MonoBehaviour
{
    // singleton pattern
    public static ItemManager instance;

    // denied sound effect to play when player tries to use an item that doesn't exist
    [SerializeField] private AudioClip deniedSound;

    // inventory object
    public InventoryScript inventory;

    // user input keys
    public KeyCode sunglassesKey = KeyCode.Alpha1;
    public KeyCode slippersKey = KeyCode.Alpha2;
    public KeyCode brainBlastBarKey = KeyCode.Alpha3;

    // a prefab whose children are meant to represented in separate object pools
    [SerializeField] private GameObject itemCollection;
    // the number of GameObjects to be stored in each object pool
    [SerializeField] private int numberOfObjectsInPool = 100;

    // stores all GameObject pools (implemented as lists) with the GameObject's ItemType as a key
    private Dictionary<ItemType, List<GameObject>> pools = new Dictionary<ItemType, List<GameObject>>();
    // empty GameObject meant to organize the item pools in the Unity hierarchy
    private GameObject itemPools;

    public void Awake()
    {
        // singleton
        if (instance == null) {
            instance = this;
        }

        // intermediate list of GameObjects retrieved from the itemCollection GameObject
        List<GameObject> itemsFromCollection = new List<GameObject>();
        // iterate through each child in the itemCollection and add it to the itemsFromCollection list
        foreach(Transform child in itemCollection.transform) {
            GameObject temp = child.gameObject;
            itemsFromCollection.Add(temp);
        }

        // create an empty GameObject to store and organize the item pool GameObjects
        itemPools = new GameObject("Item Pools");

        foreach(GameObject collectionObject in itemsFromCollection) {
            // create an empty GameObject that will hold the pooled GameObjects for this type in the unity hierarchy
            GameObject poolRepresentative = new GameObject(collectionObject.name);
            // make the empty GameObject a child of the itemPools GameObject
            poolRepresentative.transform.parent = itemPools.transform;

            // for each GameObject in the list of itemsFromCollection, create a new list (pool)
            List<GameObject> newPool = new List<GameObject>();

            for (int j = 0; j < numberOfObjectsInPool; j++) {
                GameObject obj = Instantiate(collectionObject);
                obj.transform.parent = poolRepresentative.transform;
                obj.SetActive(false);
                newPool.Add(obj);

                // get the type of the first item in the pool and use that to represent all objects in the pools dictionary
                if (j == 0) {
                    ItemType listType = obj.GetComponent<Item>().GetItemType();
                    pools.Add(listType, newPool);
                }
            }
        }
    }

    public bool UpdateInventory(ItemType collidedItem)
    {
        if (inventory.addItem(collidedItem)) {
            return true;
        }
        return false;
    }

    public GameObject GetPooledObject(ItemType desiredType)
    {
        // search through the pools dictionary for a pool that matches the desiredType
        foreach(KeyValuePair<ItemType, List<GameObject>> kvp in pools) {
            if (kvp.Key == desiredType) {
                // search through the pool for an available GameObject
                for (int i = 0; i < kvp.Value.Count; i++) {
                    if (kvp.Value[i].activeInHierarchy == false) {
                        kvp.Value[i].SetActive(true);
                        return kvp.Value[i];
                    }
                }
                // all items in pool are active
                return null;
            }
        }
        // there is no pool that matches that ItemType
        return null;
    }

    public bool ReturnPooledObject(GameObject returnedObj)
    {
        // get the ItemType of the returned object
        ItemType type = returnedObj.GetComponent<Item>().GetItemType();

        // search through the pools dictionary for a pool that matches the type of the returned object
        foreach(KeyValuePair<ItemType, List<GameObject>> kvp in pools) {
            if (kvp.Key == type) {
                returnedObj.SetActive(false);
                return true;
            }
        }
        // no pool matches the type of the item that was returned
        return false;
    }

    public void Update()
    {
        // check for user input
        if (Input.GetKeyDown(sunglassesKey)) {
            // query the inventory to ensure that the player has the item
            // if (inventory.ExistsInInventory(ItemType.Sunglasses == true) {
            //     // call the item's effect
            // } else {
            //     // play "denial" sound
            // }

            if (inventory.removeItem(ItemType.Sunglasses)) {
                // play success sound

                // activate effect
                ActivateItemEffect(ItemType.Sunglasses);
            }
            else {
                //AudioSource.PlayClipAtPoint(deniedSound, transform.position);
            }
        } else if (Input.GetKeyDown(slippersKey)) {
            if (inventory.removeItem(ItemType.Slippers)) {
                ActivateItemEffect(ItemType.Slippers);
            }
            else {
                //AudioSource.PlayClipAtPoint(deniedSound, transform.position);
            }
        } else if (Input.GetKeyDown(brainBlastBarKey)) {
            if (inventory.removeItem(ItemType.BrainBlastBar)) {
                ActivateItemEffect(ItemType.BrainBlastBar);
            }
            else {
                //AudioSource.PlayClipAtPoint(deniedSound, transform.position);
                //AudioSource.Play(deniedSound);
                //deniedSound.Play();
            }
        }
    }

    /*
     * This function should be called whenever the effect of an item needs
     * to execute. This function does not check for whether the item
     * currently exists in the inventory system, so it could be called
     * even if no items exist in the inventory.
     *
     * Parameters:
     * itemType-- ItemType of the item whose effect needs to run
     */
    public void ActivateItemEffect(ItemType itemType)
    {
        GameObject obj = GetPooledObject(itemType);

        if (obj == null) {
            Debug.Log("ERROR, COULDN'T GET ITEM");
            return;
        }

        // ## Dynamic binding ##
        // Superclass: Item
        // Subclasses: AloeVera, BrainBlastBar, Slippers, Sunglasses, Sunscreen
        Item itemScript = obj.GetComponent<Item>();
        if (itemScript.effectIsActive == false) {
            StartCoroutine(itemScript.UseEffect());
        }

        if (!ReturnPooledObject(obj)) {
            Debug.Log("ERROR, COULDN'T RETURN ITEM");
            return;
        }
    }

    // if you want to spawn a random item, pass null in to the first argument
    // if you want to spawn a speficci item, pass ItemType.[type] into the first argument
    // if you want to set the pos but not the itemType, call SpawnItem(null, posVal)
    public void SpawnItem(ItemType? itemType = null, Vector2? pos = null)
    {
        if (pos == null) {
            GameObject heroObject = GameObject.FindGameObjectWithTag("Hero");
            // this is not guaranteed to spawn the item on a platform
            pos = new Vector2(heroObject.transform.position.x + 20, heroObject.transform.position.y + 10);
        }

        if (itemType == null) {
            // choose a random ItemType besides undefined
            List<ItemType> enums = ((ItemType[])Enum.GetValues(typeof(ItemType))).ToList();
            enums.Remove(ItemType.Undefined);
            System.Random random = new System.Random();
            itemType = enums[random.Next(enums.Count)];
            Debug.Log(itemType.ToString());
        }

        GameObject spawnedObj = this.GetPooledObject((ItemType)itemType);
        // no objects avaialable in pool
        if (spawnedObj == null) {
            return;
        }
        spawnedObj.transform.position = (Vector2)pos;
    }
}

