using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Tests
{   
    public class HealthScript1Test
    {

        [Test]
        public void HealthScript1TestSimplePasses()
        {
            var go = new GameObject("MyGameObject");
            Assert.AreEqual("MyGameObject", go.name);
        }

        [UnityTest]
        public IEnumerator HealthScript1TestWithEnumeratorPasses()
        {
            var go = new GameObject();
            go.AddComponent<Rigidbody>();
            var originalPosition = go.transform.position.y;







        }
    }
}
