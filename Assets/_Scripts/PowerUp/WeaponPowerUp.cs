using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Weapon")]
public class WeaponPowerUp : PowerUp
{

    [SerializeField] float time;
    [SerializeField] float fireRate;
    [SerializeField] GameObject projectile;
    [SerializeField] bool doubleShot = false;

    public override void Use(Paddle pad)
    {
        base.Use(pad);
        pad.SetShooter(time, projectile, fireRate, doubleShot);
    }
}
