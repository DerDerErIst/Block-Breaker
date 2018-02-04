using UnityEngine;
using UnityEngine.SceneManagement;


/*
 The Level Manager is at the moment a bit of a Mess and i dont know actually what Functions i use and need
 But i have other Stuff i need to deal with, so i will clean this one Up in the Future.
     */
public class LevelManager : MonoBehaviour {

    public static int checkpoint;

    public static bool adventureMode;

    public void LoadLevel(string name)
    {
        Cursor.visible = true;
        SceneManager.LoadScene(name);
    }

    public void LoadLevelWithReset(string name)
    { 
        adventureMode = false;
        Reset();
        SceneManager.LoadScene(name);
    }

    public void LoadLevelWithResetAdventureMode(string name)
    {
        adventureMode = true;
        Reset();
        SceneManager.LoadScene(name);
    }

    public void LoadLevelStart()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("01a Start Menu");
    }

    public void Reset()
    {
        Paddle.score = 0;
        Paddle.lives = 3;
    }

    public void LoadNextLevel()
    {
        PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex - 5); //Not Sure if this is actually working right xD
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void QuitRequest()
    {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
    Application.Quit();
#elif (UNITY_UWP)
        Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#else
        Application.Quit();
#endif
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 1)
        {
            LoadNextLevel();
        }     
    }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(checkpoint);
        Paddle.score = 0;
        Paddle.lives = 3;
    }

    public void LoadInvaderLevel(string name)
    {
        SceneWarp.checkpointScene = name;
        SceneManager.LoadScene("01c SceneWarp");  
    }
}
