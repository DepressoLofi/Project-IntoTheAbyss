using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppy : MonoBehaviour
{
    // status
    public float speed;
    public float jumpForce;

    // some components
    private Rigidbody rigid;
    private Transform shootPoint;
    private Collider puppyCollider;


    //checkers 
    [Header("Ground")]
    [SerializeField] private bool grounded = true;
    public LayerMask whatIsGround;

    //shooting
    private float shootCooldown = 0.4f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        shootPoint = transform.Find("ShootPoint");
        puppyCollider = GetComponent<Collider>();

    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1 * 0.5f + 0.29f, whatIsGround);


        if (VirtualInputManager.Instance.moveRight)
        {
            this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            shootPoint.localPosition = new Vector3(0, 0, 0.94f);
            shootPoint.localRotation = Quaternion.identity;
        }

        if (VirtualInputManager.Instance.moveLeft)
        {
            this.gameObject.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            shootPoint.localPosition = new Vector3(0, 0, -0.94f);
            shootPoint.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (VirtualInputManager.Instance.jump && grounded)
        {
            Jump();
        }

    }

    void Jump()
    {

        rigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

    }


}
