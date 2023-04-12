using UnityEngine;


public class DundeeDashController : MonoBehaviour
{
    private Stopwatch stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        stopwatch = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerScore();
    }

    private void updatePlayerScore()
    {
        int currentScore = (Mathf.RoundToInt(stopwatch.GetElapsedTime() * 100));

        //update the player's score in the singleton
        GameManager._instance.playerStats.setCurrentScore(currentScore);
    }


}
