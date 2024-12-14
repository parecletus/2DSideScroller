using UnityEditor.U2D.Aseprite;
using UnityEngine;

public abstract class PlayerState : State
{
    public Rigidbody2D rb => player.rb;
    public Collider2D coll => player.coll;
    public StateMachine machine => player.machine;
    public bool StopMovement= false;
    public override void Enter()
    {
        base.Enter();
        animator.speed = 1;
    }
    public override void Do()
    {
        base.Do();
        if(!StopMovement) // With this i dont have to make a bool to stop movement for each state
            MoveWInput();
        if (Input.GetButtonDown("Jump"))
        {   //Checks if there is a wall 
            if (player.wallSlide.wallsliding)
                machine.Set(player.wallJump);
            else 
                machine.Set(player.air);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            machine.Set(player.dash,true);
        if(grounded.Ground()&& Input.GetMouseButtonDown(0))
            machine.Set(player.attack,true);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void FixedDo()
    {
        base.FixedDo();
    }

    public void MoveWInput()
    {
        if (Mathf.Abs(player.xInput) > 0)
        {
            float increment = player.xInput * player.acceleration;
            float newSpeed = Mathf.Clamp(rb.velocity.x + increment, -player.ms, player.ms);
            rb.velocity = new Vector2(newSpeed, rb.velocity.y);

            float direction = Mathf.Sign(player.xInput);
            grounded.Facing(direction);
            player.transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    public void Player_ApplyFriction()
    {
        if (grounded.Ground() && player.xInput == 0 && rb.velocity.y <= 0)
        {
            rb.velocity *= player.groundDecay;
        }
    }
    public void Airbone()
    {
        if (!grounded.Ground())
            machine.Set(player.air);
    }
    public void IdleRun()
    {
        if (player.xInput == 0)
            machine.Set(player.idle);
        else machine.Set(player.run);
    }

}
