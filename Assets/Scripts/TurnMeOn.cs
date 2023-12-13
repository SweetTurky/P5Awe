using UnityEngine;

public class TurnMeOn : MonoBehaviour
{
    public TorchManager torchManager; // Reference to the TorchManager script
    public AudioSource audioSourceWhoosh; // Reference to the AudioSource component
    public AudioSource audioSourceBurning; // Reference to the AudioSource component
    public ParticleSystem[] particleSystems;
    public Light[] lights;

    private bool hasBeenLit = false; // Flag to track if the torch has been lit

    private void Awake()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        lights = GetComponentsInChildren<Light>();
    }

    public void ActivateLightAndParticles()
    {
        // If the torch has already been lit, return to avoid re-triggering the torch lit logic
        if (hasBeenLit)
        {
            return;
        }

        // Activate lights and particle systems on collision

        foreach (Light light in lights)
        {
            light.enabled = true;
        }


        foreach (ParticleSystem particles in particleSystems)
        {
            particles.Play();
        }

        // Play the audio clip if an AudioSource component is assigned
        if (audioSourceWhoosh != null && audioSourceBurning != null)
        {
            if (!audioSourceWhoosh.isPlaying && !audioSourceBurning.isPlaying) // Check if the audio is not already playing
            {
                audioSourceWhoosh.Play();
                audioSourceBurning.Play();
            }
        }

        // Set the flag to true indicating the torch has been lit
        hasBeenLit = true;

        // Notify the TorchManager that this torch has been lit
        if (torchManager != null)
        {
            torchManager.TorchLit();
        }
    }
}
