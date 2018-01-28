using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string LEVEL_KEY = "level_unlocked_";

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 3)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 3) //Input the Number of Non Level Scenes 
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogWarning("Trying to Query a level not Unlocked");
            return false;
        }
    }
}
