using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<int> OnAmountChanged;

    public int Amount { get; private set; } = 0;

    public void AddCoin(int value)
    {
        Amount += value;
        OnAmountChanged?.Invoke(Amount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            AddCoin(coin.Count);
            Destroy(coin.gameObject);
        }
    }
}