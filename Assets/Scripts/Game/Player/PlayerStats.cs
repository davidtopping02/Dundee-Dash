using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Define private variables that store the player's current stats
    private float health;
    private int currentScore;
    private int highScore;
    private bool highScoreSet;
    private string nickName;
    private int coinsCollected;

    void Start()
    {
        // Initialize the player's stats
        coinsCollected = 0;
        health = 1;
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("hiScore");
        nickName = PlayerPrefs.GetString("nickName");
        highScoreSet = false;

    }

    // Reset the player's stats to default values
    public void Reset()
    {
        health = 1;
        currentScore = 0;
        coinsCollected = 0;
        highScoreSet = false;
    }

    // Add a coin to the player's collection
    public void addCoin()
    {
        coinsCollected++;
    }

    // Get the number of coins the player has collected
    public int getCoins()
    {
        return coinsCollected;
    }

    // Get the player's nickname
    public string getNickName()
    {
        return nickName;
    }

    // Set the player's nickname
    public void setNickName(string newNickName)
    {
        nickName = newNickName;
        PlayerPrefs.SetString("nickName", nickName);
        StartCoroutine(changeLootlockerName());
    }

    // Coroutine that changes the player's name in the global leaderboard
    public IEnumerator changeLootlockerName()
    {
        yield return GameManager._instance.globalLeaderBoard.setPlayerName(nickName);
    }

    // Save the player's high score
    public void saveHighScore()
    {
        if (PlayerPrefs.HasKey("hiScore"))
        {
            if (currentScore > PlayerPrefs.GetInt("hiScore"))
            {
                setHighScore(currentScore);
                highScoreSet = true;
            }
        }
        else
        {
            setHighScore(currentScore);
            highScoreSet = true;
        }

        StartCoroutine(GameManager._instance.globalLeaderBoard.SubmitScore(currentScore));
    }

    // Save the player's coins
    public void saveCoins()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coinsCollected);
        PlayerPrefs.Save();
    }

    // Set the player's health
    public void setHealth(float x)
    {
        health += x;
    }

    // Get the player's current health
    public float getHealth()
    {
        return health;
    }

    // Set the player's current score
    public void setCurrentScore(int x)
    {
        currentScore = x;
    }

    // Get the player's current score
    public int getCurrentScore()
    {
        return currentScore;
    }

    // Set the player's high score
    public void setHighScore(int x)
    {
        highScore = x;
        PlayerPrefs.SetInt("hiScore", x);
        PlayerPrefs.Save();
    }

    // Get the player's high score
    public int getHighScore()
    {
        return highScore;
    }

    // Check if the player's high score has been set
    public bool isHighScoreSet()
    {
        return highScoreSet;
    }
}
