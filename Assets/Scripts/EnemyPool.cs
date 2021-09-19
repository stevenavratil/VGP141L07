using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public int totalEnemies;
    public Enemy enemyPrefab;

    Enemy[] enemyPool;
    public Transform randomSpawn;

    // Create empty variables to hold the boundary of the randomSpawn
    float x;
    float z;

    private void Awake()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            Transform spawn = RandomSpawn();
            Instantiate(enemyPrefab, spawn.position, spawn.rotation);
        }
        enemyPool = FindObjectsOfType<Enemy>();

        if (totalEnemies <= 0)
            totalEnemies = 5;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < enemyPool.Length; i++)
            {
                Create();
            }
        }
    }

    public void Create()
    {
        for (int i = 0; i < enemyPool.Length; i++)
        {
            Transform spawn = RandomSpawn();

            if (!enemyPool[i].InUse())
            {
                enemyPool[i].Init(spawn);
                break;
            }
        }
    }

    Transform RandomSpawn()
    {
        x = Random.Range(-25, 25);
        z = Random.Range(-25, 25);
        Vector3 randomPos = new Vector3(x, 0, z);
        Quaternion randomRot = new Quaternion(0, Random.Range(0.0f, 360.0f), 0, 0);
        Vector3 regScale = new Vector3(1, 1, 1);

        randomSpawn.position = randomPos;
        randomSpawn.rotation = randomRot;
        randomSpawn.localScale = regScale;

        return randomSpawn;
    }
}
