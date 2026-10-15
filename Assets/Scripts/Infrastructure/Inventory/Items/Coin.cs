using UnityEngine;

public class Coin : Item
{
    [SerializeField] private int _count = 1;

    public int Count => _count;

    public override void Collect()
    {
        base.Collect();
    }
}