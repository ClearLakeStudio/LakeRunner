using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LoadLevel
{
    private GameObject[] levelMenus;

    [UnityTest]
    public IEnumerator LoadLevelWithEnumeratorPasses()
    {
        SceneManager.LoadScene("Overworld");
        yield return null;

        levelMenus = GameObject.FindGameObjectsWithTag("Level Menu");

        foreach (GameObject levelMenu in levelMenus) {
            LevelMenu menu = levelMenu.GetComponent<LevelMenu>();

            menu.unlocked = false;
            menu.menuButton.onClick.Invoke();
            yield return new WaitForSeconds(1);
            Assert.AreNotEqual(menu.levelName, SceneManager.GetActiveScene().name);

            SceneManager.LoadScene("Overworld");
            yield return null;

            menu.unlocked = true;
            menu.menuButton.onClick.Invoke();
            yield return new WaitForSeconds(1);
            Assert.AreEqual(menu.levelName, SceneManager.GetActiveScene().name);

            SceneManager.LoadScene("Overworld");
            yield return null;
        }
    }
}
