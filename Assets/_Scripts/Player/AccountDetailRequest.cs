using UnityEngine;

public class AccountDetailRequest : MonoBehaviour
{
    public static AccountDetailRequest accReq;

    private void Awake()
    {
        accReq = this;
        GetAccountData();        
    }

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
                    PlayerSceneManager.playerManager.UpdateSpaceBrickText();
                }
                else
                {
                    Debug.Log("Error Retrieving Account Details...");
                }
            });
    }

    public void GivePlayerMoreCashBttn()
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

