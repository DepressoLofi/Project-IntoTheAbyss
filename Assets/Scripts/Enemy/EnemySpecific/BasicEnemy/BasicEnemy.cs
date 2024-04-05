using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;

    public override void Awake()
    {
        base.Awake();
        moveState = new E1_MoveState(this, stateMachine, moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, idleStateData, this);

        stateMachine.Initialize(moveState);
    }
    private void Start()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Damaged();
        }
    }

}
