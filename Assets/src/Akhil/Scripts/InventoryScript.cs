/*
 * FileName: InventoryScript.cs
 * Developer: Akhil
 * Purpose: Stores the amount of collectible items and Displays them on the screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* This class is responsible for storing the items
* and checks if items are there to use
*/

public class InventoryScript : MonoBehaviour
{
    // Max no if items it can store
    [SerializeField] int max_items = 5;
    // Stores the Count of BrainBlastBars player has collected
    public int BBarCount;
    // Shows the Count of BrainBlastBars
    public Text BBarText;

    // Stores the Count of SunGlasses player has collected
    public int SGlassCount;    
    // Shows the Count of SunGlasses 
    public Text SGlassText;

    // Stores the Count of Slippers player has collected
    public int SlprCount;
    // Shows the Count of Slippers
    public Text SlprText;

    /*
    * This function interacts with the inventory system to add and store the item 
    * according to the item type
    * and ensures it does not cross the max no of items
    */

    public bool AddItem(ItemType collectedItem)
    {
        switch (collectedItem) {
            case ItemType.BrainBlastBar :
                if (BBarCount < max_items) {
                    BBarCount++;
                    return true;
                }
                else {  
                    return false;
                }
            break;
            case ItemType.Sunglasses :
                if (SGlassCount < max_items) {
                    SGlassCount++;
                    return true;
                }
                else {  
                    return false;
                }
            break;
            case ItemType.Slippers :
                if (SlprCount < max_items) {
                    SlprCount++;
                    return true;
                }
                else {
                    return false;
                }
            break;
            default:
                return false;
            break;
        }
    }

    /*
    * This function interacts with the inventory system to use the item 
    * according to the item type
    * and ensures that no item is used when it is not there
    */

    public bool RemoveItem(ItemType ActivateItemEffect)
    {
        switch (ActivateItemEffect) {
            case ItemType.BrainBlastBar :
                if (BBarCount > 0) {
                    BBarCount--;
                    return true;
                }
                else {  
                    return false;
                }
            break;
            case ItemType.Sunglasses :
                if (SGlassCount > 0) {
                    SGlassCount--;
                    return true;
                }
                else {  
                    return false;
                }
            break;
            case ItemType.Slippers :
                if (SlprCount > 0) {
                    SlprCount--;
                    return true;
                }
                else {
                    return false;
                }
            break;
            default:
                return false;
            break;
        }
    }

    // initializes the quantities of the items
    void Start()
    {
        BBarCount = 0;
        SGlassCount = 0;     
        SlprCount = 0;
    }

    // updates the quantities of the items on the screen
    void Update()
    {
        BBarText.text = BBarCount.ToString();
        SGlassText.text = SGlassCount.ToString();
        SlprText.text = SlprCount.ToString();
    }
}