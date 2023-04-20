using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class InventoryIsUpdated
{
    private string generic_level = "TestScene";

    [UnityTest]
    public IEnumerator BrainBlastBarInventoryIsUpdated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var heroCollider = GameObject.FindGameObjectWithTag("Hero").GetComponent<Collider2D>();
        var brainBlastBar = GameObject.FindGameObjectWithTag("BrainBlastBar").GetComponent<BrainBlastBar>();

        brainBlastBar.OnTriggerEnter2D(heroCollider);
        yield return null;

        var count = GameObject.Find("BBarCount").GetComponent<Text>();
        Assert.AreEqual("1", count.text);
    }

    [UnityTest]
    public IEnumerator SlippersInventoryIsUpdated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var heroCollider = GameObject.FindGameObjectWithTag("Hero").GetComponent<Collider2D>();
        var slippers = GameObject.FindGameObjectWithTag("Slippers").GetComponent<Slippers>();

        slippers.OnTriggerEnter2D(heroCollider);
        yield return null;

        var count = GameObject.Find("SlipperCount").GetComponent<Text>();
        Assert.AreEqual("1", count.text);
    }

    [UnityTest]
    public IEnumerator SunglassesInventoryIsUpdated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var heroCollider = GameObject.FindGameObjectWithTag("Hero").GetComponent<Collider2D>();
        var sunglasses = GameObject.FindGameObjectWithTag("Sunglasses").GetComponent<Sunglasses>();

        sunglasses.OnTriggerEnter2D(heroCollider);
        yield return null;

        var count = GameObject.Find("SunglassesCount").GetComponent<Text>();
        Assert.AreEqual("1", count.text);
        yield return null;
    }
}
