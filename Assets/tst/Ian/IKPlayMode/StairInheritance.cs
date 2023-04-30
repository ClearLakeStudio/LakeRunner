using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StairInheritance
{    
    [UnityTest]
    public IEnumerator StairInheritsTest()
    {
        GameObject theTerr = (GameObject)Resources.Load("TerrStairGreen");

        TerrParent stairs = new TerrStair(theTerr);
        stairs.SetPos(new Vector2(0,0));
        theTerr = stairs.CreateChunk();

        Assert.IsTrue(theTerr.transform.position.y == -0.75f);
        return null;
    }
}
