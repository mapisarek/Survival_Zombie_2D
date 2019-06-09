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

        public void monsterSpawn(int waitingForNextSpawn, int theCountdown, int animalAmount, int monstersAmount)
        {
            var n = new Stats_monsterSpawn(waitingForNextSpawn, theCountdown, animalAmount, monstersAmount);


        }




        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
