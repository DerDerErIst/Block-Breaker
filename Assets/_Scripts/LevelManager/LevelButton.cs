using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    string nextLevelString;
    Button button;

	public void SetLevel(int level)
    {
        nextLevelString = "02 Level_" + level.ToString(); //TODO think about how to Solve This without that stupid Strings
        SetButton();
    }

    private void SetButton()
    {
        Text buttonText = GetComponentInChildren<Text>();
        buttonText.text = nextLevelString;
    }

    public void CallLevel()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadLevelWithReset(nextLevelString);
    }
}
