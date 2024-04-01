using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class Puppy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField]private int lifeCount;
    [SerializeField] private Vector3 lastCheckPoint;
    [SerializeField] private bool alive;

    [Header("Collect")]
    public int star;
    public StarSystem starSystem;

    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        alive = true;
        lifeCount = 3;
        lastCheckPoint = transform.position;
    }

    public void SetCheckpoint(Vector3 newPoint)
    {
        lastCheckPoint = newPoint;
        
    }

    private void Die()
    {
        meshRenderer.enabled = false;
        alive = false;
        alive = false;
        GameStateManager.Instance.PuppyDied();
        lifeCount -= 1;
        if (lifeCount > 0)
        {
            StartCoroutine(Respawn(0.5f));
        }
        else
        {
            //add game over script
            Debug.Log("You ran out of life");
        }
        
    }

    IEnumerator Respawn(float duration)
    {

        yield return Helpers.GetWait(duration);
        transform.position = lastCheckPoint;
        alive = true;
        GameStateManager.Instance.PuppyRevived();
        meshRenderer.enabled = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Monster"))
        {
            Die();
        }
        if (other.CompareTag("Star"))
        {
            CollectableStars collectableStars = other.GetComponent<CollectableStars>();
            collectableStars.IsCollected();
            star++;
            if (starSystem != null)
            {
                starSystem.IncreaseStarCount(star);

            }


        }

    }

}
