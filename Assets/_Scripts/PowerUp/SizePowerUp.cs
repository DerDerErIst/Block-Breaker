using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Size")]
public class SizePowerUp : PowerUp
{

    public float time;
    public float size;

    public override void Use()
    {
        base.Use();
        paddle.IncreaseSize(time, size);
    }
}
