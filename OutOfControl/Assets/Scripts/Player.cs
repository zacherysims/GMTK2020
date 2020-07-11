using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIController uiController;
    private bool canBeHit = true;

    //Detect when the player collides with an enemy,
    //but give a grace period after getting hit so the player can't
    //just get mucked in 3 frames
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && canBeHit)
        {
            canBeHit = false;
            StartCoroutine(TempInvinsibility(1f));

            uiController.DecreaseConfidence();
            Debug.Log("Player Hit");
        }
    }

    private IEnumerator TempInvinsibility(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        canBeHit = true;
    }
}
