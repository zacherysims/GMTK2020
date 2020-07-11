using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        float confidenceLevel = uiController.confidenceSlider.value;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.parent.rotation * Quaternion.Euler(0,0,90f));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce((firePoint.right + (firePoint.up * Random.Range(-confidenceLevel, confidenceLevel))) * bulletForce, ForceMode2D.Impulse);
    }

    public void AutoShoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
            return;

        GameObject e = enemies[UnityEngine.Random.Range(0, enemies.Length)];

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.parent.rotation * Quaternion.Euler(0, 0, 90f));
        bullet.GetComponent<SpriteRenderer>().color = Color.green;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 moveDirection = (e.transform.position - transform.position).normalized * bulletForce * 2;

        rb.velocity = moveDirection;
    }
}
