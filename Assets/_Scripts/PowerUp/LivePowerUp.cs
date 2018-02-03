using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Live")]
public class LivePowerUp : PowerUp {

    [SerializeField] bool Increase;

	public override void Use()
    {
        base.Use();
        if (Increase)
        {
            Paddle.lives++;
        }
        else
        {
            Paddle.lives--;
        }
        Paddle.paddleInstance.liveText.text = Paddle.lives.ToString();
    }
}
