using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    public float currHealth;
    public float maxHealth;
    public int score;
    public bool loadedPreviously;
    public CarryOverPlayerStats stats;

    public void Awake()
    {
        currHealth = stats.currHealth;
        maxHealth = stats.maxHealth;
        loadedPreviously = stats.loadedPreviously;
        score = stats.score;
/*        Debug.Log("PlayerStatManager Score is: " + score.ToString());
        Debug.Log("PlayerStatManager loadedPreviously is: " + loadedPreviously.ToString());*/
    }

    public void Update()
    {
        if (!loadedPreviously)
        {
            loadedPreviously=true;
            stats.loadedPreviously = true;
        }
        stats.currHealth = currHealth;
        stats.maxHealth = maxHealth; 
        stats.score = score;
    }
}
