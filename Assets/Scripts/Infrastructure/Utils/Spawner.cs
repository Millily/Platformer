using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private List<Transform> _positions;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (Transform position in _positions)
        {
            Create(_item, position.position);
        }
    }

    private Item Create(Item item, Vector3 position)
    {
        Item newItem = Instantiate(item, position, Quaternion.identity);

        return newItem;
    }
}