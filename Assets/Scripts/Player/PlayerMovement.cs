using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float screenBorder;

    private Rigidbody2D rb;
    private Vector2 movementIn;
    private Vector2 smoothMoveIn;
    private Vector2 smoothMoveV;
    private Camera screen;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        screen = Camera.main;
    }

    private void FixedUpdate()
    {
        setPlayerV();
        rotateToInput();
    }

    private void setPlayerV()
    {
        smoothMoveIn = Vector2.SmoothDamp(smoothMoveIn, movementIn, ref smoothMoveV, 0.1f);
        rb.velocity = smoothMoveIn * speed;

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
