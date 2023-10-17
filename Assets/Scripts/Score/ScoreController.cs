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
    [SerializeField] private int dashUnlock;
    [SerializeField] private int homingMissileUnlock;

    private PlayerStatManager statManager;

    public void Awake()
    {
        Debug.Log("ScoreController Awake");
        statManager = GetComponent<PlayerStatManager>();
        if (statManager != null)
        {
/*            Debug.Log("ScoreController Score is:" + statManager.score.ToString());
            Debug.Log("ScoreController LoadedPreviously is:" + statManager.loadedPreviously.ToString());*/
            if (statManager.loadedPreviously)
            {
                Score = statManager.score;
                scoreUpdate.Invoke();
            }
            else
            {
                Score = 0;
            }
        }
        else
        {
            Debug.Log("ScoreController cannot find statManager");
        }
    }
    public void Update()
    {
        if (Score >= dashUnlock)
        {
            canDash = true;
        }
        if (Score >= homingMissileUnlock)
        {
            homingMissile = true;
        }
    }
    public void addScore(int amt)
    {
        Score += amt;
        statManager.score = Score;
        scoreUpdate.Invoke();
    }

    public void Reset()
    {
/*        Debug.Log("ScoreReset!");*/
        scoreUpdate.Invoke();
    }
}
