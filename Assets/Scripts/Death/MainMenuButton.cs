using UnityEngine;
using UnityEngine.Events;

public class MainMenuButton : MonoBehaviour
{
    // MainMenuButtonClick function called when MainMenuButton is clicked
    public void MainMenuButtonClick()
    {
        // Invoke MainMenuButtonClicked event
        DeathScreenEvents.MainMenuButtonClicked.Invoke();
    }
}

public static class DeathScreenEvents
{
    public static UnityEvent MainMenuButtonClicked = new UnityEvent();
}