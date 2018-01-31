using UnityEngine;
using GameSparks.Core;
using UnityEngine.UI;

public class GameSparksManager : MonoBehaviour {

    /// <summary>The GameSparks Manager singleton</summary>
    public static GameSparksManager instance = null;

    public LevelManager levelManager;
    public GameObject registerName;

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
                    Invoke("LoadLevel", 1f);
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
                        Debug.Log("Device Authenticated...");
                        Invoke("LoadLevel", 2f);
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
}
