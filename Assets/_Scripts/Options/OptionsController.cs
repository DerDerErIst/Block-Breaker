using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

public class OptionsController : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectSlider;

    public Toggle toggleFullscren;
    public Toggle fogToggle;

    public AudioMixer audioMixer;

    public Dropdown qualityLevel;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;


    void Start()
    {
        masterSlider.value = PlayerPrefsManager.GetMasterVolume();
        musicSlider.value = PlayerPrefsManager.GetMusicVolume();
        effectSlider.value = PlayerPrefsManager.GetEffectVolume();
        toggleFullscren.isOn = (PlayerPrefsManager.GetFullscreen() == 0);
        fogToggle.isOn = (PlayerPrefsManager.GetFogSetting() == 0);
        qualityLevel.value = PlayerPrefsManager.GetGraphicQuality();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetFog(bool isFog)
    {
        fogToggle.isOn = isFog;
        if (isFog)
        {
            FogDisable.fogDisable.disable = true;
            PlayerPrefsManager.SetFogSetting(0);
        }
        else if (!isFog)
        {
            FogDisable.fogDisable.disable = false;
            PlayerPrefsManager.SetFogSetting(1);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMasterVolume()
    {
        audioMixer.SetFloat("masterVolume", masterSlider.value);
    }

    public void SetMusicVolume()
    {
        audioMixer.SetFloat("musicVolume", musicSlider.value);
    }

    public void SetEffectVolume()
    {
        audioMixer.SetFloat("effectVolume", effectSlider.value);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefsManager.SetGraphicQuality(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
        {
            PlayerPrefsManager.SetFullscreen(0);
        }
        else if (!isFullscreen)
        {
            PlayerPrefsManager.SetFullscreen(1);
        }
    }

    public void Save()
    {
        PlayerPrefsManager.SetMasterVolume(masterSlider.value);
        PlayerPrefsManager.SetMusicVolume(musicSlider.value);
        PlayerPrefsManager.SetEffectVolume(effectSlider.value);

    }

    public void SetDefaults()
    {
        masterSlider.value = -20f;
        musicSlider.value = -20f;
        effectSlider.value = -20f;
        Save();
    }
}
