using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript1 : MonoBehaviour
{
    public int hp = 1;
    public bool isEnemy = true;

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Dead!
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?

        Attack2 shot = otherCollider.gameObject.GetComponent<Attack2>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }


}
