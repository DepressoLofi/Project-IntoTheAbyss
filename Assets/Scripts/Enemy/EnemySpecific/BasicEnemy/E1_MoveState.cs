using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    private BasicEnemy enemy;
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, D_MoveState stateData, BasicEnemy enemy) : base(entity, stateMachine, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetTurnAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
        else {
            entity.SetVelocity(stateData.movementSpeed);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
