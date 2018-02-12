using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    LevelManager levelManager;
    PlayerSceneManager playerManager;
    Paddle paddle;

    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>())
        {
            if (PlayerSceneManager.lives <= 0)
            {
                if (PlayerSceneManager.playerManager.breakerLevel)
                {
                    playerManager = FindObjectOfType<PlayerSceneManager>();
                    if (playerManager.breakerHighscore <= PlayerSceneManager.score) //If Score from Paddle is higher then highscore
                    {
                        Debug.Log("Old Highscore for Cloud" + playerManager.breakerHighscore);
                        playerManager.breakerHighscore = PlayerSceneManager.score; //Set New Highscore
                        Debug.Log("New Highscore on Paddle" + PlayerSceneManager.score + "New Highscore for Cloud" + playerManager.breakerHighscore);
                    }
                    AccountDetailRequest.accReq.SaveBrickData();
                }
                LevelManager.checkpoint = SceneManager.GetActiveScene().buildIndex;
                levelManager.LoadMenueStructure("03b Lose_Breaker");
            }
            else
            {
                Destroy(collision.gameObject);
                Invoke("FindOtherBalls", .25f);
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    void FindOtherBalls()
    {
        Ball ball = null;
        ball = FindObjectOfType<Ball>();
        if (ball == null)
        {
            paddle.InstantiateBall(); //TODO HOW TO GET RID OF THAT PFUI
            PlayerSceneManager.lives--;
            PlayerSceneManager.playerManager.UpdateGameDisplay();
        }
    }
}
