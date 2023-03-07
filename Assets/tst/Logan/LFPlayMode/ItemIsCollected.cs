using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ItemIsCollected
{
    /*
    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("TestingScene");
    }
    */

    [UnityTest]
    // whenever an item collides with an object with the "Hero" tag, it should be destroyed
    public IEnumerator ItemIsCollectedTest()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        var gameObject = new GameObject();
        var item = gameObject.AddComponent<Sunglasses>();

        item.Collected();

        yield return null;

        Assert.IsTrue(item.isCollected);
    }
}
