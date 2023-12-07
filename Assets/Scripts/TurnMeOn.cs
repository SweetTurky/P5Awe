using UnityEngine;

public class TurnMeOn : MonoBehaviour
{
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
    }
}
