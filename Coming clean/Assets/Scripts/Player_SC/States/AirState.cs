using UnityEngine;

public class AirState : PlayerState
{
    public float js = 4;
    float jumpcount;
    public override void Enter()
    {
        dontplay = false;
        base.Enter();
        jumpcount = 0;
        if (Input.GetKeyDown(KeyCode.Space))
            rb.velocity = new Vector2(rb.velocity.x, player.air.js);
    }
    public override void Do()
    {
        base.Do();
        AirAnimation();
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, player.air.js);
            jumpcount++;
        }
        if (grounded.Ground())
            IdleRun();
        if (grounded.Walled())
            machine.Set(player.wallSlide);
    }

    private void AirAnimation()
    {
        if (rb.velocity.y - 0.1f < -js)
        {
            animator.speed = 1;
            animator.Play(this.anim.name);
        }
        else
        {
            float time = Helpers.Map(rb.velocity.y, js, -js, 0, 1, true);
            animator.Play("Jump", 0, time);
            animator.speed = 0;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
