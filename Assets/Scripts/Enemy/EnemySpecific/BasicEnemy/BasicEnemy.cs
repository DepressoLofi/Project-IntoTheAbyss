using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetectedState playerDetectedStateData;
    [SerializeField] private D_ChargeState chargeStateData;


    public override void Awake()
    {
        base.Awake();
        moveState = new E1_MoveState(this, stateMachine, moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, playerDetectedStateData, this);
        chargeState = new E1_ChargeState(this, stateMachine, chargeStateData, this);


        stateMachine.Initialize(moveState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Damaged();
        }
    }

}
