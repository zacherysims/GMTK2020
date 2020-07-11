using UnityEngine; 
public class BouncingEnemy : Enemy
{
    private Rigidbody2D m_phys;

    private bool m_is_grounded;
    private float m_grounded_time;
    private double m_timeout;
    private float m_thrust;
    
    private void Start()
    {
        scoreOnKill = 200;
        m_phys = GetComponent<Rigidbody2D>();
        m_grounded_time = 0;
        m_is_grounded = false;
        m_timeout = Random.value * 4.0;
        m_thrust = (float)(Random.value * 7.0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            m_is_grounded = true;
            m_grounded_time = Time.time;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            m_is_grounded = false;
        } 
    }

    private void FixedUpdate()
    {
        if (m_is_grounded && Time.time - m_grounded_time > m_timeout)
        {
            m_phys.AddForce(transform.up * m_thrust, ForceMode2D.Impulse);
        }
    }
}
