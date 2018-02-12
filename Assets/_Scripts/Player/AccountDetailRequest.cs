using UnityEngine;
using GameSparks.Core;

public class AccountDetailRequest : MonoBehaviour
{
    public static AccountDetailRequest accReq;

    private void Awake()
    {
        accReq = this;
        playerManager = GetComponent<PlayerSceneManager>();                
    }

    PlayerSceneManager playerManager;

    public void GetAccountData()
    {
        Debug.Log("Fetching Account Details...");
        new GameSparks.Api.Requests.AccountDetailsRequest()
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Account Details Found...");
                    PlayerSceneManager.playerManager.playerName = response.DisplayName;
                    PlayerSceneManager.playerManager.spacebricksCurrency = (int)response.Currency1;
                    if (response.VirtualGoods != null)
                    {
                        PlayerSceneManager.playerManager.PADDLE_ABSTRACT = (response.VirtualGoods.GetNumber("PADDLE_ABSTRACT") == 1);
                        PlayerSceneManager.playerManager.PADDLE_INBOUND = (response.VirtualGoods.GetNumber("PADDLE_INBOUND") == 1);
                        PlayerSceneManager.playerManager.PADDLE_INROUNDBOUND = (response.VirtualGoods.GetNumber("PADDLE_INROUNDBOUND") == 1);
                        PlayerSceneManager.playerManager.PADDLE_ROUNDBOUND = (response.VirtualGoods.GetNumber("PADDLE_ROUNDBOUND") == 1);
                        PlayerSceneManager.playerManager.PADDLE_TRIANGLE = (response.VirtualGoods.GetNumber("PADDLE_TRIANGLE") == 1);

                        PlayerSceneManager.playerManager.SHIP_DOUBLE = (response.VirtualGoods.GetNumber("SHIP_DOUBLE") == 1);
                        PlayerSceneManager.playerManager.SHIP_STRONG = (response.VirtualGoods.GetNumber("SHIP_STRONG") == 1);

                        PlayerSceneManager.playerManager.BALL_BLUE = (response.VirtualGoods.GetNumber("BALL_BLUE") == 1);
                        PlayerSceneManager.playerManager.BALL_GREEN = (response.VirtualGoods.GetNumber("BALL_GREEN") == 1);
                        PlayerSceneManager.playerManager.BALL_RED = (response.VirtualGoods.GetNumber("BALL_RED") == 1);
                        PlayerSceneManager.playerManager.BALL_PURPLE = (response.VirtualGoods.GetNumber("BALL_PURPLE") == 1);
                    }
                    else
                    {
                        PlayerSceneManager.playerManager.PADDLE_ABSTRACT = false;
                        PlayerSceneManager.playerManager.PADDLE_INBOUND = false;
                        PlayerSceneManager.playerManager.PADDLE_INROUNDBOUND = false;
                        PlayerSceneManager.playerManager.PADDLE_ROUNDBOUND = false;
                        PlayerSceneManager.playerManager.PADDLE_TRIANGLE = false;

                        PlayerSceneManager.playerManager.SHIP_DOUBLE = false;
                        PlayerSceneManager.playerManager.SHIP_STRONG = false;

                        PlayerSceneManager.playerManager.BALL_BLUE = false;
                        PlayerSceneManager.playerManager.BALL_GREEN = false;
                        PlayerSceneManager.playerManager.BALL_RED = false;
                        PlayerSceneManager.playerManager.BALL_PURPLE = false;

                    }
                    PlayerSceneManager.playerManager.UpdateSpaceBrickDisplay();
                }
                else
                {
                    Debug.Log("Error Retrieving Account Details...");
                }
            });
    }

    public void GetBrickData()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("LOAD_BRICKS")
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Recieved Load Bricks Data From GameSparks...");
                        GSData data = response.ScriptData.GetGSData("brick_Data");
                        playerManager.destroyedBricks = (int)data.GetInt("destroyedBricks"); //Mark as Int working
                        playerManager.breakerOverallScore = (int)data.GetInt("score");
                        playerManager.breakerHighscore = (int)data.GetInt("highscore");
                    }
                    else
                    {
                        Debug.Log("Error Loading Brick Data...");
                    }
                });
    }

    public void GetRaiderData()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("LOAD_RAIDER")
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Recieved Load Raider Data From GameSparks...");
                        GSData data = response.ScriptData.GetGSData("raider_Data");
                        playerManager.destroyedAsteroids = (int)data.GetInt("asteroidsDestroyed"); //Mark as Int working
                        playerManager.destroyedAsteroidsInRow = (int)data.GetInt("asteroidsDestroyedInRow");
                        playerManager.highestDifficultInRaider = (int)data.GetInt("highestDifficult");
                        int difficult = (int)data.GetInt("highestDifficult");
                        Debug.Log(difficult);

                        float resultNormal = 0;
                        string timeNormal = data.GetString("timeNormal");                        
                        float.TryParse(timeNormal, out resultNormal);
                        
                        playerManager.longestTimeInRaiderWithNormal = resultNormal;

                        float resultDouble = 0;
                        string timeDouble = data.GetString("timeDouble");
                        float.TryParse(timeDouble, out resultDouble);

                        playerManager.longestTimeInRaiderWithDouble = resultDouble;

                        float resultStrong = 0;
                        string timeStrong = data.GetString("timeStrong");
                        float.TryParse(timeStrong, out resultStrong);

                        playerManager.longestTimeInRaiderWithStrong = resultStrong;
                    }
                    else
                    {
                        Debug.Log("Error Loading Raider Data...");
                    }
                });
    }

    public void SaveBrickData()
    {

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_BRICK")
            .SetEventAttribute("BRICK", playerManager.destroyedBricks)
            .SetEventAttribute("SCORE_ALL", playerManager.breakerOverallScore)
            .SetEventAttribute("HIGHSCORE", playerManager.breakerHighscore)
            .Send((response) =>
            {

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

    public void SaveRaiderData()
    {
        new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_RAIDER")
                .SetEventAttribute("ASTEROIDS_DESTROYED", playerManager.destroyedAsteroids)
                .SetEventAttribute("ASTEROIDS_DESTROYED_INROW", playerManager.destroyedAsteroidsInRow)
                .SetEventAttribute("HIGHEST_DIFFICULT", playerManager.highestDifficultInRaider)
                .SetEventAttribute("TIME_NORMAL", playerManager.longestTimeInRaiderWithNormal.ToString())
                .SetEventAttribute("TIME_DOUBLE", playerManager.longestTimeInRaiderWithDouble.ToString())
                .SetEventAttribute("TIME_STRONG", playerManager.longestTimeInRaiderWithStrong.ToString())
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Raider Posted Sucessfully...");
                        AccountDetailRequest.accReq.GetAccountData();
                    }
                    else
                    {
                        Debug.Log("Error Raider Scores...");
                    }
                });
    }

    public void SaveCashData()
    {
        new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("GRANT_CURRENCY")
                .SetEventAttribute("CASH", playerManager.earnedSpaceBricks)
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

    public void GivePlayerMoreCash()
    {
        Debug.Log("Adding More Cash...");
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("GRANT_CURRENCY")
            .SetEventAttribute("CASH", 1000)
            .Send((response) => {

                if (!response.HasErrors)
                {
                    Debug.Log("Cash Added Successfully...");                    
                }
                else
                {
                    Debug.Log("Error adding cash...");
                }
            });
    }
}

