using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace MovementTests
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
            Object.Destroy(gameObject);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void MovementTestsSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GameObjectCanMove()
        {
            Movement script = gameObject.GetComponent<Movement>();
            gameObject.transform.position = new Vector3(0, 0, 0);
            Vector3 initial = gameObject.transform.position;
            script.speed = 2.0f;

            script.MoveTo(new Vector2(0,10));
            yield return new WaitForSeconds(0.1f);

            Vector3 result = gameObject.transform.position;
            Debug.Log(result);

            Assert.AreNotEqual(initial, result);
        }
    }
}
