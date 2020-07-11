using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnRate = 1.0f;
    private float spawnCountdown;

    public GameObject[] enemy;

    public Transform[] spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;

        if (spawnCountdown <= 0)
        {
            spawnCountdown = spawnRate;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int spawnpointIndex = Random.Range(0, spawnpoint.Length);
        int enemyIndex = Random.Range(0, enemy.Length);

        Vector2 spawnlocation = new Vector2(spawnpoint[spawnpointIndex].transform.position.x, spawnpoint[spawnpointIndex].transform.position.y);

        Instantiate(enemy[enemyIndex], spawnlocation, Quaternion.identity);

    }
}
