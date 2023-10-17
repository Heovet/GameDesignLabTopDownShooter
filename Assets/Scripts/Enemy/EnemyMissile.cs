using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Camera m_Camera;
    private Rigidbody2D rb;

    private void Awake()
    {
        m_Camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }
    
    private void Update()
    {
        DestroyOffScreen();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ScoreController>() != null)
        {
            HealthController playerHC = collision.GetComponent<HealthController>();
            playerHC.takeDamage(10);
            /*            Destroy(collision.gameObject);*/
            Destroy(gameObject);
        }
    }

    private void DestroyOffScreen()
    {
        Vector2 screenPosition = m_Camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > m_Camera.pixelWidth || screenPosition.y < 0 || screenPosition.y > m_Camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}