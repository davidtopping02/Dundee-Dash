using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameState : BaseState
{
    // The state to change to when this state is done.
    private BaseState changedState;

    public MainGameState() : base()
    {
        // Set the state to change to as itself.
        changedState = this;
        Debug.Log("in main game state");
    }


    public override void OnEnter()
    {
        // Load the new scene asynchronously.
        SceneManager.LoadScene("MainGame");

    }

    public override BaseState OnUpdate()
    {
        return changedState;
    }
}
