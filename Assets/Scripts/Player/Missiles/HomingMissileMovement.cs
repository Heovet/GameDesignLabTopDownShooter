using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rb;
    private HomingMissilesAwareness awareness;
    private Vector2 targetDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        awareness = GetComponent<HomingMissilesAwareness>();
        targetDir = transform.up;
    }

    private void FixedUpdate()
    {
        targetPlayer();
        rotateToTarget();
        updateV();
    }

    private void targetPlayer()
    {
        if (awareness.awareOfEnemy)
        {
            targetDir = awareness.dirToEnemy;
        }
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
