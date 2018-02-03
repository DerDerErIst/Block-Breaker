using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed = 8;
	
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

}
