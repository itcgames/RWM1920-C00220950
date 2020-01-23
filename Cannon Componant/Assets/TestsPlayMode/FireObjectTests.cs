using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace MovementTests
{
    public class FireObjectTests : MonoBehaviour
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

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator BulletIsFired()
        {
            //CannonBall(Clone)
            FireObject script = gameObject.GetComponent<FireObject>();

            script.FireBullet();   
            yield return new WaitForSeconds(0.1f);

            bool result = GameObject.Find("CannonBall(Clone)");

            Assert.IsTrue(result);
        }
    }
}
