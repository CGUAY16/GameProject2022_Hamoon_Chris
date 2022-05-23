using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_StandingState : P_GroundedState
{
    protected bool isCrouching = default;
    

    public P_StandingState(PlayerController pc, P_ActionStateMachine sm) : base(pc, sm)
    {

    }

    public override void Enter()
    {
        base.Enter();
        isCrouching = false;
        
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if(input_JumpParam != 0)
        {
            isJumping = true;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isCrouching)
        {
            stateMachineRef.ChangeState(characterRef.crouchState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        characterRef.MovePlayerNormal();
        base.PhysicsUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
