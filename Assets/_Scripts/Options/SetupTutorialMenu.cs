using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupTutorialMenu : MonoBehaviour {

    public GameObject[] setupStart;

    private void Start()
    {
        for (int i = 0; i < setupStart.Length; i++)
        {   //When we use a Tutorial in the Part we need to set the Object to false when we start the Scene
            //Otherwise the GraphicDisable cannot find the Tutorial Windows to Delete.
            setupStart[i].SetActive(false);
        }
    }
}
