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

    public static int lives = 3;
    public static int score = 0;
    public bool isShooter;

    public Text liveText;
    public Text highscoreText;

    public GameObject weapons;
    public GameObject leftWeapon;
    public GameObject rightWeapon;
    public GameObject projectile;

    public GameObject[] balls;
    public GameObject ballSpawn;

    float fireRate;
    float nextFire; 

	void Start ()
    {
        highscoreText.text = score.ToString();
        liveText.text = lives.ToString();
        InstantiateBall(balls[Random.Range(0, balls.Length)]);
    }

    public void InstantiateBall(GameObject ball)
    {
        Instantiate(ball, ballSpawn.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update ()
    {
        if(isShooter)
        {            
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
        }
        MoveWithMouse();
    }

    void Fire()
    {
        Instantiate(projectile, leftWeapon.transform.position, Quaternion.identity);
        Instantiate(projectile, rightWeapon.transform.position, Quaternion.identity);
    }

    void MoveWithMouse()
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
        if(transform.localScale.x <= 4 && transform.localScale.x >= 0.5f)
        this.transform.localScale = new Vector3(transform.localScale.x * size, transform.localScale.y, transform.localScale.z);
        CancelInvoke("normalSize");
        Invoke("normalSize", time);        
    }

    void normalSize()
    {
        this.transform.localScale = new Vector3(2f, transform.localScale.y, transform.localScale.z);
    }

    public void TimeScaler(float time, float indicator)
    {
        Time.timeScale = indicator;
        CancelInvoke("normalTime");
        Invoke("normalTime", time);
    }

    void normalTime()
    {
        Time.timeScale = 1;
    }
}
