using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{

    private Transform target;
    

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    protected override void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
}
