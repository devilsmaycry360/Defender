using TMPro;
using UnityEngine;

public class SetCoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  coin;

    private void OnEnable()
    {
        coin.text = "0";
        PlayerResources.OnCoinChanged += SetText;
    }

    private void SetText()
    {
        coin.text = PlayerResources.Coins.ToString();
    }
}
