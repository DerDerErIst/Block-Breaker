using UnityEngine;
using GameSparks.Core;
using UnityEngine.UI;

public class GameSparksManager : MonoBehaviour {

    /// <summary>The GameSparks Manager singleton</summary>
    public static GameSparksManager instance = null;

    public LevelManager levelManager;
    public GameObject registerName;

    PlayerSceneManager playerManager;

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
        playerManager = GetComponent<PlayerSceneManager>();
        GS.GameSparksAvailable += OnAvailable;
    }

    public Text displayName;

    void LoadLevel()
    {
        levelManager.LoadLevelStartWithReset();
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
                    AccountDetailRequest.accReq.GetAccountData();
                    AccountDetailRequest.accReq.GetBrickData();
                    AccountDetailRequest.accReq.GetRaiderData();
                    Invoke("LoadLevel", 2f);
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
                        AccountDetailRequest.accReq.GetAccountData();
                        AccountDetailRequest.accReq.GetBrickData();
                        AccountDetailRequest.accReq.GetRaiderData();
                        Invoke("LoadLevel", 2f);
                        Debug.Log("Device Authenticated...");
                    }
                }
                else
                {
                    Debug.Log("Error Authenticating Device...");
                    Debug.Log("New Player");
                    SetupNewPlayer();
                    registerName.SetActive(true);
                }
            });
    }

    void SetupNewPlayer()
    {
        if (GameSparksManager.instance)
        {
            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_BRICK")
                .SetEventAttribute("BRICK", 0)
                .SetEventAttribute("SCORE_ALL", 0)
                .SetEventAttribute("HIGHSCORE", 0)
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
            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("GRANT_CURRENCY")
                .SetEventAttribute("CASH", 100)
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Currency Posted Sucessfully...");
                        AccountDetailRequest.accReq.GetAccountData();
                    }
                    else
                    {
                        Debug.Log("Error Currency Score...");
                    }
                });
            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_RAIDER")
                .SetEventAttribute("ASTEROIDS_DESTROYED", 0)
                .SetEventAttribute("ASTEROIDS_DESTROYED_INROW", 0)
                .SetEventAttribute("HIGHEST_DIFFICULT", 0)
                .SetEventAttribute("TIME_NORMAL", 0)
                .SetEventAttribute("TIME_DOUBLE", 0)
                .SetEventAttribute("TIME_STRONG", 0)
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Raider Posted Sucessfully...");
                        AccountDetailRequest.accReq.GetAccountData();
                    }
                    else
                    {
                        Debug.Log("Error Raider Scores...");
                    }
                });
        }
    }
}
