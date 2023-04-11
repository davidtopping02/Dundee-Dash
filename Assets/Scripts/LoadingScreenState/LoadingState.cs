using UnityEngine;

public class LoadingState : BaseState
{
    private BaseState stateToChangeTo;

    public LoadingState() : base()
    {
        stateToChangeTo = this;
    }

    public override void OnEnter()
    {
        Debug.Log("in loading state");
        changeScene();

    }

    private void changeScene()
    {
        stateToChangeTo = new MainMenuState();
    }

    public override State OnUpdate()
    {
        return stateToChangeTo;
    }


}