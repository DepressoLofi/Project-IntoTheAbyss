using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector3 targetPos;

    void Start()
    {
        targetPos = posB.position;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;

        if (Vector3.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
            PuppyMovement puppyMovement = other.GetComponent<PuppyMovement>();
            if (puppyMovement != null)
            {
                puppyMovement.onPlatform = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
            PuppyMovement puppyMovement = other.GetComponent<PuppyMovement>();
            if (puppyMovement != null)
            {
                puppyMovement.onPlatform = false;
            }
        }
    }
}
