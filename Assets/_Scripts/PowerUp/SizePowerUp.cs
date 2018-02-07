using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Size")]
public class SizePowerUp : PowerUp
{
    [SerializeField] float time;
    [SerializeField] float size;

    public override void Use(Paddle pad)
    {
        base.Use(pad);
        pad.IncreaseSize(time, size);
    }
}
