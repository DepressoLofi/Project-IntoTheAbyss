using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace intoTheAbyss_input
{
    public class Puppy : MonoBehaviour
    {
        public float speed;
        public float JumpForce;

        private Rigidbody rigid;

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

            if (VirtualInputManager.Instance.jump)
            {
                Jump();
            }

        }

        void Jump()
        {
            rigid.AddForce(Vector3.up * JumpForce);

        }
    }


}

