using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteController : MonoBehaviour
{
    public Volume globalVolume; // Reference to the Global Volume in your hierarchy
    private Vignette vignette; // Reference to the Vignette component

    [Range(0f, 1f)]
    public float vignetteIntensity = 0.5f; // Intensity of the vignette effect

    [Range(0f, 1f)]
    public float vignetteSmoothness = 0.5f; // Smoothness of the vignette effect

    public float transitionDuration = 1.0f; // Duration of the transition effect

    private float currentIntensity;
    private float currentSmoothness;
    private float targetIntensity;
    private float targetSmoothness;
    private float transitionTimer;

    // Store the original values
    private float originalIntensity;
    private float originalSmoothness;

    void Start()
    {
        // Ensure the Global Volume is assigned
        if (globalVolume == null)
        {
            Debug.LogError("Global Volume is not assigned!");
            return;
        }

        // Try to get the Vignette component from the Global Volume
        if (!globalVolume.profile.TryGet(out vignette))
        {
            // Add the Vignette component if it doesn't exist in the profile
            vignette = globalVolume.profile.Add<Vignette>();
        }

        // Ensure the Vignette component is not null
        if (vignette == null)
        {
            Debug.LogError("Vignette component not found or could not be added!");
            return;
        }

        // Initialize values
        currentIntensity = vignette.intensity.value;
        currentSmoothness = vignette.smoothness.value;
        targetIntensity = currentIntensity;
        targetSmoothness = currentSmoothness;

        // Store the original values
        originalIntensity = vignetteIntensity;
        originalSmoothness = vignetteSmoothness;
    }

    // Method to gradually change vignette parameters
    public void ChangeVignetteParameters()
    {
        // Update target values
        targetIntensity = vignetteIntensity;
        targetSmoothness = vignetteSmoothness;

        // Start transition
        transitionTimer = 0f;
    }

    // Method to revert vignette parameters to their original values gradually
    public void RevertVignetteParameters()
    {
        // Set the values back to their original state
        vignetteIntensity = originalIntensity;
        vignetteSmoothness = originalSmoothness;

        // Start transition to revert to original values
        ChangeVignetteParameters();
    }

    void Update()
    {
        // Gradually transition vignette parameters
        if (transitionTimer < transitionDuration)
        {
            transitionTimer += Time.deltaTime;
            float t = Mathf.Clamp01(transitionTimer / transitionDuration);

            // Apply gradual changes
            vignette.intensity.Override(Mathf.Lerp(currentIntensity, targetIntensity, t));
            vignette.smoothness.Override(Mathf.Lerp(currentSmoothness, targetSmoothness, t));
        }

        // Update current values
        currentIntensity = vignette.intensity.value;
        currentSmoothness = vignette.smoothness.value;
    }
}
