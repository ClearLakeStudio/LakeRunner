using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HighInheritance
{
    [UnityTest]
    public IEnumerator HighInheritsTest()
    {
        var theTerr = new GameObject();
        theTerr.AddComponent<LoadLevel>();

        TerrHigh high = new TerrHigh(theTerr);
        high.SetPos(new Vector2(0,0));

        Debug.Log(high.terrPos.y);

        Assert.IsTrue(high.terrPos.y == -1.0f);
        return null;
    }
}