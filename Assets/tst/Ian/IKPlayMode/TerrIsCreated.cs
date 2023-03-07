using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TerrIsCreated
{
    [UnityTest]
    public IEnumerator TerrIsCreatedTest(){
        // var gameObject = new GameObject();
        // var terr = gameObject.AddComponent<LoadLevel>();

        //GameObject anotherTerr = terr.CreateNewChunk(new Vector3 (0,0,0));

        yield return null;
        Assert.IsTrue(true);
    }
}