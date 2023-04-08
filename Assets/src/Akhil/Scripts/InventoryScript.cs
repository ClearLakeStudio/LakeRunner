using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{

    [SerializeField] int max_items = 5;
    public int BBarCount;
    public Text BBarText;
    public int SGlassCount;     
    public Text SGlassText;
    public int SlprCount;
    public Text SlprText;

    bool addItem(ItemType collectedItem)
    {
        switch (collectedItem)
        {
            case ItemType.BrainBlastBar :
                if (BBarCount < max_items)
                {
                    BBarCount++;
                    return true;
                }
                else
                {  
                    return false;
                }
            break;
            case ItemType.Sunglasses :
                if (SGlassCount < max_items)
                {
                    SGlassCount++;
                    return true;
                }
                else
                {  
                    return false;
                }
            break;
            case ItemType.Slippers :
                if (SlprCount < max_items)
                {
                    SlprCount++;
                    return true;
                }
                else
                {
                    return false;
                }
            break;
            default:
                return false;
            break;
        }
    }

    // bool addItem(Item.Collected == true)
    // {
    //     if (Item.Collected.type == "BrainBlastBar" ){
    //         if (BBarCount < max_items)
    //         {
    //             BBarCount++;
    //             return true;
    //         }
    //         else{
    //             return false;
    //         }
    //     }

    //     if (Item.Collected.type == "Sunglasses" )
    //     {
    //         if (SGlassCount < max_items)
    //         {
    //             SGlassCount++;
    //             return true;
    //         }
    //         else{
    //             return false;
    //         }
    //     }
    //     if (Item.Collected.type == "Slippers" )
    //     {
    //         if (SlprCount < max_items)
    //         {
    //             SlprCount++;
    //             return true;
    //         }
    //         else{
    //             return false;
    //         }
    //     }
    // }

    bool removeItem (ItemType ActivateItemEffect)
    {
        switch (ActivateItemEffect)
        {
            case ItemType.BrainBlastBar :
                if (BBarCount > 0)
                {
                    BBarCount--;
                    return true;
                }
                else
                {  
                    return false;
                }
            break;
            case ItemType.Sunglasses :
                if (SGlassCount > 0)
                {
                    SGlassCount--;
                    return true;
                }
                else
                {  
                    return false;
                }
            break;
            case ItemType.Slippers :
                if (SlprCount > 0)
                {
                    SlprCount--;
                    return true;
                }
                else
                {
                    return false;
                }
            break;
            default:
                return false;
            break;
        }
    }

    void Start()
    {
        BBarCount = 0;
        SGlassCount = 0;     
        SlprCount = 0;
    }

    void Update()
    {
        BBarText.text = BBarCount.ToString();
        SGlassText.text = SGlassCount.ToString();
        SlprText.text = SlprCount.ToString();
    }
}