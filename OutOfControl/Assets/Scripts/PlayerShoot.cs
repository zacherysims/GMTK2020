using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float bulletForce = 20f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.parent.rotation * Quaternion.Euler(0,0,90f));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    public void AutoShoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.parent.rotation * Quaternion.Euler(0, 0, 90f));
        bullet.GetComponent<SpriteRenderer>().color = Color.green;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 moveDirection = (enemies[0].transform.position - transform.position).normalized * bulletForce;

        rb.velocity = moveDirection;
    }
}
