using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
	GameObject diver;
	public Camera cam;

	[SetUp]
	public void Setup() 
	{
		if(diver == null) {
				cam = Resources.Load<Camera>("Main Camera");
                cam = MonoBehaviour.Instantiate(cam);
                diver = Resources.Load<GameObject>("PlayerObjects\\diver");
                diver = MonoBehaviour.Instantiate(diver);
		}
	}

    [UnityTest]
    public IEnumerator PlayerActiveMovementTest()
   {
		float diverBefore, diverAfter;
		GameObject diver = GameObject.FindWithTag("Player");
		diverBefore = diver.transform.position.y;
		yield return new WaitForSeconds(1);
		diverAfter = diver.transform.position.y;
		Assert.AreNotEqual(diverBefore,diverAfter);
   }

   [UnityTest]
   public IEnumerator PlayerMovementGameStoppedTest()
   {
		float diverBefore, diverAfter;
		GameObject diver = GameObject.FindWithTag("Player");
		 diver.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
		diverBefore = diver.transform.position.y;
		yield return new WaitForSeconds(1);
		diverAfter = diver.transform.position.y;
		Assert.AreEqual(diverBefore,diverAfter);
   }


}

