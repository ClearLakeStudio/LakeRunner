using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EffectIsActivated
{
    private string generic_level = "Level1";

    [UnityTest]
    /*
     * There are two possible outcomes when the AloeVera effect is activated:
     * 1. The Hero has full health. If this is the case, the health is not affected.
     * 2. The Hero has depleted health. If this is the case, the health will be increased.
     * In both cases, the Hero's health should not be lower after the AloeVera effect is activated.
     */
    public IEnumerator AloeVeraEffectIsActivated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        var originalHealth = hero.GetHealth();

        var aloeVera = new GameObject().AddComponent<AloeVera>().GetComponent<AloeVera>();
        aloeVera.StartCoroutine(aloeVera.UseEffect());

        var newHealth = hero.GetHealth();
        Assert.IsTrue(originalHealth <= newHealth);
    }

    [UnityTest]
    /*
     * The BrainBlastBar is an inventory item and has a "effectIsActive" boolean.
     * That boolean will only be set to true when the effect is currently activated
     * and will be set to false when the effect is not activated.
     */
    public IEnumerator BrainBlastBarEffectIsActivated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var brainBlastBar = new GameObject().AddComponent<BrainBlastBar>().GetComponent<BrainBlastBar>();

        // make sure the effect isn't already active
        Assert.IsFalse(BrainBlastBar.GetEffectIsActive());

        // activate the effect
        brainBlastBar.StartCoroutine(brainBlastBar.UseEffect());

        Assert.IsTrue(BrainBlastBar.GetEffectIsActive());
    }

    [UnityTest]
    /*
     * The Slippers is an inventory item and has a "effectIsActive" boolean.
     * That boolean will only be set to true when the effect is currently activated
     * and will be set to false when the effect is not activated.
     */
    public IEnumerator SlippersEffectIsActivated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var slippers = new GameObject().AddComponent<Slippers>().GetComponent<Slippers>();

        // make sure the effect isn't already active
        Assert.IsFalse(Slippers.GetEffectIsActive());

        // activate the effect
        slippers.StartCoroutine(slippers.UseEffect());

        Assert.IsTrue(Slippers.GetEffectIsActive());
    }

    [UnityTest]
    /*
     * The Sunglesses is an inventory item and has a "effectIsActive" boolean.
     * That boolean will only be set to true when the effect is currently activated
     * and will be set to false when the effect is not activated.
     */
    public IEnumerator SunglassesEffectIsActivated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var sunglasses = new GameObject().AddComponent<Sunglasses>().GetComponent<Sunglasses>();

        // make sure the effect isn't already active
        Assert.IsFalse(Sunglasses.GetEffectIsActive());

        // activate the effect
        sunglasses.StartCoroutine(sunglasses.UseEffect());

        Assert.IsTrue(Sunglasses.GetEffectIsActive());
    }

    [UnityTest]
    /*
     * There are two possible outcomes when the Sunscreen effect is activated:
     * 1. The Hero has full shield (sunscreen). If this is the case, the shield (sunscreen) is not affected.
     * 2. The Hero has depleted shield (sunscreen). If this is the case, the shield (sunscreen) will be increased.
     * In both cases, the Hero's shield (sunscreen) should not be lower after the Sunscreen effect is activated.
     */
    public IEnumerator SunscreenEffectIsActivated()
    {
        SceneManager.LoadScene(generic_level);
        yield return null;

        var hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        var originalShield= hero.GetShield();

        var sunscreen = new GameObject().AddComponent<Sunscreen>().GetComponent<Sunscreen>();
        sunscreen.StartCoroutine(sunscreen.UseEffect());

        var newShield = hero.GetShield();
        Assert.IsTrue(originalShield <= newShield);
    }
}
