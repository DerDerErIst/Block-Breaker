using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [Header("ScrollRect Content")]
    public GameObject parentObject;

    [Header("Level Scenes")]
    public GameObject[] levelScenes;

    [Header("Insert ButtonPrefab")]
    public GameObject buttonPrefab;

    //Im very Proud of my LevelSelector he isnt finish yet
    //But he is a Big Timesafer if you understand how he works.
    //I will improve him over the next Time that he also fit into the Space Invader Part
    void Awake()
    {
        //ForLoop go through all Scenes and Add For Each Level Scene a Button
        //We Unlock Level 1 every Time
        PlayerPrefsManager.UnlockLevel(levelScenes[0].name);
        for (int i = 0; i < levelScenes.Length; i++)
        {   //Instantiate Every Button and give some Parameter for it            
            GameObject Level = Instantiate(buttonPrefab);
            LevelButton levelButton = Level.GetComponent<LevelButton>();
            levelButton.SetLevel(levelScenes[i].name);
            //Check if Level Unlocked
            bool levelUnlocked = PlayerPrefsManager.IsLevelUnlocked(levelScenes[i].name);
            if (!levelUnlocked)
            {
                //Debug.Log("Set Interactive False");
                Level.GetComponent<Button>().interactable = false;
            }
            //Set the Button as Children to the Parent
            Level.transform.parent = parentObject.transform; //Instantiate it as Child into Content then the Rect will Layout them
        }
    }
}
