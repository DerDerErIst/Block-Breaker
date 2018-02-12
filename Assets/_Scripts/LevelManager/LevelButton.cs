using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    string nextLevelString;
    Button button;

	public void SetLevel(string level)
    {
        nextLevelString = level; //TODO think about how to Solve This without that stupid Strings
        SetButton();
    }

    void SetButton()
    {
        Text buttonText = GetComponentInChildren<Text>();
        buttonText.text = nextLevelString;
    }

    public void CallLevel()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadLevelWithResetAdventureMode(nextLevelString);
    }
}
