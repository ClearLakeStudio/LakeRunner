using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TagIsDetected
{
    [UnityTest]
    public IEnumerator AloeVeraTagIsDetected()
    {
        var obj = new GameObject();
        var item = obj.AddComponent<AloeVera>();

        yield return null;
        Assert.AreEqual(obj.tag, "Aloe Vera");
    }

    [UnityTest]
    public IEnumerator BrainBlastBarTagIsDetected()
    {
        var obj = new GameObject();
        var item = obj.AddComponent<BrainBlastBar>();

        yield return null;
        Assert.AreEqual(obj.tag, "BrainBlastBar");
    }

    [UnityTest]
    public IEnumerator SlippersTagIsDetected()
    {
        var obj = new GameObject();
        var item = obj.AddComponent<Slippers>();

        yield return null;
        Assert.AreEqual(obj.tag, "Slippers");
    }

    [UnityTest]
    public IEnumerator SunglassesTagIsDetected()
    {
        var obj = new GameObject();
        var item = obj.AddComponent<Sunglasses>();

        yield return null;
        Assert.AreEqual(obj.tag, "Sunglasses");
    }

    [UnityTest]
    public IEnumerator SunscreenTagIsDetected()
    {
        var obj = new GameObject();
        var item = obj.AddComponent<Sunscreen>();

        yield return null;
        Assert.AreEqual(obj.tag, "Sunscreen");
    }
}
