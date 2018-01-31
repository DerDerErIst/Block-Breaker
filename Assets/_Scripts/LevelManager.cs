using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int checkpoint;

    Player playerManager;

    private void Start()
    {
        playerManager = FindObjectOfType<Player>();
    }

    public void LoadLevel(string name)
    {
        PostDataToGameSpark();
        Debug.Log("New Level load: " + name);
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
        PostDataToGameSpark();
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
#endif
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
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

    public void PostDataToGameSpark()
    {
        if (GameSparksManager.instance)
        {
            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_BRICK")
                .SetEventAttribute("BRICK", playerManager.brickCounter)
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Brick Posted Sucessfully...");
                    }
                    else
                    {
                        Debug.Log("Error Posting Score...");
                    }
                });
        }
    }

}
