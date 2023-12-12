using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject fadeBlackImage;
    public float fadeInSpeed = 0.2f;
    public float fadeOutSpeed = 1.0f;

    void Start()
    {
        StartCoroutine(FadeBlackOutSquare(false, 0)); // Start immediately by default
    }

    public void FadeIn(float delay = 0) //call this from other scripts
    {
        StartCoroutine(FadeBlackOutSquare(false, delay));
    }

    public void FadeOut(float delay = 0) //call this from other scripts
    {
        StartCoroutine(FadeBlackOutSquare(true, delay));
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float delay = 0)
    {
        yield return new WaitForSeconds(delay); // Wait for specified delay

        Color objectColor = fadeBlackImage.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (fadeBlackImage.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeOutSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadeBlackImage.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (fadeBlackImage.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeInSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadeBlackImage.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
