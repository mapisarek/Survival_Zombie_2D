using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Test
    {
        [Test]
        public void TestSimplePasses()
        {

        }

        [UnityTest]
        public IEnumerator TestWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
