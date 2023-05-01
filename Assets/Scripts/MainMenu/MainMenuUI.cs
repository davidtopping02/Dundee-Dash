using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI playerNamesLeaderboard;
    public TextMeshProUGUI playeScoresLeaderboard;



    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + GameManager._instance.playerStats.getHighScore();
        coinText.text = PlayerPrefs.GetInt("coins").ToString();
        UpdateLeaderboard();
    }

    private void Update()
    {
        UpdateLeaderboard();
    }

    private void UpdateLeaderboard()
    {
        // Update the text fields
        playerNamesLeaderboard.text = GameManager._instance.globalLeaderBoard.PlayerNames;
        playeScoresLeaderboard.text = GameManager._instance.globalLeaderBoard.PlayerScores;
    }
}
