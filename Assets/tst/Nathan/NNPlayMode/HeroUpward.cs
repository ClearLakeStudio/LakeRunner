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
        //SceneManager.LoadScene("GameScene");
        GameObject obj = GameObject.FindWithTag("Hero");
        obj.GetComponent<Hero>().Jump();
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(0<obj.transform.position.y);
    }
}
