using UnityEngine;

public class SetupSelector : MonoBehaviour {

    public GameObject parentObject;
    public GameObject[] objectsToSelect;
    public GameObject buttonPrefab;

    void Awake()
    {
        for (int i = 0; i < objectsToSelect.Length; i++)
        {             
            GameObject gameObjectButton = Instantiate(buttonPrefab);
            SelectButton selectButton = gameObjectButton.GetComponent<SelectButton>();
            selectButton.objectToSelect = objectsToSelect[i];
            selectButton.SetupButton(objectsToSelect[i].name);
            gameObjectButton.transform.SetParent(parentObject.transform);
        }
    }
}
