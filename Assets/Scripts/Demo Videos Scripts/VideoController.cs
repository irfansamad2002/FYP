using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.Sprites;
using UnityEngine.UI;
using TMPro;

public class VideoController : MonoBehaviour
{
    [SerializeField]private VideoPlayer videoPlayer;
    [SerializeField]private TMP_Text toolNameText;
    private Texture vidTex;
    //private Image progressBar;

    public Button playPauseButton;
    public Sprite startSprite;
    public Sprite pauseSprite;

    public TMP_Text videoTimeText;

    [Header("Scripts")]
    public SceneChanger sceneChanger;
    private void Start()
    {
        if (ButtonReferenceManager.Instance.storedDTHButtonID == DTHEnum.DT)
        {
            toolNameText.text = ButtonReferenceManager.Instance.dtTools[ButtonReferenceManager.Instance.storedIndex].Name;
            videoPlayer.clip = ButtonReferenceManager.Instance.dtTools[ButtonReferenceManager.Instance.storedIndex].videoClip;
        }
        else if (ButtonReferenceManager.Instance.storedDTHButtonID == DTHEnum.DH)
        {
            toolNameText.text = ButtonReferenceManager.Instance.dhTools[ButtonReferenceManager.Instance.storedIndex].Name;
            videoPlayer.clip = ButtonReferenceManager.Instance.dhTools[ButtonReferenceManager.Instance.storedIndex].videoClip;
        }

        videoPlayer.Play();
        playPauseButton.image.sprite = pauseSprite;
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
        //AudioPlayer.Instance.PlayAudioOneShot(0);
    }

    public void OnSkipForward()
    {
        videoPlayer.time += 5f;
        //AudioPlayer.Instance.PlayAudioOneShot(0);
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
        //AudioPlayer.Instance.PlayAudioOneShot(0);
    }

    public void OnHomeClicked()
    {
        ButtonReferenceManager.Instance.storedDTHButtonID = DTHEnum.NONE;
        ButtonReferenceManager.Instance.storedButtonID = ButtonENUM.MAINSCENE;
        sceneChanger.ChangeToMainScene();
        //AudioPlayer.Instance.PlayAudioOneShot(0);
    }
}
