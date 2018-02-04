using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float speed;

    Rigidbody rb;

    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
}
