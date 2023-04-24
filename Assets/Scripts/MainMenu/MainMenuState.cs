using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : BaseState
{
    // BaseState changedState;

    public MainMenuState() : base()
    {
        changedState = this;
        Debug.Log("in main menu state");
    }

    public override void OnEnter()
    {
        // Load the new scene asynchronously.
        SceneManager.LoadScene("MainMenu");

        GameManager._instance.GetComponent<AudioManager>().playMainMenuMusic();


        // add onclick functionality
        MainMenuEvents.playButtonClicked.AddListener(PlayButtonClick);
    }


    public void PlayButtonClick()
    {
        // instantiate a new main game state
        changedState = new MainGameState();

    }

    public override BaseState OnUpdate()
    {
        return changedState;
    }
}
