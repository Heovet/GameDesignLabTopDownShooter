using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipMovement : MonoBehaviour
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
    private Camera screen;

    private float changeDirTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerAwarenessController>();
        targetDir = transform.up;
        screen = Camera.main;
    }

    private void FixedUpdate()
    {
        updateTargetDir();
        rotateToTarget();
        updateV();
    }

    private void updateTargetDir()
    {
        randomPatrolDirection();
        targetPlayer();
        moveToScreen();
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

    private void randomPatrolDirection()
    {
        changeDirTime -= Time.deltaTime;

        if (changeDirTime <= 0 )
        {
            float randomAngle = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(randomAngle, transform.forward);
            targetDir = rotation * targetDir;

            changeDirTime = Random.Range(1f, 5f);
        }
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

    private void moveToScreen()
    {
        Vector2 screenPosition = screen.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && targetDir.x < 0) || (screenPosition.x > screen.pixelWidth - screenBorder && targetDir.x > 0))
        {
            targetDir = new Vector2(-targetDir.x, targetDir.y);
        }

        if ((screenPosition.y < screenBorder && targetDir.y < 0) || (screenPosition.y > screen.pixelHeight - screenBorder && targetDir.y > 0))
        {
            targetDir = new Vector2(targetDir.x, -targetDir.y);
        }
    }
}
