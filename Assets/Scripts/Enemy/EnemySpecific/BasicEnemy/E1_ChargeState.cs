using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
    private BasicEnemy enemy;
    public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, D_ChargeState stateData, BasicEnemy enemy) : base(entity, stateMachine, stateData)
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

        if (isChargeTimeOver)
        {
            if (isPlayerInAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            } else
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(isDetectingWall || !isDetectingLedge) {
            entity.SetVelocity(0);
            enemy.idleState.SetTurnAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        } else {
            entity.SetVelocity(stateData.chargeSpeed);
        }
        
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

}
