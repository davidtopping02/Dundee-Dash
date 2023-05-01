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
        MainGameEvents.coinCollected.AddListener(incrementCoins);
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
        float timeToMaxSpeed = 30f;
        float maxSpeed = 60;
        float acceleration = 2 * maxSpeed / (timeToMaxSpeed * timeToMaxSpeed);

        if (moveSpeed < maxSpeed)
        {
            moveSpeed += acceleration * Time.deltaTime;
            moveSpeed = Mathf.Min(moveSpeed, maxSpeed);
        }
    }

    private void checkForDeath()
    {
        if (GameManager._instance.playerStats.getHealth() <= 0)
        {
            moveSpeed = 0;
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

    private void incrementCoins()
    {
        GameManager._instance.playerStats.addCoin();
    }
}
