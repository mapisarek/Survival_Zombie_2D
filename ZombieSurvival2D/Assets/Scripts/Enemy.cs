using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{

    [SerializeField]
    private CanvasGroup healthGroup;
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
            direction = (target.transform.position - transform.position);
            healthGroup.alpha = 1;
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
        }
        else
        {
            healthGroup.alpha = 0;
        }
    }

    public override void TakeDamage(float damage)
    {
        direction = Vector2.zero;
        base.TakeDamage(damage);
    }
}
