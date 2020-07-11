using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{
    public float speed;
    public float waitToDrop = 0f;
    public Transform groundDetection;

    private bool movingRight = true;
    private float distance = 1f;

    //After a set amount of time, increase the ground detection distance
    //so that the enemy doesn't hand out on one platform forever
    private IEnumerator Start()
    {
        scoreOnKill = 50;
        if (waitToDrop == 0)
            yield return null;
        else
        {
            yield return new WaitForSecondsRealtime(waitToDrop);
            distance = 5f;
        }
    }

    //Move in one direction until the edge of a platform is detected,
    //then flip around
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        Debug.DrawRay(groundDetection.position, Vector2.down, Color.green);

        if (groundInfo.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
