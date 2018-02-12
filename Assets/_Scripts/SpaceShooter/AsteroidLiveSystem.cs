using UnityEngine;

public class AsteroidLiveSystem : ShipLiveSystem
{
    [Range(1, 10)] public int minValueSpaceBricks;
    [Range(2, 20)] public int maxValueSpaceBricks;

    int spaceBricks;

    public override void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        spaceBricks = Random.Range(minValueSpaceBricks, maxValueSpaceBricks);
        PlayerSceneManager playerManager = PlayerSceneManager.playerManager;
        playerManager.earnedSpaceBricks += spaceBricks;
        ++playerManager.actualAsteroids;
        playerManager.UpdateAsteroidsDisplay();        
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Boundary")
        {
            return;
        }
        if (collision.tag == "Player")
        {
            Instantiate(collision.GetComponent<ShipLiveSystem>().explosion, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<ShipLiveSystem>().TakeDamage(hullPoints);
            Die();
        }
        if (collision.tag == "Projectile")
        {
            Instantiate(explosion, collision.transform.position, transform.rotation);
        }
    }
}

