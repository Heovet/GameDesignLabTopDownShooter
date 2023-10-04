using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float damageAmt;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.takeDamage(damageAmt);
        }
    }
}
