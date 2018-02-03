using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{    
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    public AudioClip[] shotSounds;
    public bool roundRobin;

    float nextFire;
    AudioSource audioSource;

    Rigidbody rb;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            if (roundRobin)
            {
                for (int i = 0; i < shotSounds.Length; i++)
                {
                    audioSource.volume = Random.Range(0.8f, 1f);
                    audioSource.pitch = Random.Range(0.8f, 1f);
                    audioSource.PlayOneShot(shotSounds[i]);
                }
            }
            else
            {
                audioSource.volume = Random.Range(0.8f, 1f);
                audioSource.pitch = Random.Range(0.8f, 1f);
                audioSource.PlayOneShot(shotSounds[Random.Range(0,shotSounds.Length)]);
            }
        }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WSA_10_0

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            if (roundRobin)
            {
                for (int i = 0; i < shotSounds.Length; i++)
                {
                    audioSource.volume = Random.Range(0.8f, 1f);
                    audioSource.pitch = Random.Range(0.8f, 1f);
                    audioSource.PlayOneShot(shotSounds[i]);
                }
            }
            else
            {
                audioSource.volume = Random.Range(0.8f, 1f);
                audioSource.pitch = Random.Range(0.8f, 1f);
                audioSource.PlayOneShot(shotSounds[Random.Range(0,shotSounds.Length)]);
            }
        }
#endif
    }



    void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;

            rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }
    }
