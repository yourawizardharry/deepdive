using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerControlsTest
    {
        public GameObject diver;
        public Camera cam;

        [SetUp]
        public void Setup()
        {
            if (diver == null)
            {
                cam = Resources.Load<Camera>("Main Camera");
                cam = MonoBehaviour.Instantiate(cam);
                diver = Resources.Load<GameObject>("diver");
                diver = MonoBehaviour.Instantiate(diver);
                diver.GetComponent<PlayerControls>().addCamera(cam);
            }
        }

        [UnityTest]
        public IEnumerator MoveLeftWithinBounds()
        {
            Vector3 beforeMove, afterMove;
            beforeMove = diver.transform.position;
            diver.GetComponent<PlayerControls>().updatePosition(diver.transform.position.x - 2); //get camera bounds and do this nicely
            yield return new WaitForSeconds(1);
            afterMove = diver.transform.position;
            diver.transform.position = beforeMove;
            Debug.Log(beforeMove);
            Debug.Log(afterMove);
            Assert.IsTrue(beforeMove.x > afterMove.x);
            yield return null;
        }

        [UnityTest]
        public IEnumerator MoveRightWithinBounds()
        {
            Vector3 beforeMove, afterMove;
            beforeMove = diver.transform.position;
            diver.GetComponent<PlayerControls>().updatePosition(diver.transform.position.x + 2); //get camera bounds and do this nicely
            yield return new WaitForSeconds(1);
            afterMove = diver.transform.position;
            diver.transform.position = beforeMove;
            Debug.Log(beforeMove);
            Debug.Log(afterMove);
            Assert.IsTrue(beforeMove.x < afterMove.x);
            yield return null;
        }

        [UnityTest]
        public IEnumerator MoveRightOutOfBounds()
        {
            Vector3 beforeMove, afterMove;
            beforeMove = diver.transform.position;
            diver.GetComponent<PlayerControls>().updatePosition(diver.transform.position.x + 20); //get camera bounds and do this nicely
            yield return new WaitForSeconds(1);
            afterMove = diver.transform.position;
            diver.transform.position = beforeMove;
            Debug.Log(beforeMove);
            Debug.Log(afterMove);
            Assert.IsTrue(beforeMove.x == afterMove.x);
            yield return null;
        }

        [UnityTest]
        public IEnumerator MoveLeftOutOfBounds()
        {
            Vector3 beforeMove, afterMove;
            beforeMove = diver.transform.position;
            diver.GetComponent<PlayerControls>().updatePosition(diver.transform.position.x - 20); //get camera bounds and do this nicely
            yield return new WaitForSeconds(1);
            afterMove = diver.transform.position;
            diver.transform.position = beforeMove;
            Debug.Log(beforeMove);
            Debug.Log(afterMove);
            Assert.IsTrue(beforeMove.x == afterMove.x);
            yield return null;
        }
    }
}
