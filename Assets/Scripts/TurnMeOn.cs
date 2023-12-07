using UnityEngine;

public class TurnMeOn : MonoBehaviour
{
    public Light[] pointLights; // Array of point lights
    public ParticleSystem[] particleSystems; // Array of particle systems

    public void ActivateLightAndParticles()
    {
        // Activate all point lights in the array
        foreach (Light light in pointLights)
        {
            if (light != null)
            {
                light.enabled = true;
            }
        }

        // Play all particle systems in the array
        foreach (ParticleSystem particles in particleSystems)
        {
            if (particles != null)
            {
                particles.Play();
            }
        }
    }
}
