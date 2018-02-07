using UnityEngine;

public class Highscore_Submit : MonoBehaviour
{
    PlayerSceneManager playerManager; // Reference for send Event Save

    void Start()
    {
        playerManager = FindObjectOfType<PlayerSceneManager>();
        if (playerManager.player.highscore <= PlayerSceneManager.score) //If Score from Paddle is higher then highscore
        {
            Debug.Log("Old Highscore for Cloud" + playerManager.player.highscore);
            playerManager.player.highscore = PlayerSceneManager.score; //Set New Highscore
            Debug.Log("New Highscore on Paddle" + PlayerSceneManager.score + "New Highscore for Cloud" + playerManager.player.highscore);
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
            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("GRANT_CURRENCY")
                .SetEventAttribute("CASH", PlayerSceneManager.playerManager.earnedSpaceBricks)
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Currency Posted Sucessfully...");
                        AccountDetailRequest.accReq.GetAccountData();
                    }
                    else
                    {
                        Debug.Log("Error Currency Score...");
                    }
                });
        }
    }
}
