using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrState => currState;
    State currState;

    protected bool InTransition;

    private void Start()
    {
        ChangeState<ChasePlayerState>();
    }

    public void ChangeState<T>() where T : State
    {
        T targetState = GetComponent<T>();
        if(targetState == null)
        {
            Debug.Log("tried to change to null state");
            return;
        }
        InitiateNewState(targetState);
    }

    void InitiateNewState(State targetState)
    {
        if (currState != targetState && !InTransition)
        {
            CallNewState(targetState);
        }
    }

    void CallNewState(State newState)
    {
        InTransition = true;

        //
        currState?.Exit();
        currState = newState;
        currState?.Enter();
        //

        InTransition = false;
    }

    private void Update()
    {
        if(CurrState != null && !InTransition)
        {
            CurrState.Tick();
        }
    }

}
