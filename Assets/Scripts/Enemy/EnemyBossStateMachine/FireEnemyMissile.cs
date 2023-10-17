using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyMissile : MonoBehaviour
{
    [SerializeField]
    private bool fireMissile;
    [SerializeField]
    private GameObject enemyMissilePrefab;

    void Update()
    {
        if(fireMissile)
        {
            GameObject missile = Instantiate(enemyMissilePrefab, transform.position, transform.rotation);
            Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>();
            missile.transform.parent = transform;
            fireMissile = false;
        }
    }

    public void volleyFire(Component sender, object data)
    {
        if ( data is bool)
        {
            fireMissile = (bool) data;
        }
    }
}
