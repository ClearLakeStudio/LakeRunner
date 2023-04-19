using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class FrogAttack
{
    [UnityTest]
    public IEnumerator AttackSpeed()
    {
        GameObject obj = GameObject.FindWithTag("Enemy");
        while(obj==null){
            yield return new WaitForSeconds(0.5f);
            obj = GameObject.FindWithTag("Enemy");
        }
        Assert.IsTrue(obj.GetComponent<Enemy>().attacktimer > 0.1f);
    }
}
