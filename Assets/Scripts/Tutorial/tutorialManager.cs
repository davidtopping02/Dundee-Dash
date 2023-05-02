using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public Canvas tutorial;

    // Start is called before the first frame update
    void Awake()
    {

        // PlayerPrefs.SetInt("FIRSTTIMEOPENING", 1);

        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            enterTutorial();

        }
    }

    private void enterTutorial()
    {
        Time.timeScale = 0;
        tutorial.gameObject.SetActive(true);
        MainGameEvents.pauseControlls.Invoke();
    }

}
