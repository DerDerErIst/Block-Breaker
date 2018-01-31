using UnityEngine;

public class Ball : MonoBehaviour {

    public static Ball ballInstance;

    private void Awake()
    {
        ballInstance = this;
    }

    [SerializeField] AudioClip[] clip;

    private Paddle paddle;
    public bool hasStarted = false;
    private Vector3 paddleToBallVector;
    private AudioSource audioSource;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
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
            Vector2 dir = new Vector2(x*10, 10);
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
