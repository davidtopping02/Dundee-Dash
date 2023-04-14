using System.Collections;
using UnityEngine;


public class DundeeDashController : MonoBehaviour
{
    private Stopwatch stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        stopwatch = gameObject.AddComponent<Stopwatch>();
        MainGameEvents.fullObstacleCollision.AddListener(FullCollision);
        MainGameEvents.playerTrip.AddListener(PlayerTrip);
        MainGameEvents.quitGame.AddListener(quitGame);
        GameManager._instance.playerStats.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        checkForDeath();
        updatePlayerScore();
    }

    private void checkForDeath()
    {
        if (GameManager._instance.playerStats.getHealth() <= 0)
        {
            MainGameEvents.playerFall.Invoke();
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
