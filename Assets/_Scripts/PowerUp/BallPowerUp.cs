using UnityEngine;

[CreateAssetMenu(fileName = "Ball", menuName = "PowerUp/Ball")]
public class BallPowerUp : PowerUp
{
    public override void Use(Paddle pad)
    {
        base.Use(pad);        
        pad.InstantiateBall();
    }
}
