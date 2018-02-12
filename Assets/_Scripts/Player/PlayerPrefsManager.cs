using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
    #region Graphic
    const string GRAPHIC_QUALITY = "graphic_quality";

    public static void SetGraphicQuality(int qualityLevel)
    {        
      PlayerPrefs.SetInt(GRAPHIC_QUALITY, qualityLevel);       
    }

    public static int GetGraphicQuality()
    {
        return PlayerPrefs.GetInt(GRAPHIC_QUALITY);
    }

    const string FULLSCREEN = "fullscreen";

    public static void SetFullscreen(int boolQuestion)
    {
        PlayerPrefs.SetInt(FULLSCREEN, boolQuestion);
    }

    public static int GetFullscreen()
    {
        return PlayerPrefs.GetInt(FULLSCREEN);
    }

    const string FOGSETTING = "fogsetting";

    public static void SetFogSetting(int boolQuestion)
    {
        PlayerPrefs.SetInt(FOGSETTING, boolQuestion);
    }

    public static int GetFogSetting()
    {
        return PlayerPrefs.GetInt(FOGSETTING);
    }

    const string TUTORIALSETTING = "tutorialsetting";

    public static void SetTutorialSetting(int boolQuestion)
    {
        PlayerPrefs.SetInt(TUTORIALSETTING, boolQuestion);
    }

    public static int GetTutorialSetting()
    {
        return PlayerPrefs.GetInt(TUTORIALSETTING);
    }

    const string PLANETSETTING = "planetsetting";

    public static void SetPlanetSetting(int boolQuestion)
    {
        PlayerPrefs.SetInt(PLANETSETTING, boolQuestion);
    }

    public static int GetPlanetSetting()
    {
        return PlayerPrefs.GetInt(PLANETSETTING);
    }

    const string NEBULASETTING = "nebulasetting";

    public static void SetNebulaSetting(int boolQuestion)
    {
        PlayerPrefs.SetInt(NEBULASETTING, boolQuestion);
    }

    public static int GetNebulaSetting()
    {
        return PlayerPrefs.GetInt(NEBULASETTING);
    }

    const string SPECIALEFFECTSETTING = "specialeffetsetting";

    public static void SetSpecialEffectSetting(int boolQuestion)
    {
        PlayerPrefs.SetInt(SPECIALEFFECTSETTING, boolQuestion);
    }

    public static int GetSpecialEffectSetting()
    {
        return PlayerPrefs.GetInt(SPECIALEFFECTSETTING);
    }

    #endregion

    #region Sound
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
    #endregion

    #region Breaker Level
    const string LEVEL_KEY_BREAKER = "breaker_level_unlocked_";
    //TODO Let the Cloud handle this
    public static void UnlockLevel(string scene)
    {
        PlayerPrefs.SetString(LEVEL_KEY_BREAKER + scene, scene);
    }

    public static bool IsLevelUnlocked(string scene)
    {
         bool isLevelUnlocked = (PlayerPrefs.GetString(LEVEL_KEY_BREAKER + scene) == scene);
         return isLevelUnlocked;
    }
    #endregion
}
