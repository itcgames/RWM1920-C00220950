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
    public bool fireOnContact;
    private bool hasFired = true;
    private float fireCooldown;
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (Input.GetKey("space") && fireCooldown <= 0 && !autoFire)
        {
            FireBullet();
        }

        if (fireCooldown <= 0 && autoFire)
        {
            if (!fireOnce)
            {
                FireBullet();
            }
            else if (fireOnce && !hasFired)
            {
                hasFired = true;
                FireBullet();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (fireOnContact && other.rigidbody)
        {
            hasFired = false;
            Destroy(projectile);
            projectile = other.gameObject;
            other.transform.position = new Vector3(1000, 1000, 0);
            other.gameObject.SetActive(false);
        }
    }

    public void FireBullet()
    {
        fireCooldown = fireDelay;
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;

        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(-transform.right * -FireStrength);
        StartCoroutine(TempIgnore(bullet, 0.5f));
        audioData.Play();
    }

    private IEnumerator TempIgnore(GameObject obj, float delay)
    {
        Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        foreach (Collider2D c in GetComponentsInChildren<Collider2D>())
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), c);
        }
        yield return new WaitForSeconds(delay);
        Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        foreach (Collider2D c in GetComponentsInChildren<Collider2D>())
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), c, false);
        }
    }
}