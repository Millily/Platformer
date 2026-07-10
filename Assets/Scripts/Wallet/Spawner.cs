using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _positions;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (Transform position in _positions)
        {
            Create(_coin, position.position);
        }
    }

    private Coin Create(Coin coin, Vector3 position)
    {
        Coin newCoin = Instantiate(coin, position, Quaternion.identity);

        return newCoin;
    }
}