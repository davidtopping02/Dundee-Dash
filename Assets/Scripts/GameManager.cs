using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    private State state;

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
        state = new LoadingState();
        state.OnEnter();
    }

    void Update()
    {
        // On update, call the OnUpdate method of the current state. 
        HandleNewState(state.OnUpdate(), state);
    }

    void FixedUpdate()
    {
        // On FixedUpdate, call the OnFixedUpdate method of the current state.
        HandleNewState(state.OnFixedUpdate(), state);
    }

    void HandleNewState(State newState, State oldState)
    {
        if (newState != oldState)
        {
            state = newState;
            state.OnEnter();
        }
    }


}