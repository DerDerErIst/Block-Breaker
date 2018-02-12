using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockLevel : MonoBehaviour
{
	void Start ()
    {
        PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().name);
    }
}
