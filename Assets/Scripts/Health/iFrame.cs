using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iFrame : MonoBehaviour
{
    private HealthController hc;

    private void Awake()
    {
        hc = GetComponent<HealthController>();
    }

    public void startIFrame(float invincibilityDur)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDur));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDur)
    {
        hc.iFrame = true;
        yield return new WaitForSeconds(invincibilityDur);
        hc.iFrame = false;
    }
}
