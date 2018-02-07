using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeScaler", menuName = "PowerUp/TimeScale")]
public class TimeScalePowerUp : PowerUp {

    [SerializeField] float time;
    [SerializeField] [Range(0,2)]public float indicator;

    public override void Use(Paddle pad)
    {
        base.Use(pad);
        pad.TimeScaler(time, indicator);
    }
}
