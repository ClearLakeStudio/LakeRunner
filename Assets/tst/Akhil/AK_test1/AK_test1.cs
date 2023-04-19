using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class AK_test1
{

   /* HealthBar health1; */

    //GameObject HealthBar = Resources.Load<GameObject>("HealthBar");

    public GameObject HealthBar; 
   // int var = HealthBar.maxHealth;

//    GameObject health = GameObject.Instantiate(SetMaxHealth);

    [Test]
    public void AK_test1SimplePasses()
    {
                   // var SpawnObj = Instantiate(health1);
       /* health1 = GameObject.Find("HealthBar").GetComponent<HealthBar>(); 
       health1.SetMaxHealth;
        HealthBarVal = GameObject.Find ("HealthBar").GetComponent <Slider> ().value;
        Assert.AreEqual(health1.maxHealth, 100);
        

        Assert.AreEqual(health1.UpdateHealth(70), 70);

        Assert.AreEqual(health1.UpdateHealth(10), 10);

        Assert.AreEqual(health1.UpdateHealth(-10), -10);   */

    }  


    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AK_test1WithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
