using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class WallSlide : PlayerState
{
    public bool wallsliding;
    public override void Enter()
    {
        base.Enter();
        wallsliding = true;
        dontplay = false;
        rb.velocity = new Vector2(0, 0);
    }
    public override void Do()
    {
        base.Do();
        animator.Play("WallSlide");
        rb.velocity = new Vector2(0, rb.velocity.y + player.yInput * 0.2f);
        if (grounded.Ground())
            machine.Set(player.idle);
    }
    public override void Exit()
    {
        base.Exit();
        wallsliding = false;
    }
}
