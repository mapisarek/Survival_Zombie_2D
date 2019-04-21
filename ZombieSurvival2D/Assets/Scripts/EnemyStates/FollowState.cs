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

    }

    public void Update()
    {
        parent.Direction = (parent.Target.transform.position - parent.Target.transform.position);
        parent.transform.position = Vector3.MoveTowards(parent.transform.position, parent.Target.position, parent.Speed * Time.deltaTime);
    }
}