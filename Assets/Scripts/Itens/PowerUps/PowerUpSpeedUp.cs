using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : _PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerMoviment.Instance.PowerUpSpeedUp(amountSpeed);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerMoviment.Instance.ResetSpeed();
    }
}
