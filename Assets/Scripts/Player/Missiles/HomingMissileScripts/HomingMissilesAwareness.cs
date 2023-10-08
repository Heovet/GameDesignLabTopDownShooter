using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HomingMissilesAwareness : MonoBehaviour
{
    public bool awareOfEnemy { get; private set; }
    public Vector2 dirToEnemy { get; private set; }

    private Transform enemy;

    [SerializeField]
    private HomingMissileDestroy hmd;
    public UnityEvent targetLocked;
    public UnityEvent targetLost;

    // Update is called once per frame
    void Update()
    {
        trackingEnemy();
        toDestroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AlienShipMovement>())
        {
            awareOfEnemy = true;
            enemy = collision.transform;
            targetLocked.Invoke();
        }
    }

    private void trackingEnemy()
    {
        if (awareOfEnemy && enemy != null)
        {
            Vector2 missileToEnemy = enemy.position - transform.position;
            dirToEnemy = missileToEnemy.normalized;
        }
        else
        {
            awareOfEnemy = false;
            targetLost.Invoke();
        }
    }

    private void toDestroy()
    {
        if (hmd.toDestroy)
        {
/*            Debug.Log("Destroyed!");*/
            Destroy(gameObject);
        }
    }
}
