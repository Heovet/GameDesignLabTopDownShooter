using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("WASD Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Vector2 movementIn;
    private Vector2 smoothMoveIn;
    private Vector2 smoothMoveV;

    [Header("Screen Boarder")]
    [SerializeField] private float screenBorder;
    private Camera screen;

    [Header("Dashing Movement")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashLength;
    [SerializeField] private float dashCooldown;
    private float dashCounter;
    private float dashCoolCounter;
    private TrailRenderer trailRenderer;

    private Rigidbody2D rb;
    private float currSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        screen = Camera.main;
        trailRenderer = GetComponent<TrailRenderer>();
        currSpeed = speed;
    }

    private void FixedUpdate()
    {
        setPlayerV();
        rotateToInput();
        dashManager();
    }

    private void setPlayerV()
    {
        smoothMoveIn = Vector2.SmoothDamp(smoothMoveIn, movementIn, ref smoothMoveV, 0.1f);
        rb.velocity = smoothMoveIn * currSpeed;

        preventMovingOffScreen();
    }

    private void rotateToInput()
    {
        if(movementIn != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothMoveIn);
            Quaternion rotaion = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.SetRotation(rotaion);
        }
    }

    private void OnMove(InputValue iv)
    {
        movementIn = iv.Get<Vector2>();
    }

    private void dashManager()
    {
        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if(dashCounter < 0)
            {
                currSpeed = speed;
                dashCoolCounter = dashCooldown;
                trailRenderer.enabled = false;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void OnDash(InputValue iv)
    {
/*        Debug.Log("Dash!");*/
        if(dashCoolCounter <= 0 && dashCoolCounter <= 0)
        {
            currSpeed = dashSpeed;
            dashCounter = dashLength;
            trailRenderer.enabled = true;
        }
    }

    private void preventMovingOffScreen()
    {
        Vector2 screenPosition = screen.WorldToScreenPoint(transform.position);

        if((screenPosition.x < screenBorder && rb.velocity.x < 0)|| (screenPosition.x > screen.pixelWidth - screenBorder && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if ((screenPosition.y < screenBorder && rb.velocity.y < 0) || (screenPosition.y > screen.pixelHeight - screenBorder && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
