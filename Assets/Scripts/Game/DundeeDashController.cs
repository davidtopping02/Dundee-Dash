using System.Collections;
using UnityEngine;


public class DundeeDashController : MonoBehaviour
{
    private Stopwatch stopwatch;
    public static float moveSpeed;
    bool playerDead;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 35;
        stopwatch = gameObject.AddComponent<Stopwatch>();
        MainGameEvents.fullObstacleCollision.AddListener(FullCollision);
        MainGameEvents.playerTrip.AddListener(PlayerTrip);
        MainGameEvents.quitGame.AddListener(quitGame);
        GameManager._instance.playerStats.Reset();
        playerDead = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDead)
        {
            checkForDeath();
            updatePlayerScore();
            updateMoveSpeed();
        }
    }

    private void updateMoveSpeed()
    {
        // this factor takes 3mins to reach full speed
        float acceleration = 0.1389f;

        if (moveSpeed > 0)
        {
            // Increase the move speed based on the elapsed time
            moveSpeed += acceleration * Time.deltaTime;
            int maxSpeed = 60;

            // Cap the move speed at the maximum value
            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }

        }

    }

    private void checkForDeath()
    {
        if (GameManager._instance.playerStats.getHealth() <= 0)
        {
            playerDead = true;
            MainGameEvents.playerFall.Invoke();
            GameManager._instance.GetComponent<AudioManager>().jumpSound();
            StartCoroutine(WaitTwoSeconds());
        }
    }

    IEnumerator WaitTwoSeconds()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        MainGameEvents.playerDeath.Invoke();
        Destroy(gameObject);
    }

    private void updatePlayerScore()
    {
        int currentScore = (Mathf.RoundToInt(stopwatch.GetElapsedTime() * 100));

        //update the player's score in the singleton
        GameManager._instance.playerStats.setCurrentScore(currentScore);
    }

    private void FullCollision()
    {
        moveSpeed = 0;
        GameManager._instance.playerStats.setHealth(-1);
        stopwatch.Pause();
    }

    private void PlayerTrip()
    {
        GameManager._instance.playerStats.setHealth(-0.5f);
        StartCoroutine(resetPlayerHealth());

    }

    IEnumerator resetPlayerHealth()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second
        GameManager._instance.playerStats.setHealth(1);
    }

    private void quitGame()
    {
        MainGameEvents.suddenGameEnd.Invoke();
    }
}
