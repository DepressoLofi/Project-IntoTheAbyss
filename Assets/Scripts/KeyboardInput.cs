using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            VirtualInputManager.Instance.moveRight = true;
        }
        else
        {
            VirtualInputManager.Instance.moveRight = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            VirtualInputManager.Instance.moveLeft = true;
        }
        else
        {
            VirtualInputManager.Instance.moveLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            VirtualInputManager.Instance.jump = true;
        }
        else
        {
            VirtualInputManager.Instance.jump = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            VirtualInputManager.Instance.shoot = true;
        }
        else
        {
            VirtualInputManager.Instance.shoot = false;
        }
    }
}





