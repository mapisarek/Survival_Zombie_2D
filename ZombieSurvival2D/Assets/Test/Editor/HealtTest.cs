using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class HealtTest 
{
    [Test]
    public void HeltMax_Is_max(int maxHealth,int maxArmour, int maxStamina)
    {
        var n = new Stats(maxHealth, maxArmour, maxStamina);
        Assert.AreEqual(maxHealth, 100);
        Assert.AreEqual(maxArmour, 100);
        Assert.AreEqual(maxStamina, 100);


    }



}
