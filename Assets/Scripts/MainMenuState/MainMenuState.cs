using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuState : BaseState
{
    // The state to change to when this state is done.
    private BaseState stateToChangeTo;

    // The button that triggers the game to start.
    private Button playButton;

    public MainMenuState() : base()
    {
        // Set the state to change to as itself.
        stateToChangeTo = this;
        Debug.Log("in main menu state");
    }

    public override void OnEnter()
    {
        // Load the new scene asynchronously.
        SceneManager.LoadSceneAsync("MainMenu");

        // Add a listener to the sceneLoaded event.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void PlayBUttonClick()
    {
        Debug.Log("Button clicked!");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the sceneLoaded event.
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Print the name of the scene.
        Debug.Log("Current scene: " + scene.name);

        // Get the Button component from the button game object
        // Check if the button is already set.
        if (playButton == null)
        {
            // Find the button GameObject and get the Button component.
            GameObject buttonGameObject = GameObject.Find("PlayGameButton");

            if (buttonGameObject != null)
            {
                Debug.Log("buttonGameObject != null");
            }
            else
            {
                Debug.Log("buttonGameObject == null");
            }

            playButton = buttonGameObject.GetComponent<Button>();


            if (playButton != null)
            {
                Debug.Log("playButton != null");
            }
            else
            {
                Debug.Log("playButton == null");
            }

            Debug.Log("playButton type is: " + playButton.GetType().Name);

            // Add a listener to the button
            playButton.onClick.AddListener(PlayBUttonClick);

            if (playButton.onClick.GetPersistentEventCount() > 0)
            {
                Debug.Log("Button has listeners attached.");
            }
            else
            {
                Debug.Log("Button has NO listeners attached.");
            }
        }
    }


    public override State OnUpdate()
    {
        return stateToChangeTo;
    }
}
