using UnityEngine;

[CreateAssetMenu(fileName = "Ball", menuName = "PowerUp/Ball")]
public class BallPowerUp : PowerUp
{
    [SerializeField] GameObject ball;

    public override void Use()
    {
        base.Use();
        Paddle.paddleInstance.InstantiateBall(ball);
    }
}
