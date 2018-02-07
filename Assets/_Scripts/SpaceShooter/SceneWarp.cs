using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWarp : MonoBehaviour {

	public static string checkpointScene;
    public static string sceneToLoad;

    private void Start()
    {
        Invoke("LoadCheckpointScene", 3.5f);
    }

    void LoadCheckpointScene()
    {
        SceneManager.LoadScene(checkpointScene);
    }
}
