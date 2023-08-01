using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [Header("Volume Slider")]
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeText = null;
    private float volumeValue;

    [HideInInspector]
    public GameObject audioPlayer;
    AudioPlayer audioPlay;
    //AudioSource audioSrc;

    private void Start()
    {
        audioPlayer = GameObject.FindGameObjectWithTag("AudioPlayerTag");
        audioPlay = audioPlayer.GetComponent<AudioPlayer>();
        LoadVolume();
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = volume.ToString("0.0");
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
    }

    public void SaveVolume()
    {
        volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadVolume();
        //Debug.Log("saved volume: " + PlayerPrefs.GetFloat("VolumeValue"));
    }

    public void LoadVolume()
    {
        volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        audioPlay.audioSrc.volume = volumeValue;
    }
    
    // on reset data button pressed
    public void OnResetLeaderboardPressed()
    {
        //PlayerPrefs.DeleteKey("Scores");
        //PlayerPrefs.DeleteKey("Names");
        if (PlayerPrefs.GetInt("doNotShowAgainChecked") != 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("doNotShowAgainChecked", 1);
        }
        else
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("doNotShowAgainChecked", 0);
        }
        Debug.Log("Reset Leaderboard");
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
    }

    public void OnResetDoNotShowAgainPressed()
    {
        PlayerPrefs.DeleteKey("doNotShowAgainChecked");
        Debug.Log("Reset DoNotShowAgain");
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
    }
}
