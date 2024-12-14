using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        
    }
    public override void Do()
    {
        base.Do();
        if (player.xInput == 0 && grounded.Ground())
            machine.Set(player.idle);
        Airbone();
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void FixedDo()
    {
        base.FixedDo();
    }
}
