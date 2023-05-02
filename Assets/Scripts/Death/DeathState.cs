using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathState : BaseState
{
    //BaseState changedState;

    public DeathState() : base()
    {
        changedState = this;
        Debug.Log("in main death state");
    }

    public override void OnEnter()
    {

        // save player high score
        GameManager._instance.playerStats.saveHighScore();
        GameManager._instance.playerStats.saveCoins();
        Debug.Log(PlayerPrefs.GetInt("coins"));
        GameManager._instance.GetComponent<AudioManager>().stopMusic();



        // Load the new scene asynchronously.
        SceneManager.LoadSceneAsync("DeathScene");

        // Add a listener to the sceneLoaded event.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the sceneLoaded event.
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // add onclick functionality
        // make event handler for this state
        DeathScreenEvents.MainMenuButtonClicked.AddListener(MainMenuButton);

    }

    public void MainMenuButton()
    {
        // instantiate a new main game state
        changedState = new MainMenuState();

    }

    public override BaseState OnUpdate()
    {
        return changedState;
    }
}
