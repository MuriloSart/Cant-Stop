using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ItemManager : Singleton<_ItemManager>
{
    public SOInt coins;
    public UIManager uiManager;

    private void Start()
    {
        if(uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        Reset();
    }
    private void Reset()
    {
        coins.value = 0;
        CoinUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        CoinUI();
    }
    public void CoinUI()
    {
        uiManager.UpdateTextCoins(coins.value);
    }
}
