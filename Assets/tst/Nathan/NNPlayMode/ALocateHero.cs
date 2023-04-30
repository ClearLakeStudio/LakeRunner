using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ALocateHero
{

    [UnityTest]
    public IEnumerator Locate()
    {
        GameObject obj = GameObject.FindWithTag("Hero");
        Assert.IsTrue(obj!=null);
        Hero hero = obj.GetComponent<Hero>();
        Assert.IsTrue((-1 < hero.GetPosition().y) && (-1 < hero.GetPosition().x) && (1 > hero.GetPosition().y) && (1 > hero.GetPosition().x));
        return null;
    }
}
