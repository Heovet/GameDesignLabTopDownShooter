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
    private float screenBorder;

    private Rigidbody2D rb;
    private PlayerAwarenessController controller;
    private Vector2 targetDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerAwarenessController>();
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
        if (controller.awareOfPlayer)
        {
            targetDir = controller.dirToPlayer;
        }
        /*        else
                {
                    targetDir = Vector2.zero;
                }*/
    }

    private void rotateToTarget()
    {
        /*        if (targetDir == Vector2.zero)
                {
                    return;
                }*/

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDir);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void updateV()
    {
        /*        if (targetDir == Vector2.zero)
                {
                    return;
                }
                else
                {
                    rb.velocity = transform.up * speed;
                }*/
        rb.velocity = transform.up * speed;
    }

}
