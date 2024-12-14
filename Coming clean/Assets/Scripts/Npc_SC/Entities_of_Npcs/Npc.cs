using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Npc : Entity
{
    #region  States
    public Idle_Npc idle;
    public Patrol_Npc patrol;
    public Attack_Npc attack;
    #endregion
    public float groundDecay = 1f;
    public int health_Bar =  100;
    public void Awake()
    {
        SetUp(this, grounded);// Grounded gets the info
        machine.Start(idle);// Starts with idle
    }
    public void Update()
    {
        machine.state.Do();// Keep States Running 
    }
    public void SetUp(Entity _entity, Grounded _grounded) // Works 
    {
        machine = new StateMachine();// New StateMachine for each npc script
        Npc npc = _entity as Npc;

        if (npc != null)
        {
            State[] allChilds = npc.GetComponentsInChildren<State>(); // Get the states
            Debug.Log("Parent of states " + _entity.name + " \n      " + " Number of states " + allChilds.Length); 
            foreach (State state in allChilds) // for every state there is 
            {
                state.animator = this.animator; // Set up Animator
                state.SetNpc(npc, grounded); // Set up this script
            }
        }
    }
}
