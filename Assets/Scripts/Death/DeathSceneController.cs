using TMPro;
using UnityEngine;

public class DeathSceneController : MonoBehaviour
{

    public Canvas regularPlayerStatsCanvas;
    public TextMeshProUGUI regHighScore;
    public TextMeshProUGUI regCurrentScore;

    public Canvas highScoreCanvas;
    public TextMeshProUGUI hHighScore;


    private void Start()
    {
        if (GameManager._instance.playerStats.isHighScoreSet())
        {
            highScoreCanvas.gameObject.SetActive(true);
            hHighScore.text = GameManager._instance.playerStats.getHighScore().ToString();
        }
        else
        {
            regularPlayerStatsCanvas.gameObject.SetActive(true);
            regHighScore.text = "High Score: " + GameManager._instance.playerStats.getHighScore().ToString();
            regCurrentScore.text = "Score: " + GameManager._instance.playerStats.getCurrentScore().ToString();
        }

    }




}
