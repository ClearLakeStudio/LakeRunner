using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class VerifyItemPool
{
    private string generic_level = "TestScene";

    [UnityTest]
    public IEnumerator VerifyAloeVeraPool()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var aloeVeraPool = GameObject.Find("AloeVeraPool");
        Transform[] children = new Transform[aloeVeraPool.transform.childCount];
        for (int i = 0; i < aloeVeraPool.transform.childCount; i++) {
            var aloeVera = aloeVeraPool.transform.GetChild(i).GetComponent<Item>();
            Assert.AreEqual(ItemType.AloeVera, aloeVera.GetItemType());
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator VerifyBrainBlastBarPool()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var brainBlastBarPool = GameObject.Find("BrainBlastBarPool");
        Transform[] children = new Transform[brainBlastBarPool.transform.childCount];
        for (int i = 0; i < brainBlastBarPool.transform.childCount; i++) {
            var brainBlastBar = brainBlastBarPool.transform.GetChild(i).GetComponent<Item>();
            Assert.AreEqual(ItemType.BrainBlastBar, brainBlastBar.GetItemType());
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator VerifySlippersPool()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var slippersPool = GameObject.Find("SlippersPool");
        Transform[] children = new Transform[slippersPool.transform.childCount];
        for (int i = 0; i < slippersPool.transform.childCount; i++) {
            var slippers = slippersPool.transform.GetChild(i).GetComponent<Item>();
            Assert.AreEqual(ItemType.Slippers, slippers.GetItemType());
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator VerifySunglassesPool()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var sunglassesPool = GameObject.Find("SunglassesPool");
        Transform[] children = new Transform[sunglassesPool.transform.childCount];
        for (int i = 0; i < sunglassesPool.transform.childCount; i++) {
            var sunglasses = sunglassesPool.transform.GetChild(i).GetComponent<Item>();
            Assert.AreEqual(ItemType.Sunglasses, sunglasses.GetItemType());
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator VerifySunscreenPool()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var sunscreenPool = GameObject.Find("SunscreenPool");
        Transform[] children = new Transform[sunscreenPool.transform.childCount];
        for (int i = 0; i < sunscreenPool.transform.childCount; i++) {
            var sunscreen = sunscreenPool.transform.GetChild(i).GetComponent<Item>();
            Assert.AreEqual(ItemType.Sunscreen, sunscreen.GetItemType());
        }
        yield return null;
    }
}
