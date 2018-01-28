using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject {

    [Header("Leave Paddle Empty")]
    public Paddle paddle;

    [Header("Start Here")]
    public GameObject pickUp;

    

    public virtual void Use()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
    }
}
