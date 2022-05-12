using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_CrouchState : P_GroundedState
{
    public P_CrouchState(PlayerController p, P_ActionStateMachine sm) : base(p, sm)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
