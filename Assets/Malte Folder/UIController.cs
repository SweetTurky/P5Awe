using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject fadeBlackImage;
    public float fadeInSpeed = 0.2f;
    public float fadeOutSpeed = 1.0f;
    

    void Start()
    {
        StartCoroutine(fadeBlackOutSquare(false));
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(fadeBlackOutSquare());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(fadeBlackOutSquare(false));
        }
        if(fadeBlackImage.GetComponent<Image>().color.a < 0.01f)
        {
            fadeBlackImage.SetActive(false);
        }
        if (fadeBlackImage.GetComponent<Image>().color.a > 0.01f)
        {
            fadeBlackImage.SetActive(true);
        }*/
    }

    public IEnumerator fadeBlackOutSquare(bool fadeToBlack = true)
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds

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
        }else
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

