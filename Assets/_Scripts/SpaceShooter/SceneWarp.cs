using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWarp : MonoBehaviour {

	public static string checkpointScene;

    private void Start()
    {
        Invoke("LoadCheckpointScene", 3f);
    }

    void LoadCheckpointScene()
    {
        SceneManager.LoadScene(checkpointScene);
    }
}
