using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LoadLevel
{
    [UnityTest]
    public IEnumerator LoadLevelWithEnumeratorPasses()
    {
        var gameObject = new GameObject();
        var level = gameObject.AddComponent<OverworldLevel>();

        level.LoadLevel();

        yield return null;

        Scene currentScene = SceneManager.GetActiveScene();

        Assert.AreEqual("GameScene", currentScene.name);
    }
}