using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    protected float startTime;

    //anim

    public State(Entity entity, FiniteStateMachine stateMachine)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        //anim
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        DoChecks();
        //add anim
    }

    public virtual void Exit() 
    {
        //add anim
    }

    public virtual void LogicUpdate()
    {
        DoChecks();
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void DoChecks()
    {

    }

}
