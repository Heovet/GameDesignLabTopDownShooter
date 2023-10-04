using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addScore : MonoBehaviour
{
    [SerializeField]
    private int mScore = 0;

    private ScoreController mController;

    private void Awake()
    {
        mController = FindObjectOfType<ScoreController>();
    }

    public void add()
    {
        mController.addScore(mScore);
    }
}
