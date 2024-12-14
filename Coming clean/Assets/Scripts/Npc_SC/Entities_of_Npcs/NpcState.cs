using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState : State
{
    public StateMachine machine_npc => npc.machine;
    public Rigidbody2D rb => npc.rb;
    public override void Enter()
    {
        base.Enter();
    }
    public override void Do()
    {
        base.Do();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
