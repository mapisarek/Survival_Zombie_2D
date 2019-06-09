using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Player_test
    {
        [Test]
        public void NewTestScriptSimplePasses()
        {
        }
        [TestCase(100,100,100)]
        public void PlayerStatsMax100(int maxHealth,int maxArmour,int maxStamina)
        {
            var n = new Stats(maxHealth, maxArmour, maxStamina);
            Assert.AreEqual(maxHealth, 100);
            Assert.AreEqual(maxArmour, 100);
            Assert.AreEqual(maxStamina, 100);
        }

        [TestCase(100)]
        public void PlayerStatsNotMinu()
        {
            var n = new Stats();
            Assert.GreaterOrEqual(, 100);

        }



        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
