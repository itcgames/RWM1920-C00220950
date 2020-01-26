using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovementTests : MonoBehaviour
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

        [UnityTest]
        public IEnumerator MovesBetween2Points()
        {
            Movement script = gameObject.GetComponent<Movement>();
            script.move = true;
            script.position1 = new Vector2(0.0f, 0.0f);
            script.position2 = new Vector2(10.0f, 10.0f);
            script.speed = 10.0f;

            Vector3 previous = gameObject.transform.position;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            yield return new WaitForSeconds(0.1f);

            Vector3 result = gameObject.transform.position;

            Assert.AreNotEqual(previous, result);
        }
    }
}
