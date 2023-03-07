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
        yield return new WaitForSeconds(1); //1 second is a timely majic number
        Assert.IsTrue(0<obj.transform.position.y);
    }
}
