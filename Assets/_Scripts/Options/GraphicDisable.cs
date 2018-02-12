using UnityEngine;
using UnityEngine.SceneManagement;

public class GraphicDisable : MonoBehaviour
{
    public static GraphicDisable graphicDisable;

    private void Awake()
    {
        graphicDisable = this;

        fogDisable = (PlayerPrefsManager.GetFogSetting() == 0);
        tutorialDisable = (PlayerPrefsManager.GetTutorialSetting() == 0);
        planetDisable = (PlayerPrefsManager.GetPlanetSetting() == 0);
        nebulaDisable = (PlayerPrefsManager.GetNebulaSetting() == 0);
        specialEffectsDisable = (PlayerPrefsManager.GetSpecialEffectSetting() == 0);
    }

    public bool tutorialDisable = false;
    public bool fogDisable = false;
    public bool planetDisable = false;
    public bool nebulaDisable = false;
    public bool specialEffectsDisable = false;

    private void OnEnable()
    {   //This Happen before the Scene show Up after Awake and Before        
        SceneManager.sceneLoaded += DisableGraphicOnLoadScene;        
    }

    public void DisableGraphicOnLoadScene (Scene scene, LoadSceneMode mode) //Im Not sure why i need that Parameters but i leave them for now
    {
        DisableSettings();
    }

    void DisableSettings()
    {
        if (tutorialDisable)
        {   //We Find all Fog Objects in Scene and loop through to deactivate them 
            GameObject[] Tutorial = GameObject.FindGameObjectsWithTag("Tutorial");
            for (int i = 0; i < Tutorial.Length; i++)
            {
                Tutorial[i].SetActive(false);
                Destroy(Tutorial[i].gameObject);
            }
        }
        if (fogDisable)
        {   //We Find all Fog Objects in Scene and loop through to deactivate them 
            GameObject[] Fog = GameObject.FindGameObjectsWithTag("Fog");
            for (int i = 0; i < Fog.Length; i++)
            {
                Fog[i].SetActive(false);
            }
        }

        if (planetDisable)
        {   //We Find all Planet Objects in Scene and loop through to deactivate them 
            GameObject[] Planet = GameObject.FindGameObjectsWithTag("SpaceScene_Planet");
            for (int i = 0; i < Planet.Length; i++)
            {
                Planet[i].SetActive(false);
            }
        }
        if (nebulaDisable)
        {   //We Find all Nebula Objects in Scene and loop through to deactivate them 
            GameObject[] Nebula = GameObject.FindGameObjectsWithTag("SpaceScene_Nebula");
            for (int i = 0; i < Nebula.Length; i++)
            {
                Nebula[i].SetActive(false);
            }
        }
        if (specialEffectsDisable)
        {   //We Find all Nebula Objects in Scene and loop through to deactivate them 
            GameObject[] SpecialEffect = GameObject.FindGameObjectsWithTag("SpecialEffect");
            for (int i = 0; i < SpecialEffect.Length; i++)
            {
                SpecialEffect[i].SetActive(false);
            }
        }
    }

    public void ActivateFog() //We will call this Function from the UI
    {
        if (!fogDisable)
        {   //We Find all Fog Objects in Scene and loop through to Activate them 
            GameObject[] Fog = GameObject.FindGameObjectsWithTag("Fog");
            for (int i = 0; i < Fog.Length; i++)
            {
                Fog[i].SetActive(true);
            }
        }
    }
}
