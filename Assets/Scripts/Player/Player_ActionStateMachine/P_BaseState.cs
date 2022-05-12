using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class P_BaseState
{
    // Input Values
    public float input_MovementParam;
    public float input_JumpParam;


    protected P_ActionStateMachine stateMachineRef;
    protected PlayerController characterRef;
    public P_BaseState(PlayerController c, P_ActionStateMachine sm)
    { 
        characterRef = c;
        stateMachineRef = sm;
    }

    public virtual void Enter()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void UpdateInput()
    {
        input_MovementParam = characterRef.MovementInputParam;
        input_JumpParam = characterRef.JumpInputParam;
    }
}
