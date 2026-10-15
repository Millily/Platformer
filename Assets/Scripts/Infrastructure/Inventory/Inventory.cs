using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action<int> AmountCoinChanged;

    public int CoinAmount { get; private set; } = 0;

    public void AddCoin(Coin coin)
    {
        CoinAmount += coin.Count;
        AmountCoinChanged?.Invoke(CoinAmount);
    }
}