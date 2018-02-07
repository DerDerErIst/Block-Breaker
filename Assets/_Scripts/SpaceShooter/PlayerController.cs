using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public int price; //Just for Display
    public Sprite shipImage; //TODO Lets Think about how to make this as Movie

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform[] shotSpawn;
    public float fireRate;

    public AudioClip[] shotSounds;
    public bool roundRobin;

    float nextFire;
    AudioSource audioSource;
    Rigidbody rb;
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    { //On the Desktop Version we simple Shot with MouseButton on the Mobile Phone we use Automatic Shot or maybe a Button (hard to realise)
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        FireOnStandalone();
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WSA_10_0 
        FireOnMobile();
#endif
    }

    //Im Using a Process here that called Round Robin
    // Simple i go though an Array of Audio Clips and play them with a random volume and random pitch
    // So i got X different Sounds they get mixed everytime again together with another random values
    // This gives the abilitiie to make amazing Shot Sounds possible
    // If you wanna Know more about https://en.wikipedia.org/wiki/Round-robin_scheduling

    void FireOnMobile()
    {
        if (Time.time > nextFire)
        {   //Automatic FireSystem
            nextFire = Time.time + fireRate;
            for (int i = 0; i < shotSpawn.Length; i++)
            {
                Instantiate(shot, new Vector3(shotSpawn[i].position.x, 0f, 0f), shotSpawn[i].rotation);
            }
            if (roundRobin)
            {
                for (int y = 0; y < shotSounds.Length; y++)
                {
                    audioSource.volume = Random.Range(0.8f, 1f);
                    audioSource.pitch = Random.Range(0.8f, 1f);
                    audioSource.PlayOneShot(shotSounds[y]);
                }
            }
            else
            {
                audioSource.volume = Random.Range(0.8f, 1f);
                audioSource.pitch = Random.Range(0.8f, 1f);
                audioSource.PlayOneShot(shotSounds[Random.Range(0, shotSounds.Length)]);
            }

        }
    }

    void FireOnStandalone()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < shotSpawn.Length; i++)
            {
                Instantiate(shot, new Vector3(shotSpawn[i].position.x, 0f, shotSpawn[i].position.z), shotSpawn[i].rotation);                
            }
            if (roundRobin)
            {   
                for (int y = 0; y < shotSounds.Length; y++)
                {
                    audioSource.volume = Random.Range(0.8f, 1f);
                    audioSource.pitch = Random.Range(0.8f, 1f);
                    audioSource.PlayOneShot(shotSounds[y]);
                }
            }
            else
            {   //If we Deactivate Round Robin he plays Random Sounds from the Array with Random Values
                audioSource.volume = Random.Range(0.8f, 1f);
                audioSource.pitch = Random.Range(0.8f, 1f);
                audioSource.PlayOneShot(shotSounds[Random.Range(0, shotSounds.Length)]);
            }
        }
    }

    void FixedUpdate()
    { //On the Desktop we can Move with Keyboard on the Mobile we need a Sort of Touch Function to control
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
         MoveWithKeyBoard();
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WSA_10_0
        MoveWithTouchScreen();
#endif
    }

    void MoveWithTouchScreen()
    {
        if (Input.GetMouseButton(0)) //If we Press Mousebutton 0 similar to Touchscreen Touch 0      
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //Mouse Position in WorldSpace
            mousePosition.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, 30 * Time.deltaTime);
        }
        transform.position = new Vector3    //Calculate Boundary
                                (
                                Mathf.Clamp(this.transform.position.x, boundary.xMin, boundary.xMax),
                                0.0f,
                                Mathf.Clamp(this.transform.position.z, boundary.zMin, boundary.zMax)                                 
                                );
    }

    void MoveWithKeyBoard()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.transform.position = new Vector3 //Calculate Boundary
                                (
                                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                                0.0f,
                                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                                );

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}

