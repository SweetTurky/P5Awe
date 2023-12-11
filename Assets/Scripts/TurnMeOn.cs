using UnityEngine;

public class TurnMeOn : MonoBehaviour
{
    public TorchManager torchManager; // Reference to the TorchManager script
    public AudioSource audioSourceWhoosh; // Reference to the AudioSource component
    public AudioSource audioSourceBurning; // Reference to the AudioSource component

    public void ActivateLightAndParticles()
    {
        // Activate lights and particle systems on collision
        Light[] lights = GetComponentsInChildren<Light>();
        foreach (Light light in lights)
        {
            light.enabled = true;
        }

        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particles in particleSystems)
        {
            particles.Play();
        }

        // Play the audio clip if an AudioSource component is assigned
        if (audioSourceWhoosh != null && audioSourceBurning != null)
        {
            if (!audioSourceWhoosh.isPlaying && !audioSourceBurning.isPlaying) // Check if the audio is not already playing
            {
                audioSourceWhoosh.PlayOneShot(audioSourceWhoosh.clip);
                audioSourceBurning.Play();
            }
        }

        // Notify the TorchManager that this torch has been lit
        if (torchManager != null)
        {
            torchManager.TorchLit();
        }
    }
}
