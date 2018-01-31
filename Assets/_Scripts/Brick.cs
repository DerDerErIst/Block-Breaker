using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount = 0;

    [Header("PowerUp Settings")]
    [Range(0,1)]public float dropchance;
    public GameObject[] powerUps;

    [Header("Points per Hit")]
    public int score;

    [Header("Fill In some goodies")]
    [SerializeField] AudioClip[] crack;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] GameObject explosion;


    LevelManager levelManager;
    AudioSource audioSource;
    int timesHit;
    bool isBreakable;

    Player playerManager;
    // Use this for initialization
    void Start () {
        playerManager = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();

        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(crack[Random.Range(0, crack.Length)]);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBreakable && collision.GetComponent<Projectile>())
        {
            HandleHits();
            Destroy(collision.gameObject);
        }
    }

    private void HandleHits()
    {
        ++timesHit;
        int maxHits = hitSprites.Length + 1;
        Paddle.score += score;
        playerManager.score += score;
        Paddle.paddleInstance.highscoreText.text = Paddle.score.ToString();

        bool isDropTime = UnityEngine.Random.Range(0f, 1f) <= dropchance;
        if (isDropTime)
        {
           Instantiate(powerUps[Random.Range(0, powerUps.Length)], gameObject.transform.position, Quaternion.identity);

        }

        if (timesHit >= maxHits)
        {
            ++playerManager.brickCounter;
            breakableCount--;            
            levelManager.BrickDestroyed();
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing!!");
        }
    }
}
