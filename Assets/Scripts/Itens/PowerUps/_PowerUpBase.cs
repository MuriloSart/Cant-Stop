using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PowerUpBase : ItemCollectableBase
{
    [Header("Power Up")]
    public float duration = 1f;
    protected override void Collect()
    {
        base.Collect();
        StartPowerUp();
        PlayerMoviment.Instance.Bounce();
    }
    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
        Invoke(nameof(EndPowerUp), duration);
    }
    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");
    }
}
