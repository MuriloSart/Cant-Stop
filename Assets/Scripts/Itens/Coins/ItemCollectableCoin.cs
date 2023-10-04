using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public AudioSource audioSource;
    public SOInt coinValue;

    private void Start()
    {
        CoinsAnimationManager.Instance.RegisterCoin(this);
    }
    protected override void OnCollect()
    {
        base.OnCollect();
        _ItemManager.Instance.AddCoins(coinValue.value);
        if(audioSource != null) audioSource.Play();
        PlayerMoviment.Instance.Bounce();
    }
}
