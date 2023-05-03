using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource, effectSource;
    public AudioClip mainMenu;
    public AudioClip gameMusic;
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip death;

    public void changeMusicState()
    {
        if (musicSource.volume > 0)
        {
            musicSource.volume = 0;
        }
        else
        {
            musicSource.volume = 100;
        }
    }

    public void changeSoundFxState()
    {
        if (effectSource.volume > 0)
        {
            effectSource.volume = 0;
        }
        else
        {
            effectSource.volume = 100;
        }
    }

    public bool isMusicEnabled()
    {
        if (musicSource.volume > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isSoundFxEnabled()
    {
        if (effectSource.volume > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void playMainMenuMusic()
    {
        stopMusic();
        musicSource.PlayOneShot(mainMenu);
    }

    public void playGameMusic()
    {
        stopMusic();
        musicSource.clip = gameMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void stopMusic()
    {
        musicSource.loop = false;
        musicSource.Stop();
    }

    public void jumpSound()
    {
        effectSource.PlayOneShot(jump);
    }

    public void coinSound()
    {
        effectSource.PlayOneShot(coin);
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

    public float getMasterVol()
    {
        return AudioListener.volume;
    }
}
