using UnityEngine;

public abstract class  Idle_Npc : NpcState
{
    public float start_Patrol_Timer;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idling");
    }
    public override void Do()
    {
        base.Do();
        if (timer >= start_Patrol_Timer)
            machine_npc.Set(npc.patrol);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
