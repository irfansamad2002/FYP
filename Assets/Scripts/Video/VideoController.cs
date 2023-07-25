using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.Sprites;
using UnityEngine.UI;
using TMPro;

public class VideoController : MonoBehaviour/*, IDragHandler, IPointerDownHandler*/
{
    [SerializeField]private VideoPlayer videoPlayer;
    private Texture vidTex;
    //private Image progressBar;

    public Button playPauseButton;
    public Sprite startSprite;
    public Sprite pauseSprite;

    public TMP_Text videoTimeText;
    private void Start()
    {
        videoPlayer.Play();
        playPauseButton.image.sprite = pauseSprite;
        //Debug.Log("video player prepared: " + videoPlayer.isPrepared);
        videoPlayer.GetComponent<VideoPlayer>();

        
        //if (videoPlayer.isPrepared == true)
        //{
        //    vidTex = videoPlayer.texture;
        //    Debug.Log("Vidtex = texture");
        //}

        //float videoWidth = vidTex.width;
        //float videoHeight = vidTex.height;
    }

    private void Update()
    {
        if (videoPlayer.isPrepared == true)
        {
            vidTex = videoPlayer.texture;

            float videoWidth = vidTex.width;
            float videoHeight = vidTex.height;
        }

        videoTimeText.text = videoPlayer.time.ToString("0.00");
    }

    public void OnSkipBackward()
    {
        videoPlayer.time -= 5f;
    }

    public void OnSkipForward()
    {
        videoPlayer.time += 5f;
    }
    public void OnStartPausePressed()
    {
        if (videoPlayer.isPlaying == false)
        {
            videoPlayer.Play();
            playPauseButton.image.sprite = pauseSprite;
        }
        else
        {
            videoPlayer.Pause();
            playPauseButton.image.sprite = startSprite;
        }
    }
}
