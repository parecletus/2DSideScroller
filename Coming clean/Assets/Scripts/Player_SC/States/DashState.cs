using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
    public float dashms;
    public float dashdur;
    public override void Enter()
    {
        base.Enter();
        dontplay = false;
    }
    public override void Do()
    {
        base.Do();
        animator.Play("Dash");
        rb.velocity = new Vector2(dashms * player.transform.localScale.x, 0);

        if (timer > dashdur){
            machine.forced();
            IdleRun();}
    }
    public override void Exit()
    {
        base.Exit();
        rb.velocity = new Vector2(0, 0);
    }
}
