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

    void Update()
    {
        

        

    }

    private void FixedUpdate()
    {
        
    }

    private void SetCheckpoint()
    {

    }

    private void Die()
    {
        meshRenderer.enabled = false;
        alive = false;
        lifeCount -= 1;
        alive = false;
        GameStateManager.Instance.PuppyDied();
        StartCoroutine(Respawn(0.5f));
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
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }

}
