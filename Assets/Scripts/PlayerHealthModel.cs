using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthModel : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public float CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = value;
            OnHealthChanged?.Invoke(_currentHealth / _maxHealth);
            if (_currentHealth <= 0)
            {
                ResetHealth();
                OnDeath?.Invoke();
            }
        }
    }

    public event Action<float> OnHealthChanged;
    public event Action OnDeath;

    private void Start()
    {
        ResetHealth();
    }

    private void ResetHealth()
    {
        _currentHealth = _maxHealth;
        OnHealthChanged?.Invoke(_currentHealth / _maxHealth);
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }
}
