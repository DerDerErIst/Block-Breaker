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
    public Toggle tutorialToggle;
    public Toggle planetToggle;
    public Toggle nebulaToggle;
    public Toggle specialEffectToggle;

    public AudioMixer audioMixer;

    public Dropdown qualityLevel;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Awake()
    {
        masterSlider.value = PlayerPrefsManager.GetMasterVolume();
        musicSlider.value = PlayerPrefsManager.GetMusicVolume();
        effectSlider.value = PlayerPrefsManager.GetEffectVolume();

        toggleFullscren.isOn = (PlayerPrefsManager.GetFullscreen() == 0);
        fogToggle.isOn = (PlayerPrefsManager.GetFogSetting() == 0);
        tutorialToggle.isOn = (PlayerPrefsManager.GetTutorialSetting() == 1);
        planetToggle.isOn = (PlayerPrefsManager.GetPlanetSetting() == 1);
        nebulaToggle.isOn = (PlayerPrefsManager.GetNebulaSetting() == 1);
        specialEffectToggle.isOn = (PlayerPrefsManager.GetSpecialEffectSetting() == 1);

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
            PlayerPrefsManager.SetFogSetting(0);
            GraphicDisable.graphicDisable.fogDisable = true;
        }
        else if (!isFog)
        {
            PlayerPrefsManager.SetFogSetting(1);
            GraphicDisable.graphicDisable.fogDisable = false;

        }
    }

    public void SetTutorial(bool isTutorial)
    {
        tutorialToggle.isOn = isTutorial;
        if (isTutorial)
        {
            PlayerPrefsManager.SetTutorialSetting(1);
            GraphicDisable.graphicDisable.tutorialDisable = false;
        }
        else if (!isTutorial)
        {
            PlayerPrefsManager.SetTutorialSetting(0);
            GraphicDisable.graphicDisable.tutorialDisable = true;
        }
    }

    public void SetPlanet(bool isPlanet)
    {
        planetToggle.isOn = isPlanet;
        if (isPlanet)
        {
            PlayerPrefsManager.SetPlanetSetting(1);
            GraphicDisable.graphicDisable.planetDisable = false;
        }
        else if (!isPlanet)
        {
            PlayerPrefsManager.SetPlanetSetting(0);
            GraphicDisable.graphicDisable.planetDisable = true;
        }
    }

    public void SetNebula(bool isNebula)
    {
        nebulaToggle.isOn = isNebula;
        if (isNebula)
        {
            PlayerPrefsManager.SetNebulaSetting(1);
            GraphicDisable.graphicDisable.nebulaDisable = false;
        }
        else if (!isNebula)
        {
            PlayerPrefsManager.SetNebulaSetting(0);
            GraphicDisable.graphicDisable.nebulaDisable = true;
        }
    }

    public void SetSpecialEffect(bool isSpecialEffect)
    {
        specialEffectToggle.isOn = isSpecialEffect;
        if (isSpecialEffect)
        {
            PlayerPrefsManager.SetSpecialEffectSetting(1);
            GraphicDisable.graphicDisable.specialEffectsDisable = false;
        }
        else if (!isSpecialEffect)
        {
            PlayerPrefsManager.SetSpecialEffectSetting(0);
            GraphicDisable.graphicDisable.specialEffectsDisable = true;
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
        PlayerPrefsManager.SetMasterVolume(masterSlider.value);
    }

    public void SetMusicVolume()
    {
        audioMixer.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefsManager.SetMusicVolume(musicSlider.value);

    }

    public void SetEffectVolume()
    {
        audioMixer.SetFloat("effectVolume", effectSlider.value);
        PlayerPrefsManager.SetEffectVolume(effectSlider.value);

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

    public void SetDefaults()
    {   //TODO Setup a Default Button
        masterSlider.value = -20f;
        musicSlider.value = -20f;
        effectSlider.value = -20f;
    }
}
