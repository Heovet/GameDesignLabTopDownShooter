using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool awareOfPlayer { get; private set; }
    public Vector2 dirToPlayer { get; private set; }
    [SerializeField]
    private float detectionRadius;

    private Transform player;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        dirToPlayer = enemyToPlayer.normalized;

        if(enemyToPlayer.magnitude <= detectionRadius)
        {
            awareOfPlayer = true;
        }
        else
        {
            awareOfPlayer = false;
        }
    }
}
