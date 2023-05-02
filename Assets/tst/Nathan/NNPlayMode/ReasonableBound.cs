// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;

// public class ReasonableBounds
// {
//     [UnityTest]
//     public IEnumerator FindBounds()
//     {
//         GameObject obj = GameObject.FindWithTag("Hero");
//         Assert.IsTrue(obj!=null);
//         Hero hero = obj.GetComponent<Hero>();
//         Assert.IsTrue((-5 > hero.gameBoundaryLow.x) && (-5 > hero.gameBoundaryLow.y));
//         Assert.IsTrue((20 < hero.gameBoundaryHigh.x) && (10 < hero.gameBoundaryHigh.y));
//         return null;
//     }
// }
