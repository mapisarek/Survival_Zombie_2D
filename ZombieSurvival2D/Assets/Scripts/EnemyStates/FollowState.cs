using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}