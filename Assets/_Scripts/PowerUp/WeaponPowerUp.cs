using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Weapon")]
public class WeaponPowerUp : PowerUp
{

    [SerializeField] float time;
    [SerializeField] float fireRate;
    [SerializeField] GameObject projectile;

    public override void Use()
    {
        base.Use();
        Paddle.paddleInstance.SetShooter(time, projectile, fireRate);
    }
}
