using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource, effectSource;
    public AudioClip mainMenu;
    public AudioClip gameMusic;
    public AudioClip jump;
    public AudioClip duck;
    public AudioClip death;

    void Start()
    {
        // Set the loop property of the musicSource to true
        musicSource.loop = true;
    }

    public void playMainMenuMusic()
    {
        stopMusic();
        musicSource.PlayOneShot(mainMenu);
    }

    public void playGameMusic()
    {
        stopMusic();
        musicSource.PlayOneShot(gameMusic);
    }

    public void stopMusic()
    {
        musicSource.Stop();
    }

    public void jumpSound()
    {
        effectSource.PlayOneShot(jump);
    }

    public void duckSound()
    {
        effectSource.PlayOneShot(duck);
    }

    public void deathSound()
    {
        effectSource.PlayOneShot(death);
    }


    // TODO create volume slider
    public void changeMasterVol(float vol)
    {
        AudioListener.volume = vol;
    }
}
