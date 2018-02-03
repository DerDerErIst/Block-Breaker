using UnityEngine;

public class Highscore_Submit : MonoBehaviour {

    PlayerManager playerManager; // Reference for send Event Save

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager.player.highscore <= Paddle.score) //If Score from Paddle is higher then highscore
        {
            Debug.Log("Old Highscore for Cloud" + playerManager.player.highscore);
            playerManager.player.highscore = Paddle.score; //Set New Highscore
            Debug.Log("New Highscore on Paddle" + Paddle.score + "New Highscore for Cloud" + playerManager.player.highscore);
        }
        PostDataToGameSpark(); //Post Data to Gamespark Cloud
    }

    void PostDataToGameSpark()
    {
        if (GameSparksManager.instance)
        {
            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_BRICK")
                .SetEventAttribute("BRICK", playerManager.player.brickCounter)
                .SetEventAttribute("SCORE_ALL", playerManager.player.score)
                .SetEventAttribute("HIGHSCORE", playerManager.player.highscore)
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Brick Posted Sucessfully...");
                    }
                    else
                    {
                        Debug.Log("Error Posting Score...");
                    }
                });
        }
    }
}
