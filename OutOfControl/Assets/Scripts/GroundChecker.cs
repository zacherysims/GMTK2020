using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to check if the player is on the ground so you can't
//just spam the jump button and fly away
public class GroundChecker : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            player.GetComponent<PlayerMovement>().isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            player.GetComponent<PlayerMovement>().isGrounded = false;
    }
}
