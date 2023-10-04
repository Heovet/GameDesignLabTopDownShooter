using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text scoreTxt;

    private void Awake()
    {
        scoreTxt = GetComponent<TMP_Text>();
    }

    public void updateScoreUI(ScoreController scoreController)
    {
        scoreTxt.text = $"Ships Destroyed: {scoreController.Score}";
    }

}
