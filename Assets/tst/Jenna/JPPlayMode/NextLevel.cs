using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NextLevel
{
    private OverworldManager overworldManager;
    private LevelDatastore datastore;
    private GameObject[] levels;

    [UnityTest]
    public IEnumerator NextLevelWithEnumeratorPasses()
    {
        SceneManager.LoadScene("Overworld");
        yield return null;

        overworldManager = GameObject.FindGameObjectWithTag("OverworldManager").GetComponent<OverworldManager>();
        datastore = overworldManager.datastore;

        levels = GameObject.FindGameObjectsWithTag("Level");

        for (int i = 0; i < 100; i++) {
            string currentLevel = levels[Random.Range(0, 4)].name;
            datastore.FinishLevel(currentLevel);
            int nextLevel = datastore.GetNextLevel();

            if (int.Parse(currentLevel.Replace("Level", "")) < 5) {
                Assert.AreEqual(expected: int.Parse(currentLevel.Replace("Level", "")) + 1, actual: nextLevel);
            } else {
                Assert.AreEqual(expected: 5, actual: nextLevel);
            }

            yield return null;
        }
    }

    [UnityTest]
    public IEnumerator HeroPositionWithEnumeratorPasses()
    {
        SceneManager.LoadScene("Overworld");
        yield return new WaitForSeconds(1);

        overworldManager = GameObject.FindGameObjectWithTag("OverworldManager").GetComponent<OverworldManager>();
        OverworldMap overworld = overworldManager.overworld;
        datastore = overworldManager.datastore;
        GameObject hero = GameObject.Find("Hero");
        int nextLevel = datastore.GetNextLevel();
        Vector3 heroPosition = hero.transform.position;

        if (nextLevel < 5) {
            Assert.AreEqual(expected: overworld.heroPos[nextLevel - 1], actual: heroPosition);
        } else {
            Assert.AreEqual(expected: overworld.heroPos[4], actual: heroPosition);
        }
    }
}
