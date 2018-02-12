using UnityEngine;

public class WinObjectToDestroy : MonoBehaviour {

    [Header("PowerUp Settings")]
    [Range(0, 1)]
    public float dropchance;
    public GameObject[] powerUps;

    public GameObject[] explosions;
    public AudioClip[] explosionSounds;

    public int score;
    public int maxHits;

    public int timesHit;
    AudioSource audioSource;
    AdventureMode avMode;

    private void Awake()
    {        
        audioSource = GetComponent<AudioSource>();
        timesHit = 0;
    }

    private void Start()
    {
        avMode = FindObjectOfType<AdventureMode>();
        avMode.objectiveNumber.text = (maxHits - timesHit).ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosions[Random.Range(0, explosions.Length)], collision.transform.position, Quaternion.identity);
        audioSource.PlayOneShot(explosionSounds[Random.Range(0, explosionSounds.Length)]);
        HandleHits();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            Instantiate(explosions[Random.Range(0, explosions.Length)], collision.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(explosionSounds[Random.Range(0, explosionSounds.Length)]);
            HandleHits();
            Destroy(collision.gameObject);
        }
    }

    void HandleHits()
    {
        ++timesHit;
        PlayerSceneManager.score += score;
        avMode.objectiveNumber.text = (maxHits - timesHit).ToString();
        if (powerUps != null)
        {
            CheckForPowerUp();
        }

        if (timesHit >= maxHits)
        {
            ++PlayerSceneManager.playerManager.destroyedBricks;
            AdventureMode.destroyedBrickCount++;            
            Instantiate(explosions[1], gameObject.transform.position, Quaternion.identity);
            AdventureMode.WinCondition();
            Destroy(gameObject);            
        }
    }

    void CheckForPowerUp()
    {
        bool isDropTime = UnityEngine.Random.Range(0f, 1f) <= dropchance;
        if (isDropTime)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], gameObject.transform.position, Quaternion.identity);
        }
    }
}
