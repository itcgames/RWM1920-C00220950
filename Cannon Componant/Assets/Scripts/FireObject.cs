using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public int FireStrength;
    public float fireDelay;
    private float fireCooldown;

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (Input.GetKey("space") && fireCooldown <= 0)
        {
            fireCooldown = fireDelay;
            GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * -FireStrength);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        }
    }
}
