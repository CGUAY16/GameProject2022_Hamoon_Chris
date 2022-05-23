using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class B_BaseState
{
    // five input variables need to connect to this base state, inputs for switching bullets, and the shoot input
    public bool isBulletOneActive;
    public bool isBulletTwoActive;
    public bool isBulletThreeActive;
    public bool isBulletFourActive;
    public bool isBasicBulletActive;

   


    protected Pistol_Behavior pistolRef;
    protected BaseBullet_Behavior bulletRef;

    public B_BaseState(Pistol_Behavior pistolRef, BaseBullet_Behavior bulletRef)
    {
        this.pistolRef = pistolRef;
        this.bulletRef = bulletRef;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void UpdateInput()
    {
        isBulletOneActive = pistolRef.IsBulOneActive;
        isBulletTwoActive = pistolRef.IsBulTwoActive;
        isBulletThreeActive = pistolRef.IsBulThreeActive;
        isBulletFourActive = pistolRef.IsBulFourActive;
        isBasicBulletActive = pistolRef.IsBulBasicActive;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
