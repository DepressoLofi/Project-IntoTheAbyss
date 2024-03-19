using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            InputManager.Instance.moveRight = true;
        }
        else
        {
            InputManager.Instance.moveRight = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            InputManager.Instance.moveLeft = true;
        }
        else
        {
            InputManager.Instance.moveLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputManager.Instance.jump = true;
        }
        else
        {
            InputManager.Instance.jump = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            InputManager.Instance.shoot = true;
        }
        else
        {
            InputManager.Instance.shoot = false;
        }
    }


}
