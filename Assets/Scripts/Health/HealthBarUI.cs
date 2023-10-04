using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image hpBar;
    public void updateHealthBar(HealthController hc)
    {
        hpBar.fillAmount = hc.remainingHealthPercent;
    }
}
