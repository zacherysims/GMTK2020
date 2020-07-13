using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded;
    
    private const float MoveSpeed = 5f;
    private float m_leftConstraint;
    private float m_rightConstraint;
    private float m_topConstraint;
    private float m_bottomConstraint;
    
    private float m_distanceZ;

    private Camera m_cam;
    private Rigidbody2D m_rb;

    public void Start()
    {
        m_cam = Camera.main;
        if (m_cam != null)
        {
            m_distanceZ = Mathf.Abs(m_cam.transform.position.z + transform.position.z);
            m_leftConstraint = m_cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, m_distanceZ)).x;
            m_rightConstraint = m_cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, m_distanceZ)).x;
            m_bottomConstraint = m_cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, m_distanceZ)).y;
            m_topConstraint = m_cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, m_distanceZ)).y;
        }
        m_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        var pos = transform.position;
        if(pos.x < m_leftConstraint)
        {
            transform.position = new Vector3(m_rightConstraint, pos.y , pos.z);
        }

        if (pos.x > m_rightConstraint)
        {
            transform.position = new Vector3(m_leftConstraint, pos.y, pos.z);
        }

        if (pos.y < m_bottomConstraint)
        {
            transform.position = new Vector3(m_topConstraint, pos.x, pos.y);
        }

        var movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Time.deltaTime * MoveSpeed * movement;

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    private void Jump()
    {
         m_rb.AddForce(new Vector3(0f, 7f), ForceMode2D.Impulse);
    }
}
