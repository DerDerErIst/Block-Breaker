using UnityEngine;
using UnityEngine.SceneManagement;

public class FogDisable : MonoBehaviour {


    public static FogDisable fogDisable;

    private void Awake()
    {
        fogDisable = this;
    }

    public bool disable = true;

    private void OnEnable()
    {   //This Happen before the Scene show Up after Awake and Before 
        if (disable)
        {
            SceneManager.sceneLoaded += DisableFog;
        }
    }

    public void DisableFog (Scene scene, LoadSceneMode mode) //Im Not sure why i need that Parameters but i leave them for now
    {
        if (disable)
        {   //We Find all Fog Objects in Scene and loop through to deactivate them 
            GameObject[] Fog = GameObject.FindGameObjectsWithTag("Fog");
            for (int i = 0; i < Fog.Length; i++)
            {
                Fog[i].SetActive(false);
            }
        }
	}

    public void ActivateFog() //We will call this Function from the UI
    {
        if (!disable)
        {   //We Find all Fog Objects in Scene and loop through to Activate them 
            GameObject[] Fog = GameObject.FindGameObjectsWithTag("Fog");
            for (int i = 0; i < Fog.Length; i++)
            {
                Fog[i].SetActive(true);
            }
        }
    }
}
