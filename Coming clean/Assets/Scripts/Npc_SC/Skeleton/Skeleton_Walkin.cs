using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Walkin : Patrol_Npc
{
    // Start is called before the first frame updat
    public override void Enter()
    {
        base.Enter();
        dontplay = false;
    }

    // Update is called once per frame
    public override void Do()
    {
        base.Do();
        float frame = (float)timer % 1;
        frame = Helpers.Map(frame, 0, 1, 0, 1, true);
        if (frame > 0.6f)
            rb.velocity = new Vector2(ms, 0);
        else rb.velocity = new Vector2(0, 0);
        if (frame == 1)
            frame = 0;
        animator.Play(anim.name, 0, frame);
        if(timer>= 5)
         {
            machine_npc.Set(npc.idle);
         }
    }

}
