using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FireMissile : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float missileV;
    [SerializeField] private float reloadTime;

    private bool firing;
    private bool fireSingle;
    private float lastFired;

    void Update()
    {
        if (firing || fireSingle)
        {
            float lastFireTime = Time.time - lastFired;
            if(lastFireTime > reloadTime)
            {
                fireMissile();
                lastFired = Time.time;
                fireSingle = false;
            }
        }
    }

    private void fireMissile()
    {
        GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);
        Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>();
        missileRb.velocity = missileV * transform.up;
        missile.transform.parent = transform;
    }

    private void OnFire(InputValue inVal)
    {
        firing = inVal.isPressed;
        if(inVal.isPressed)
        {
            fireSingle = true;
        }
    }
}
