using UnityEngine;

public class WorldWrap : MonoBehaviour
{
    private float m_leftConstraint;
    private float m_rightConstraint;
    private float m_topConstraint;
    private float m_bottomConstraint;
    
    private float m_distanceZ;

    public void Start()
    {
        var cam = Camera.main;
        m_distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);
        m_leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, m_distanceZ)).x;
        m_rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, m_distanceZ)).x;
        m_bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, m_distanceZ)).y;
        m_topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, m_distanceZ)).y;
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

    }
}