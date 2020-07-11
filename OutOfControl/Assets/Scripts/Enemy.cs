using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreOnKill;
    //Handle getting shot
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            GameObject.Find("UI").GetComponent<UIController>().IncreaseScore(scoreOnKill);
        }
    }
}
