using UnityEngine;
using UnityEngine.UI;

public class SelectedBall : MonoBehaviour {

    public static SelectedBall selectedBall;

    public GameObject objectToDisplay;

    [Header("Optional")]
    public Text objectNameDisplay;

    RawImage imageDisplay;
    MovieTexture movie;

    private void Awake()
    {
        selectedBall = this;
        objectToDisplay = PlayerSceneManager.playerManager.playerBall;
        movie = objectToDisplay.GetComponent<Ball>().movieTexture;
        imageDisplay = GetComponent<RawImage>();
        imageDisplay.texture = movie;
        if (objectNameDisplay != null)
        {
            objectNameDisplay.text = objectToDisplay.name;
        }
    }

    public void UpdateDisplay()
    {
        movie = objectToDisplay.GetComponent<Ball>().movieTexture;
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
