using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton instance

    public AudioSource voiceoverSource; // Reference to the AudioSource for voiceover clips

    // AudioClip variables for different voiceover clips
    public AudioClip introClip;
    public AudioClip midGameClip;
    public AudioClip secondMidGameClip;
    public AudioClip endGameClip;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayIntroVoiceoverWithDelay(4f);
    }

    // Method to play the intro voiceover clip with a delay
    public void PlayIntroVoiceoverWithDelay(float delay)
    {
        StartCoroutine(PlayVoiceoverDelayed(introClip, delay));
    }

    // Method to play the mid-game voiceover clip with a delay
    public void PlayMidGameVoiceoverWithDelay(float delay)
    {
        StartCoroutine(PlayVoiceoverDelayed(midGameClip, delay));
    }

    // Method to play the second mid-game voiceover clip with a delay
    public void Play2ndMidGameVoiceoverWithDelay(float delay)
    {
        StartCoroutine(PlayVoiceoverDelayed(secondMidGameClip, delay));
    }

    // Method to play the end-game voiceover clip with a delay
    public void PlayEndGameVoiceoverWithDelay(float delay)
    {
        StartCoroutine(PlayVoiceoverDelayed(endGameClip, delay));
    }

    // Coroutine to play a voiceover clip after a delay
    public IEnumerator PlayVoiceoverDelayed(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (voiceoverSource != null && clip != null)
        {
            voiceoverSource.clip = clip;
            voiceoverSource.Play();
        }
    }
}
