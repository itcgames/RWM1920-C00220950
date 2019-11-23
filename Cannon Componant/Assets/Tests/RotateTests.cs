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
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(gameObject);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void RotateTest()
        {
            // Use the Assert class to test conditions
            Rotate rotate = gameObject.GetComponent<Rotate>();
            rotate.angle = 30;
            rotate.changeAngle(30);
            float result = rotate.angle;
            float expectedResult = 60;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void AutoRotateTest()
        {
            // Use the Assert class to test conditions
            Rotate script = gameObject.GetComponent<Rotate>();
            script.angle = 60;
            script.autoRotate = true;
            script.turnSpeed = 5;
            script.automaticMovingClockwise = false;
            script.autoAngle1 = 90;
            script.autoAngle2 = 0;

            script.handleAutomatic();

            float result = script.angle;
            float expectedResult = 65;

            Assert.AreEqual(expectedResult, result);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            yield return null;
        }
    }
}
