using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    private enum State
    {
        Walking,
        Knockback,
        Dead
    }

    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        movementSpeed;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck;

    [SerializeField]
    private LayerMask whatIsGround;


    private int facingDirection;

    private Vector3 movement;

    private bool
        groundDetected,
        wallDetected;

    private GameObject mesh;
    private Rigidbody rb;

    private void Start()
    {
        mesh = transform.Find("Mesh").gameObject;
        rb = GetComponent<Rigidbody>();

        facingDirection = 1;
    }

    private void Update()
    {
        switch(currentState)
        {
            case State.Walking:
                UpdateWalkingState(); break;
            case State.Knockback: 
                UpdateKnockbackState(); break;
            case State.Dead:
                UpdateDeadState(); break;

        }
    }

    // -- WALKING STATE--------------------------------------------------------------------------------

    private void EnterWalkingState()
    {

    }

    private void UpdateWalkingState()
    {
        groundDetected = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics.Raycast(wallCheck.position, transform.forward, wallCheckDistance, whatIsGround);

        if (!groundDetected || wallDetected)
        {
            turn();
        }
        else
        {
            movement.Set(rb.velocity.x, rb.velocity.y, movementSpeed * facingDirection);
            rb.velocity = movement;


        }
    }

    private void ExitWalkingState()
    {

    }

    //-- KNOCKBACK STATE -------------------------------------------------

    private void EnterKnockbackState()
    {

    }

    private void UpdateKnockbackState()
    {

    }

    private void ExitKnockbackState()
    {

    }

    // --DEAD STATE -----------------------------------------------------

    private void EnterDeadState()
    {
        //spawn vfx blood die
        Destroy(gameObject);
    }

    private void UpdateDeadState()
    {

    }
    private void ExitDeadState()
    {

    }

    // -- Other Functions ---------------------------------------------

    private void Damaged()
    {
        SwitchState(State.Dead);
    }

    private void turn()
    {
        facingDirection *= -1;
        mesh.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Walking:
                ExitWalkingState();
                break;
            case State.Knockback:
                ExitKnockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }

        switch (state)
        {
            case State.Walking:
                EnterWalkingState();
                break;
            case State.Knockback:
                EnterKnockbackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }

        currentState = state;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance, groundCheck.position.z));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x, wallCheck.position.y, wallCheck.position.z + wallCheckDistance));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            turn();
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Damaged();
        }
    }



}
