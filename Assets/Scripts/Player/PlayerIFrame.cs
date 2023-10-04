using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIFrame : MonoBehaviour
{
    [SerializeField]
    private float invincibilityFrmDmg;
    private iFrame iF;

    private void Awake()
    {
        iF = GetComponent<iFrame>();
    }
    public void startIFrame()
    {
        iF.startIFrame(invincibilityFrmDmg);
    }
}
