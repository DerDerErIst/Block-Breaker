using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons; //Leave this for the Moment

    [Header("ScrollRect Content")]
    public GameObject parentObject;

    [Header("Insert Number of Non Level Scenes")]
    public int nonLevelScenes;

    [Header("Insert ButtonPrefab")]
    public GameObject buttonPrefab;

    int levelScenes;

    private void Awake()
    {
        //ForLoop go through all Scenes and Add For Each Level Scene a Button
        levelScenes = (SceneManager.sceneCountInBuildSettings - nonLevelScenes);
        Debug.Log("Level Scenes " + levelScenes);
        for (int i = 0; i < levelScenes; i++)
        {   //Instantiate Every Button and give some Parameter for it            
            GameObject Level = Instantiate(buttonPrefab);
            LevelButton levelButton = Level.GetComponent<LevelButton>();
            levelButton.SetLevel(i);
            Level.transform.parent = parentObject.transform; //Instantiate it as Child into Content then the Rect will Layout them
        }
    }

    void Start()
    {
        //Should Disable Levels not unlocked but its buggy atm
        for (int i = 1; i < levelButtons.Length; i++)
        {
            bool levelReached = PlayerPrefsManager.IsLevelUnlocked(i);
            if (!levelReached)
            {
                //Debug.Log("Set Interactive False");
                levelButtons[i].interactable = false;
            }
        }
    }
}
