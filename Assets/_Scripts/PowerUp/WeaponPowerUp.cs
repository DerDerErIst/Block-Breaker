using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Weapon")]
public class WeaponPowerUp : PowerUp
{

    public float time;
    public float fireRate;
    public GameObject projectile;

    public override void Use()
    {
        base.Use();
        paddle.SetShooter(time, projectile, fireRate);
    }
}
