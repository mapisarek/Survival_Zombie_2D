using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSubstitute;
using NUnit;

public class AttackTest
{
    [Test]
    //Enemy got dmg -10hp
    [TestCase(10, 0, 0, true)]
    //Player can attack if cooldown is <= set value
    [TestCase(10, -5, -5, true)]
    public void PlayerIsAttacking_EnemiesInRange(int damage, float timeBtwAttk, float startTimeAttk, bool input)
    {
        PlayerAttackHandler playerAttackHandler = new PlayerAttackHandler();
        IEnemy enemy = Substitute.For<IEnemy>();
        enemy.HealthValue = 100;
        Assert.IsNotNull(enemy);
        playerAttackHandler.attackInRange(enemy, damage, timeBtwAttk, startTimeAttk, input);
        Assert.AreEqual(90, enemy.HealthValue);
    }

    [Test]
    //Enemy cant get dmg < 0
    [TestCase(-40, 0, 0, true)]
    //Enemy cant get dmg if player not press space button
    [TestCase(10, 0, 0, false)]
    //Player cant use attack on cooldown
    [TestCase(10, 5, 5, true)]
    public void PlayerCantAttack_EnemiesInRange(int damage, float timeBtwAttk, float startTimeAttk, bool input)
    {
        PlayerAttackHandler playerAttackHandler = new PlayerAttackHandler();
        IEnemy enemy = Substitute.For<IEnemy>();
        enemy.HealthValue = 100;
        playerAttackHandler.attackInRange(enemy, damage, timeBtwAttk, startTimeAttk, input);
        Assert.IsNotNull(enemy);
        Assert.AreEqual(100, enemy.HealthValue);
    }


    [Test]
    //Damage 1
    [TestCase(1)]
    //Damage 50
    [TestCase(50)]
    //Damage 100
    [TestCase(100)]
    public void EnemyIsAttacking_PlayerInRange(int damage)
    {
        EnemyAttackHandler enemyAttackHandler = new EnemyAttackHandler();
        IPlayer player = Substitute.For<IPlayer>();
        player.HealthValue = 100;
        //Theres player in range
        Assert.IsNotNull(player);
        enemyAttackHandler.PlayerEnteredHandler(player, damage);
        Assert.AreNotEqual(100, player.HealthValue);
    }

    [Test]
    //Damage 100
    [TestCase(100)]
    //Damage 500
    [TestCase(500)]
    //Damage 1000
    [TestCase(1000)]
    public void EnemyIsAttacking_PlayerHealthBelowZero(int damage)
    {
        EnemyAttackHandler enemyAttackHandler = new EnemyAttackHandler();
        IPlayer player = Substitute.For<IPlayer>();
        player.HealthValue = 100;
        //Health cant be below 0
        enemyAttackHandler.PlayerEnteredHandler(player, damage);
        Assert.AreEqual(0, player.HealthValue);
    }


}
