using UnityEngine;

public class leaderBoardButton : MonoBehaviour
{
    public GameObject leaderboardCanvas;
    public GameObject settingsCanvas;

    public void leaderboardButtonClicked()
    {
        if (leaderboardCanvas.activeSelf)
        {
            leaderboardCanvas.SetActive(false);
        }
        else
        {
            settingsCanvas.SetActive(false);
            leaderboardCanvas.SetActive(true);
        }
    }

    public void settingsButtonClicked()
    {
        if (settingsCanvas.activeSelf)
        {
            settingsCanvas.SetActive(false);
        }
        else
        {
            leaderboardCanvas.SetActive(false);
            settingsCanvas.SetActive(true);

        }

    }
}
