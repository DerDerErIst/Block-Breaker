using UnityEngine;

public class Brick : MonoBehaviour
{
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

    void Awake () {
        audioSource = GetComponent<AudioSource>();

        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            AdventureMode.breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(crack[Random.Range(0, crack.Length)]);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBreakable && collision.GetComponent<Projectile>())
        {
            HandleHits();
            Destroy(collision.gameObject);
        }
    }

    void HandleHits()
    {
        ++timesHit;
        int maxHits = hitSprites.Length + 1;
        PlayerSceneManager.score += score;
        PlayerSceneManager.playerManager.UpdateGameDisplay();
        bool isDropTime = UnityEngine.Random.Range(0f, 1f) <= dropchance;
        if (isDropTime)
        {
           Instantiate(powerUps[Random.Range(0, powerUps.Length)], gameObject.transform.position, Quaternion.identity);
        }

        if (timesHit >= maxHits)
        {
            ++PlayerSceneManager.playerManager.player.brickCounter;
            AdventureMode.breakableCount--;            
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
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
