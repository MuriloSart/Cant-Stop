using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI textCoins;
    public void UpdateTextCoins(int c)
    {
        Instance.textCoins.text = "x" + c.ToString();
    }
}
