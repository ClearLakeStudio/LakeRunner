using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TerrIsCreated
{
    [UnityTest]
    public IEnumerator TerrainMake(){


        yield return null;
        //Assert.AreEqual(lastTerrainLoc % 5.12, -1);
    }
}