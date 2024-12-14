using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class AttackState : PlayerState
{
    private Collider2D colliders;
    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(0,0);
    }
    public override void Do()
    {
        base.Do();
        if(timer>2)
        {
            machine.forced();
            machine.Set(player.idle);} 
    }
    public override void Exit()
    {
        base.Exit();
    }
}
