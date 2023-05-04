using UnityEngine;

public class PauseFunctionality : MonoBehaviour
{
    public Canvas pauseScreen;

    // This method is called when the player clicks the pause button
    public void PauseGameButtonClick()
    {
        Debug.Log("paused");

        // Set the Time.timeScale value to 0, which effectively pauses the game
        Time.timeScale = 0;

        MainGameEvents.pauseControlls.Invoke();
        pauseScreen.gameObject.SetActive(true);
    }

    // This method is called when the player clicks the resume button
    public void ResumeGameButtonClick()
    {
        Debug.Log("resumed");

        // Set the Time.timeScale value to 1, which resumes the game
        Time.timeScale = 1;

        MainGameEvents.unPauseControlls.Invoke();
        pauseScreen.gameObject.SetActive(false);
    }

    // This method is called when the player clicks the quit button
    public void QuitGameButtonClick()
    {
        MainGameEvents.quitGame.Invoke();
        Time.timeScale = 1;
    }
}
