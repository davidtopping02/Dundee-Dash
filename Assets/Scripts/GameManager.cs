// context script for the finite state machine
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // for the singleton functionality
    public static GameManager _instance = null;
    public PlayerStats playerStats;

    // for state machine
    private BaseState currentState;

    /**
     * Code for singleton implementation
     */
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }


    /**
     * Code for the game manager functionality
     */
    private void Start()
    {
        currentState = new MainMenuState();
        playerStats = gameObject.AddComponent<PlayerStats>();
        currentState.OnEnter();

        // used to quicly reset the high score
    }

    void Update()
    {
        // On update, call the OnUpdate method of the current state. 
        HandleNewState(currentState.OnUpdate(), currentState);
    }

    void HandleNewState(BaseState newState, BaseState oldState)
    {
        if (newState != oldState)
        {
            currentState = newState;
            currentState.OnEnter();
        }
    }

}