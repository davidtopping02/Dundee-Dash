using UnityEngine;
using UnityEngine.SceneManagement;



// Defines the DeathState class which represents the state of the game when the player has died
public class DeathState : BaseState
{
    // Constructor for the DeathState class
    public DeathState() : base()
    {
        changedState = this;
        Debug.Log("in main death state");
    }

    // Called when the state is entered
    public override void OnEnter()
    {
        // Save the player's high score and coins
        GameManager._instance.playerStats.saveHighScore();
        GameManager._instance.playerStats.saveCoins();
        Debug.Log(PlayerPrefs.GetInt("coins"));

        // Stop the game music
        GameManager._instance.GetComponent<AudioManager>().stopMusic();

        // Load the DeathScene asynchronously
        SceneManager.LoadSceneAsync("DeathScene");

        // Add a listener to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Called when the DeathScene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        DeathScreenEvents.MainMenuButtonClicked.AddListener(MainMenuButton);
    }

    // Called when the MainMenuButton is clicked
    public void MainMenuButton()
    {
        changedState = new MainMenuState();
    }

    public override BaseState OnUpdate()
    {
        // Return the changed state
        return changedState;
    }

}
