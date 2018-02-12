using UnityEngine;
using UnityEngine.UI;

public class SelectedShip : MonoBehaviour
{
    public static SelectedShip selectedShip;

    RawImage imageDisplay;
    public GameObject objectToDisplay;

    [Header("Optional")]
    public Text objectNameDisplay;

    MovieTexture movie;

    private void Awake()
    {
        selectedShip = this;
        objectToDisplay = PlayerSceneManager.playerManager.playerShip;
        movie = objectToDisplay.GetComponent<ShipController>().movieTexture;
        imageDisplay = GetComponent<RawImage>();
        imageDisplay.texture = movie;
        if (objectNameDisplay != null)
        {
            objectNameDisplay.text = objectToDisplay.name;
        }
    }

    public void UpdateDisplay()
    {
        movie = objectToDisplay.GetComponent<ShipController>().movieTexture;
        imageDisplay = GetComponent<RawImage>();
        imageDisplay.texture = movie;
        if (objectNameDisplay != null)
        {
            objectNameDisplay.text = objectToDisplay.name;
        }
    }

    private void Update()
    {
        if (movie != null)
        {
            if (movie.isPlaying)
            {
                //Debug.Log("Movie is Playing");
                return;
            }
            else
            {
                //Debug.Log("Restart Movie");
                movie.loop = true; //Set loop to true
                movie.Play();
            }
        }
    }
}
