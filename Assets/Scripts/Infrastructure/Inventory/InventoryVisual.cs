using TMPro;
using UnityEngine;

public class InventoryVisual : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private TextMeshProUGUI _score;

    private void OnEnable()
    {
        _inventory.AmountCoinChanged += UpdateUI;
        UpdateUI(_inventory.CoinAmount);
    }

    private void OnDisable()
    {
        _inventory.AmountCoinChanged -= UpdateUI;
    }

    private void UpdateUI(int newAmount)
    {
        _score.text = $"Money in wallet: {newAmount}";
    }
}