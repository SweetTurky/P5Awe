using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteController : MonoBehaviour
{
    public Volume globalVolume; // Reference to the Global Volume in your hierarchy
    private Vignette vignette; // Reference to the Vignette component

    private float originalIntensity;
    private float originalSmoothness;

    public float transitionDuration = 1.0f; // Duration of the transition effect

    private float targetIntensity;
    private float targetSmoothness;
    private float transitionTimer;

    private void Start()
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

        // Store the original values
        originalIntensity = vignette.intensity.value;
        originalSmoothness = vignette.smoothness.value;
    }

    // Method to gradually increase vignette parameters
    public void GraduallyIncreaseVignette()
    {
        // Set target values for the increase
        targetIntensity = 0.90f; // You can adjust this value based on your needs
        targetSmoothness = 0.25f; // You can adjust this value based on your needs

        // Start the transition
        transitionTimer = 0f;
    }

    // Method to gradually revert vignette parameters to their original values
    public void GraduallyRevertVignette()
    {
        // Set target values for the revert
        targetIntensity = originalIntensity;
        targetSmoothness = originalSmoothness;

        // Start the transition
        transitionTimer = 0f;
    }

    private void Update()
    {
        // Gradually transition vignette parameters
        if (transitionTimer < transitionDuration)
        {
            transitionTimer += Time.deltaTime;
            float t = Mathf.Clamp01(transitionTimer / transitionDuration);

            // Apply gradual changes
            vignette.intensity.Override(Mathf.Lerp(originalIntensity, targetIntensity, t));
            vignette.smoothness.Override(Mathf.Lerp(originalSmoothness, targetSmoothness, t));
        }
    }
}
