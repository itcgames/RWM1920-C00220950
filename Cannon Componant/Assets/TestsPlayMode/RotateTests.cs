using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RotateTests
    {
        private GameObject gameObject;

        [SetUp]
        public void Setup()
        {
            gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cannon"));
            Rotate script = gameObject.GetComponent<Rotate>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(gameObject);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void RotateTestsSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator BarrelRotationIsUpdatedWithAngle()
        {
            Rotate script = gameObject.GetComponent<Rotate>();
            gameObject.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, 180);
            script.angle = 0;
            script.autoRotate = false;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            yield return new WaitForSeconds(0.1f);

            float result = gameObject.transform.GetChild(0).transform.localEulerAngles.z;
            float expectedResult = 0;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
