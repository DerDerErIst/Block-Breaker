using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour {

    public Transform target;
    public float speed;
    public float rotspeed;


    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotspeed * Time.deltaTime);

    }
}
