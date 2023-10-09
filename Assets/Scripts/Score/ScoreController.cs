using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent scoreUpdate;
    public int Score {  get; private set; }
    public bool canDash { get; private set; }
    public bool homingMissile { get; private set; }

    [Header("Unlock Upgrades")]
    [SerializeField] public int dashUnlock;
    [SerializeField] public int homingMissileUnlock;

    public void addScore(int amt)
    {
        Score += amt;
        scoreUpdate.Invoke();
        if (Score >= dashUnlock)
        {
            canDash = true;
        }
        if (Score >= homingMissileUnlock)
        {
            homingMissile = true;
        }
    }

    public void Reset()
    {
        Score = 0;
        scoreUpdate.Invoke();
    }
}
