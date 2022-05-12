using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_GroundedState : P_BaseState
{
    protected bool isJumping = default;

    public P_GroundedState(PlayerController character, P_ActionStateMachine stateMachine): base(character, stateMachine) 
    {
    }

    #region Base Methods
    public override void Enter()
    {
        base.Enter();
        isJumping = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isJumping)
        {
            stateMachineRef.ChangeState(characterRef.jumpState);
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
    #endregion
}
