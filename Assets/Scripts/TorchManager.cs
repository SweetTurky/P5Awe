using UnityEngine;
using UnityEngine.SceneManagement;


public class TorchManager : MonoBehaviour
{
    public int torchesToLight = 3; // Specify the number of torches to light before scene switch
    public float invokeTime = 1.0f; // Assignable time before invoking the scene switch
    public ParticleSystem winParticles;
    private int litTorchesCount = 0;
    private bool hasPlayedEndGameVoiceover = false; // Flag to track if the end game voiceover has been played
    public AudioClip lightVO;

    public void TorchLit()
    {
        litTorchesCount++;

        if (litTorchesCount == 1 && !hasPlayedEndGameVoiceover)
        {
            // Play the end game voiceover
            StartCoroutine(AudioManager.instance.PlayVoiceoverDelayed(lightVO, 1f));
            hasPlayedEndGameVoiceover = true; // Update the flag indicating the voiceover has been played
        }
        // Check if the specified number of torches have been lit
        if (litTorchesCount >= torchesToLight)
        {
            //Play the fire effect
            winParticles.Play();
            //Play final speak from AudioManager
            AudioManager.instance.PlayEndGameVoiceoverWithDelay(0f);
            // Invoke the scene switch after the specified time
            Invoke("SwitchScene", invokeTime);
        }
    }

    private void SwitchScene()
    {
        // Replace "YourSceneName" with the actual scene name you want to switch to
        SceneManager.LoadScene("Main Scene (Day)");
    }
}
