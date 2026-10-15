using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Medicine> MedicinePicked;
    public event Action<Coin> CoinPicked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            if (item is Coin coin)
            {
                CoinPicked?.Invoke(coin);
            }
            else if (item is Medicine medicine)
            {
                MedicinePicked?.Invoke(medicine);
            }

            item.Collect();
        }
    }
}