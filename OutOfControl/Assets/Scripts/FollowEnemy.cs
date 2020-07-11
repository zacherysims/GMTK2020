using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : Enemy
{
    public float speed;
    private Transform target;
    private Rigidbody2D rb;

    private void Start()
    {
        scoreOnKill = 100;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    //Follow the player
    private void FixedUpdate()
    {
        float xPosition = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (transform.position.x < xPosition)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
