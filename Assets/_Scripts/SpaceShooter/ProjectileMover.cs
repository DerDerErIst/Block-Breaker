using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float speed;
    public float damage;

    Rigidbody rb;

    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Asteroids")
        {
            collision.gameObject.GetComponent<AsteroidLiveSystem>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
