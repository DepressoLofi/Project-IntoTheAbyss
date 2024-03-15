using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace intoTheAbyss_input
{
    public class Puppy : MonoBehaviour
    {
        public float speed;
        public float jumpForce;

        private Rigidbody rigid;

        [Header("Ground")]
        public bool grounded = true;

        private void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (VirtualInputManager.Instance.moveRight)
            {
                this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }


            if (VirtualInputManager.Instance.moveLeft)
            {
                this.gameObject.transform.Translate(-Vector3.forward * speed * Time.deltaTime);

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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                grounded = true;
            } 
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                grounded = false;
            }
        }
    }


}

