using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApplicationExit : MonoBehaviour
{
    public UIController uiController; // Reference to the UIController script

    void Start()
    {
        // Assign the reference to UIController if not already assigned
        if (uiController == null)
        {
            uiController = FindObjectOfType<UIController>();
            if (uiController == null)
            {
                Debug.LogError("UIController reference not found!");
            }
        }
    }

    // Public method to trigger the fade-out effect and exit the application
    public void ExitApplication()
    {
        StartCoroutine(FadeOutAndExit());
    }

    // Method to perform the fade-out effect and exit the application
    IEnumerator FadeOutAndExit(float delay = 0)
    {
        yield return StartCoroutine(uiController.FadeBlackOutSquare(true, delay));

        // Call the FadeOut method from UIController
        uiController.FadeOut();

        // Wait for the fade-out effect to complete (you might need to adjust this time)
        yield return new WaitForSeconds(3f);

        // Exit the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops the editor play mode
#else
            Application.Quit(); // Quits the application in a build
#endif
    }
}
