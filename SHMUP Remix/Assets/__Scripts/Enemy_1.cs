using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    private Vector3 p1;

    [Header("Enemy_1 Fields")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 80f;
    public float birthTime;
    public float lifeTime = 10;

    void Start()
    {
        birthTime = Time.time;
        Invoke("Fire", 1f / fireRate);
    }


    public void Fire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.AddForce(0, -10 * projectileSpeed, 0);

        GameObject projGO2 = Instantiate<GameObject>(projectilePrefab);
        projGO2.transform.position = transform.position + new Vector3(1f, 0, 0);
        projGO2.transform.rotation = Quaternion.Euler(0, 0, 30);
        Rigidbody rigidB2 = projGO2.GetComponent<Rigidbody>();
        rigidB2.AddForce(0, -10 * projectileSpeed, 0);
        rigidB2.AddForce(10 * projectileSpeed, 0, 0);

        GameObject projGO3 = Instantiate<GameObject>(projectilePrefab);
        projGO3.transform.position = transform.position - new Vector3(1f, 0, 0);
        projGO3.transform.rotation = Quaternion.Euler(0, 0, -30);
        Rigidbody rigidB3 = projGO3.GetComponent<Rigidbody>();
        rigidB3.AddForce(0, -10 * projectileSpeed, 0);
        rigidB3.AddForce(-10 * projectileSpeed, 0, 0);

        Invoke("Fire", 1f / fireRate);
    }

    // Override the Move function on Enemy
    public override void Move()
    {
        // Bézier curves work based on a u value between 0 & 1
        float u = (Time.time - birthTime) / lifeTime;

        // If u>1, then it has been longer than lifeTime since birthTime
        if (u > 1)
        {
            // This Enemy_2 has finished its life
            Destroy(this.gameObject); // d
            return;
        }
    }
}
