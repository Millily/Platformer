using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _count = 1;

    public int Count { get; private set; }

    private void Awake()
    {
        Count = _count;
    }
}