using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class SplashScreenTouchScreen : MonoBehaviour
{
    [SerializeField] GameObject logoImage;
    [SerializeField] GameObject tapScreenText;

    bool ableToTapScreen = false;

    private void OnEnable()
    {
        StartCoroutine(FadeInLogo(.5f));

    }

    private void Start()
    {
        

    }

    private void Awake()
    {
        logoImage.GetComponent<Image>().color = new Color(logoImage.GetComponent<Image>().color.r, logoImage.GetComponent<Image>().color.g, logoImage.GetComponent<Image>().color.b, 0f);
        tapScreenText.GetComponent<TMP_Text>().color = new Color(tapScreenText.GetComponent<TMP_Text>().color.r, tapScreenText.GetComponent<TMP_Text>().color.g, tapScreenText.GetComponent<TMP_Text>().color.b, 0f);
    }


    public void TouchedScreen()
    {
        if(ableToTapScreen)
            SceneManager.LoadScene("Main Scene");
    }

  

    private IEnumerator FadeInLogo(float fadeSpeed)
    {
        float fadeAmount;
        Color LogoColor = logoImage.GetComponent<Image>().color;


        while (logoImage.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = LogoColor.a + (fadeSpeed * Time.deltaTime);
            //Debug.Log(fadeAmount);

            LogoColor = new Color(LogoColor.r, LogoColor.g, LogoColor.b, fadeAmount);
            logoImage.GetComponent<Image>().color = LogoColor;
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        Color textColor = tapScreenText.GetComponent<TMP_Text>().color;
        fadeSpeed *= 2;
        while (tapScreenText.GetComponent<TMP_Text>().color.a < 1)
        {
            if (tapScreenText.GetComponent<TMP_Text>().color.a > .5f)
            {
                ableToTapScreen = true;
            }
            fadeAmount = textColor.a + (fadeSpeed * Time.deltaTime);
            //Debug.Log(fadeAmount);

            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
            tapScreenText.GetComponent<TMP_Text>().color = textColor;
            yield return null;
        }
    }

}
