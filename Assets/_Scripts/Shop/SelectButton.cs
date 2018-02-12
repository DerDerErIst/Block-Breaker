using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public GameObject objectToSelect;

    public Text objectNameText;

    [Header("ForMovieTexture")]
    public RawImage rawPreview;

    
    public Text objectJoke;    

    public bool shop;
    public Text price;
    public Button buyButton;
    
    MovieTexture movie;
    public GameObject error;

    public void SetupButton(string text)
    {
        if(objectToSelect.GetComponent<Ball>())
        {
            Ball ball = objectToSelect.GetComponent<Ball>();
            objectNameText.text = ball.name;
            if (shop)
            {
                price.text = ball.price.ToString();
            }
            else if (!shop)
            {
                objectJoke.text = "Force: " + (ball.xControlForce + ball.yControlForce * 100).ToString();
            }
            if (rawPreview != null)
            {
                movie = ball.movieTexture;
                rawPreview.texture = movie;
            }
        }
        if (objectToSelect.GetComponent<ShipController>())
        {
            ShipController ship = objectToSelect.GetComponent<ShipController>();
            objectNameText.text = ship.name;
            if (shop)
            {
                price.text = ship.price.ToString();
            }
            else if (!shop)
            {
                objectJoke.text = ship.objectJoke;

            }
            if (rawPreview != null)
            {
                movie = ship.movieTexture;
                rawPreview.texture = movie;
            }
        }
        // Setup for Paddle Items
        if (objectToSelect.GetComponentInChildren<Paddle>())
        {
            Paddle paddle = objectToSelect.GetComponentInChildren<Paddle>();
            objectNameText.text = paddle.name;
            if (rawPreview != null)
            {
                movie = paddle.movieTexture;
                rawPreview.texture = movie;
            }
            if (shop)
            {
                price.text = paddle.price.ToString();
            }
            else if (!shop)
            {
                objectJoke.text = paddle.objectJoke;
            }
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
                //Button thisButton = GetComponent<Button>();
                //thisButton.interactable = false;
                Destroy(this.gameObject); //Actually We Destroy the Button if we not have the Item
            }
        }
        if (shop)
        {
            //TODO Think about this but i not have another idea actually
            if (ShopSelect())
            {
                //buyButton.interactable = false;
                Destroy(this.gameObject); //Actually We Destroy the Button if we have the Item already
            }
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
        SelectedPaddle.selectedPaddle.objectToDisplay = objectToSelect;
        SelectedPaddle.selectedPaddle.UpdateDisplay();
    }

    public void SelectBall()
    {
        PlayerSceneManager.playerManager.playerBall = objectToSelect;
        SelectedBall.selectedBall.objectToDisplay = objectToSelect;
        SelectedBall.selectedBall.UpdateDisplay();
    }

    public void SelectShip()
    {
        PlayerSceneManager.playerManager.playerShip = objectToSelect;
        SelectedShip.selectedShip.objectToDisplay = objectToSelect;
        SelectedShip.selectedShip.UpdateDisplay();
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
                    PlayerSceneManager.playerManager.UpdateSpaceBrickDisplay();
                    //TODO This Part issnt actually working Lets think about a solution
                    //After we buy something we need to Rebuild the Selector Window
                    //Its not working because we Deactivate the Objects
                    SetupSelector[] setupSelector = FindObjectsOfType<SetupSelector>();
                    for (int i = 0; i < setupSelector.Length; i++)
                    {
                        setupSelector[i].Rebuild();
                    }
                    
                    if(objectToSelect.GetComponentInChildren<Paddle>())
                    {
                        SelectPaddle();
                    }
                    else if (objectToSelect.GetComponent<Ball>())
                    {
                        SelectBall();
                    }
                    else if (objectToSelect.GetComponent<ShipController>())
                    {
                        SelectShip();
                    }
                    this.GetComponent<Button>().interactable = false;
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
