using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int health;
    private int currentScore;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        health = 0;
        currentScore = 0;

        //implement this functionality
        highScore = 0;
    }

    public void setHealth(int x)
    {
        health += x;
    }

    public int getHealth()
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
