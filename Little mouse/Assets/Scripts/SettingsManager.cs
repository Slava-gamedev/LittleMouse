using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Dropdown ResolutionDrop;
    public Slider VolumeSlider;
    private Resolution[] resolutions;
    private float currentVolume;
    public AudioMixer audioMix;
    public GameObject menu;
    public GameObject settings;
    public Toggle ful;
    // Start is called before the first frame update
    void Start()
    {
        LoadSettings();
        settings.SetActive(false);
        resolutions = Screen.resolutions;
        ResolutionDrop.ClearOptions();
        List<string> options = new List<string>();
        int curResIndex = 0;
        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResIndex = i;
            }
        }
        ResolutionDrop.AddOptions(options);
        ResolutionDrop.value = curResIndex;
        ResolutionDrop.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution= resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen= isFullScreen;
    }
     
    public void SetVolume(float volume)
    {
        audioMix.SetFloat("Volume", volume);
        currentVolume = VolumeSlider.value;
    }
    
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreference", ResolutionDrop.value);
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings(/*int CurrentResolutionIndex*/)
    {
        //if (PlayerPrefs.HasKey("ResolutionPreference"))
        //    ResolutionDrop.value = PlayerPrefs.GetInt("ResolutionPreference");
        //else
        //    ResolutionDrop.value = CurrentResolutionIndex;
        if (PlayerPrefs.HasKey("VolumePreference"))
        {
            //VolumeSlider.normalizedValue= PlayerPrefs.GetFloat("VolumePreference");
            VolumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        }
        else
            VolumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
        ful.isOn = Screen.fullScreen;
    }
    public void CloseSettings()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }
    public void OpenSettings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }
}
