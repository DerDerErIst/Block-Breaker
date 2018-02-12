using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdventureMode : MonoBehaviour
{
    public static bool isLevelEnd;
    public static void WinCondition()
    {   //Use this as a Callback for ObjectToDestroy Win Condition
        AdventureMode.isLevelEnd = true;
    }
    public static int destroyedBrickCount = 0;
    [Header("Timer Condition")]
    public Slider adventureTimer;
    public bool timeCondition;
    public float levelTime;
    public Text timerText;
    [Space(5)]
    [Header("Object Condition Setup")]
    public GameObject objectiveObject;
    public Text objectiveText;
    public Text objectiveNumber;
    [Space(5)]
    [Header("Object Condition")]
    public bool objectCondition;
    public GameObject objectToDestroy;
    [Space(5)]
    [Header("Brick Condition")]
    public bool brickCondition;
    public GameObject[] bricksInScene;
    public int bricksToDestroy;

    [Header("WinCondition")]
    public GameObject winDisplayObject;
    public GameObject playFinishButton;

    public int unlockLevelNumber;


    GameObject smoke;
    LevelManager levelManager;
    WinObjectToDestroy winObject;
    bool adventureMode;
    bool levelWon;
    bool playFinish;
    int brickInSceneCount;
    int leftHits;

    void Awake()
    {
        RefreshAdventureScene();

        if (LevelManager.adventureMode == false)
        {
            adventureMode = false;
            objectiveObject.SetActive(true);
            objectiveText.text = "Bricks Left: ";
        }
        else
        {
            adventureMode = true;

            if (timeCondition)
            {
                adventureTimer.gameObject.SetActive(true);
            }
            else if (objectToDestroy)
            {
                objectiveObject.SetActive(true);
                winObject = objectiveObject.GetComponent<WinObjectToDestroy>();
                objectiveText.text = objectiveObject.name;
            }
            else if (brickCondition)
            {
                objectiveObject.SetActive(true);
                objectiveText.text = "Bricks Left: ";
            }
            else
            {
                objectiveObject.SetActive(true);
                objectiveText.text = "Bricks Left: ";
            }
        }
    }

    void RefreshAdventureScene()
    {
        destroyedBrickCount = 0;
        playFinish = false;
        winDisplayObject.SetActive(false);
        bricksInScene = GameObject.FindGameObjectsWithTag("Breakable");
        for (int i = 0; i < bricksInScene.Length; i++)
        {
            ++brickInSceneCount;
        }
        adventureTimer.gameObject.SetActive(false);
        objectiveObject.SetActive(false);
        levelManager = FindObjectOfType<LevelManager>();
        isLevelEnd = false;
        levelWon = false;
    }

    void Update ()
    {
        if (!levelWon)
        {
            if (adventureMode)
            {
                if (timeCondition)
                {
                    CheckForTimeEndCondition();
                }
                else if (objectCondition)
                {
                    CheckForObjectEndCondition();
                }
                else if (brickCondition)
                {
                    CheckForBrickEndCondition();
                }
                else
                {
                    CheckForEndCondition(); 
                }
            }
            else
            {
                CheckForEndCondition();
            }
        }
        else if (playFinish)
        {            
            CheckForEndCondition();
        }
    }

    void CheckForEndCondition()
    {
        int leftHits = (brickInSceneCount - destroyedBrickCount);
        objectiveNumber.text = leftHits.ToString();
        if (leftHits == 0 && !levelWon || leftHits == 0 && playFinish)
        {
            if (!playFinish)
            {
                playFinish = true;
            }            
            LevelWon();
        }
    }

    void CheckForBrickEndCondition()
    {
        int leftHits = (bricksToDestroy - destroyedBrickCount);
        objectiveNumber.text = leftHits.ToString();
        if (leftHits == 0 && !levelWon)
        {
            LevelWon();
        }
    }

    void CheckForObjectEndCondition()
    {
        if (isLevelEnd && !levelWon && objectCondition)
        {
            LevelWon();
        }
         
    }

    void CheckForTimeEndCondition()
    {
        bool timeIsUp = (Time.timeSinceLevelLoad >= levelTime);
        adventureTimer.value = Time.timeSinceLevelLoad / levelTime;
        float countdown = Mathf.Clamp(Time.timeSinceLevelLoad, 0f, Mathf.Infinity);
        timerText.text = string.Format("{0:00:00}", countdown) + " / " + string.Format("{0:00:00}", levelTime);
        if (timeIsUp && !levelWon)
        {
            LevelWon();
        }
    }

    void LevelWon()
    {
        if(playFinish)
        {
            playFinishButton.SetActive(false);
        }
        else
        {
            playFinishButton.SetActive(true);
        }
        levelWon = true;
        Cursor.visible = true;
        Time.timeScale = 0;
        winDisplayObject.SetActive(true);
        string sceneName = "02 Level_" + unlockLevelNumber;
        PlayerPrefsManager.UnlockLevel(sceneName);
        Debug.Log("Unlock " + sceneName);
    }

    public void LoadNextLevelBtn()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        levelManager.LoadNextLevel();
    }

    public void PlayLevelFinish()
    {
        Cursor.visible = false;
        winDisplayObject.SetActive(false);
        objectiveObject.SetActive(true);
        objectiveText.text = "Bricks Left: ";
        playFinish = true;
        Time.timeScale = 1;
    }
}
