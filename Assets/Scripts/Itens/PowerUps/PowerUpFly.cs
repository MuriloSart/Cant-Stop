using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : _PowerUpBase
{
    [Header("Power Up Fly")]
    public float amountHeight = 2f;
    public float durationTransition = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerMoviment.Instance.ChangeHeight(amountHeight, durationTransition, ease);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerMoviment.Instance.ResetHeight(durationTransition, ease);
    }
}
