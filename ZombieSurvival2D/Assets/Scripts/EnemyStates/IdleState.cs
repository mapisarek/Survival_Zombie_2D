using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class IdleState : IState
{
    private Enemy parent;

    public void Enter(Enemy parent)
    {
        this.parent = parent;
    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (parent.Target != null)
        {
            parent.ChangeState(new FollowState());
        }
    }
}
