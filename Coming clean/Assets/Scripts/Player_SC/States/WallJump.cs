using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : PlayerState
{
    public float wjs_x;
    public float wjs_y;
    public float wjs_dur;
    public override void Enter()
    {
        base.Enter();
        dontplay = false;
    }
    public override void Do()
    {
        animator.Play(anim.name);
        rb.velocity = new Vector2(player.transform.localScale.x * -1 * wjs_x, wjs_y);

        base.Do();
        if (timer > wjs_dur)
            machine.Set(player.air);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
