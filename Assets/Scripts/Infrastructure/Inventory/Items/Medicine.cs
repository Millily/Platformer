using UnityEngine;

public class Medicine : Item
{
    [SerializeField] private int _healCount = 10;
    public int HealCount => _healCount;

    public override void Collect()
    {
        base.Collect();
    }
}