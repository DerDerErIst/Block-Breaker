using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Live")]
public class LivePowerUp : PowerUp {

    [SerializeField] bool Increase;

	public override void Use(Paddle pad)
    {
        base.Use(pad);
        if (Increase)
        {
            PlayerSceneManager.lives++;
        }
        else
        {
            PlayerSceneManager.lives--;
        }
        PlayerSceneManager.playerManager.UpdateGameDisplay();
    }
}
