using UnityEngine;

public abstract class BaseState
{
    protected MonoBehaviour monoBehaviour;
    protected BaseState changedState;

    // On Enter should implement any one-off logic that needs to happen when the state is entered.
    public abstract void OnEnter();

    // On Update should implement any logic that needs to happen every frame.
    public abstract BaseState OnUpdate();

}