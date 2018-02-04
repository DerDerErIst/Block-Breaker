using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsController : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectSlider;

    public AudioMixer audioMixer;

    void Start()
    {
        masterSlider.value = PlayerPrefsManager.GetMasterVolume();
        musicSlider.value = PlayerPrefsManager.GetMusicVolume();
        effectSlider.value = PlayerPrefsManager.GetEffectVolume();
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
