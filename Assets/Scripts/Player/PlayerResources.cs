using System;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static int Coins => coins;
    public static Action OnCoinChanged;

    private static int coins;

    public static void AddCoins(int amount)
    {
        if (amount < 0 && Mathf.Abs(amount) > coins)
            return;
        
        coins += amount;
        
        OnCoinChanged?.Invoke();
    }
}
