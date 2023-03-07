using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TagIsDetected
{
    [UnityTest]
    public IEnumerator TagIsDetectedWithEnumeratorPasses()
    {
        var gameObject = new GameObject();
        gameObject.tag = "Sunglasses";
        var item = gameObject.AddComponent<Sunglasses>();

        yield return null;
        Assert.AreEqual(item.GetItemType(), Item.ItemType.Sunglasses);
    }
}
