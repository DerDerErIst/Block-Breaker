using UnityEngine;

public class AsteroidRandomizer : MonoBehaviour {

    [Range(0.2f, 3f)] public float tumble = 1f;
    public bool boss = false;

    [Range(0.3f, 2f)] public float localScaleX;
    [Range(0.2f, 1f)] public float localScaleYZ;
    

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SizeRandomizer();
    }

    void SizeRandomizer()
    {
        if (!boss)
        {
            transform.localScale = new Vector3(Random.Range(localScaleX, localScaleX * 1.3f), Random.Range(localScaleYZ, localScaleYZ * 1.3f), Random.Range(localScaleYZ, localScaleYZ * 1.3f));   
        }
        if (boss)
        {
            transform.localScale = new Vector3(Random.Range(localScaleX * 1.3f, localScaleX * 1.8f), Random.Range(localScaleYZ * 1.3f, localScaleYZ * 1.8f), Random.Range(localScaleYZ * 1.3f, localScaleYZ * 1.8f));
        }
    }

    void Start()
    {        
        rb.angularVelocity = Random.insideUnitSphere * Random.Range(tumble, tumble*2);
    }
}
