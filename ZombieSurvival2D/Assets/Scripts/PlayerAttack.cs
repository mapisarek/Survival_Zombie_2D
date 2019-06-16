using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    IEnemy[] enemies;
    Collider2D[] enemiesToDamage;
    PlayerAttackHandler playerAttackHandler;
    public bool keyPressed;

    private void Awake()
    {
        playerAttackHandler = new PlayerAttackHandler();
    }

    void Update()
    {
        keyPressed = Input.GetKeyDown(KeyCode.Space);
        DetectEnemiesAround();
    }



    public void DetectEnemiesAround()
    {
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        if (enemiesToDamage.Length > 0)
        {
            foreach (var item in enemiesToDamage)
            {
                var enemy = item.GetComponent<IEnemy>();
                playerAttackHandler.attackInRange(enemy, damage, timeBtwAttack, startTimeBtwAttack, keyPressed);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}

public class PlayerAttackHandler
{

    public void attackInRange(IEnemy enemiesToDamage, int damage, float timeBtwAttack, float startTimeBtwAttack, bool input)
    {
        if (timeBtwAttack <= 0)
        {
            if (input)
            {
                if (damage > 0)
                {
                    var enemy = enemiesToDamage;
                    enemy.HealthValue -= damage;

                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

}

