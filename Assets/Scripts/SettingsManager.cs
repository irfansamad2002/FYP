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
    float volumeValue;

    [Header("Scripts")]
    AudioPlayer audioPlayer;
        
    private void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
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
        Debug.Log("saved volume: " + PlayerPrefs.GetFloat("VolumeValue"));

    }

    public void LoadVolume()
    {
        volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        audioPlayer.audioSrc.volume = volumeValue;
        //Debug.Log("saved volume: " + PlayerPrefs.GetFloat("VolumeValue"));
    }
    
    // on reset data button pressed
    public void OnResetPressed()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Reset all playerprefs");
    }
}
