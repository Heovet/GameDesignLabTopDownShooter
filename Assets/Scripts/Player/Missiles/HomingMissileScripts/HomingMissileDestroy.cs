using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileDestroy : MonoBehaviour
{
    private Camera m_Camera;
    public bool toDestroy { get; private set; }

    private void Awake()
    {
        m_Camera = Camera.main;
        toDestroy = false;
    }

    private void Update()
    {
        DestroyOffScreen();
        transform.position = transform.parent.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AlienShipMovement>())
        {
            HealthController enemyHC = collision.GetComponent<HealthController>();
            enemyHC.takeDamage(10);
            /*            Destroy(collision.gameObject);*/
/*            Destroy(gameObject);*/
            toDestroy = true;
        }
    }

    private void DestroyOffScreen()
    {
        Vector2 screenPosition = m_Camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > m_Camera.pixelWidth || screenPosition.y < 0 || screenPosition.y > m_Camera.pixelHeight)
        {
/*            Destroy(gameObject);*/
            toDestroy = true;
        }
    }
}
