using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
	GameObject gm;
	[SetUp]
	public void Setup() 
	{
		if(gm == null) {
		gm = Resources.Load<GameObject>("Game_Manager");
		gm = MonoBehaviour.Instantiate(gm);
		}
	}

    [UnityTest]
    public IEnumerator PlayerActiveMovementTest()
   {
		float diverBefore, diverAfter;
		yield return new WaitForSeconds(1);
		gm.GetComponent<Game>().startGame();
		GameObject diver = GameObject.FindWithTag("Player");
		diverBefore = diver.transform.position.y;
		yield return new WaitForSeconds(1);
		diverAfter = diver.transform.position.y;
		Assert.AreNotEqual(diverBefore,diverAfter);
   }

   [UnityTest]
   public IEnumerator PlayerMovementGameStoppedTest()
   {
		gm.GetComponent<Game>().stopGame();
		yield return new WaitForSeconds(1);
		float diverBefore, diverAfter;
		GameObject diver = GameObject.FindWithTag("Player");
		diverBefore = diver.transform.position.y;
		yield return new WaitForSeconds(1);
		diverAfter = diver.transform.position.y;
		Assert.AreEqual(diverBefore,diverAfter);
   }

}

