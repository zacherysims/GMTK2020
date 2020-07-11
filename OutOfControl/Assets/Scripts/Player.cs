using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIController uiController;

    private float confidenceLevel;
    private bool canBeHit = true;

    private void Start()
    {
        StartCoroutine(ManageConfidence());
    }

    private IEnumerator ManageConfidence()
    {
        for (; ;)
        {
            confidenceLevel = uiController.confidenceSlider.value;
            yield return new WaitForSeconds(3.5f - confidenceLevel);
            if (confidenceLevel > 0.5)
            {
                Debug.Log("shoot" + confidenceLevel);
                GetComponent<PlayerShoot>().AutoShoot();
            }
        }
    }

    //Detect if the player collides with an enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && canBeHit)
            PlayerHit();
    }

    //Detect if the player collides with an enemy who's collider is a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && canBeHit)
            PlayerHit();
    }

    //Register a player hit but give a grace period after getting hit so the player can't
    //just get mucked in 3 frames
    private void PlayerHit()
    {
        Debug.Log("Player Hit");
        canBeHit = false;
        StartCoroutine(TempInvinsibility(1f));

        uiController.DecreaseConfidence();
    }

    private IEnumerator TempInvinsibility(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        canBeHit = true;
    }
}
