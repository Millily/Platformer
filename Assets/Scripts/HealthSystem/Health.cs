using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int _currentHealth;

    public int CurrentHealth { get; private set; }
    public event Action<int> DamageTaken;
    public event Action Dyed;

    private void Awake()
    {
        _currentHealth = maxHealth;
        CurrentHealth = _currentHealth;
    }

    private void OnEnable()
    {
        DamageTaken += TakeDamage;
    }

    private void OnDisable()
    {
        DamageTaken -= TakeDamage;
    }

    public void TakeMedicine(Medicine medicine)
    {
        Heal(medicine.HealCount);
    }

    private void Heal(int health)
    {
        _currentHealth += health;

        if (_currentHealth +  health > maxHealth)
        {
            _currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            Dyed?.Invoke();
        }
    }
}