using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool triggered;

    private void Start()
    {
        triggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            Puppy puppy = other.GetComponent<Puppy>();
            puppy.SetCheckpoint(transform.position);
            triggered = true;

        }
    }
}
