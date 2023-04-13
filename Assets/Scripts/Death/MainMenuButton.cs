using UnityEngine;
using UnityEngine.Events;


public class MainMenuButton : MonoBehaviour
{
    public void MainMenuButtonClick()
    {
        DeathScreenEvents.MainMenuButtonClicked.Invoke();
    }
}

public static class DeathScreenEvents
{
    public static UnityEvent MainMenuButtonClicked = new UnityEvent();
}