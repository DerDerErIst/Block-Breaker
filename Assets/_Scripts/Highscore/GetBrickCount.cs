using UnityEngine;
using UnityEngine.UI;

public class GetBrickCount : MonoBehaviour {

    public Text brickCount;
    public Text overallScore;
    public Text highScore;

    PlayerManager playerManager;

    // Use this for initialization
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        ChangeBrickText();
    }

    void ChangeBrickText()
    {
        brickCount.text = playerManager.player.brickCounter.ToString();
        overallScore.text = playerManager.player.score.ToString();
        highScore.text = playerManager.player.highscore.ToString();
    }
}
