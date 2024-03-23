using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Puppy : MonoBehaviour
{
    [Header("Status")]
    public float speed;
    public float jumpForce;
    public float fallMultiplier;
    public float pullMultiplier;

    [SerializeField] private CinemachineVirtualCamera vcm;

    // some components
    private Rigidbody rigid;
    private Transform shootPoint;
    private Collider puppyCollider;


    //checkers 
    [Header("Ground")]
    [SerializeField] private bool grounded;
    [SerializeField] private bool doubleJump;
    public LayerMask whatIsGround;



    private void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        shootPoint = transform.Find("ShootPoint");
        puppyCollider = GetComponent<Collider>();

    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1 * 0.5f + 0.29f, whatIsGround);

        if (grounded) {
            doubleJump = true;
        } 


        if (InputManager.Instance.moveRight)
        {
            this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            shootPoint.localPosition = new Vector3(0, 0, 0.94f);
            shootPoint.localRotation = Quaternion.identity;
            vcm.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.z = 1f;
        }

        if (InputManager.Instance.moveLeft)
        {
            this.gameObject.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            shootPoint.localPosition = new Vector3(0, 0, -0.94f);
            shootPoint.localRotation = Quaternion.Euler(0f, 180f, 0f);
            vcm.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.z = -1f;
        }

        if (InputManager.Instance.jump)
        {
            if (grounded)
            {
                Jump();
            }
            else if(doubleJump)
            {
                Jump();
                doubleJump = false;
            }

        }

        

    }

    private void FixedUpdate()
    {
        if (rigid.velocity.y < 0)
        {
            rigid.velocity += (-Vector3.up * fallMultiplier);
        }

        if (rigid.velocity.y > 0f)
        {
            rigid.velocity += (-Vector3.up * pullMultiplier);

        }
    }

    void Jump()
    {
        rigid.velocity = Vector3.up * jumpForce;

    }

}
