using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderParticleImpact : MonoBehaviour {

    public GameObject explosionParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosionParticle, collision.transform.position, Quaternion.identity);
    }
}
