using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlatformStop
{
    [UnityTest]
    public IEnumerator ItemIsCollectedTest()
    {
        var finishLine = new GameObject();
        finishLine.gameObject.transform.position = new Vector2(0,0);
        finishLine.AddComponent<LevelFinish>();

        var hero = new GameObject();
        hero.gameObject.tag = "Hero";
        hero.gameObject.transform.position = new Vector2(0,10);

        yield return null;

        Assert.IsFalse(finishLine.GetComponent<LevelFinish>().CanPlacePlatforms());
    }
}