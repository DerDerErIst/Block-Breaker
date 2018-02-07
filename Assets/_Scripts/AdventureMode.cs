using System;
using UnityEngine;
using UnityEngine.UI;

public class AdventureMode : MonoBehaviour {

    public static bool isLevelEnd;
    public static void WinCondition()
    {   //I Use this as a Callback for ObjectToDestroy Wind Condition
        AdventureMode.isLevelEnd = true;
    }
    public static int breakableCount = 0;

    public bool timeCondition;
    public float levelTime;
    public Slider adventureTimer;

    public bool objectCondition;
    public GameObject objectToDestroy;

    public bool brickCondition;
    public GameObject[] bricksInScene;  //Just to let the Designer know how much Bricks in Scene
    public int bricksToDestroy;


    GameObject smoke;
    LevelManager levelManager;
    bool adventureMode;
    bool levelWon;

    void Awake()
    {
#if UNITY_EDITOR
        bricksInScene = GameObject.FindGameObjectsWithTag("Breakable"); //Just to let the Designer know how much Bricks in Scene
#endif
        adventureTimer.gameObject.SetActive(false);
        levelManager = FindObjectOfType<LevelManager>();
        isLevelEnd = false;
        levelWon = false;
        if (LevelManager.adventureMode == false)
        {
            adventureTimer.gameObject.SetActive(false);
            adventureMode = false;            
        }
        else
        {
            if (timeCondition)
            {
                adventureTimer.gameObject.SetActive(true);
            }
            if (objectToDestroy)
            {
                //Display Hits Left
            }
            if (brickCondition)
            {
                //Display Bricks Left
            }
            else
            {
                //Display Amount of Bricks in Scene
            }
            adventureMode = true;
        }
    }

    void Update ()
    {
		if(timeCondition)
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
            CheckForEndCondition(); //if Adventure Mode Falls thus Endless Mode
        }
	}

    private void CheckForEndCondition()
    {
        if (breakableCount <= 0 && !levelWon)
        {
            levelWon = true;
            levelManager.LoadNextLevel();
        }
    }

    private void CheckForBrickEndCondition()
    {
        if(bricksToDestroy == breakableCount && !levelWon)
        {
            levelWon = true;
            levelManager.LoadNextLevel();
        }
    }

    private void CheckForObjectEndCondition()
    {
        if(isLevelEnd && !levelWon)
        {
            levelWon = true;
            levelManager.LoadNextLevel();
        }
    }

    void CheckForTimeEndCondition()
    {
        bool timeIsUp = (Time.timeSinceLevelLoad >= levelTime);
        adventureTimer.value = Time.timeSinceLevelLoad / levelTime;

        if (timeIsUp && !levelWon)
        {
            //Fill in the Win Condition such s Load Next Level and Unlock next Level etc
            levelWon = true;
            levelManager.LoadNextLevel();
        }
    }
}
