using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 8;
	
	void Update ()
    {   //We Are Using for the Space Invader Game a different Solution to avoid complexity
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

}
