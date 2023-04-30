using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ItemIsCollected
{
    private string generic_level = "Level1";

    [UnityTest]
    public IEnumerator AloeVeraIsCollected()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var item = new GameObject().AddComponent<AloeVera>().GetComponent<AloeVera>();
        item.Collected();
        Assert.IsTrue(item.isCollected);
    }

    [Test]
    public void BrainBlastBarIsCollected()
    {
        var item = new GameObject().AddComponent<BrainBlastBar>().GetComponent<BrainBlastBar>();
        item.Collected();
        Assert.IsTrue(item.isCollected);
    }

    [Test]
    public void SlippersAreCollected()
    {
        var item = new GameObject().AddComponent<Slippers>().GetComponent<Slippers>();
        item.Collected();
        Assert.IsTrue(item.isCollected);
    }

    [Test]
    public void SunglassesAreCollected()
    {
        var item = new GameObject().AddComponent<Sunglasses>().GetComponent<Sunglasses>();
        item.Collected();
        Assert.IsTrue(item.isCollected);
    }

    [UnityTest]
    public IEnumerator SunscreenIsCollected()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var item = new GameObject().AddComponent<Sunscreen>().GetComponent<Sunscreen>();
        item.Collected();
        Assert.IsTrue(item.isCollected);
    }
}
