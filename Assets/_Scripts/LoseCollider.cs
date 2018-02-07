using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    LevelManager levelManager;
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
                LevelManager.checkpoint = SceneManager.GetActiveScene().buildIndex;
                levelManager.LoadMenueStructure("03 Lose");
            }
            else
            {
                Destroy(collision.gameObject);
                Invoke("FindOtherBalls", .5f);
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    void FindOtherBalls()
    { 
        Ball ball = FindObjectOfType<Ball>();
        if (ball == null)
        {
            paddle.InstantiateBall(); //TODO HOW TO GET RID OF THAT PFUI
            PlayerSceneManager.lives--;
            PlayerSceneManager.playerManager.UpdateGameDisplay();
        }
    }
}
