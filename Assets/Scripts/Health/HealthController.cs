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

    private PlayerStatManager statManager;
    private bool isPlayer = false;

    private void Awake()
    {
        statManager = GetComponent<PlayerStatManager>();
        if (statManager != null)
        {
            isPlayer = true;
            if (statManager.loadedPreviously)
            {
                maxHealth = statManager.maxHealth;
                currHealth = statManager.currHealth;
                onHealthChange.Invoke();
            }
            else
            {
                statManager.maxHealth = maxHealth;
                statManager.currHealth = currHealth;
            }
        }
    }

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
        if (isPlayer) { statManager.currHealth = currHealth; }

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
        if (isPlayer) { statManager.currHealth = currHealth; }

        if (currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }
    }

    public void kill()
    {
        currHealth = 0;
        onDeath.Invoke();
    }
    
}
