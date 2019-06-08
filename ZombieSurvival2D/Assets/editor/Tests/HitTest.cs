using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HitTest
    {
        [Test]
        public void HitTestSimplePasses()
        {
            Movement movement = new Movement();
            Assert.IsTrue( movement.speed==0);
        }

        [UnityTest]
        public IEnumerator HitTestWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
