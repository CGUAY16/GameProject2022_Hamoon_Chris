using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ActionStateMachine
{
    public P_BaseState currentState { get; private set; }

    public void Initialize(P_BaseState startingState)
    {
        currentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(P_BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        newState.Enter();
    }


}
