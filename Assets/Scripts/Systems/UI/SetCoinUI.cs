using System;
using TMPro;
using UnityEngine;

public class SetCoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  coin;

    private Action setTextAction => SetText;
    
    private void OnEnable()
    {
        coin.text = "0";
        PlayerResources.OnCoinChanged += setTextAction;
    }

    private void OnDisable()
    {
        PlayerResources.OnCoinChanged -= setTextAction;
    }

    private void SetText()
    {
        coin.text = PlayerResources.Coins.ToString();
    }
}
