using UnityEngine;

public class leaveTutorialButton : MonoBehaviour
{

    public Canvas tutorial;

    public void playGame()
    {
        Time.timeScale = 1;
        MainGameEvents.unPauseControlls.Invoke();
        tutorial.gameObject.SetActive(false);
    }

}
