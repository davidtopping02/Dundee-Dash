using UnityEngine;

// Defines the Audio Manager class which controls the game's audio
public class AudioManager : MonoBehaviour
{
    // Audio clips used for specific sounds and music tracks
    public AudioSource musicSource, effectSource;
    public AudioClip mainMenu;
    public AudioClip gameMusic;
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip death;

    // Changes the state of the music volume
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

    // Changes the state of the sound effect volume
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

    // Returns whether music is currently enabled
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

    // Returns whether sound effects are currently enabled
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

    // Plays the main menu music
    public void playMainMenuMusic()
    {
        stopMusic();
        musicSource.PlayOneShot(mainMenu);
    }

    // Plays the game music
    public void playGameMusic()
    {
        stopMusic();
        musicSource.clip = gameMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Stops the music playback
    public void stopMusic()
    {
        musicSource.loop = false;
        musicSource.Stop();
    }

    // Plays the jump sound effect
    public void jumpSound()
    {
        effectSource.PlayOneShot(jump);
    }

    // Plays the coin sound effect
    public void coinSound()
    {
        effectSource.PlayOneShot(coin);
    }

    // Plays the death sound effect
    public void deathSound()
    {
        effectSource.PlayOneShot(death);
    }

    // Changes the master volume of the game
    public void changeMasterVol(float vol)
    {
        AudioListener.volume = vol;
    }

    // Returns the current master volume of the game
    public float getMasterVol()
    {
        return AudioListener.volume;
    }
}
