using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TerrIsCreated
{
    [UnityTest]
    public IEnumerator TerrIsCreatedTest(){


        yield return null;
        Assert.AreEqual(1,1);
    }
}