using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class HeroUpward
{
    [UnityTest]
    public IEnumerator JumpDir()
    {
        GameObject obj = GameObject.FindWithTag("Hero");
        Assert.IsTrue(obj!=null);
        Hero hero = obj.GetComponent<Hero>();
        hero.Jump();
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(0 < hero.GetPosition().y);
    }
}
