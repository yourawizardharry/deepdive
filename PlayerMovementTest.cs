using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
	GameObject diver;
	public Camera cam;
	PlayerMovement PlayerMovementScript;

	[SetUp]
	public void Setup() 
	{
		if(diver == null) {
				cam = Resources.Load<Camera>("Main Camera");
                cam = MonoBehaviour.Instantiate(cam);
                diver = Resources.Load<GameObject>("diver");
                diver = MonoBehaviour.Instantiate(diver);
                diver.AddComponent<PlayerMovement>();
				PlayerMovementScript = diver.GetComponent<PlayerMovement>();
		}
	}

    [UnityTest]
    public IEnumerator PlayerActiveMovementTest()
   {
		float diverBefore, diverAfter;
		PlayerMovementScript.startMovement();
		GameObject diver = GameObject.FindWithTag("Player");
		diverBefore = diver.transform.position.y;
		yield return new WaitForSeconds(1);
		diverAfter = diver.transform.position.y;
		Assert.AreNotEqual(diverBefore,diverAfter);
   }

   [UnityTest]
   public IEnumerator PlayerMovementGameStoppedTest()
   {
		PlayerMovementScript.stopMovement();
		float diverBefore, diverAfter;
		GameObject diver = GameObject.FindWithTag("Player");
		diverBefore = diver.transform.position.y;
		yield return new WaitForSeconds(1);
		diverAfter = diver.transform.position.y;
		Assert.AreEqual(diverBefore,diverAfter);
   }


}

