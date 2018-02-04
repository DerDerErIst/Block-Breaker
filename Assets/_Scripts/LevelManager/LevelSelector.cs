using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    [Header("ScrollRect Content")]
    public GameObject parentObject;

    [Header("Insert Number of Non Level Scenes")]
    public int nonLevelScenes;

    [Header("Insert ButtonPrefab")]
    public GameObject buttonPrefab;

    int levelScenes;

    //Im very Proud of my LevelSelector he isnt finish yet
    //But he is a Big Timesafer if you understand how he works.
    //I will improve him over the next Time that he also fit into the Space Invader Part
    void Awake()
    {
        //ForLoop go through all Scenes and Add For Each Level Scene a Button
        levelScenes = (SceneManager.sceneCountInBuildSettings - nonLevelScenes);
        Debug.Log("Level Scenes " + levelScenes);
        PlayerPrefsManager.UnlockLevel(0);
        for (int i = 0; i < levelScenes; i++)
        {   //Instantiate Every Button and give some Parameter for it            
            GameObject Level = Instantiate(buttonPrefab);
            LevelButton levelButton = Level.GetComponent<LevelButton>();
            levelButton.SetLevel(i);
            bool levelReached = PlayerPrefsManager.IsLevelUnlocked(i);
            if (!levelReached)
            {
                //Debug.Log("Set Interactive False");
                Level.GetComponent<Button>().interactable = false;
            }
            Level.transform.parent = parentObject.transform; //Instantiate it as Child into Content then the Rect will Layout them
        }
    }
}
