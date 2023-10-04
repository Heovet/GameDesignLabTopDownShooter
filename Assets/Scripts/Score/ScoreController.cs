using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent scoreUpdate;
    public int Score {  get; private set; }

    public void addScore(int amt)
    {
        Score += amt;
        scoreUpdate.Invoke();
    }

    public void Reset()
    {
        Score = 0;
        scoreUpdate.Invoke();
    }
}
