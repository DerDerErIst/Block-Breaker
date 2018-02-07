using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public GameObject objectToSelect;

    public Image previewImage;
    [Header("ForMovieTexture")]
    public RawImage rawPreview;
    public MovieTexture[] movieTexture;


    public Text price;

    [SerializeField]bool shop;
    public GameObject error;

    public void SetupButton(string text)
    {
        if(objectToSelect.GetComponent<Ball>())
        {
            previewImage.sprite = objectToSelect.GetComponent<Ball>().sprite;
        }
        if (objectToSelect.GetComponent<PlayerController>())
        {
            if (rawPreview != null)
            {
                for (int i = 0; i < movieTexture.Length; i++)
                {
                    if (movieTexture[i].name == objectToSelect.name + "movie")
                    {
                        rawPreview.texture = movieTexture[i];
                        MovieTexture movie = (MovieTexture)rawPreview.mainTexture;
                        movie.Play();

                    }
                }
            }
            previewImage.sprite = objectToSelect.GetComponent<PlayerController>().shipImage;
            //TODO Price    
        }

        if (objectToSelect.GetComponentInChildren<Paddle>())
        {
            Paddle paddle = objectToSelect.GetComponentInChildren<Paddle>();
            Sprite paddleSprite = paddle.GetComponent<SpriteRenderer>().sprite;
            previewImage.sprite = paddleSprite;
            //TODO Price
        }

        Text buttonText = GetComponentInChildren<Text>();
        buttonText.text = text;

        if (error != null)
        {
            error.SetActive(false);
        }

        if (!shop)
        {
            //TODO Think about this but i not have another idea actually
            if (Select())
            {
                Button thisButton = GetComponent<Button>();
                thisButton.interactable = false;
            }
        }
        else if (shop)
        {
            //TODO Think about this but i not have another idea actually
            if (ShopSelect())
            {
                Button thisButton = GetComponent<Button>();
                thisButton.interactable = false;
            }
        }
    }

    bool ShopSelect()
    {
        return PlayerSceneManager.playerManager.PADDLE_ABSTRACT && objectToSelect.name == "PADDLE_ABSTRACT" ||
               PlayerSceneManager.playerManager.PADDLE_INBOUND && objectToSelect.name == "PADDLE_INBOUND" ||
               PlayerSceneManager.playerManager.PADDLE_INROUNDBOUND && objectToSelect.name == "PADDLE_INROUNDBOUND" ||
               PlayerSceneManager.playerManager.PADDLE_ROUNDBOUND && objectToSelect.name == "PADDLE_ROUNDBOUND" ||
               PlayerSceneManager.playerManager.PADDLE_TRIANGLE && objectToSelect.name == "PADDLE_TRIANGLE" ||

               PlayerSceneManager.playerManager.SHIP_DOUBLE && objectToSelect.name == "SHIP_DOUBLE" ||
               PlayerSceneManager.playerManager.SHIP_STRONG && objectToSelect.name == "SHIP_STRONG" ||

               PlayerSceneManager.playerManager.BALL_BLUE && objectToSelect.name == "BALL_BLUE" ||
               PlayerSceneManager.playerManager.BALL_GREEN && objectToSelect.name == "BALL_GREEN" ||
               PlayerSceneManager.playerManager.BALL_RED && objectToSelect.name == "BALL_RED" ||
               PlayerSceneManager.playerManager.BALL_PURPLE && objectToSelect.name == "BALL_PURPLE";
    }

    bool Select()
    {
        return !PlayerSceneManager.playerManager.PADDLE_ABSTRACT && objectToSelect.name == "PADDLE_ABSTRACT" ||
               !PlayerSceneManager.playerManager.PADDLE_INBOUND && objectToSelect.name == "PADDLE_INBOUND" ||
               !PlayerSceneManager.playerManager.PADDLE_INROUNDBOUND && objectToSelect.name == "PADDLE_INROUNDBOUND" ||
               !PlayerSceneManager.playerManager.PADDLE_ROUNDBOUND && objectToSelect.name == "PADDLE_ROUNDBOUND" ||
               !PlayerSceneManager.playerManager.PADDLE_TRIANGLE && objectToSelect.name == "PADDLE_TRIANGLE" ||

               !PlayerSceneManager.playerManager.SHIP_DOUBLE && objectToSelect.name == "SHIP_DOUBLE" ||
               !PlayerSceneManager.playerManager.SHIP_STRONG && objectToSelect.name == "SHIP_STRONG" ||

               !PlayerSceneManager.playerManager.BALL_BLUE && objectToSelect.name == "BALL_BLUE" ||
               !PlayerSceneManager.playerManager.BALL_GREEN && objectToSelect.name == "BALL_GREEN" ||
               !PlayerSceneManager.playerManager.BALL_RED && objectToSelect.name == "BALL_RED" ||
               !PlayerSceneManager.playerManager.BALL_PURPLE && objectToSelect.name == "BALL_PURPLE";
    }    

    public void SelectPaddle()
    {
        PlayerSceneManager.playerManager.playerPaddle = objectToSelect;
    }

    public void SelectBall()
    {
        PlayerSceneManager.playerManager.playerBall = objectToSelect;
    }

    public void SelectShip()
    {
        PlayerSceneManager.playerManager.playerShip = objectToSelect;
    }

    public void BuyBttn()
    {
        Debug.Log("Buying Virtual Goods...");
        new GameSparks.Api.Requests.BuyVirtualGoodsRequest()
            .SetCurrencyType(1)
            .SetQuantity(1)
            .SetShortCode(objectToSelect.name)
            .Send((response) => {

                if (!response.HasErrors)
                {
                    Debug.Log("Virtual Goods Bought Successfully...");
                    AccountDetailRequest.accReq.GetAccountData();
                    PlayerSceneManager.playerManager.UpdateSpaceBrickText();
                }
                else
                {
                    Debug.Log("Error Buying Virtual Goods...");
                    error.SetActive(true);
                    Invoke("DeactivateErrorMessage", 2f);
                }
            });
    }

    void DeactivateErrorMessage()
    {
        error.SetActive(false);
    }
}
