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

        public void PlayerStatsMax100(int maxHealth,int maxArmour,int maxStamina)
        {
            var n = new Stats(maxHealth, maxArmour, maxStamina);


        }


        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
