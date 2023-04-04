/*
 * Filename:  Item.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "item" abstract class.
 */

using UnityEngine;

/*
 * This superclass lays the foundation for all of the items featured in LakeRunner.
 * Only common functions that are necessary for every kind of item are defined.
 *
 * Member Variables:
 * isCollected      -- bool that reflects the current status of the item instance.
 * type             -- ItemType that tells what kind of item this instance is.
 * collectSound     -- AudioClip that holds an audio file that is played an pick-up.
 */
public enum ItemType {
    Undefined     = -1,
    AloeVera      = 0,
    Sunscreen     = 1,
    Sunglasses    = 10,
    BrainBlastBar = 11,
    Slippers      = 12,
}

public class Item : MonoBehaviour
{
    public bool isCollected = false;

    [SerializeField] AudioClip collectSound;
    protected ItemType type = ItemType.Undefined;

    /*
     * Should be called whenever the hero collides with an uncollected
     * item in a level. Updates the isCollected member variable to reflect the
     * current status of the item instance.
     *
     * Returns:
     * ItemType -- the type of the item that was collected (can go towards updating
     *             statistics or inventory UI, etc.)
     */
    public virtual ItemType Collected()
    {
        this.isCollected = true;
        Debug.Log("(Logan) Item Class: " + this.type.ToString() + " collected.");
        return this.type;
    }

    public ItemType GetItemType()
    {
        return this.type;
    }

    protected void Awake()
    {
        if (gameObject.tag == "Sunscreen") {
            this.SetType(ItemType.Sunscreen);
        }
        else if (gameObject.tag == "Aloe Vera") {
            this.SetType(ItemType.AloeVera);
        }
        else if (gameObject.tag == "Sunglasses") {
            this.SetType(ItemType.Sunglasses);
        }
        else if (gameObject.tag == "Slippers") {
            this.SetType(ItemType.Slippers);
        }
        else if (gameObject.tag == "BrainBlastBar") {
            this.SetType(ItemType.BrainBlastBar);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero") {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            this.Collected();
            Destroy(gameObject);
        }
    }

    /*
     * Parameters:
     * desiredType -- ItemType that will set the instances type variable
     */
    public void SetType(ItemType desiredType)
    {
        // come back and validate the value that is passed
        this.type = desiredType;
    }

    public virtual void UseEffect()
    {
        Debug.Log("Hello from Item");
    }
}
