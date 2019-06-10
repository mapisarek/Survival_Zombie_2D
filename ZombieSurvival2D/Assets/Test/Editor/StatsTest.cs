using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StatsTest 
{
    [Test]
    [TestCase(100, 0, 50)]
    [TestCase(0, 0, 0)]
    [TestCase(120, 1240, 12310)]
    public void PlayerStatsNotMinu(int currentHealth, int currentArmour, int currentStamina)
    {
        var n = new Stats1(currentHealth, currentArmour, currentStamina);
        Assert.GreaterOrEqual(currentHealth, 0);
        Assert.GreaterOrEqual(currentArmour, 0);
        Assert.GreaterOrEqual(currentStamina, 0);


    }
    public void PlayerRegenNotMinu(int canRegenerate, int canRegenerateeat)
    {
        var n = new Stats2(canRegenerate, canRegenerateeat);
        Assert.GreaterOrEqual(canRegenerate, 0);
        Assert.GreaterOrEqual(canRegenerateeat, 0);


    }





}
