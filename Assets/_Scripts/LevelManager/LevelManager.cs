using UnityEngine;
using UnityEngine.SceneManagement;


/*
 The Level Manager is at the moment a bit of a Mess and i dont know actually what Functions i use and need
 But i have other Stuff i need to deal with, so i will clean this one Up in the Future.
     */
public class LevelManager : MonoBehaviour {

    public static int checkpoint;

    public static bool adventureMode;

    public void LoadHighscoreScene()
    {
        SceneManager.LoadScene("01b Highscore");
    }

    public void LoadMenueStructure(string name)
    {
        PlayerSceneManager.playerManager.breakerLevel = false;
        PlayerSceneManager.playerManager.raiderLevel = false;
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void LoadLevelEndlessBreaker(string name)
    {
        MusicPlayer.instance.isBreaker = true;
        MusicPlayer.instance.isMenue = false;
        MusicPlayer.instance.isRaider = false;

        PlayerSceneManager.playerManager.breakerLevel = true;
        PlayerSceneManager.playerManager.raiderLevel = false;
        adventureMode = false;
        Reset();
        SceneManager.LoadScene(name);
    }

    public void LoadLevelWithReset(string name)
    {
        PlayerSceneManager.playerManager.breakerLevel = true;
        PlayerSceneManager.playerManager.raiderLevel = false;
        adventureMode = false;
        Reset();
        SceneManager.LoadScene(name);
    }

    public void LoadLevelWithResetAdventureMode(string name)
    {
        MusicPlayer.instance.isBreaker = true;
        MusicPlayer.instance.isMenue = false;
        MusicPlayer.instance.isRaider = false;
        PlayerSceneManager.playerManager.breakerLevel = true;
        PlayerSceneManager.playerManager.raiderLevel = false;
        adventureMode = true;
        Reset();
        SceneManager.LoadScene(name);
    }

    public void LoadLevelStartWithReset()
    {
        Reset();
        MusicPlayer.instance.isMenue = true;
        MusicPlayer.instance.isBreakerWon = false;
        MusicPlayer.instance.isBreakerLost = false;
        MusicPlayer.instance.isRaider = false;
        MusicPlayer.instance.isBreaker = false;
        PlayerSceneManager.playerManager.breakerLevel = false;
        PlayerSceneManager.playerManager.raiderLevel = false;
        Cursor.visible = true;
        SceneManager.LoadScene("01a Start Menu");
    }

    public void Reset()
    {
        PlayerSceneManager.score = 0;
        PlayerSceneManager.lives = 3;
        PlayerSceneManager.playerManager.earnedSpaceBricks = 0;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void QuitRequest()
    {
        AccountDetailRequest.accReq.SaveBrickData();
        AccountDetailRequest.accReq.SaveRaiderData();
        AccountDetailRequest.accReq.SaveCashData();
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

    public void LoadLastLevel()
    {
        PlayerSceneManager.playerManager.breakerLevel = true;
        MusicPlayer.instance.isBreakerLost = false;
        Reset();
        SceneManager.LoadScene(checkpoint);
    }

    public void LoadInvaderLevel(string name)
    {
        MusicPlayer.instance.isRaider = true;
        MusicPlayer.instance.isBreaker = false;
        MusicPlayer.instance.isMenue = false;
        PlayerSceneManager.playerManager.breakerLevel = false;
        PlayerSceneManager.playerManager.raiderLevel = true;
        SceneWarp.checkpointScene = name;
        SceneManager.LoadScene("01d SceneWarp");  
    }
}
