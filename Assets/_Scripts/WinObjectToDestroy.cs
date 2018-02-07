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

    int timesHit;
    bool isBreakable;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            AdventureMode.breakableCount++;
        }
        timesHit = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            Instantiate(explosions[Random.Range(0, explosions.Length)], collision.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(explosionSounds[Random.Range(0, explosionSounds.Length)]);
            HandleHits();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBreakable && collision.GetComponent<Projectile>())
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
        if (powerUps != null)
        {
            CheckForPowerUp();
        }

        if (timesHit >= maxHits)
        {
            ++PlayerSceneManager.playerManager.player.brickCounter;
            AdventureMode.breakableCount--;
            Instantiate(explosions[1], gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            AdventureMode.WinCondition();
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
