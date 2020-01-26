using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FireTests : MonoBehaviour
    {
        private GameObject gameObject;

        [SetUp]
        public void Setup()
        {
            gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cannon"));
        }

        [TearDown]
        public void Teardown()
        {
            GameObject[] allObjects = FindObjectsOfType<GameObject>();
            foreach (GameObject go in allObjects)
                Destroy(go);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator FireAGameObject()
        {
            FireObject script = gameObject.GetComponent<FireObject>();
            script.FireBullet();

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            yield return new WaitForSeconds(0.1f);

            GameObject result = GameObject.Find("CannonBall(Clone)");

            Assert.IsNotNull(result);
        }

        [UnityTest]
        public IEnumerator AutoFiringAGameObject()
        {
            FireObject script = gameObject.GetComponent<FireObject>();
            script.autoFire = true;
            script.fireDelay = 0.01f;
            script.fireOnce = false;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            yield return new WaitForSeconds(0.1f);

            GameObject result = GameObject.Find("CannonBall(Clone)");

            Assert.IsNotNull(result);
        }
    }
}
