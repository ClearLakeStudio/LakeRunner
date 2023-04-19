using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StairInheritance
{
    [UnityTest]
    public IEnumerator StairInheritsTest()
    {
        var theTerr = new GameObject();
        theTerr.AddComponent<LoadLevel>();

        TerrStair stairs = new TerrStair(theTerr);
        stairs.SetPos(new Vector2(0,0));

        Debug.Log(stairs.terrPos.y);

        Assert.IsTrue(stairs.terrPos.y == -0.75f);
        return null;
    }
}
