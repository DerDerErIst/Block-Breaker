using UnityEngine;
using UnityEngine.UI;

public class BreakerConditionScene : MonoBehaviour {

    public float lastBlinkTime = 10f;
    public float blinkTime = .3f;
    public GameObject newHighscore;

    public Text scoreText;
    public Text highscoreText;

    [SerializeField] int score;
    [SerializeField] int highscore;
    float nextBlinkTime = 0f;
    bool startBlink;

    private void Awake()
    {
        if (gameObject.tag == "Finish")
        {
            MusicPlayer.instance.isBreakerWon = true; //TODO Make a For Loop for all this Bool Changes in Music Player
            MusicPlayer.instance.isBreakerLost = false;
            MusicPlayer.instance.isBreaker = false;
            MusicPlayer.instance.isMenue = false;
            MusicPlayer.instance.isRaider = false;
        }
        else
        {
            MusicPlayer.instance.isBreakerLost = true;
            MusicPlayer.instance.isBreakerWon = false;
            MusicPlayer.instance.isBreaker = false;
            MusicPlayer.instance.isMenue = false;
            MusicPlayer.instance.isRaider = false;
        }
    }

    // Use this for initialization
    void Start ()
    {
        if(score == highscore)
        {
            startBlink = true;
        }
        score = PlayerSceneManager.score;
        highscore = PlayerSceneManager.playerManager.breakerHighscore;

        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();		
	}
	

	void Update ()
    {
        if (startBlink)
        {
            if (score == highscore && Time.time > nextBlinkTime && Time.time < lastBlinkTime)
            {
                if (Time.time > lastBlinkTime)
                {
                    startBlink = false;
                }
                nextBlinkTime = Time.time + blinkTime;
                newHighscore.SetActive(!newHighscore.activeSelf);
            }
        }
    }
}
