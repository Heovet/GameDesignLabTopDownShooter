using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
    public void destroy(float waitTime)
    {
        Destroy(gameObject, waitTime);
    }
}
