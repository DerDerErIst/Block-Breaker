using UnityEngine;
using UnityEngine.UI;

public class OptionsButtonFinder : MonoBehaviour {

    private void Awake()
    {
        Button thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(AddClickListener);       
    }
    void AddClickListener()
    {
        PauseController controller = FindObjectOfType<PauseController>();
        controller.OpenMenue();
    }
}
