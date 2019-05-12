using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class FollowState : IState
{
    private Enemy parent;

    public void Enter(Enemy parent)
    {
        this.parent = parent;
    }

    public void Exit()
    {
        parent.Direction = Vector3.zero;
    }

    public void Update()
    {
        if(parent.Target != null)
        {
            parent.Direction = (parent.Target.transform.position - parent.transform.position).normalized;
            parent.transform.position = Vector3.MoveTowards(parent.transform.position, parent.Target.position, parent.Speed * Time.deltaTime);
        }
        else
        {
            parent.ChangeState(new IdleState());
        }
    }
} 