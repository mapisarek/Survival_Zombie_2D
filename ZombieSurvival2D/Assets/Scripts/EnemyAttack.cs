using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("Player collision - dmg");
            player.damagePlayer(damage);
        }
    }

}
