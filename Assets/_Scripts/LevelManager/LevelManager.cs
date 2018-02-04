using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int checkpoint;

    public void LoadLevel(string name)
    {        
        SceneManager.LoadScene(name);
    }

    public void LoadLevelWithReset(string name)
    {
        Reset();
        SceneManager.LoadScene(name);
    }

    public void LoadLevelStart()
    {
        SceneManager.LoadScene("01a Start Menu");
    }

    public void Reset()
    {
        Paddle.score = 0;
        Paddle.lives = 3;
    }

    public void LoadNextLevel()
    {        
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
