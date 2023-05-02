using UnityEngine.Events;

public static class MainGameEvents
{
    public static UnityEvent fullObstacleCollision = new UnityEvent();
    public static UnityEvent playerTrip = new UnityEvent();
    public static UnityEvent playerFall = new UnityEvent();
    public static UnityEvent playerDeath = new UnityEvent();
    public static UnityEvent quitGame = new UnityEvent();
    public static UnityEvent suddenGameEnd = new UnityEvent();
    public static UnityEvent coinCollected = new UnityEvent();
    public static UnityEvent firstTimePlay = new UnityEvent();
    public static UnityEvent pauseControlls = new UnityEvent();
    public static UnityEvent unPauseControlls = new UnityEvent();
}
