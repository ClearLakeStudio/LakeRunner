using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ItemPoolIsCreated
{
    private string generic_level = "TestScene";

    [UnityTest]
    public IEnumerator ParentPoolIsCreated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var parentPool = GameObject.Find("Item Pools");
        Assert.IsNotNull(parentPool);
    }

    [UnityTest]
    public IEnumerator AloeVeraPoolIsCreated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var aloeVeraPool = GameObject.Find("AloeVeraPool");
        Assert.IsNotNull(aloeVeraPool);
    }

    [UnityTest]
    public IEnumerator BrainBlastBarPoolIsCreated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var brainBlastBarPool = GameObject.Find("BrainBlastBarPool");
        Assert.IsNotNull(brainBlastBarPool);
    }

    [UnityTest]
    public IEnumerator SlippersPoolIsCreated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var slippersPool = GameObject.Find("SlippersPool");
        Assert.IsNotNull(slippersPool);
    }

    [UnityTest]
    public IEnumerator SunglassesPoolIsCreated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var sunglassesPool = GameObject.Find("SunglassesPool");
        Assert.IsNotNull(sunglassesPool);
    }

    [UnityTest]
    public IEnumerator SunscreenPoolIsCreated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var sunscreenPool = GameObject.Find("SunscreenPool");
        Assert.IsNotNull(sunscreenPool);
    }
}
