using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public UIController uiController;

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
        var confidenceLevel = uiController.confidenceSlider.value;
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.parent.rotation * Quaternion.Euler(0,0,90f));
        var rb = bullet.GetComponent<Rigidbody2D>();
        var bulletDir = firePoint.right + 0.1f * Random.Range(-confidenceLevel, confidenceLevel) * firePoint.up;
        rb.AddForce(bulletDir * bulletForce, ForceMode2D.Impulse);
    }

    public void AutoShoot()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
            return;

        var e = enemies[UnityEngine.Random.Range(0, enemies.Length)];

        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.parent.rotation * Quaternion.Euler(0, 0, 90f));
        bullet.GetComponent<SpriteRenderer>().color = Color.green;
        var rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 moveDirection = bulletForce * 2 * (e.transform.position - transform.position).normalized;

        rb.velocity = moveDirection;
    }
}
