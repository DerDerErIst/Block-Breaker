using UnityEngine;
using UnityEngine.UI;

public class SelectedPaddle : MonoBehaviour {

    public static SelectedPaddle selectedPaddle;

    public GameObject objectToDisplay;

    [Header("Optional")]
    public Text objectNameDisplay;

    RawImage imageDisplay;
    MovieTexture movie;

    private void Awake()
    {
        selectedPaddle = this;
        objectToDisplay = PlayerSceneManager.playerManager.playerPaddle;
        movie = objectToDisplay.GetComponentInChildren<Paddle>().movieTexture;
        imageDisplay = GetComponent<RawImage>();
        imageDisplay.texture = movie;
        if(objectNameDisplay != null)
        {
            objectNameDisplay.text = objectToDisplay.name;
        }
    }

    public void UpdateDisplay()
    {
        movie = objectToDisplay.GetComponentInChildren<Paddle>().movieTexture;
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
