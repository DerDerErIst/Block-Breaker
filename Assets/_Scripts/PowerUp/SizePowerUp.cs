using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Size")]
public class SizePowerUp : PowerUp
{

    [SerializeField] float time;
    [SerializeField] float size;

    public override void Use()
    {
        base.Use();
        Paddle.paddleInstance.IncreaseSize(time, size);
    }
}
