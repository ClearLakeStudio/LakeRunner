using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TerrIsDeleted
{
    [UnityTest]
    public IEnumerator TerrIsDeletedTest(){


        yield return null;
        Assert.AreEqual(1,1);
    }
}