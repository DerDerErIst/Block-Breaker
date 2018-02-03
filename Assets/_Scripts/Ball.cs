using UnityEngine;

public class Ball : MonoBehaviour {


    [SerializeField] AudioClip[] clip;

    Paddle paddle;
    bool hasStarted = false;
    Vector3 paddleToBallVector;
    AudioSource audioSource;
    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();        
    }

    void Update () {
        if (!hasStarted)
        {
        rb.transform.position = paddle.transform.position + paddleToBallVector;
        }
        if (Input.GetMouseButtonDown(0) && !hasStarted)
        {
            hasStarted = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 10f);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x*9, 10);
            rb.velocity = dir;
        }
        if (collision.gameObject.tag == "Collider")
        {
            audioSource.PlayOneShot(clip[Random.Range(0, clip.Length)]);
        }
    }
    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    public void ResetBallPosition()
    {
        rb.transform.position = paddle.transform.position + paddleToBallVector;
    }
}
