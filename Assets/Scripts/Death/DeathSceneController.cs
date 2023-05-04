using TMPro;
using UnityEngine;

// Defines the Death Scene Controller class which manages the UI of the death scene
public class DeathSceneController : MonoBehaviour
{
    // Canvas for displaying the regular player stats
    public Canvas regularPlayerStatsCanvas;

    // Text field for displaying the regular player's high score
    public TextMeshProUGUI regHighScore;

    // Text field for displaying the regular player's current score
    public TextMeshProUGUI regCurrentScore;

    // Canvas for displaying the high score message
    public Canvas highScoreCanvas;

    // Text field for displaying the high score
    public TextMeshProUGUI hHighScore;

    // Initializes the UI based on the player's high score
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
