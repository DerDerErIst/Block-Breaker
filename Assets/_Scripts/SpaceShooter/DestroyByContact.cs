using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    [Range(1, 10)]public int valueSpaceBricks;
    [Range(2, 20)] public int maxValueSpaceBricks;

    int spacebricks;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
        }
        Instantiate(explosion, transform.position, transform.rotation);
        spacebricks = Random.Range(valueSpaceBricks, maxValueSpaceBricks);
        PlayerSceneManager.playerManager.earnedSpaceBricks += spacebricks;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
