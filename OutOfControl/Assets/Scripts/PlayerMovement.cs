using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public float leftConstraint = Screen.width;
    public float rightConstraint = Screen.width;
    public Camera cam;
    public float distanceZ;

    private Rigidbody2D rb;

    void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.x < leftConstraint)
        {
            transform.position = new Vector3(rightConstraint, transform.position.y, transform.position.z);
        }

        if (transform.position.x > rightConstraint)
        {
            transform.position = new Vector3(leftConstraint, transform.position.y, transform.position.z);
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    public void Jump()
    {
         rb.AddForce(new Vector3(0f, 7f), ForceMode2D.Impulse);
    }
}
