using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float health;
    private int currentScore;
    private int highScore;
    private bool highScoreSet;
    private string nickName;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("hiScore");
        //nickName = PlayerPrefs.GetString("nickName");
        setNickName("DavyT");
        highScoreSet = false;
    }

    public void Reset()
    {
        health = 1;
        currentScore = 0;
        highScoreSet = false;
    }

    public void setNickName(string newNickName)
    {
        nickName = newNickName;
        PlayerPrefs.SetString("nickName", nickName);
        StartCoroutine(testNicname());
    }

    public IEnumerator testNicname()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(GameManager._instance.globalLeaderBoard.setPlayerName(nickName));
    }

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
        }

        StartCoroutine(GameManager._instance.globalLeaderBoard.SubmitScore(currentScore));
        // setHighScore(0);
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
        PlayerPrefs.SetInt("hiScore", x);
        PlayerPrefs.Save();
    }

    public int getHighScore()
    {
        return highScore;
    }

    public bool isHighScoreSet()
    {
        return highScoreSet;
    }
}
