using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissiles : MonoBehaviour
{
    public bool awareOfEnemy { get; private set; }
    public Vector2 dirToEnemy { get; private set; }
    [SerializeField]
    private float detectionRadius;

    private Transform enemy;

    private void Awake()
    {
        enemy = FindAnyObjectByType<AlienShipMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = enemy.position - transform.position;
        dirToEnemy = enemyToPlayer.normalized;

        if (enemyToPlayer.magnitude <= detectionRadius)
        {
            awareOfEnemy = true;
        }
        else
        {
            awareOfEnemy = false;
        }
    }
}
