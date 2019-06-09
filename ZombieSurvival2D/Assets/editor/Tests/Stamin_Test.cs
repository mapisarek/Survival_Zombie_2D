using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        [Test]
        public void NewTestScriptSimplePasses()
        {
        }





        [TestCase(1)]
        [TestCase(12)]
        [TestCase(1)]



        public void SpeedIsGreatherOrEqualThanZero(int speed)
        {
            var n = new Movementx(speed);

            Assert.GreaterOrEqual(speed, 1);

        }

        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
