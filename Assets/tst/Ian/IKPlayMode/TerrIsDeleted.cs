using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TerrIsDeleted
{
    [UnityTest]
    public IEnumerator TerrIsDeletedTest(){
        var hero = new GameObject();
        hero.gameObject.transform.position = new Vector2(0,0);
        hero.gameObject.tag = "Hero";
        // hero.AddComponent<RigidBody2D>();
        // hero.AddComponent<Hero>();
        
        var terr = new GameObject();
        terr.gameObject.transform.position = new Vector2(0,0);
        terr.AddComponent<TerrainBehavior>();

        hero.gameObject.transform.position = new Vector2(0, 40.1f);

        yield return null;
        Assert.IsNotNull(terr);
    }
}