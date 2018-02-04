using UnityEngine;
using GameSparks.Core;
using UnityEngine.UI;

public class GameSparksManager : MonoBehaviour {

    /// <summary>The GameSparks Manager singleton</summary>
    public static GameSparksManager instance = null;

    public LevelManager levelManager;
    public GameObject registerName;

    PlayerManager playerManager;

    void Awake()
    {
        if (instance == null) // check to see if the instance has a reference
        {
            instance = this; // if not, give it a reference to this class...
            DontDestroyOnLoad(this.gameObject); // and make this object persistent as we load new scenes
        }
        else // if we already have a reference then remove the extra manager from the scene
        {
            Destroy(this.gameObject);
        }
        playerManager = GetComponent<PlayerManager>();
        GS.GameSparksAvailable += OnAvailable;
    }

    public Text displayName;

    void LoadLevel()
    {
        levelManager.LoadLevelStart();
    }

    public void AuthenticateDeviceBttn()
    {
        Debug.Log("Display Entry: " + displayName.text);
        Debug.Log("Authenticating Device...");

        new GameSparks.Api.Requests.ChangeUserDetailsRequest()
            .SetDisplayName(displayName.text)
            .Send((response) =>
            {
                                
                if (!response.HasErrors)
                {
                    GetPlayerData();
                    Debug.Log("Device Authenticated...");
                                    }
                else
                {
                    Debug.Log("Error Authenticating Device...");
                }
            });
    }

    void OnAvailable(bool _true)
    {
        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
            .Send((responses) => {
                if (!(bool)responses.NewPlayer)
                {
                    if (!responses.HasErrors)
                    {
                        GetPlayerData();
                        Debug.Log("Device Authenticated...");
                    }
                }
                else
                {
                    Debug.Log("Error Authenticating Device...");
                    Debug.Log("New Player");
                    registerName.SetActive(true);
                }
            });
    }

    void GetPlayerData()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("LOAD_BRICKS")            
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Recieved Load Bricks Data From GameSparks...");
                        GSData data = response.ScriptData.GetGSData("brick_Data");
                        playerManager.player.brickCounter = (int)data.GetInt("destroyedBricks"); //Mark as Int working
                        playerManager.player.score = (int)data.GetInt("score");
                        playerManager.player.highscore = (int)data.GetInt("highscore");                        
                        playerManager.player.playerName = (string)data.GetString("playerDisplay");
                        Invoke("LoadLevel", 2f);
                    }
                    else
                    {
                        Debug.Log("Error Loading Player Data...");
                    }
                });
    }
}
