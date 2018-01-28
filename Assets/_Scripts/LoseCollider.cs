using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>())
        {
            if (Paddle.lives <= 0)
            {
                LevelManager.checkpoint = SceneManager.GetActiveScene().buildIndex;
                levelManager.LoadLevel("Lose Screen");
            }
            else
            {
                Paddle.lives--;
                Paddle.paddleInstance.liveText.text = Paddle.lives.ToString();
                Ball.ballInstance.hasStarted = false;
                Ball.ballInstance.ResetBallPosition();

            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
