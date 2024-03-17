using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualInputManager : MonoBehaviour
{
    public static VirtualInputManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public bool moveRight;
    public bool moveLeft;
    public bool jump;
    public bool shoot;
}


