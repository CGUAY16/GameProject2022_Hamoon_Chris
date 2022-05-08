using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_JumpingState : P_BaseState
{
    private bool grounded;
    private float jumpParam;

    public P_JumpingState(PlayerController character, P_ActionStateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        characterRef.gameObject.GetComponent<Rigidbody2D>().velocity = characterRef.gameObject.GetComponent<Rigidbody2D>().velocity * new Vector2(0.95f, 1f);
        characterRef.PlayerJumpNormal();
    }

    public override void HandleInput()
    {
        jumpParam = input_JumpParam;
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // check to see if char hits ground
        if (grounded)
        {
            stateMachineRef.ChangeState(characterRef.standingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // plan : have side to side movement?
        //        jumping state will contain only way of activating rope swing?
        //        

        

        grounded = characterRef.IsOurPlayerOnGround();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
