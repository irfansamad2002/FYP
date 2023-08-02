using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomethingHappen : MonoBehaviour
{
    public GameObject bottle1;
    public GameObject spider;
    public GameObject bottleButton;
    public GameObject spiderButton;
    public GameObject videoCanvas;
    public GameObject BottlebackButton;
    public GameObject SpiderbackButton;

    void Start()
    {
        //bottle1.SetActive(false);
        //spider.SetActive(false);
        bottleButton.SetActive(false);
        spiderButton.SetActive(false);
        videoCanvas.SetActive(false);
        BottlebackButton.SetActive(false);
        SpiderbackButton.SetActive(false);
    }
    public void bottleImageLost()
    {
        BottlebackButton.SetActive(false);
        bottleButton.SetActive(false);
        bottle1.SetActive(false);

    }
    public void bottleImageFound()
    {
        BottlebackButton.SetActive(true);
        bottleButton.SetActive(true);
        bottle1.SetActive(true);
    }

    public void spiderImageLost()
    {
        SpiderbackButton.SetActive(false);
        spiderButton.SetActive(false);
        spider.SetActive(false);
    }

    public void spiderImageFound()
    {
        SpiderbackButton.SetActive(true);
        spiderButton.SetActive(true);
        spider.SetActive(true);
    }
    public void bottle1Appear()//Click on Bottle Btn
    {
        //bottle1.SetActive(true);
        videoCanvas.SetActive(true);
        BottlebackButton.SetActive(false);
    }

    public void spiderAppear()//Click on Bottle Btn
    {
        //spider.SetActive(true);
        videoCanvas.SetActive(true);
        SpiderbackButton.SetActive(false);
    }
    public void ResetUI()
    {
        bottle1.SetActive(false);
        spider.SetActive(false);
        bottleButton.SetActive(false);
        spiderButton.SetActive(false);
        BottlebackButton.SetActive(false);
        SpiderbackButton.SetActive(false);
    }
    public void ResetEverything()
    {
        ResetUI();
        videoCanvas.SetActive(false);
    }
}
