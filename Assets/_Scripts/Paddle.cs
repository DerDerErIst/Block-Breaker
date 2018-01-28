using System;
using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour {

    public static Paddle paddleInstance;

    private void Awake()
    {
        if (!paddleInstance)
        {
            paddleInstance = this;
        }
    }

    [SerializeField] bool autoPlay = false;
    public static int lives = 3;
    public static int highscore = 0;
    public bool isShooter;

    public Text liveText;
    public Text highscoreText;

    public GameObject weapons;
    public GameObject leftWeapon;
    public GameObject rightWeapon;
    public GameObject projectile;

    public float fireRate;

    float nextFire;

    private Ball ball;
	// Use this for initialization
	void Start ()
    {
        
        highscoreText.text = highscore.ToString();
        liveText.text = lives.ToString();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    private static void Reset()
    {
        lives = 3;
        highscore = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        if(isShooter)
        {            
            if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                FireOne();
                FireTwo();
            }
        }
        


        if (Input.GetKeyDown(KeyCode.W))
        {
            SetShooter(5, projectile, 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            IncreaseSize(5, 1.4f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            IncreaseSize(5, .6f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            autoPlay = !autoPlay;
        }
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void FireOne()
    {
        Instantiate(projectile, leftWeapon.transform.position, Quaternion.identity);
    }

    void FireTwo()
    {
        Instantiate(projectile, rightWeapon.transform.position, Quaternion.identity);
    }

    private void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0f, 20f);
        this.transform.position = paddlePos;
    }

    private void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 20;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 20f);
        this.transform.position = paddlePos;
    }

    public void SetShooter(float time, GameObject pro, float rate)
    {
        isShooter = true;
        weapons.SetActive(true);
        projectile = pro;
        fireRate = rate;
        Invoke("DeactivateShooter", time);
        
    }

    void DeactivateShooter()
    {
        isShooter = false;
        weapons.SetActive(false);
    }

    public void IncreaseSize(float time, float size)
    {
        this.transform.localScale = new Vector3(transform.localScale.x * size, transform.localScale.y, transform.localScale.z);
        CancelInvoke();
        Invoke("normalSize", time);
        
    }
    void normalSize()
    {
        this.transform.localScale = new Vector3(2f, 1f, transform.localScale.z);
    }
}
