using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameState : BaseState
{
    // The state to change to when this state is done.
    //private BaseState changedState;

    public MainGameState() : base()
    {
        // Set the state to change to as itself.
        changedState = this;
        Debug.Log("in main game state");

        MainGameEvents.playerDeath.AddListener(playerDeath);
        MainGameEvents.suddenGameEnd.AddListener(returnToMainMenu);

    }

    private void playerDeath()
    {
        changedState = new DeathState();
    }

    private void returnToMainMenu()
    {
        changedState = new MainMenuState();
    }

    public override void OnEnter()
    {
        // Load the new scene asynchronously.
        SceneManager.LoadScene("MainGame");
        GameManager._instance.GetComponent<AudioManager>().playGameMusic();


    }

    public override BaseState OnUpdate()
    {
        return changedState;
    }
}
