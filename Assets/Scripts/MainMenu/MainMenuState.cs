using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : BaseState
{
    BaseState changedState;

    public MainMenuState() : base()
    {
        changedState = this;
        Debug.Log("in main menu state");
    }

    public override void OnEnter()
    {
        // Load the new scene asynchronously.
        SceneManager.LoadSceneAsync("MainMenu");

        // Add a listener to the sceneLoaded event.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the sceneLoaded event.
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // add onclick functionality
        MainMenuEvents.playButtonClicked.AddListener(PlayButtonClick);

    }

    public void PlayButtonClick()
    {

        Debug.Log("Button clicked!");
        // instantiate a new main game state
        changedState = new MainGameState();

    }

    public override BaseState OnUpdate()
    {
        return changedState;
    }
}
