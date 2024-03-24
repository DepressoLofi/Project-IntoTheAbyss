using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject muzzlePrefab;

    private void Start()
    {
        if (muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            Destroy(muzzleVFX, 0.8f);



        }
    }

    void Update()
    {
        if(speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        speed = 0;
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, contact.normal);
        Vector3 pos = contact.point;
        var psMuzzle = muzzlePrefab.GetComponent<ParticleSystem>();

        if (muzzlePrefab != null) { 
            var hitVFX = Instantiate(muzzlePrefab, pos, rot);
            Destroy(hitVFX, 0.8f);
        }

        Destroy(gameObject);
    }

}
