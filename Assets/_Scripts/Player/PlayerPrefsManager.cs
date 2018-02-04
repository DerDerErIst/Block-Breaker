using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
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
    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 9)
        {
            PlayerPrefs.SetInt(LEVEL_KEY_BREAKER + level.ToString(), 1); // Use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY_BREAKER + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 9) //Input the Number of Non Breaker Level Scenes 
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogWarning("Trying to Query a level not Unlocked");
            return false;
        }
    }
    #endregion
}
