using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float health;
    private int currentScore;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        currentScore = 0;

        //implement this functionality
        highScore = 0;
    }

    public void Reset()
    {
        health = 1;
        currentScore = 0;
    }

    public void saveHighScore()
    {
        if (PlayerPrefs.HasKey("hiScore"))
        {
            if (currentScore > PlayerPrefs.GetInt("hiScore"))
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("hiScore", highScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("hiScore", highScore);
            PlayerPrefs.Save();
        }

        //  PlayerPrefs.SetInt("hiScore", 0);
        //PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("hiScore"));
    }

    public void setHealth(float x)
    {
        health += x;
    }

    public float getHealth()
    {
        return health;
    }

    public void setCurrentScore(int x)
    {
        currentScore = x;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    public void setHighScore(int x)
    {
        highScore = x;
    }
}
