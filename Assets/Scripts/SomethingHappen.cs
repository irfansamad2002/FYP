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

    void Start()
    {
        bottle1.SetActive(false);
        spider.SetActive(false);
        bottleButton.SetActive(false);
        spiderButton.SetActive(false);
        videoCanvas.SetActive(false);

    }
    public void bottleImageLost()
    {
        bottleButton.SetActive(false);
        bottle1.SetActive(false);
        spider.SetActive(false);

    }
    public void bottleImageFound()
    {
        bottleButton.SetActive(true);
        //set video canvas active
    }

    public void spiderImageLost()
    {
        spiderButton.SetActive(false);
        bottle1.SetActive(false);
        spider.SetActive(false);

    }

    public void spiderImageFound()
    {
        spiderButton.SetActive(true);

    }
    public void bottle1Appear()//Click on Bottle Btn
    {
        //bottle1.SetActive(true);
        videoCanvas.SetActive(true);

    }

    public void spiderAppear()//Click on Bottle Btn
    {
        //spider.SetActive(true);
        videoCanvas.SetActive(true);

    }
    public void ResetUI()
        {
            bottle1.SetActive(false);
            spider.SetActive(false);
            bottleButton.SetActive(false);
            spiderButton.SetActive(false);
        }
    public void ResetEverything()
    {
        ResetUI();
        videoCanvas.SetActive(false);
    }
    
    
    
}
