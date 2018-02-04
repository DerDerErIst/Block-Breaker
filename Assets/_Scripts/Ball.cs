using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip[] clip;

    Paddle paddle;
    public bool hasStarted = false;
    public bool mobileStart = false;
    Vector3 paddleToBallVector;
    AudioSource audioSource;
    Rigidbody2D rb;

    public delegate void LaunchMobileBall();
    public static event LaunchMobileBall onMobile;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();

            //In This Section iam Asking if its a Standalone or a Mobile and when its a Mobile i Call the Delegate onMobile
            //This allows me to Add an Listener to the MobileBallLauncher
            //Which Activate the Launcher Button on Mobile Devices
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        //We Launching The Ball when we Press Space
        Debug.Log("No Launch Button");
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WSA_10_0
        onMobile();
#endif
    }

    void Update ()
    {    
        if (!hasStarted)
        {
        rb.transform.position = paddle.transform.position + paddleToBallVector;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !hasStarted || mobileStart && !hasStarted) //I ask for both solutions of Desktop and Mobile
        {             
            hasStarted = true;            
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 10f);
            mobileStart = false;
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //I ask what the Ball Hits
        if (collision.gameObject.tag == "Player")
        {   //When he Hit the Player in form of Paddle then i calculate the new Force based on the hitfactor
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
        //Calculate the hitfactor and return values
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    public void ResetBallPosition()
    {
        //Bring the the Ball back to Paddle Position can be used for a PowerUp i have in mind
        rb.transform.position = paddle.transform.position + paddleToBallVector;
    }
}
