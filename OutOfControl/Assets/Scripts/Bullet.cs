using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Destroy a bullet if it exists for 3 seconds
    private void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    //Allows bullets to pass through ground, but registers a hit on anything else
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ground")
            Destroy(this.gameObject);
    }
}
