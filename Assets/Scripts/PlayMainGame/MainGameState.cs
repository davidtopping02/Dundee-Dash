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


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the sceneLoaded event.
        SceneManager.sceneLoaded -= OnSceneLoaded;

        Debug.Log("scene loaded");

    }

    public override void OnEnter()
    {
        // Load the new scene asynchronously.
        SceneManager.LoadSceneAsync("MainGame");

        // Add a listener to the sceneLoaded event.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override BaseState OnUpdate()
    {
        return changedState;
    }
}
