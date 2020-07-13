using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded;
    
    private const float MoveSpeed = 5f;
    private float m_distanceZ;

    private Rigidbody2D m_rb;

    public void Start()
    {
        m_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Time.deltaTime * MoveSpeed * movement;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            m_rb.AddForce(new Vector3(0f, 7f), ForceMode2D.Impulse);
        }
    }
}
