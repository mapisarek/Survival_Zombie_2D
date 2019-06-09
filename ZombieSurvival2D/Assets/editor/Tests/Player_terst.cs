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

        [TestCase(100,0,50,10,10,10,10)]
        public void PlayerStatsNotMinu(int currentHealth, int currentArmour, int currentStamina, int canRegenerate, int canRegenerateeat,int speed,int speeds)
        {
            var n = new Stats2(currentHealth, currentArmour, currentStamina, canRegenerate, canRegenerateeat, speed, speeds);
            Assert.GreaterOrEqual(currentHealth, 0);
            Assert.GreaterOrEqual(currentArmour, 0);
            Assert.GreaterOrEqual(currentStamina, 0);
            Assert.GreaterOrEqual(canRegenerate, 0);
            Assert.GreaterOrEqual(canRegenerateeat, 0);
            Assert.GreaterOrEqual(speed, 0);
            Assert.GreaterOrEqual(speeds, 0);

        }
        [TestCase()]
        public void PlayerStatsNotMinu(int currentHealth, int currentArmour, int currentStamina)
        {
            var n = new Stats3(currentHealth, currentArmour, currentStamina);
            Assert.LessOrEqual(currentHealth, 0);
            Assert.LessOrEqual(currentArmour, 100);
            Assert.LessOrEqual(currentStamina, 0);


        }


        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
