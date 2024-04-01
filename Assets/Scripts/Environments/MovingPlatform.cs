using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public bool goToB;
    public int speed;
    Vector3 targetPos;
    private bool isMoving;


    void Start()
    {
        isMoving = true;
        if (goToB)
        {
            targetPos = posB.position;
        } else
        {
            targetPos = posA.position;
        }
        
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            if (Vector3.Distance(transform.position, posA.position) < .1f)
            {
                targetPos = posB.position;
                StartCoroutine(StopForMoment());
            }

            if (Vector3.Distance(transform.position, posB.position) < .1f)
            {
                targetPos = posA.position;
                StartCoroutine(StopForMoment());
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }

    }

    IEnumerator StopForMoment()
    {
        isMoving = false;
        yield return Helpers.GetWait(1);
        isMoving = true;
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
