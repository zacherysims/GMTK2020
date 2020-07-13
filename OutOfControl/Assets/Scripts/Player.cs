using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIController uiController;

    private float m_confidenceLevel;
    private bool m_canBeHit = true;
    private PlayerShoot m_shooter;

    private void Start()
    {
        m_shooter = GetComponent<PlayerShoot>();
        StartCoroutine(ManageConfidence());
    }

    private IEnumerator ManageConfidence()
    {
        for (; ;)
        {
            m_confidenceLevel = uiController.confidenceSlider.value;
            yield return new WaitForSeconds(3.5f - m_confidenceLevel);
            if (m_confidenceLevel > 0.5)
            {
                m_shooter.AutoShoot();
            }
        }
    }

    //Detect if the player collides with an enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && m_canBeHit)
            PlayerHit();
    }

    //Detect if the player collides with an enemy who's collider is a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && m_canBeHit)
            PlayerHit();
    }

    //Register a player hit but give a grace period after getting hit so the player can't
    //just get mucked in 3 frames
    private void PlayerHit()
    {
        Debug.Log("Player Hit");
        m_canBeHit = false;
        StartCoroutine(TempInvinsibility(1f));

        uiController.DecreaseConfidence();
    }

    private IEnumerator TempInvinsibility(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        m_canBeHit = true;
    }
}
