using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string MUSIC_VOLUME_KEY = "music_volume";
    const string EFFECT_VOLUME_KEY = "effect_volume";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= -80f && volume <= 0f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.Log("Can´t Set Master Volume - Out of Range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetMusicVolume(float volume)
    {
        if (volume >= -80f && volume <= 0f)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        }
        else
        {
            Debug.Log("Can´t Set Music Volume - Out of Range");
        }
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
    }

    public static void SetEffectVolume(float volume)
    {
        if (volume >= -80f && volume <= 0f)
        {
            PlayerPrefs.SetFloat(EFFECT_VOLUME_KEY, volume);
        }
        else
        {
            Debug.Log("Can´t Set Music Volume - Out of Range");
        }
    }

    public static float GetEffectVolume()
    {
        return PlayerPrefs.GetFloat(EFFECT_VOLUME_KEY);
    }
}
