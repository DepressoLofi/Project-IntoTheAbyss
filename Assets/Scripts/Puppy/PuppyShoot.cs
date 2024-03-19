using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyShoot : MonoBehaviour
{
    public Transform shootPoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;

    private float timeToFire = 0;

    void Start()
    {
        effectToSpawn = vfx[0];

    }

    void Update()
    {
        if (InputManager.Instance.shoot && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;
        if (shootPoint != null)
        {
            vfx = Instantiate(effectToSpawn, shootPoint.position, shootPoint.rotation);
            Destroy(vfx, 1f);

        } else
        {
            Debug.Log("No Shoot Point");
        }
    }



}
