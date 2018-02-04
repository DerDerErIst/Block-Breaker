using UnityEngine;
using UnityEngine.UI;

public class AdventureMode : MonoBehaviour {

    public float levelTime;
    public Slider adventureTimer;

    bool adventureMode;
    bool isLevelEnd;

    void Awake()
    {
        if(LevelManager.adventureMode == false)
        {
            adventureTimer.gameObject.SetActive(false);
            adventureMode = false;
        }
        else
        {
            adventureTimer.gameObject.SetActive(true);
            adventureMode = true;
        }
    }	

	void Update ()
    {
		if(adventureMode)
        {
            adventureTimer.value = Time.timeSinceLevelLoad / levelTime;
            CheckForEndCondition();
        }
	}

    void CheckForEndCondition()
    {
        bool timeIsUp = (Time.timeSinceLevelLoad >= levelTime);
        if (timeIsUp && !isLevelEnd)
        {
            //Fill in the Win Condition such s Load Next Level and Unlock next Level etc
            isLevelEnd = true;
            LevelManager lvlManager = FindObjectOfType<LevelManager>();
            lvlManager.LoadNextLevel();
        }
    }
}
