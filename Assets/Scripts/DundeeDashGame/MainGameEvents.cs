using UnityEngine.Events;

public static class MainGameEvents
{
    public static UnityEvent fullObstacleCollision = new UnityEvent();
    public static UnityEvent playerTrip = new UnityEvent();
    public static UnityEvent playerDeath = new UnityEvent();

}
