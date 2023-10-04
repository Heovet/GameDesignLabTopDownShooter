using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float minSpawnTime;

    private float timeToSpawn;

    private void Awake()
    {
        setTimeToSpawn();
    }

    private void Update()
    {
        timeToSpawn -= Time.deltaTime;

        if(timeToSpawn <=0 ) 
        {
            GameObject newEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            setTimeToSpawn();
        }
    }

    private void setTimeToSpawn()
    {
        timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
