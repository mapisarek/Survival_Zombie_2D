using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSubstitute;
using NUnit;

public class AttackTest
{
    [Test]
    public void PlayerIsAttacking_EnemiesInRange()
    {
        PlayerAttackHandler playerAttackHandler = new PlayerAttackHandler();
        IEnemy enemy = Substitute.For<IEnemy>();
        enemy.HealthValue = 100;
        //Enemy got dmg -10hp
        playerAttackHandler.attackInRange(enemy, 10, 0, 0, true);
        Assert.AreEqual(90, enemy.HealthValue);
        //Enemy cant get dmg < 0
        playerAttackHandler.attackInRange(enemy, -40, 0, 0, true);
        Assert.AreEqual(90, enemy.HealthValue);
        //Enemy cant get dmg if player not press space button
        playerAttackHandler.attackInRange(enemy, 10, 0, 0, false);
        Assert.AreEqual(90, enemy.HealthValue);
        //Enemy cant use attack on cooldown
        playerAttackHandler.attackInRange(enemy, 10, 5, 5, true);
        Assert.AreEqual(90, enemy.HealthValue);
        //Enemy is in range
        Assert.IsNotNull(enemy);
        //Player can attack if cooldawn is <= set value
        playerAttackHandler.attackInRange(enemy, 10, -5, 5, true);
        Assert.AreEqual(80, enemy.HealthValue);
    }

    [Test]
    public void EnemyIsAttacking_PlayerInRange()
    {

    }
}
