using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : _PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerMoviment.Instance.SetInvencible();
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerMoviment.Instance.SetInvencible(false);
    }
}
