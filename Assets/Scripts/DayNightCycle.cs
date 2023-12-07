using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun; // Reference to your directional light representing the sun/moon
    public Material daySkybox; // Reference to the skybox material for day
    public Material nightSkybox; // Reference to the skybox material for night
    public Color dayFogColor; // Color for day fog
    public Color nightFogColor; // Color for night fog
    public float dayFogDensity; // Density for day fog
    public float nightFogDensity; // Density for night fog
    public GameObject cloudsDayPrefab; // Reference to the clouds prefab for day
    public GameObject cloudsNightPrefab; // Reference to the clouds prefab for night
    public float transitionSpeed = 1.0f; // Adjust this to control the transition speed
    public float dayTargetIntensity = 1.0f; // Target intensity for day
    public float nightTargetIntensity = 0.0f; // Target intensity for night

    private float targetIntensity; // Intensity value at the transition (e.g., 0 for night, 1 for day)
    private float currentIntensity;

    private Material skyboxMaterial;
    private Color targetFogColor;

    private Color nightLightColor; // Color for the night directional light
    private Color dayLightColor; // Color for the day directional light

    // Start is called before the first frame update
    void Start()
    {
        // Set initial intensity values
        currentIntensity = sun.intensity;
        targetIntensity = nightTargetIntensity; // Start during the night

        // Set initial skybox material and fog color for night
        skyboxMaterial = nightSkybox;
        RenderSettings.skybox = skyboxMaterial;
        RenderSettings.fogColor = nightFogColor;
        RenderSettings.fogDensity = nightFogDensity; // Assuming starting during the night
        targetFogColor = nightFogColor;

        // Convert hexadecimal color to Unity Color for night and day directional lights
        nightLightColor = HexToColor("355BA2");
        dayLightColor = HexToColor("FFFADA");

        // Set night directional light color
        sun.color = nightLightColor;
    }

    // Update is called once per frame
    void Update()
    {
        // Example: Checking for an event to trigger the transition
        if (Input.GetKeyDown(KeyCode.T)) // Example: Triggering transition with 'T' key
        {
            TriggerDayNightTransition();
        }

        // Smoothly transition the intensity of the light
        currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, Time.deltaTime * transitionSpeed);
        sun.intensity = currentIntensity;

        // Transition fog color and density
        RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, targetFogColor, Time.deltaTime * transitionSpeed);
        RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, targetIntensity > 0.3f ? dayFogDensity : nightFogDensity, Time.deltaTime * transitionSpeed);
    }

    // Method to trigger the day-night transition
    public void TriggerDayNightTransition()
    {
        // Toggle between day and night by adjusting target intensity and environmental settings
        if (targetIntensity > 0.3f) // Check if it's day
        {
            targetIntensity = nightTargetIntensity; // Set to night
            skyboxMaterial = nightSkybox;
            targetFogColor = nightFogColor;
            RenderSettings.fogDensity = nightFogDensity;
            sun.color = nightLightColor; // Set night directional light color
            cloudsNightPrefab.SetActive(true); // Enable clouds for night
            cloudsDayPrefab.SetActive(false); // Disable clouds for day
            RenderSettings.skybox = nightSkybox; // Change the skybox to night
        }
        else
        {
            targetIntensity = dayTargetIntensity; // Set to day
            skyboxMaterial = daySkybox;
            targetFogColor = dayFogColor;
            RenderSettings.fogDensity = dayFogDensity;
            sun.color = dayLightColor; // Set day directional light color
            cloudsDayPrefab.SetActive(true); // Enable clouds for day
            cloudsNightPrefab.SetActive(false); // Disable clouds for night
            RenderSettings.skybox = daySkybox; // Change the skybox to day
        }
    }

    // Helper method to convert hexadecimal color to Unity Color
    private Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }
}
