using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public int FireStrength;
    public float fireDelay;
    public bool autoFire;
    public bool fireOnce;
    private bool hasFired = true;
    private float fireCooldown;

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (Input.GetKey("space") && fireCooldown <= 0 && !autoFire)
        {
            fireCooldown = fireDelay;
            GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * -FireStrength);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        }
        
        if (fireCooldown <= 0 && autoFire)
        {
            if(!fireOnce)
            {
                fireCooldown = fireDelay;
                GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
                bullet.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * -FireStrength);
            }
            else if(fireOnce && !hasFired)
            {
                hasFired = true;
                fireCooldown = fireDelay;
                GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
                bullet.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * -FireStrength);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        hasFired = false;
        Destroy(projectile);
        projectile = other.gameObject;
        other.transform.position = new Vector3(1000, 1000, 0);
    }
}
