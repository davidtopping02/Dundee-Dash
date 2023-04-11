using UnityEngine;
using UnityEngine.Events;

public class PlayButtonScript : MonoBehaviour
{
    public void PlayButtonClick()
    {
        MainMenuEvents.playButtonClicked.Invoke();
    }
}

public static class MainMenuEvents
{
    public static UnityEvent playButtonClicked = new UnityEvent();
}