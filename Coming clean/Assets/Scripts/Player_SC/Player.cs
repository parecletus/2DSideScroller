using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class Player : Entity
{
    #region States 
    [Header("States")]
    // Instead of declaring states at the game start we put them on inspector.
    public IdleState idle;
    public RunState run;
    public AirState air;
    public DashState dash;
    public WallSlide wallSlide;
    public WallJump wallJump;
    public AttackState attack;
    #endregion
    public float xInput;
    public float yInput;

    #region Movement
    [Header("Movement")]
    // Veriables
    [Range(0f, 1f)]
    public float groundDecay = 1f;
    public float acceleration = 2;
    public float ms = 4;
    public bool enable_Damage;
    #endregion
    public void Awake()
    {
        SetUp(this, grounded);
    }
    public void Start()
    {
        // AnimationUtility.SetAnimationEvents(animator,some animation event)
        machine.Start(idle);
    }

    public void Update()
    {
        machine.state.Do();
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
    public void FixedUpdate()
    {
        machine.state.FixedDo();
    }
    public void SetUp(Entity _entity, Grounded _grounded)
    {
        machine = new StateMachine();
        Player player = _entity as Player;
        if (player != null)
        {
            State[] allChilds = player.GetComponentsInChildren<State>(); // finds all states under player script
            foreach (State state in allChilds)
            {
                // for each state we declare animator, player and grounded. 
                state.animator = this.animator;
                state.SetPlayer(player, grounded);
            }
        }
    }

}
