using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class IdleState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void Do()
    {
        base.Do();

        Player_ApplyFriction();
        if (player.xInput != 0)
            machine.Set(player.run);
        float framer = anim.length % anim.frameRate;
        if (timer >= 10)
        {
            timer = 0;
        }
        int frame = (int)(framer * timer);
        Airbone();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
