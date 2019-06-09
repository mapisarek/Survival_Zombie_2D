using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MonstarSpawn_test
    {
        [Test]
        public void NewTestScriptSimplePasses()
        {
        }
        [TestCase(100, 10, 50, 10)]
        public void monsterSpawnNotZero(int waitingForNextSpawn, int theCountdown, int animalAmount, int monstersAmount)
        {
            var n = new Stats_monsterSpawn(waitingForNextSpawn, theCountdown, animalAmount, monstersAmount);
            Assert.GreaterOrEqual(waitingForNextSpawn, 0);
            Assert.GreaterOrEqual(theCountdown, 0);
            Assert.GreaterOrEqual(animalAmount, 0);
            Assert.GreaterOrEqual(monstersAmount, 0);

        }




        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
