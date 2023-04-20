using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HighInheritance
{
    [UnityTest]
    public IEnumerator HighInheritsTest()
    {
        GameObject theTerr = (GameObject)Resources.Load("HighTerrGreen");

        TerrParent high = new TerrHigh(theTerr);
        high.SetPos(new Vector2(0,0));
        theTerr = high.CreateChunk();

        Assert.IsTrue(theTerr.transform.position.y == -1.0f);
        return null;
    }
}