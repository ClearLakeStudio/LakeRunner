using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class SelectLevel
{
    private OverworldManager overworldManager;
    private OverworldMap overworld;
    private GameObject[] levels;

    [UnityTest]
    public IEnumerator SelectLevelWithEnumeratorPasses()
    {
        SceneManager.LoadScene("Overworld");
        yield return null;

        levels = GameObject.FindGameObjectsWithTag("Level");
        overworldManager = GameObject.FindGameObjectWithTag("OverworldManager").GetComponent<OverworldManager>();
        overworld = overworldManager.overworld;

        foreach (GameObject level in levels) {
            overworld.SelectLevel(level.name);
            yield return null;
            GameObject menu = GameObject.FindGameObjectWithTag("Level Menu");
            Assert.AreEqual(expected: level.name + "Menu", actual: menu.name);
        }
    }

    [UnityTest]
    public IEnumerator ActiveLevelMenusWithEnumeratorPasses()
    {
        GameObject[] levelMenus = GameObject.FindGameObjectsWithTag("Level Menu");
        yield return null;

        if (levelMenus.Length != 0) {
            Assert.AreEqual(expected: 1, actual: levelMenus.Length);
        }
    }
}
