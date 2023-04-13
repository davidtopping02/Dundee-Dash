using UnityEngine;

public class PauseFunctionality : MonoBehaviour
{
    public Canvas pauseScreen;


    public void PauseGameButtonClick()
    {
        Debug.Log("paused");
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);

    }

    public void ResumeGameButtonClick()
    {
        Debug.Log("resumed");
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
    }

    public void QuitGameButtonClick()
    {
        MainGameEvents.quitGame.Invoke();
        Time.timeScale = 1;
    }
}
