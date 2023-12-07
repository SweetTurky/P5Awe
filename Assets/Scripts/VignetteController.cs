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
        // ... (existing code remains unchanged)

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
        // ... (existing code remains unchanged)
    }
}
