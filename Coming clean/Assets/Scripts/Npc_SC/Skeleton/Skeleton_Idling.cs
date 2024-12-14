using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Idling : Idle_Npc
{
    public override void Enter()
    {
        base.Enter();   
        rb.velocity = new Vector2(0, 0);
        dontplay = false;
        animator.Play(anim.name);

    }

    public override void Do()
    {
        base.Do();
    }
}
