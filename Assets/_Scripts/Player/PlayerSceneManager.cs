using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

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

    public bool breakerLevel;
    public bool raiderLevel;

    public GameObject playerBall;
    public GameObject playerPaddle;
    public GameObject playerShip;
    
    public static int lives = 3;
    public static int score = 0;
    public int earnedSpaceBricks = 0;
    public int actualAsteroids = 0;

    Text scoreText = null;
    Text liveText = null;
    Text playerNameText = null;
    Text spaceBricksText = null;
    Text asteroidsDestroyedText = null;
    Text bricksEarnedText = null;

    [Header("Get This Data from Cloud")]
    public string playerName = null;
    public int spacebricksCurrency = 0;
    public int breakerHighscore = 0;
    public int breakerOverallScore = 0;
    public int destroyedBricks = 0;

    public int destroyedAsteroids = 0;
    public int destroyedAsteroidsInRow = 0;
    public int highestDifficultInRaider = 0;
    public float longestTimeInRaiderWithNormal = 0f;
    public float longestTimeInRaiderWithDouble = 0f;
    public float longestTimeInRaiderWithStrong = 0f;


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
        if(breakerLevel)
        {
            Instantiate(playerPaddle, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
        if (FindObjectOfType<FindShipPosition>())
        {
            Transform transformShipPosition = FindObjectOfType<FindShipPosition>().gameObject.transform;
            GameObject Ship = Instantiate(playerShip, transformShipPosition.position, Quaternion.identity);
            Ship.transform.SetParent(FindObjectOfType<FindShipPosition>().transform);
        }
        if (FindObjectOfType<FindPlayerNameText>())
        {
            SetupPlayerNameDisplay();
        }
        else
        {
            Debug.LogWarning("No PlayerName Display to Set in Scene");
        }
        if (FindObjectOfType<FindSpaceBrickText>())
        {
            SetupSpaceBrickDisplay();
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

        if(FindObjectOfType<FindAsteroidText>() && FindObjectOfType<FindBrickEarnedText>())
        {
            SetupAsteroidDisplay();
        }
        else
        {
            Debug.LogWarning("No Asteroid Display to Set in Scene");
        }
    }

    private void SetupAsteroidDisplay()
    {
        asteroidsDestroyedText = FindObjectOfType<FindAsteroidText>().GetComponent<Text>();
        asteroidsDestroyedText.text = actualAsteroids.ToString();
        bricksEarnedText = FindObjectOfType<FindBrickEarnedText>().GetComponent<Text>();
        bricksEarnedText.text = earnedSpaceBricks.ToString();
    }

    void SetupSpaceBrickDisplay()
    {
        spaceBricksText = FindObjectOfType<FindSpaceBrickText>().GetComponent<Text>();
        spaceBricksText.text = spacebricksCurrency.ToString();
    }

    void SetupPlayerNameDisplay()
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

    public void UpdateSpaceBrickDisplay()
    {
        if (spaceBricksText != null)
        {
            spaceBricksText.text = spacebricksCurrency.ToString();
        }
    }

    public void UpdateAsteroidsDisplay()
    {
        if (asteroidsDestroyedText != null && bricksEarnedText != null)
        {
            asteroidsDestroyedText.text = actualAsteroids.ToString();
            bricksEarnedText.text = earnedSpaceBricks.ToString();
        }
    }
}
