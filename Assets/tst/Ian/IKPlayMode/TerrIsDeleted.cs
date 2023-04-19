using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TerrIsDeleted
{
    [UnityTest]
    public IEnumerator TerrIsDeletedTest(){
        // var hero = new GameObject();
        // hero.gameObject.transform.position = new Vector2(0,0);
        // hero.gameObject.tag = "Hero";
        var hero = GameObject.FindWithTag("Hero");
        
        var terr = new GameObject();
        terr.gameObject.transform.position = new Vector2(0,0);
        terr.AddComponent<TerrainBehavior>();

        hero.transform.position = new Vector2(42, 0);
        new WaitForSeconds(0.1f);

        yield return null;
        Assert.IsNull(terr);
        Assert.IsNotNull(hero);
    }
}