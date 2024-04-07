using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyMovement : MonoBehaviour
{
    [Header("Movement stats")]
    public float speed;
    public float jumpForce;
    public float fallMultiplier;
    public float pullMultiplier;
    private Vector3 movement;

    [Header("Camera")]
    [SerializeField] private CinemachineVirtualCamera vcm;
    public bool direction; //false is left, true is right

    //some components 
    private Rigidbody rigid;
    private Collider puppyCollider;
    [Header("Some Components")]
    public GameObject jumpVFX;
    public Transform jumpPoint;
    public Transform shootPoint;

    [Header("Ground")]
    [SerializeField] private bool grounded;
    [SerializeField] private bool doubleJump;
    public LayerMask whatIsGround;
    public bool onPlatform;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        puppyCollider = GetComponent<Collider>();
        onPlatform = false;
    }


    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1 * 0.5f + 0.29f, whatIsGround);

        if (grounded)
        {
            doubleJump = true;
            puppyCollider.material.dynamicFriction = 1;
        } else
        {
            puppyCollider.material.dynamicFriction = 0;
        }

        if (OnSlope()) {
            rigid.useGravity = false;
            
        } else
        {
            rigid.useGravity = true;
        }
        
        if (movement.z > 0)
        {
            //move right
            shootPoint.localPosition = new Vector3(0, 0, 0.94f);
            shootPoint.localRotation = Quaternion.identity;
            direction = true; //right
            

        } else if(movement.z < 0)
        {
            //move left
            shootPoint.localPosition = new Vector3(0, 0, -0.94f);
            shootPoint.localRotation = Quaternion.Euler(0f, 180f, 0f);
            direction = false;

        }

        if (direction)
        {
            float targetOffset = 1f;
            Vector3 targetPosition = new Vector3(0, 0, 0.94f);
            Quaternion targetRotation = Quaternion.identity;
            SmoothlyChangeOffset(targetOffset, targetPosition, targetRotation);
        } else
        {
            float targetOffset = -1f;
            Vector3 targetPosition = new Vector3(0, 0, -0.94f);
            Quaternion targetRotation = Quaternion.Euler(0f, 180f, 0f);
            SmoothlyChangeOffset(targetOffset, targetPosition, targetRotation);
        }

        if (GameStateManager.Instance.freeze)
        {
            rigid.constraints |= RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            rigid.constraints &= ~(RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ);
        }

        MyInput();
    }


    void FixedUpdate()
    {
        MovePlayer();
        ApplyGravity();
    }


    private void MyInput()
    {
        if (!GameStateManager.Instance.canInput)
        {
            return;
        }
        movement.z = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                Jump();
            }
            else if (doubleJump && GameStateManager.Instance.havePower)
            {
                Jump();
                if (jumpVFX != null)
                {
                    Instantiate(jumpVFX, jumpPoint.position, jumpPoint.rotation);
                }

                doubleJump = false;
            }
        }
    }

    private void MovePlayer()
    {
        if (onPlatform)
        {
            transform.Translate(speed * Time.deltaTime * movement);
        }
        else if (OnSlope())
        {
            rigid.MovePosition(rigid.position + GetSlopeMoveDirection() * speed * Time.deltaTime);
        } else
        {
            rigid.MovePosition(rigid.position + movement * speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        rigid.velocity = Vector3.up * jumpForce;
    }

    private void ApplyGravity()
    {
        if (rigid.velocity.y < 0 && !OnSlope())
        {
            rigid.velocity += (-Vector3.up * fallMultiplier);
        }

        if (rigid.velocity.y > 0f && !OnSlope())
        {
            rigid.velocity += (-Vector3.up * pullMultiplier);
        }
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1 * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(movement, slopeHit.normal).normalized;
    }

    void SmoothlyChangeOffset(float targetOffset, Vector3 targetPosition, Quaternion targetRotation)
    {
        CinemachineFramingTransposer transposer = vcm.GetCinemachineComponent<CinemachineFramingTransposer>();


        transposer.m_TrackedObjectOffset.z = Mathf.Lerp(transposer.m_TrackedObjectOffset.z, targetOffset, Time.deltaTime * 5f);


        shootPoint.localPosition = Vector3.Lerp(shootPoint.localPosition, targetPosition, Time.deltaTime * 5f);
        shootPoint.localRotation = Quaternion.Lerp(shootPoint.localRotation, targetRotation, Time.deltaTime * 5f);
    }

}
