using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance = null;

    public bool canInput;
    public bool freeze;
    public bool havePower;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
       
    }

    public void IntroScene()
    {
        havePower = false;
    }

    public void backToNormal()
    {
        canInput = true;
    }


    public void InCutscene()
    {
        canInput = false;
    }

    public void PuppyDied()
    {
        canInput = false;
        freeze = true;
    }

    public void PuppyRevived()
    {
        canInput = true;  
        freeze = false;
    }

}
