using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Paddle : MonoBehaviour
{      
    public bool isShooter;

    public int price; //Just for Display

    public GameObject GFX;

    public GameObject middleWeapon = null; //Lets Think about if we let the Script find them with attached Scripts
    public GameObject leftWeapon = null;   //TODO Like i made for the Health and Live
    public GameObject rightWeapon = null;
    GameObject projectile = null;

    public GameObject ballSpawn;
    public GameObject playerBall;

    bool doubleShot = false;
    
    float fireRate;
    float nextFire;

    public static Paddle paddle;

    private void Awake()
    {
        paddle = this;
        playerBall = PlayerSceneManager.playerManager.playerBall;
    }

    void Start ()
    {
        Cursor.visible = false;
        Invoke("InstantiateBall", 1f); //Playtester called that the Ball sometimes have a Offset at Start
                                       //I Try actually to fix that bug with this

#if UNITY_EDITOR
        Cursor.visible = true;
#endif
    }    


    public void InstantiateBall()
    {        
        //Need to be Public because we call it from Outside such as Loose Collider and PowerUps
        Instantiate(playerBall, ballSpawn.transform.position, Quaternion.identity);
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
    }

    //For the Power Up System i use Invokes to call the normal States.
    //This gives the Ability for the Designer to make timebased PowerUps
    //Power Ups like Size Increase and Decrease are Stackable until he reach the endsize

    void Fire()
    {
        if (!doubleShot)
        {
            Instantiate(projectile, middleWeapon.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(projectile, leftWeapon.transform.position, Quaternion.identity);
            Instantiate(projectile, rightWeapon.transform.position, Quaternion.identity);
        }
    }

    public void SetShooter(float time, GameObject pro, float rate, bool shotType)
    {
        isShooter = true;
        doubleShot = shotType;
        if(!doubleShot)
        {
            doubleShot = false;
            middleWeapon.SetActive(true);
        }
        else
        {
            doubleShot = true;
            rightWeapon.SetActive(true);
            leftWeapon.SetActive(true);        
        }
        projectile = pro;
        fireRate = rate;
        Invoke("DeactivateShooter", time);        
    }

    void DeactivateShooter()
    {
        isShooter = false;
        if (!doubleShot)
        {
            middleWeapon.SetActive(false);
            doubleShot = false;
        }
        else
        {
            rightWeapon.SetActive(false);
            leftWeapon.SetActive(false);
            doubleShot = false;
        }

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
