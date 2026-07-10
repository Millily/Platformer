using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _amount = 0;

    public event Action<int> OnAmountChanged;

    public int Amount => _amount;

    public void AddCoin(int value)
    {
        _amount += value;
        OnAmountChanged?.Invoke(_amount);
    }
}