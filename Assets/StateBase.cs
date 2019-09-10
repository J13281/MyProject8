using UnityEngine;

abstract class StateBase
{
    public StateBase nextState;
    public bool IsComplate;

    public abstract void Update();

    public void Transition(StateBase nextState)
    {
        Debug.Log($"{GetType().Name} -> {nextState.GetType().Name}");

        IsComplate = true;
        this.nextState = nextState;
    }

    public virtual void OnButtonClick(string s) { }
}