using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TerrIsCreated
{
    [SetUp]
    public void MySetUp(){
        SceneManager.LoadScene(1);
    }

    [UnityTest]
    public IEnumerator TerrIsCreatedTest(){
        new WaitForSeconds(0.1f);

        var terrExists = GameObject.FindWithTag("Terrain");

        yield return null;
        Assert.IsNotNull(terrExists);
    }

    [TearDown]
    public void MyTearDown(){
        SceneManager.UnloadSceneAsync(1);
    }

}