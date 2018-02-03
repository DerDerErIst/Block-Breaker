using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {


    LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>())
        {
            if (Paddle.lives <= 0)
            {
                LevelManager.checkpoint = SceneManager.GetActiveScene().buildIndex;
                levelManager.LoadLevel("03 Lose");
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
            Paddle.paddleInstance.InstantiateBall(Paddle.paddleInstance.balls[Random.Range(0, Paddle.paddleInstance.balls.Length)]); //TODO HOW TO GET RID OF THAT PFUI
            Paddle.lives--;
            Paddle.paddleInstance.liveText.text = Paddle.lives.ToString();
        }
    }
}
