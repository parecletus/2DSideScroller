using UnityEngine;

public class StateMachine
{
    public State state;
    public bool forcedstate;
    public void Start(State _newState) //You cant exit null soo we start with this
    {
        state = _newState;
        state.Enter();
    }

    public void Set(State _newState, bool forced = false)
    {
        if (state != _newState && !forcedstate) // change state if its not same state
        {
            state.Exit();
            state = _newState;
            state.Enter();
        }
        if (forced) forcedstate = true;  // Some states should not be intrupted so we setup a bool that enables or disables immunity.
    }
    public void forced()
    { // This is like a button. it switches whenever called. It is hard to remember if a value should be true or false. Also easier to write.
        forcedstate = !forcedstate;
    }
}
