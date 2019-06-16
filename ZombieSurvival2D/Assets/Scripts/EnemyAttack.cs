using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{

    EnemyAttackHandler enemyAttackHandler;

    private void Awake()
    {
        enemyAttackHandler = new EnemyAttackHandler();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayer player = collision.GetComponent<IPlayer>();
        if (player != null)
        {
            enemyAttackHandler.PlayerEnteredHandler(player, this.damage);
        }
    }

}

public class EnemyAttackHandler
{

    public void PlayerEnteredHandler(IPlayer player, int damage)
    {
        if (player != null)
        {
            if (player.HealthValue > 0 && damage > 0)
                player.HealthValue -= damage;
            if (player.HealthValue < 0)
                player.HealthValue = 0;

        }
    }
}