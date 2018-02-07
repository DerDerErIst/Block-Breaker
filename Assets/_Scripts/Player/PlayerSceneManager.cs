using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerSceneManager : MonoBehaviour
{
    public static PlayerSceneManager playerManager;

    public AudioMixer audioMixer;

    void Awake()
    {
        playerManager = this;
        //GameSetup
        QualitySettings.SetQualityLevel(PlayerPrefsManager.GetGraphicQuality());
        Screen.fullScreen = (PlayerPrefsManager.GetFullscreen() == 0);

        audioMixer.SetFloat("masterVolume", PlayerPrefsManager.GetMasterVolume());
        audioMixer.SetFloat("musicVolume", PlayerPrefsManager.GetMusicVolume());
        audioMixer.SetFloat("effectVolume", PlayerPrefsManager.GetEffectVolume());
    }

    public bool gameLevel;

    public Player player;
    public GameObject playerBallInspector;

    public GameObject playerBall;
    public GameObject playerPaddle;
    public GameObject playerShip;
    
    public static int lives = 3;
    public static int score = 0;
    public int earnedSpaceBricks = 0;
    Text scoreText = null;
    Text liveText = null;

    [Header("Get This Data from Cloud")]
    public string playerName = null;
    public int spacebricksCurrency = 0;    
    Text playerNameText = null;
    Text spaceBricksText = null;

    [Header("PADDLE Cloud Data")]
    public bool PADDLE_RECTANGLE = true;
    public bool PADDLE_ABSTRACT;
    public bool PADDLE_INBOUND;
    public bool PADDLE_INROUNDBOUND;
    public bool PADDLE_ROUNDBOUND;
    public bool PADDLE_TRIANGLE;
    [Header("SHIP Cloud Data")]
    public bool SHIP_NORMAL = true;
    public bool SHIP_STRONG;
    public bool SHIP_DOUBLE;
    [Header("BALL Cloud Data")]
    public bool BALL_STANDARD = true;
    public bool BALL_BLUE;
    public bool BALL_GREEN;
    public bool BALL_RED;
    public bool BALL_PURPLE;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += EnablePlayerManager;
    }

    void EnablePlayerManager(Scene scene, LoadSceneMode mode)
    {
        if(gameLevel)
        {
            Instantiate(playerPaddle, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
        if (FindObjectOfType<FindShipPosition>())
        {
            GameObject Ship = Instantiate(playerShip, FindObjectOfType<FindShipPosition>().transform.position, Quaternion.identity);
            Ship.transform.SetParent(FindObjectOfType<FindShipPosition>().transform);
        }
        if (FindObjectOfType<FindPlayerNameText>())
        {
            SetupPlayerName();
        }
        else
        {
            Debug.LogWarning("No PlayerName Display to Set in Scene");
        }
        if (FindObjectOfType<FindSpaceBrickText>())
        {
            SetupSpaceBrickText();
        }
        else
        {
            Debug.LogWarning("No Space Brick Display to Set in Scene");
        }

        if (FindObjectOfType<FindScoreText>() && FindObjectOfType<FindLiveText>())
        {
            SetupGameDisplay();
        }
        else
        {
            Debug.LogWarning("No Game Display to Set in Scene");
        }
    }

    void SetupSpaceBrickText()
    {
        spaceBricksText = FindObjectOfType<FindSpaceBrickText>().GetComponent<Text>();
        spaceBricksText.text = spacebricksCurrency.ToString();
    }

    void SetupPlayerName()
    {
        playerNameText = FindObjectOfType<FindPlayerNameText>().GetComponent<Text>();
        playerNameText.text = playerName;
    }

    void SetupGameDisplay()
    {
            scoreText = FindObjectOfType<FindScoreText>().GetComponent<Text>();
            liveText = FindObjectOfType<FindLiveText>().GetComponent<Text>();
            scoreText.text = score.ToString();            
            liveText.text = score.ToString();
    }

    public void UpdateGameDisplay()
    {
        scoreText.text = score.ToString();
        liveText.text = lives.ToString();
    }

    public void UpdateSpaceBrickText()
    {
        spaceBricksText.text = spacebricksCurrency.ToString();
    }

    private void Start()
    {
        FogDisable.fogDisable.disable = (PlayerPrefsManager.GetFogSetting() == 0);
        playerBall = playerBallInspector;
    }
}
