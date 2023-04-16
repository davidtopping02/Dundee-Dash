using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    private float startTime;
    private float pausedTime;
    private bool isRunning;

    // Start the stopwatch
    private void Start()
    {
        startTime = Time.time;
        isRunning = true;
    }

    // Get the elapsed time in seconds
    public float GetElapsedTime()
    {
        if (isRunning)
        {
            return Time.time - startTime - pausedTime;
        }
        else
        {
            return pausedTime;
        }
    }

    // Pause the stopwatch
    public void Pause()
    {
        if (isRunning)
        {
            isRunning = false;
            pausedTime = Time.time - startTime - pausedTime;
        }
    }
}
