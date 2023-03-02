using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable
{
    void Kill();
}

public class CoreKillable : MonoBehaviour, IKillable
{
    public void Kill()
    {
        Destroy(gameObject);
    }
}

public class HeldItemsDecorator : IKillable
{
    private readonly IKillable obj;
    private Item[] held_items;

    public HeldItemsDecorator(IKillable dying_thing, Item[] items)
    {
        obj = dying_thing;
        held_items = items;
    }

    public void Kill()
    {

        foreach(Item i in held_items)
        {
            //i.generate(gameObject.Transform.Position);
        }
        obj.Kill();
    }
}