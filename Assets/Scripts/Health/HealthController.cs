using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currHealth;
    [SerializeField] 
    private float maxHealth;

    public float remainingHealthPercent { get { return currHealth/maxHealth; } }
    public bool iFrame { get; set; }

    public UnityEvent onDeath;
    public UnityEvent onDmg;
    public UnityEvent onHealthChange;

    public void takeDamage(float damageAmt)
    {
        if (currHealth == 0)
        {
            return;
        }

        if (iFrame)
        {
            return;
        }
        currHealth -= damageAmt;
        onHealthChange.Invoke();

        if (currHealth < 0)
        {
            currHealth = 0;
        }
        
        if(currHealth == 0)
        {
            onDeath.Invoke();
        }
        else
        {
            onDmg.Invoke();
        }
    }

    public void addHealth(float healing)
    {
        if (currHealth == maxHealth)
        {
            return;
        }
        currHealth += healing;
        onHealthChange.Invoke();

        if (currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }
    }

    
}
