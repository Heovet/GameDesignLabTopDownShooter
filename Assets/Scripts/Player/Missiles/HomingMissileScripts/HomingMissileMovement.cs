using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private HomingMissilesAwareness awareness;

/*    [SerializeField]
    private GameObject homingMissile;*/

    private Rigidbody2D rb;
    private Vector2 targetDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (awareness.awareOfEnemy)
        {
            targetEnemy();
            rotateToTarget();
            updateV();
        }
    }

    private void targetEnemy()
    {
        targetDir = awareness.dirToEnemy;
    }

    private void rotateToTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDir);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void updateV()
    {
        rb.velocity = transform.up * speed;
    }
}
