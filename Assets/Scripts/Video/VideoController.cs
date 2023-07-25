using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Sprites;
using UnityEngine.UI;
using TMPro;

public class VideoController : MonoBehaviour
{
    [SerializeField]private VideoPlayer SsPlayer;
    //[SerializeField]private VideoPlayer FsPlayer;
    [SerializeField]private GameObject SsPlayerObj;
    //[SerializeField]private GameObject FsPlayerObj;
    public Button playPauseButton;
    public Button SsButton;
    //public Button FsButton;
    public Sprite startSprite;
    public Sprite pauseSprite;

    public Slider videoSlider;
    public TMP_Text videoTimeText;
    public float currentVideoTime;
    private void Start()
    {
        //SsPlayerObj.SetActive(true);
        //FsPlayerObj.SetActive(false);
        //SsPlayerObj.SetActive(false);
        //FsPlayerObj.SetActive(true);

        SsPlayer.Play();
        playPauseButton.image.sprite = pauseSprite;
    }

    private void Update()
    {
        videoSlider.value = 1 / (float)SsPlayer.time;
        videoTimeText.text = SsPlayer.time.ToString("0.00");
    }

    public void OnSkipBackward()
    {
        SsPlayer.time -= 10f;
        //FsPlayer.time -= 10f;
    }

    public void OnSkipForward()
    {
        SsPlayer.time += 10f;
        //FsPlayer.time += 10f;
    }
    public void OnStartPausePressed()
    {
        if (SsPlayer.isPlaying == false/* && FsPlayer.isPlaying == false*/)
        {
            SsPlayer.Play();
            //FsPlayer.Play();
            playPauseButton.image.sprite = pauseSprite;
        }
        else
        {
            SsPlayer.Pause();
            //FsPlayer.Pause();
            playPauseButton.image.sprite = startSprite;
        }
    }

    public void OnSSButtonPressed()
    {
        //SsPlayerObj.SetActive(false);
        //FsPlayerObj.SetActive(true);
        //FsButton.enabled = true;
        //FsPlayer.Play();
        //if (FsPlayer.isActiveAndEnabled == true)
        //{
        //    SsPlayer.time = FsPlayer.time;
        //    FsPlayer.Play();
        //}
        
        Debug.Log("Ss video");
    }

    public void OnFSButtonPressed()
    {
        //SsPlayerObj.SetActive(true);
        //FsPlayerObj.SetActive(false);
        SsPlayerObj.transform.position = new Vector3(SsPlayerObj.transform.position.x, SsPlayerObj.transform.position.y, 0);
        //FsPlayerObj.transform.position = new Vector3(FsPlayerObj.transform.position.x, FsPlayerObj.transform.position.y, 10000);
        SsButton.enabled = true;
        //if (SsPlayer.isActiveAndEnabled == true)
        //{
        //    FsPlayer.time = SsPlayer.time;
        //    SsPlayer.Play();
        //}
        Debug.Log("Fs video");
    }

    public void OnSliderMoved()
    {
        SsPlayer.time = videoSlider.value / SsPlayer.length;
    }
}
