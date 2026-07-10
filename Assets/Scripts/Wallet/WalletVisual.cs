using TMPro;
using UnityEngine;

public class WalletVisual : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _score;

    private void OnEnable()
    {
        _wallet.OnAmountChanged += UpdateUI;
        UpdateUI(_wallet.Amount);
    }

    private void OnDisable()
    {
        _wallet.OnAmountChanged -= UpdateUI;
    }

    private void UpdateUI(int newAmount)
    {
        _score.text = $"Money in wallet: {newAmount}";
    }
}