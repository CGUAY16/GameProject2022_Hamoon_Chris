using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Basic : B_BaseState
{
    public B_Basic(Pistol_Behavior pistolRef, BaseBullet_Behavior bulletRef) : base(pistolRef,bulletRef)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void UpdateInput()
    {
        base.UpdateInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
