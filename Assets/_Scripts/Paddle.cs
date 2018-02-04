using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Paddle : MonoBehaviour
{
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
        Cursor.visible = false;
        highscoreText.text = score.ToString();
        liveText.text = lives.ToString();
        InstantiateBall(balls[Random.Range(0, balls.Length)]);
      
#if UNITY_EDITOR
        Cursor.visible = true;
#endif
    }

    public void InstantiateBall(GameObject ball)
    {
        //We Call this also from Loose Collider actually we need to get Rid somehow
        //We Call it also from the PowerUp thats fine
        Instantiate(ball, ballSpawn.transform.position, Quaternion.identity);
    }
    
    void Update ()
    {
        if(isShooter)
        {   //For Simplicity to Mobile we not give the Player the Option to shot         
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {   //For Mobile we simple Ask if the Pointer is over a GameObject
            //We need to avoid that the Player Paddle is moving to the Launch Button
            return;
        }
        MoveWithMouse();
    }

    //For the Power Up System i use Invokes to call the normal States.
    //This gives the Ability for the Designer to make timebased PowerUps
    //Power Ups like Size Increase and Decrease are Stackable until he reach the endsize

    void Fire()
    {
        Instantiate(projectile, leftWeapon.transform.position, Quaternion.identity);
        Instantiate(projectile, rightWeapon.transform.position, Quaternion.identity);
    }

    void MoveWithMouse()
    {
        //We Move the Paddle with the Mouse from Left to Ride and Clamp the Position this also works on Mobile Devices
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
        if (transform.localScale.x <= 4 || transform.localScale.x >= 0.5f)
        {   //When we not have the End Size we multiply the size
            this.transform.localScale = new Vector3(transform.localScale.x * size, transform.localScale.y, transform.localScale.z);
            CancelInvoke("normalSize");
            Invoke("normalSize", time);
        }
        if (transform.localScale.x == 4 || transform.localScale.x == 0.5f)
        {   //If we already reach the End Size then we still collect the PowerUp and reset the Time
            this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            CancelInvoke("normalSize");
            Invoke("normalSize", time);
        }
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
