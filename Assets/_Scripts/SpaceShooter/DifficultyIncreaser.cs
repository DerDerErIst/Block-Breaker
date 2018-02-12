using System;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyIncreaser : MonoBehaviour
{
    public AsteroidController[] asteroidController;

    public int difficulty = 1;
    public float timeIncrease = 5f; //Every 5 Seconds we increase the Difficulty

    public Text difficultyText;
    public Text timeText;

    float surviveTime;
    float nextTimer;
    bool highscoreCheck = false;

    PlayerSceneManager playerManager;
    ShipLiveSystem liveSystem;

    bool decreaseTime;
    bool increaseCount;
    bool increaseSpeed;
    bool increaseSpeedWithoutTime;

	void Start ()
    {
        BoolStartSetup();
        playerManager = PlayerSceneManager.playerManager;
        asteroidController = FindObjectsOfType<AsteroidController>();
        liveSystem = FindObjectOfType<ShipLiveSystem>();
    }

    void BoolStartSetup()
    {
        decreaseTime = true;
        increaseCount = false;
        increaseSpeed = false;
        increaseSpeedWithoutTime = false;
        highscoreCheck = false;
    }

    void Update ()
    {
        nextTimer += Time.deltaTime;
        if (liveSystem.gameRunning && !highscoreCheck)
        {
            if (nextTimer >= timeIncrease)
            {
                nextTimer = 0;
                InceaseDifficult();
            }
            if (difficultyText && timeText)
            {
                UpdateDisplay();
            }
        }
        else if(!liveSystem.gameRunning && !highscoreCheck)
        {
            CheckForHighscoreCondition();
        }
	}

    void InceaseDifficult()
    {
        for (int i = 0; i < asteroidController.Length; i++)
        {
            if (asteroidController[i].spawnWait >= 1 && decreaseTime) //Aslong spawnwait is higher then 1 we decrease the wait timer
            {
                asteroidController[i].spawnWait -= 0.1f;
                decreaseTime = false;
                increaseSpeed = true;
                ++difficulty;
            }           
            else if(asteroidController[i].asteroid.GetComponent<AsteroidMover>().speed <= 4 && increaseSpeed || 
                    asteroidController[i].asteroid.GetComponent<AsteroidMover>().speed <= 4 && increaseSpeedWithoutTime)
            {
                asteroidController[i].asteroid.GetComponent<AsteroidMover>().speed += 0.03f;
                increaseSpeed = false;
                decreaseTime = true;
                ++difficulty;
            }

            if(asteroidController[i].spawnWait <= 1)
            {
                increaseCount = true;
                increaseSpeedWithoutTime = true;
            }

            if (asteroidController[i].asteroidCount <= 10 && increaseCount) //If we cannot change the spawnwait anymore then 
            {
                ++asteroidController[i].asteroidCount; //we Change the AsteroidCount Up, we also can expose that Variables and not hardcode it
                
                ++difficulty;
            }
        }
        if (difficultyText)
        {
            difficultyText.text = difficulty.ToString();
        }
    }

    void UpdateDisplay()
    {
        surviveTime = Time.timeSinceLevelLoad;
        float countdown = Mathf.Clamp(Time.timeSinceLevelLoad, 0f, Mathf.Infinity);
        timeText.text = string.Format("{0:00:00}", countdown);
    }

    public void CheckForHighscoreCondition()
    {
        highscoreCheck = true;
        if (DifficultyHigher())
        {
            playerManager.highestDifficultInRaider = difficulty;
        }
        SurviveTimeHigher();
        Debug.Log("Save Highscores");
    }

    bool DifficultyHigher()
    {
        bool thisbool = playerManager.highestDifficultInRaider <= difficulty;
        return thisbool;
    }

    void SurviveTimeHigher()
    {
        if (playerManager.longestTimeInRaiderWithNormal <= surviveTime && playerManager.playerShip.name == "SHIP_NORMAL")
        {
            playerManager.longestTimeInRaiderWithNormal = surviveTime;
        }
        else if (playerManager.longestTimeInRaiderWithDouble <= surviveTime && playerManager.playerShip.name == "SHIP_DOUBLE")
        {
            playerManager.longestTimeInRaiderWithDouble = surviveTime;
        }
        else if (playerManager.longestTimeInRaiderWithStrong <= surviveTime && playerManager.playerShip.name == "SHIP_STRONG")
        {
            playerManager.longestTimeInRaiderWithStrong = surviveTime;
        }
    }
}
