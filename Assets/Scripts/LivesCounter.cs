using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    private PlayerHealthModel _healthModel;
    [SerializeField] private int _maxLives;
    private int _currentLives;

    public event Action<int> OnLivesChanged;
    public event Action OnDefeat;

    public int CurrentLives { get; private set; }
    private void Start()
    {
        _healthModel = GetComponent<PlayerHealthModel>();
        _healthModel.OnDeath += LoseLife;
        _maxLives = 3; 
        _currentLives = _maxLives;
        OnLivesChanged?.Invoke(_currentLives);
    }

    public void LoseLife()
    {
        _currentLives--;
        if (_currentLives <= 0)
        {
            OnDefeat?.Invoke();
        }

        OnLivesChanged?.Invoke(_currentLives);
    }
}
