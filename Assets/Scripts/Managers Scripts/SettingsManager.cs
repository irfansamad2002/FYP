using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    [Header("Volume Slider")]
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeText = null;
    private static float volumeValue = 1.0f;

    [HideInInspector]
    public GameObject audioPlayer;
    AudioPlayer audioPlay;

    private void Start()
    {
        // start at full volume
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        audioPlayer = GameObject.FindGameObjectWithTag("AudioPlayerTag");
        audioPlay = audioPlayer.GetComponent<AudioPlayer>();
        LoadVolume();
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = volume.ToString("0.0");
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
        //Debug.Log("volume value loaded: " + volumeValue);
    }

    // on reset data button pressed
    public void OnResetLeaderboardPressed()
    {
        LoadVolume();
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
        SaveVolume();
        Debug.Log("Reset Leaderboard");
    }
}
