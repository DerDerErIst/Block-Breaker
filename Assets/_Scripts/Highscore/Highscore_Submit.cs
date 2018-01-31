
using System;
using UnityEngine;
using UnityEngine.UI;

public class Highscore_Submit : MonoBehaviour {

    public Text nameInput, scoreText;

    Player playerManager;

    public void Start()
    {
        playerManager = FindObjectOfType<Player>();
        scoreText.text = Paddle.score.ToString();
        if(playerManager.highscore <= Paddle.score)
        {
            NewHighScore();
        }        
    }

    private void NewHighScore()
    {
        Debug.Log("NEW HIGHSCORE" + Paddle.score + "OLD SCORE" + playerManager.highscore);
        playerManager.highscore = Paddle.score;
        Debug.Log("New PlayerManager Highscore" + playerManager.highscore);
        PostScoreBttn();
        Debug.Log("Send to Cloud");
    }

    public void PostScoreBttn()
    {
        Debug.Log("Posting Score To Leaderboard...");
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SCORE_SUBMIT")
            .SetEventAttribute("SCORE", scoreText.text)
            .Send((response) => {

                if (!response.HasErrors)
                {
                    Debug.Log("Score Posted Sucessfully...");
                    Debug.Log("Post Score" + scoreText.text);
                }
                else
                {
                    Debug.Log("Error Posting Score...");
                }
            });
    }
}
