using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;
    [SerializeField] private Color dayFogColor;
    [SerializeField] private Color nightFogColor;
    [SerializeField] private float dayFogDensity;
    [SerializeField] private float nightFogDensity;
    [SerializeField] private GameObject cloudsDayPrefab;
    [SerializeField] private GameObject cloudsNightPrefab;
    [SerializeField] private float transitionSpeed = 1.0f;
    [SerializeField] private float dayTargetIntensity = 1.0f;
    [SerializeField] private float nightTargetIntensity = 0.0f;

    private float targetIntensity;
    private Material skyboxMaterial;
    private Color targetFogColor;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial intensity values
        sun.intensity = nightTargetIntensity;
        targetIntensity = nightTargetIntensity; // Start during the night

        // Set initial skybox material and fog color for night
        RenderSettings.skybox = nightSkybox;
        RenderSettings.fogColor = nightFogColor;
        RenderSettings.fogDensity = nightFogDensity; // Assuming starting during the night
        targetFogColor = nightFogColor;
    }

    // Method to trigger the day transition
    public void TriggerDayTransition()
    {
        targetIntensity = dayTargetIntensity; // Set to day
        skyboxMaterial = daySkybox;
        targetFogColor = dayFogColor;
        RenderSettings.fogDensity = dayFogDensity;
        cloudsDayPrefab.SetActive(true); // Enable clouds for day
        cloudsNightPrefab.SetActive(false); // Disable clouds for night
        RenderSettings.skybox = daySkybox; // Change the skybox to day

        // Transition intensity and fog inside the method
        TransitionIntensityAndFog();
    }

    // Method to trigger the night transition
    public void TriggerNightTransition()
    {
        targetIntensity = nightTargetIntensity; // Set to night
        skyboxMaterial = nightSkybox;
        targetFogColor = nightFogColor;
        RenderSettings.fogDensity = nightFogDensity;
        cloudsNightPrefab.SetActive(true); // Enable clouds for night
        cloudsDayPrefab.SetActive(false); // Disable clouds for day
        RenderSettings.skybox = nightSkybox; // Change the skybox to night

        // Transition intensity and fog inside the method
        TransitionIntensityAndFog();
    }

    // Transition intensity and fog logic
    public void TransitionIntensityAndFog()
    {
        float transitionSpeed = 1.0f; // Set your desired transition speed here
        float currentIntensity = sun.intensity;
        Color currentFogColor = RenderSettings.fogColor;

        while (Mathf.Abs(currentIntensity - targetIntensity) > 0.01f || currentFogColor != targetFogColor)
        {
            currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, Time.deltaTime * transitionSpeed);
            sun.intensity = currentIntensity;

            currentFogColor = Color.Lerp(currentFogColor, targetFogColor, Time.deltaTime * transitionSpeed);
            RenderSettings.fogColor = currentFogColor;

            RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, targetIntensity > 0.3f ? dayFogDensity : nightFogDensity, Time.deltaTime * transitionSpeed);
        }
    }
}
