using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] Transform target = null;
    [SerializeField] float speed = 1500;
    [SerializeField] float fireRate = 15, nextFire;

    private void Start()
    {
        fireRate = Random.Range(2, 8);

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {

        transform.LookAt(target);
        if(Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            FireLaser();
        }
    }

    void FireLaser()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation);
        laser.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        Destroy(laser, 10);
    }
}
