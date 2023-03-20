using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    private float startTime;

    // Start the stopwatch
    private void Start()
    {
        startTime = Time.time;
    }

    // Get the elapsed time in seconds
    public float GetElapsedTime()
    {
        return Time.time - startTime;
    }
}
