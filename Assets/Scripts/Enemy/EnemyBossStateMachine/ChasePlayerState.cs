using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ChasePlayerState : State
{
    protected StateMachine stateMachine;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float reloadTime;
    private float lastFired;

    [SerializeField]
    private float screenBorder;

    private Rigidbody2D rb;
    private Vector2 targetDir;
    private Transform player;
    private Vector2 enemyToPlayer;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        rb = GetComponent<Rigidbody2D>();
        targetDir = transform.up;
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    public override void Enter()
    {
/*        Debug.Log("Start Decide");*/
    }

    public override void Tick()
    {
        /*        Debug.Log("In Decide");*/
        targetPlayer();
        rotateToTarget();
        updateV();
        changeStateToFire();
    }

    private void changeStateToFire()
    {
        float lastFireTime = Time.time - lastFired;
        if (lastFireTime > reloadTime && Mathf.Abs(enemyToPlayer.x) < 1)
        {
            lastFired = Time.time;
            stateMachine.ChangeState<FireFrontState>();
        }
    }

    private void targetPlayer()
    {
        enemyToPlayer = player.position - transform.position;
        targetDir = enemyToPlayer.normalized;
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

    public override void Exit()
    {
/*        Debug.Log("Exit Decide");*/
    }
}
