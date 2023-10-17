using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireFrontState : State
{
    public GameEvents FireFront;

    public override void Enter()
    {
        FireFront.Raise(this, true);
    }

    public override void Tick()
    {
    }

    public override void Exit()
    {

    }
}
