using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class HeroForward
{
    [UnityTest]
    public IEnumerator RunDir()
    {
        GameObject obj = GameObject.FindWithTag("Hero");
        Assert.IsTrue(obj!=null);
        Hero hero = obj.GetComponent<Hero>();
        yield return new WaitForSeconds(1); //1 second is a timely majic number
        Assert.IsTrue(0 < hero.GetPosition().x);
    }
}
