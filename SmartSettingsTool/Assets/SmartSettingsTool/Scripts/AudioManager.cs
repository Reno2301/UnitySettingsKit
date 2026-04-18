using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource backgroundMusicSource;
    public AudioSource hoverSoundSource;
    public AudioSource clickSoundSource;

    public AudioClip backgroundMusicClip;
    public AudioClip hoverClip;
    public AudioClip clickClip;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play background music
    public void PlayBackgroundMusic()
    {
        if (backgroundMusicSource.isPlaying) return;  // Prevent the music from starting multiple times
        backgroundMusicSource.clip = backgroundMusicClip;  // Set the correct clip in the AudioSource
        backgroundMusicSource.loop = true;  // Ensure the music keeps looping
        backgroundMusicSource.PlayOneShot(backgroundMusicClip);  // Play the music
    }

    void Start()
    {
        // Play background music when the game starts
        PlayBackgroundMusic();
    }

    // Play hover sound
    public void PlayHoverSound()
    {
        Debug.Log("Hover sound played");

        hoverSoundSource.PlayOneShot(hoverClip);
    }

    // Play click sound
    public void PlayClickSound()
    {
        Debug.Log("Click sound played");

        clickSoundSource.PlayOneShot(clickClip);
    }
}