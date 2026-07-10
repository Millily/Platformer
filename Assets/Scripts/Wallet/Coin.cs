using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _count = 1;

    public int Count => _count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Wallet wallet))
        {
            wallet.AddCoin(_count);
            Destroy(gameObject);
        }
    }
}