public abstract class BaseState
{

    // On Enter should implement any one-off logic that needs to happen when the state is entered.
    public abstract void OnEnter();

    // On Update should implement any logic that needs to happen every frame.
    public abstract BaseState OnUpdate();

}