using UnityEngine;

[CreateAssetMenu(fileName = "SceneWarp", menuName = "PowerUp/SceneWarp/SpaceInvader")]
public class SpaceInvaderPowerUp : PowerUp
{
    public override void Use(Paddle pad)
    {
        base.Use(pad);        
    }
}
