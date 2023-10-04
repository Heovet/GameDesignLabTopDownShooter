using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissilesAwareness : MonoBehaviour
{
    public bool awareOfEnemy { get; private set; }
    public Vector2 dirToEnemy { get; private set; }

    [SerializeField] private float detectionRadius;
    private Transform enemy;

    private void Awake()
    {
        enemy = FindAnyObjectByType<AlienShipMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 missileToEnemy = enemy.position - transform.position;
        dirToEnemy = missileToEnemy.normalized;

        if (missileToEnemy.magnitude <= detectionRadius)
        {
            awareOfEnemy = true;
        }
        else
        {
            awareOfEnemy = false;
        }
    }
}
