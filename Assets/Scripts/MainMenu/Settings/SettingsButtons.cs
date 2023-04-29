using TMPro;
using UnityEngine;

public class SettingsButtons : MonoBehaviour
{
    public TextMeshProUGUI musicButtonTxt;
    public TextMeshProUGUI soundFxButtonTxt;

    public void soundFxButtonClick()
    {
        // change state of music controller
        GameManager._instance.GetComponent<AudioManager>().changeSoundFxState();

        // change button text
        if (GameManager._instance.GetComponent<AudioManager>().isSoundFxEnabled())
        {
            soundFxButtonTxt.text = "Toggle Sound Fx\r\n (Off)";
        }
        else
        {
            soundFxButtonTxt.text = "Toggle Sound Fx\r\n (On)";
        }
    }

    public void musicButtonClick()
    {
        GameManager._instance.GetComponent<AudioManager>().changeMusicState();

        // change button text
        if (GameManager._instance.GetComponent<AudioManager>().isMusicEnabled())

        {
            musicButtonTxt.text = "Toggle music Fx\r\n (Off)";
        }
        else
        {
            musicButtonTxt.text = "Toggle music Fx\r\n (On)";
        }
    }
}