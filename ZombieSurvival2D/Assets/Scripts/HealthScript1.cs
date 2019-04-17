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


    }

   
}
