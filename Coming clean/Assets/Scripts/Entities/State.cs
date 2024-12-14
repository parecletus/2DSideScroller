using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class State : MonoBehaviour
{
  public Animator animator;
  public Grounded grounded { get; private set; }
  public Player player { get; private set; }
  public Npc npc { get; private set; }
  public AnimationClip anim;
  public bool dontplay = true;
  public float timer ;
  public virtual void Enter()
  {
    if (dontplay | anim != null)
      animator.Play(anim.name);
    timer = 0;
  }
  public virtual void Do()
  {
    timer += Time.deltaTime;
  }
  public virtual void FixedDo()
  {

  }
  public virtual void Exit()
  {
    dontplay = true;
  }
  public void SetPlayer(Player _entity, Grounded _grounded)
  {
    player = _entity;
    grounded = _grounded;
  }
  public void SetNpc(Npc _npc, Grounded _grounded)
  {
    npc = _npc;
    grounded = _grounded;
  }
}
