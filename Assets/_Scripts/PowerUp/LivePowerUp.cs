using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Live", menuName = "PowerUp/Live")]
public class LivePowerUp : PowerUp {

	public override void Use()
    {
        base.Use();
        Paddle.lives++;
        paddle.liveText.text = Paddle.lives.ToString();
    }
}
